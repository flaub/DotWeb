﻿// Copyright 2009, Frank Laub
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
using System.Text;
using System.Reflection;
using System.Diagnostics;
using DotWeb.Client;

namespace DotWeb.Hosting.Bridge
{
	public interface IObjectFactory
	{
		object CreateInstance(Type type);
	}

	public class ActivatorFactory : IObjectFactory
	{
		public object CreateInstance(Type type) {
			return Activator.CreateInstance(type);
		}
	}

	public class JsBridge : IJsHost
	{
		private ISession session;
		private IObjectFactory factory;
		private Dictionary<MethodBase, JsFunction> functionCache = new Dictionary<MethodBase, JsFunction>();
		private Dictionary<Delegate, JsDelegateWrapper> remoteDelegates = new Dictionary<Delegate, JsDelegateWrapper>();
		private Dictionary<object, int> objToRef = new Dictionary<object, int>();
		private Dictionary<int, object> refToObj = new Dictionary<int, object>();
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
					JsNativeException jne = new JsNativeException();
					jne.Handle = (int)ret.Object;
					throw new JsException(jne);
				}
				else if (retMsg.Value.IsObject) {
					object obj = this.refToObj[ret.RefId];
					if (obj is Exception) {
						throw new JsException((Exception)obj);
					}
					else {
						throw new JsException(obj.ToString());
					}
				}
				else {
					throw new JsException(ret.Object.ToString());
				}
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
					else {
						throw new InvalidOperationException();
					}
				case MessageType.Quit:
					if (needsReturn) {
						throw new Exception("Quit");
					}
					else {
						retMsg = null;
						return false;
					}
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

				Type type = Type.GetType(msg.TypeName);
				this.factory.CreateInstance(type);

