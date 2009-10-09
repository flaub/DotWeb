
using System.DotWeb;

#if HOSTED_MODE
namespace DotWeb.System
#else
namespace System
#endif
{
	[DotWebInternal]
	public static class Console
	{
		public static extern void Write(int value);

		public static extern void WriteLine(object value);

		[JsCode("console.log(value);")]
		public static extern void WriteLine(string value);

		public static extern void WriteLine(string format, params object[] args);

		public static extern void WriteLine(string format, object arg0, object arg1);
	}
}
