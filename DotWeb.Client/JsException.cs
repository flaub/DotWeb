using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Client
{
	public class JsNativeException : JsNativeBase
	{
		[JsCode("return this.toString();")]
		public override string ToString() {
			return _<string>();
		}
	}

	public class JsException : ApplicationException
	{
		public JsNativeException NativeException { get; set; }

		public JsException() {}
		public JsException(string msg) : base(msg) {}
		public JsException(Exception inner)
			: base("JsException", inner) {
		}
		public JsException(JsNativeException native) {
			this.NativeException = native;
		}
	}
}