				JsValue value = new JsValue(JsValueType.Void, null);
				ReturnMessage retMsg = new ReturnMessage { Value = value };
				this.session.SendMessage(retMsg);
			}
			catch (TargetInvocationException ex) {
				HandleException(ex.InnerException);
			}
			catch (Exception ex) {
				HandleException(ex);
			}
		}

		private void HandleException(Exception ex) {
			Debug.WriteLine(ex);
			JsValue value = new JsValue(ex.Message);
			ReturnMessage retMsg = new ReturnMessage { Value = value, IsException = true };
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
				IJsAccessible target = (IJsAccessible)obj;
				retMsg = target.GetTypeInfo();
			}
			this.session.SendMessage(retMsg);
		}

		private void InvokeMember(InvokeMemberMessage msg) {
			IJsAccessible target = (IJsAccessible)this.refToObj[msg.TargetId];
			try {
				Type retType;
				object ret = target.Invoke(msg.MemberId, msg.DispatchType, msg.Parameters, out retType);
				bool isVoid = retType == typeof(void);
				ReturnMessage retMsg = new ReturnMessage { Value = WrapValue(ret, isVoid) };
				this.session.SendMessage(retMsg);
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				JsValue value = new JsValue(ex.Message);
				ReturnMessage retMsg = new ReturnMessage { Value = value, IsException = true };
				this.session.SendMessage(retMsg);
			}
		}

		private void InvokeDelegate(InvokeDelegateMessage msg) {
			Delegate target = (Delegate)this.refToObj[msg.TargetId];
			Debug.WriteLine(string.Format("InvokeDelegate: {0}", target));
			object[] args = UnwrapParameters(msg.Parameters, DispatchType.Method, target.Method);
			try {
				object ret = target.DynamicInvoke(args);
				var retType = target.Method.ReturnType;
				bool isVoid = retType == typeof(void);
				ReturnMessage retMsg = new ReturnMessage { Value = WrapValue(ret, isVoid) };
				this.session.SendMessage(retMsg);
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				JsValue value = new JsValue(ex.Message);
				ReturnMessage retMsg = new ReturnMessage { Value = value, IsException = true };
				this.session.SendMessage(retMsg);
			}
		}

		private string ExecuteToString(JsNativeBase scope) {
			object hScope = null;
			if (scope != null)
				hScope = scope.Handle;
//			return Agent.InvokeToString(hScope);
			return null;
		}

		private bool GetRefId(object value, out int id) {
			if (!this.objToRef.TryGetValue(value, out id)) {
				id = lastRefId++;
				this.objToRef.Add(value, id);
				return false;
			}
			return true;
		}

		private JsValue[] WrapParameters(object[] args) {
			if (args == null) {
				return new JsValue[0];
			}
			JsValue[] converted = new JsValue[args.Length];
			for (int i = 0; i < args.Length; i++) {
				object arg = args[i];
				converted[i] = WrapValue(arg, false);
			}
			return converted;
		}

		internal object[] UnwrapParameters(JsValue[] args, DispatchType dispType, MemberInfo member) {
			FieldInfo fi = member as FieldInfo;
			if (fi != null) {
				throw new NotSupportedException("Fields are not supported JsAccessible members");
			}

			MethodBase method;
			if (dispType.IsMethod()) {
				method = member as MethodBase;
			}
			else if (dispType.IsPropertyGet()) {
				PropertyInfo pi = member as PropertyInfo;
				if (pi == null) {
					throw new InvalidOperationException();
				}
				method = pi.GetGetMethod();
			}
			else if (dispType.IsPropertyPut()) {
				PropertyInfo pi = member as PropertyInfo;
				if (pi == null) {
					throw new InvalidOperationException();
				}
				method = pi.GetSetMethod();
			}
			else
				throw new InvalidOperationException();

			Type[] argTypes = method.GetParameters().Select(x => x.ParameterType).ToArray();
			int len = argTypes.Length;
			object[] ret = new object[len];
			for (int i = 0; i < len; i++) {
				Type argType = argTypes[i];
				ret[i] = UnwrapValue(args[i], argType);
			}
			return ret;
		}

		private JsValue WrapValue(object arg, bool isVoid) {
			if (isVoid)
				return new JsValue(JsValueType.Void, null);

			if (arg is JsNativeBase) {
				JsNativeBase jsnb = (JsNativeBase)arg;
				return new JsValue(JsValueType.JsObject, jsnb.Handle);
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
				if (!GetRefId(arg, out id)) {
					Debug.WriteLine(string.Format("Adding refToObj: delegate[{0}] -> {1}", arg, id));
					this.refToObj.Add(id, arg);
				}
				return new JsValue(JsValueType.Delegate, id);
			}
			if (arg is Array) {
				int id;
				if (!GetRefId(arg, out id)) {
					JsArrayWrapper wrapper = new JsArrayWrapper(this, arg as Array);
					Debug.WriteLine(string.Format("Adding refToObj: JsArrayWrapper[{0}] -> {1}", arg, id));
					this.refToObj.Add(id, wrapper);
				}
				return new JsValue(JsValueType.Object, id);
			}
//			return JsValue.FromPrimitive(arg);
			return GetObjectWrapper(arg);
		}

		private JsValue GetObjectWrapper(object arg) {
			int id;
			if (!GetRefId(arg, out id)) {
				JsObjectWrapper wrapper = new JsObjectWrapper(this, arg);
				Debug.WriteLine(string.Format("Adding refToObj: JsObjectWrapper[{0}] -> {1}", arg, id));
				this.refToObj.Add(id, wrapper);
			}
			return new JsValue(JsValueType.Object, id);
		}

		internal object UnwrapValue(JsValue value, Type targetType) {
			if (value.IsJsObject) {
				if (typeof(Delegate).IsAssignableFrom(targetType)) {
					JsDelegateWrapper wrapper = new JsDelegateWrapper(this, value.RefId, targetType);
					Delegate del = wrapper.GetDelegate();
					this.remoteDelegates.Add(del, wrapper);
					return del;
				}
				else {
					JsNativeBase jsnb = (JsNativeBase)this.factory.CreateInstance(targetType);
					jsnb.Handle = value.RefId;
					return jsnb;
				}
			}
			if (value.IsObject || value.IsDelegate) {
				return this.refToObj[value.RefId];
			}

			return value.Object;
		}

		internal object InvokeRemoteDelegate(Type retType, int handle, params object[] args) {
			JsValue[] wrapped = WrapParameters(args);
			InvokeDelegateMessage msg = new InvokeDelegateMessage {
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
				DefineFunctionMessage msgDef = new DefineFunctionMessage {
					Name = function.Name,
					Parameters = function.Parameters,
					Body = function.Body
				};
				this.session.SendMessage(msgDef);
				this.functionCache.Add(method, function);
			}
			return function;
		}

		R IJsHost.InvokeRemoteMethod<R>(MethodBase method, JsNativeBase scope, params object[] args) {
			try {
				JsFunction function = PrepareRemoteFunction(method);

				int hScope = 0;
				if (scope != null)
					hScope = scope.Handle;

				JsValue[] wrapped;
				if (method.GetParameters().Count() == 1 && args.Length > 1) {
					wrapped = new JsValue[] { WrapValue(args, false) };
				}
				else {
					wrapped = WrapParameters(args);
				}

				InvokeFunctionMessage msg = new InvokeFunctionMessage {
					Name = function.Name,
					ScopeId = hScope,
					Parameters = wrapped
				};

				this.session.SendMessage(msg);
				JsValue value = DispatchAndReturn();
				if (value.IsNull || value.IsVoid) {
					return default(R);
				}

				if (method.IsConstructor) {
					Debug.Assert(value.IsJsObject);
					scope.Handle = value.RefId;
					return default(R);
				}

				MethodInfo mi = method as MethodInfo;
				return (R)UnwrapValue(value, mi.ReturnType);
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				throw ex;
			}
		}
	}

}
