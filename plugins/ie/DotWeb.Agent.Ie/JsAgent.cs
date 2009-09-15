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
using System.Text;
using System.Reflection;
using mshtml;
using System.Runtime.InteropServices.Expando;
using DotWeb.Hosting;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace DotWeb.Agent.Ie
{
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IJsAgent
	{
		void onLoad(object helper, string host, int port, string typeName);
		void onUnload();
	}

	[ComVisible(true)]
	[Guid("378F722A-A64C-4e90-9F9B-F57832FF9713")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class JsAgent : IJsAgent, IObjectSafety
	{
		private IHTMLDocument2 Document { get { return (IHTMLDocument2)this.Window.document; } }
		private IHTMLWindow2 Window { get; set; }
		private JsHelper helper;
		private TcpClient tcp;
		private ISession session;
		private Dictionary<object, int> objToRef;
		private Dictionary<int, object> refToObj;
		private int lastRefId = 1;

		#region MIME Type registration

		private const string MIME_KEYNAME = @"MIME\Database\Content Type";
		private const string MIME_TYPE = "application/x-dotweb";

		[ComRegisterFunction]
		public static void Register(Type type) {
			RegistryKey rkRoot = Registry.ClassesRoot.OpenSubKey(MIME_KEYNAME, true);
			if (rkRoot == null)
				rkRoot = Registry.ClassesRoot.CreateSubKey(MIME_KEYNAME);

			RegistryKey rkMime = rkRoot.OpenSubKey(MIME_TYPE);
			if (rkMime == null)
				rkMime = rkRoot.CreateSubKey(MIME_TYPE);

			string guid = type.GUID.ToString("B");
			rkMime.SetValue("CLSID", guid);

			rkMime.Close();
			rkRoot.Close();
		}

		[ComUnregisterFunction]
		public static void Unregister(Type type) {
			RegistryKey rkRoot = Registry.ClassesRoot.OpenSubKey(MIME_KEYNAME, true);
			if (rkRoot != null)
				rkRoot.DeleteSubKey(MIME_TYPE, false);
		}

		#endregion

		public JsAgent() {
			Debug.WriteLine("JsAgent");
		}

		public void OnEvent(string name, IHTMLEventObj evt) {
			switch (name) {
				case "onunload":
					this.OnUnload(evt);
					break;
			}
		}

		private void OnUnload(IHTMLEventObj evt) {
			this.session.SendMessage(new QuitMessage());
			this.objToRef.Clear();
			this.refToObj.Clear();
		}

		public object InvokeScript(string name, params object[] args) {
			IReflect reflect = this.Document.Script as IReflect;
			MethodInfo method = reflect.GetMethod(name, BindingFlags.Default);
			return method.Invoke(this.Window, args);
		}

		public object InvokeRemoteMember(int targetId, DispatchIdentifier dispId, DispatchType dispType, object[] args) {
			InvokeMemberMessage msg = new InvokeMemberMessage {
				TargetId = targetId,
				DispatchId = dispId,
				DispatchType = dispType,
				Parameters = WrapParameters(args)
			};
			this.session.SendMessage(msg);
			JsValue value = DispatchAndReturn();
			return WrapRemoteValue(value);
		}

		public object InvokeRemoteDelegate(int targetId, object[] args) {
			InvokeDelegateMessage msg = new InvokeDelegateMessage {
				TargetId = targetId,
				Parameters = WrapParameters(args)
			};
			this.session.SendMessage(msg);
			JsValue value = DispatchAndReturn();
			return WrapRemoteValue(value);
		}

		public GetTypeResponseMessage GetRemoteTypeInfo(int targetId) {
			GetTypeRequestMessage msg = new GetTypeRequestMessage {
				TargetId = targetId
			};
			this.session.SendMessage(msg);
			return (GetTypeResponseMessage)this.session.ReceiveMessage();
		}

		private void DefineFunction(DefineFunctionMessage msg) {
			try {
				string definition = string.Format("__$helper.functions['{0}'] = function({1}) {{ {2} }};", msg.Name, msg.Parameters, msg.Body);
				this.Window.execScript(definition, null);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				JsValue value = JsValue.FromPrimitive(ex.Message);
				ReturnMessage retMsg = new ReturnMessage { Value = value, IsException = true };
				this.session.SendMessage(retMsg);
			}
		}

		private int GetRefId(object value) {
			int id;
			if (!this.objToRef.TryGetValue(value, out id)) {
				id = lastRefId++;
				this.objToRef.Add(value, id);
				this.refToObj.Add(id, value);
			}
			return id;
		}

		private JsValue[] WrapParameters(object[] args) {
			if (args == null)
				return new JsValue[0];
			return args.Select(x => WrapLocalValue(x)).ToArray();
		}

		public JsValue WrapLocalValue(object value) {
			if (value is IReflect) {
				int id = GetRefId(value);
				return new JsValue(JsValueType.JsObject, id);
			}
			return JsValue.FromPrimitive(value);
		}

		private object WrapRemoteValue(JsValue value) {
			if (value.IsDelegate) {
				JsDispatchDelegate disp = new JsDispatchDelegate(this, value.RefId);
				return disp.IDispatch;
			}
			else if (value.IsObject) {
				JsDispatchObject disp = new JsDispatchObject(this, value.RefId);
				return disp.IDispatch;
			}
			else if (value.IsJsObject) {
				object obj = this.refToObj[value.RefId];
				return obj;
			}
			else {
				return value.Object;
			}
		}

		private void HandleReturn(object ret) {
			IReflect reflect = ret as IReflect;
			if (reflect == null)
				throw new InvalidOperationException();

			MemberInfo[] members = reflect.GetMembers(BindingFlags.Default);

			PropertyInfo pi0 = reflect.GetProperty("0", BindingFlags.Default);
			bool isException = (bool)pi0.GetValue(ret, null);

			PropertyInfo pi1 = reflect.GetProperty("1", BindingFlags.Default);
			ReturnMessage retMsg;
			if (pi1 == null) {
				retMsg = new ReturnMessage {
					IsException = isException,
					Value = new JsValue(JsValueType.Void, null)
				};
			}
			else {
				object result = pi1.GetValue(ret, null);
				retMsg = new ReturnMessage {
					IsException = isException,
					Value = WrapLocalValue(result)
				};
			}
			this.session.SendMessage(retMsg);
		}

		private void InvokeFunction(InvokeFunctionMessage msg) {
			try {
				object scope;
				if (msg.ScopeId != 0) {
					scope = this.refToObj[msg.ScopeId];
				}
				else {
					scope = null;
				}

				List<object> args = new List<object>();
				args.Add(msg.Name);
				args.Add(scope);
				foreach (JsValue arg in msg.Parameters) {
					object item = WrapRemoteValue(arg);
					args.Add(item);
				}

				object ret = this.helper.InvokeFunction(args.ToArray());
				HandleReturn(ret);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				JsValue value = JsValue.FromPrimitive(ex.Message);
				ReturnMessage retMsg = new ReturnMessage { Value = value, IsException = true };
				this.session.SendMessage(retMsg);
			}
		}

		private void InvokeDelegate(InvokeDelegateMessage msg) {
			try {
				IReflect target = this.refToObj[msg.TargetId] as IReflect;

				List<object> args = new List<object>();
				args.Add(target);

				foreach (JsValue arg in msg.Parameters) {
					object item = WrapRemoteValue(arg);
					args.Add(item);
				}

				object ret = this.helper.InvokeDelegate(args.ToArray());
				HandleReturn(ret);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				JsValue value = JsValue.FromPrimitive(ex.Message);
				ReturnMessage retMsg = new ReturnMessage { Value = value, IsException = true };
				this.session.SendMessage(retMsg);
			}
		}

		private JsValue DispatchAndReturn() {
			while (true) {
				IMessage msg = this.session.ReceiveMessage();
				switch (msg.MessageType) {
					case MessageType.DefineFunction:
						DefineFunction((DefineFunctionMessage)msg);
						break;
					case MessageType.InvokeFunction:
						InvokeFunction((InvokeFunctionMessage)msg);
						break;
					case MessageType.InvokeDelegate:
						InvokeDelegate((InvokeDelegateMessage)msg);
						break;
					case MessageType.Return:
						return ((ReturnMessage)msg).Value;
					case MessageType.Quit:
					default:
						throw new InvalidOperationException();
				}
			}
		}

		#region IJsAgent Members

		public void onLoad(object helper, string host, int port, string typeName) {
			this.helper = new JsHelper(helper, this);
			this.Window = this.helper.GetWindow();
			new JsConsole(this.Window, true);
			new JsConsole(this.Window, false);

			this.objToRef = new Dictionary<object, int>();
			this.refToObj = new Dictionary<int, object>();

			this.tcp = new TcpClient(host, port);
			this.session = new RemoteSession(this.tcp.GetStream());

			LoadMessage loadMsg = new LoadMessage {
				TypeName = typeName
			};

			this.session.SendMessage(loadMsg);

			DispatchAndReturn();
		}

		public void onUnload() {
			throw new NotImplementedException();
		}

		#endregion

		#region IObjectSafety Members
		
		// Constants for implementation of the IObjectSafety interface.
		private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001;
		private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002;
		private const int ObjectSafetyFlags = INTERFACESAFE_FOR_UNTRUSTED_CALLER | INTERFACESAFE_FOR_UNTRUSTED_DATA;
		private const int S_OK = 0;

		public int GetInterfaceSafetyOptions(ref Guid riid, out int pdwSupportedOptions, out int pdwEnabledOptions) {
			pdwSupportedOptions = ObjectSafetyFlags;
			pdwEnabledOptions = ObjectSafetyFlags;
			return S_OK;
		}

		public int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions) {
			return S_OK;
		}

		#endregion
	}
}
