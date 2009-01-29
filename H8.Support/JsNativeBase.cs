using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace DotWeb.Core
{
	public class NativeAttribute : Attribute { }

	public class JsNativeBase : JsAccessible
	{
		public object Handle { get; set; }

		//public override string ToString() {
		//    return JsBridge.Instance.ExecuteToString(this);
		//}

		private class VoidReturn { }

		protected void C_(params object[] args) {
			StackFrame frame = new StackFrame(1);
			JsHost.Execute<VoidReturn>(frame.GetMethod(), this, args);
		}

		protected void _(params object[] args) {
			StackFrame frame = new StackFrame(1);
			JsHost.Execute<VoidReturn>(frame.GetMethod(), this, args);
		}

		protected R _<R>(params object[] args) {
			StackFrame frame = new StackFrame(1);
			return JsHost.Execute<R>(frame.GetMethod(), this, args);
		}

		protected static void S_(params object[] args) {
			StackFrame frame = new StackFrame(1);
			JsHost.Execute<VoidReturn>(frame.GetMethod(), null, args);
		}

		protected static R S_<R>(params object[] args) {
			StackFrame frame = new StackFrame(1);
			return JsHost.Execute<R>(frame.GetMethod(), null, args);
		}
	}
}
