using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Reflection;

namespace DotWeb.Core
{
	public static class JsHost
	{
		private const string JsHostName = "JsHost";

		public static IJsHost Instance {
			get {
				return (IJsHost)CallContext.GetData(JsHostName);
			}
			set {
				CallContext.SetData(JsHostName, value);
			}
		}

		public static R Execute<R>(MethodBase method, JsNativeBase scope, params object[] args) {
			return Instance.Execute<R>(method, scope, args);
		}
	}
}
