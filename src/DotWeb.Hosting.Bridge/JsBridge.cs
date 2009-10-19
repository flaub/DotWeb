// Copyright 2009, Frank Laub
//
// This file is part of DotWeb.
//
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace DotWeb.Hosting.Bridge
{
	using FunctionCacheMap = Dictionary<MethodBase, JsFunction>;
	using DelegateWrapperMap = Dictionary<Delegate, JsDelegateWrapper>;
	
	using ObjectToReferenceMap = Dictionary<object, int>;
	using ReferenceToObjectMap = Dictionary<int, object>;

	using JsObjectToReferenceMap = Dictionary<object, int>;

	using DynamicPropertyMap = Dictionary<string, object>;
	using DynamicPropertyObjects = Dictionary<object, Dictionary<string, object>>;
	using DotWeb.System.DotWeb;

	class JsDynamicBase
	{
	}

	public class JsBridge : IDotWebHost
	{
		private readonly ISession session;
		private readonly IObjectFactory factory;
		private readonly FunctionCacheMap functionCache = new FunctionCacheMap();
		private readonly DelegateWrapperMap remoteDelegates = new DelegateWrapperMap();
	
		private readonly ObjectToReferenceMap objToRef = new ObjectToReferenceMap();
		private readonly ReferenceToObjectMap refToObj = new ReferenceToObjectMap();

		private readonly JsObjectToReferenceMap jsObjectToRef = new JsObjectToReferenceMap();

		private readonly DynamicPropertyObjects dynamicObjects = new DynamicPropertyObjects();

		private int lastRefId = 1;

		public JsBridge(ISession session, IObjectFactory factory) {
			this.session = session;
			this.factory = factory;
		}

		public R GetObjectByRef<R>(int id) {
			return (R)this.refToObj[id];
		}

		private JsValue DispatchAndReturn() {
			ReturnMessage retMsg;
			while (true) {
				Dispatch(true, out retMsg);
				if (retMsg != null)
					break;
			}

			JsValue ret = retMsg.Value;
			if (retMsg.IsException) {
				if (ret.IsJsObject) {
//					var jne = new JsNativeException();
//					AddRemoteReference(jne, ret.RefId);
					throw new Exception("JsException");
				}

				if (retMsg.Value.IsObject) {
					object obj = this.refToObj[ret.RefId];
					throw (Exception)obj;
				}
				throw new Exception(ret.Object.ToString());
			}
			return ret;
		}

		public void DispatchForever() {
			while (true) {
				ReturnMessage msg;
				var ret = Dispatch(false, out msg);
				if (!ret)
					return;
			}
		}

		/// <summary>
		/// Read a message from the session and dispatch based on the MessageType.
		/// </summary>
		/// <param name="needsReturn">The caller is expecting a ReturnMessage.</param>
		/// <param name="retMsg">The ReturnMessage if received.</param>
		/// <returns>true when needsReturn is true and a QuitMessage is received, otherwise false.</returns>
		private bool Dispatch(bool needsReturn, out ReturnMessage retMsg) {
			IMessage msg = this.session.ReceiveMessage();
			switch (msg.MessageType) {
				case MessageType.Load:
					OnLoad((LoadMessage)msg);
					break;
				case MessageType.GetTypeRequest:
					GetTypeInfo((GetTypeRequestMessage)msg);
					break;
				case MessageType.InvokeDelegate:
					InvokeDelegate((InvokeDelegateMessage)msg);
					break;
				case MessageType.InvokeMember:
					InvokeMember((InvokeMemberMessage)msg);
					break;
				case MessageType.Return:
					if (needsReturn) {
						retMsg = (ReturnMessage)msg;
						return true;
					}
					throw new InvalidOperationException();
				case MessageType.Quit:
					if (needsReturn) {
						throw new Exception("Quit");
					}
					retMsg = null;
					return false;
				default:
					throw new InvalidOperationException();
			}
			retMsg = null;
			return true;
		}

		private void OnLoad(LoadMessage msg) {
			try {
				this.remoteDelegates.Clear();
				this.functionCache.Clear();
				this.objToRef.Clear();
				this.refToObj.Clear();
				this.jsObjectToRef.Clear();
				this.isUnwrapping = false;

				Type type = Type.GetType(msg.TypeName);
				CreateInstance(type);

				var value = new JsValue(JsValueType.Void, null);
				var retMsg = new ReturnMessage { Value = value };
				this.session.SendMessage(retMsg);
			}
			catch (TargetInvocationException ex) {
				HandleException(ex.InnerException);
			}
			catch (Exception ex) {
				HandleException(ex);
			}
		}

		private object CreateInstance(Type type) {
			return this.factory.CreateInstance(this, type);
		}

		private void HandleException(Exception ex) {
			Debug.WriteLine(ex);
			var value = new JsValue(ex.Message);
			var retMsg = new ReturnMessage { Value = value, IsException = true };
			this.session.SendMessage(retMsg);
		}

		private void GetTypeInfo(GetTypeRequestMessage msg) {
			GetTypeResponseMessage retMsg;
			object obj = this.refToObj[msg.TargetId];
			if (obj is Delegate) {
				retMsg = new GetTypeResponseMessage {
					Members = new List<TypeMemberInfo>()
				};
			}
			else {
				var target = (IJsWrapper)obj;
				retMsg = target.GetTypeInfo();
			}
			this.session.SendMessage(retMsg);
		}

		private void InvokeMember(InvokeMemberMessage msg) {
			var target = (IJsWrapper)this.refToObj[msg.TargetId];
			try {
				Type retType;
				object ret = target.Invoke(msg.DispatchId, msg.DispatchType, msg.Parameters, out retType);
				bool isVoid = retType == typeof(void);
				var retMsg = new ReturnMessage { Value = WrapValue(ret, isVoid) };
				this.session.SendMessage(retMsg);
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				var value = new JsValue(ex.Message);
				var retMsg = new ReturnMessage { Value = value, IsException = true };
				this.session.SendMessage(retMsg);
			}
		}

		private void InvokeDelegate(InvokeDelegateMessage msg) {
			var target = (Delegate)this.refToObj[msg.TargetId];
			var targetType = target.GetType();
			Debug.WriteLine(string.Format("InvokeDelegate: {0}", target));
			var args = UnwrapParameters(msg.Parameters, DispatchType.Method, target.Method);
			try {
				object ret = target.DynamicInvoke(args);
				var retType = target.Method.ReturnType;
				bool isVoid = retType == typeof(void);
				var retMsg = new ReturnMessage { Value = WrapValue(ret, isVoid) };
				this.session.SendMessage(retMsg);
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				var value = new JsValue(ex.Message);
				var retMsg = new ReturnMessage { Value = value, IsException = true };
				this.session.SendMessage(retMsg);
			}
		}

		private bool GetLocalReference(object value, out int id) {
			if (!this.objToRef.TryGetValue(value, out id)) {
				id = lastRefId++;
				this.objToRef.Add(value, id);
				return false;
			}
			return true;
		}

		private int GetRemoteReference(object remote) {
			int id = 0;
			this.jsObjectToRef.TryGetValue(remote, out id);
			return id;
		}

		private void AddRemoteReference(object remote, int handle) {
			if (!this.jsObjectToRef.ContainsKey(remote)) {
				this.jsObjectToRef.Add(remote, handle);
			}
		}

		private JsValue[] WrapParameters(object[] args) {
			if (args == null) {
				return new JsValue[0];
			}
			return args.Select(x => WrapValue(x, false)).ToArray();
		}

		internal object[] UnwrapParameters(JsValue[] args, DispatchType dispType, MemberInfo member) {
			var fi = member as FieldInfo;
			if (fi != null) {
				throw new NotSupportedException("Fields are not supported JsObject members");
			}

			MethodBase method;
			if (dispType.IsMethod()) {
				method = member as MethodBase;
			}
			else if (dispType.IsPropertyGet()) {
				var pi = member as PropertyInfo;
				if (pi == null) {
					throw new InvalidOperationException();
				}
				method = pi.GetGetMethod();
			}
			else if (dispType.IsPropertyPut()) {
				var pi = member as PropertyInfo;
				if (pi == null) {
					throw new InvalidOperationException();
				}
				method = pi.GetSetMethod();
			}
			else
				throw new InvalidOperationException();

			var argTypes = method.GetParameters().Select(x => x.ParameterType);
			var ret = argTypes.Select((x, i) => UnwrapValue(args[i], x)).ToArray(); 
			return ret;
		}

		private JsValue WrapValue(object arg, bool isVoid) {
			if (isVoid)
				return new JsValue(JsValueType.Void, null);

			if (arg is JsObject) {
				int handle = GetRemoteReference(arg);
				Debug.Assert(handle != 0);
				return new JsValue(JsValueType.JsObject, handle);
			}

			JsValue ret = JsValue.FromPrimitive(arg);
			if (ret != null)
				return ret;

			if (arg is Delegate) {
				JsDelegateWrapper wrapper;
				if (this.remoteDelegates.TryGetValue((Delegate)arg, out wrapper)) {
					return new JsValue(JsValueType.JsObject, wrapper.Handle);
				}

				int id;
				if (!GetLocalReference(arg, out id)) {
					Debug.WriteLine(string.Format("Adding refToObj: delegate[{0}] -> {1}", arg, id));
					this.refToObj.Add(id, arg);
				}
				return new JsValue(JsValueType.Delegate, id);
			}
			if (arg is Array) {
				int id;
				if (!GetLocalReference(arg, out id)) {
					var wrapper = new JsArrayWrapper(this, arg as Array);
					Debug.WriteLine(string.Format("Adding refToObj: JsArrayWrapper[{0}] -> {1}", arg, id));
					this.refToObj.Add(id, wrapper);
				}
				return new JsValue(JsValueType.Object, id);
			}
			return GetObjectWrapper(arg);
		}

		private JsValue GetObjectWrapper(object arg) {
			int id;
			if (!GetLocalReference(arg, out id)) {
				IJsWrapper wrapper;
				if (arg is JsDynamicBase) {
					wrapper = new JsDynamicWrapper(this, (JsDynamicBase)arg);
				}
				else {
					wrapper = new JsObjectWrapper(this, arg);
				}
				Debug.WriteLine(string.Format("Adding refToObj: {0}[{1}] -> {2}", wrapper, arg, id));
				this.refToObj.Add(id, wrapper);
			}
			return new JsValue(JsValueType.Object, id);
		}

		internal object UnwrapValue(JsValue value, Type targetType) {
			if (value.IsJsObject) {
				if (typeof(Delegate).IsAssignableFrom(targetType)) {
					var wrapper = new JsDelegateWrapper(this, value.RefId, targetType);
					Delegate del = wrapper.GetDelegate();
					this.remoteDelegates.Add(del, wrapper);
					return del;
				}

				isUnwrapping = true;
				object ret;
				try {
					ret = CreateInstance(targetType);
				}
				finally {
					isUnwrapping = false;
				}

				AddRemoteReference(ret, value.RefId);

				return ret;
			}
			if (value.IsObject || value.IsDelegate) {
				return this.refToObj[value.RefId];
			}

			return value.Object;
		}

		internal object InvokeRemoteDelegate(Type retType, int handle, params object[] args) {
			JsValue[] wrapped = WrapParameters(args);
			var msg = new InvokeDelegateMessage {
				TargetId = handle,
				Parameters = wrapped
			};
			this.session.SendMessage(msg);
			JsValue value = DispatchAndReturn();
			return UnwrapValue(value, retType);
		}

		private JsFunction PrepareRemoteFunction(MethodBase method) {
			JsFunction function;
			if (!this.functionCache.TryGetValue(method, out function)) {
				function = new JsFunction(method);
				var msgDef = new DefineFunctionMessage {
					Name = function.Name,
					Parameters = function.Parameters,
					Body = function.Body
				};
				this.session.SendMessage(msgDef);
				this.functionCache.Add(method, function);
			}
			return function;
		}

		public object Invoke(object scope, object objMethod, object[] args) {
			try {
				MethodBase method = (MethodBase)objMethod;
				JsFunction function = PrepareRemoteFunction(method);

				int hScope = 0;
				if (scope != null)
					hScope = GetRemoteReference(scope);

				JsValue[] wrapped;
				if (method.GetParameters().Count() == 1 && args.Length > 1) {
					wrapped = new JsValue[] { WrapValue(args, false) };
				}
				else {
					wrapped = WrapParameters(args);
				}

				var msg = new InvokeFunctionMessage {
					Name = function.Name,
					ScopeId = hScope,
					Parameters = wrapped
				};

				this.session.SendMessage(msg);
				JsValue value = DispatchAndReturn();
				if (value.IsNull || value.IsVoid) {
					return null;
				}

				if (method.IsConstructor) {
					Debug.Assert(value.IsJsObject);
					AddRemoteReference(scope, value.RefId);
					return null;
				}

				var mi = (MethodInfo)method;
				return UnwrapValue(value, mi.ReturnType);
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				throw;
			}
		}

		//public object InvokeRemoteMethod(object scope, int stackDepth, params object[] args) {
		//    if (this.isUnwrapping) {
		//        return null;
		//    }
			
		//    StackFrame frame = new StackFrame(stackDepth + 1);
		//    var method = frame.GetMethod();

		//    if (method.IsConstructor) {
		//        StackFrame previous = new StackFrame(stackDepth + 2);
		//        // this prevents ctors from being called twice
		//        // we only want the derived class's ctor to execute, not any bases
		//        //if (previous.GetMethod().DeclaringType.IsSubclassOf(typeof(JsNativeBase))) {
		//        //    return null;
		//        //}
		//    }

		//    return InvokeRemoteMethod(method, scope, args);
		//}

		public T Cast<T>(object obj) {
			int handle = GetRemoteReference(obj);
			var brother = CreateInstance(typeof(T));
			AddRemoteReference(brother, handle);
			return (T)brother;
		}

		public object GetImplicitDynamicProperty(object obj, int stackDepth) {
			StackFrame frame = new StackFrame(stackDepth + 1);
			string name = GetPropertyName(frame);
			return GetDynamicProperty(obj, name);
		}

		public void SetImplicitDynamicProperty(object obj, int stackDepth, object value) {
			StackFrame frame = new StackFrame(stackDepth + 1);
			string name = GetPropertyName(frame);
			SetDynamicProperty(obj, name, value);
		}

		public bool TryGetDynamicProperty(object obj, string name, out object value) {
			var map = GetDynamicPropertyMap(obj);
			return map.TryGetValue(name, out value);
		}

		public object GetDynamicProperty(object obj, string name) {
			var map = GetDynamicPropertyMap(obj);
			return map[name];
		}

		public void SetDynamicProperty(object obj, string propertyName, object value) {
			var map = GetDynamicPropertyMap(obj);
			map[propertyName] = value;
		}

		public DynamicPropertyMap GetDynamicPropertyMap(object obj) {
			DynamicPropertyMap map;
			if (!this.dynamicObjects.TryGetValue(obj, out map)) {
				map = new DynamicPropertyMap();
				this.dynamicObjects.Add(obj, map);
			}
			return map;
		}

		private string GetPropertyName(StackFrame frame) {
			return frame.GetMethod().Name.Substring("get_".Length);
		}

		private bool isUnwrapping = false;
	}

}
