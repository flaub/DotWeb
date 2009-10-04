using System.Runtime.CompilerServices;

namespace DotWeb.Client.System
{
	[JsNamespace("System")]
	public class String
	{
		public int Length { get; private set; }

		public static string Format(string format, params object[] args) {
			return null;
		}

		[JsCode("return str0 + str1 + str2;")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string Concat(string str0, string str1, string str2);
	}
}
