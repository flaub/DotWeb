#if HOSTED_MODE
namespace DotWeb.System.DotWeb
#else
namespace System.DotWeb
#endif
{
	public class JsString
	{
		[JsMacro("RegExp({1}, 'g')")]
		private static extern string RE(string pattern);

		public static string HtmlEncode(string value) {
			return value.Replace(RE("&"), "&amp;").Replace(RE("<"), "&lt;").Replace(RE(">"), "&gt;");
		}
	}
}
