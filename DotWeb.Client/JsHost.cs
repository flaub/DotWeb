using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Reflection;
using System.Diagnostics;

namespace DotWeb.Client
{
	public interface IJsHost
	{
		R InvokeRemoteMethod<R>(MethodBase method, JsNativeBase scope, params object[] args);
	}

	public static class JsHost
	{
		private const string JsHostName = "JsHost";

		public static IJsHost Instance {
			get {
				IJsHost host = CallContext.GetData(JsHostName) as IJsHost;
				if (host == null) {
					Debugger.Log(0, "DotWeb", "Lost my mind");
					Debugger.Break();
				}
				return host;
			}
			set {
				CallContext.SetData(JsHostName, value);
			}
		}

		public static R Execute<R>(MethodBase method, JsNativeBase scope, params object[] args) {
			string str = string.Format("{0}: {1}, {2}\n", method, scope, args);
			Debugger.Log(0, "DotWeb", str);
			return Instance.InvokeRemoteMethod<R>(method, scope, args);
		}
	}
}
