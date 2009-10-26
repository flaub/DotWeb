
#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using System.DotWeb;
namespace System
#endif
{
	public static class Console
	{
		[JsCode("console.log(value);")]
		public static extern void Write(int value);

		[JsCode("console.log(value);")]
		public static extern void WriteLine(object value);

		[JsCode("console.log(value);")]
		public static extern void WriteLine(string value);

		[JsCode("console.log(format);")]
		public static extern void WriteLine(string format, params object[] args);

		[JsCode("console.log(format);")]
		public static extern void WriteLine(string format, object arg0, object arg1);
	}
}
