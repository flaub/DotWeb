using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Twinkie
{
	public class JsNativeBase
	{
		public object _(params object[] args) {
			StackFrame frame = new StackFrame(1);
			return JsBridge.ExecuteNative(frame.GetMethod(), this, args);
		}

		public static object S_(params object[] args) {
			StackFrame frame = new StackFrame(1);
			return JsBridge.ExecuteNative(frame.GetMethod(), null, args);
		}
	}
}
