using System.DotWeb;

#if HOSTED_MODE
using ThisType = DotWeb.System.String;
namespace DotWeb.System
#else
using ThisType = System.String;
namespace System
#endif
{
	public class String
	{
		public extern int Length { get; private set; }

		public extern static string Format(string format, params object[] args);

		[JsCode("return str0 + str1 + str2;")]
		public static extern string Concat(string str0, string str1, string str2);

		public static bool operator !=(ThisType a, ThisType b) {
			return false;
		}

		public static bool operator ==(ThisType a, ThisType b) {
			return false;
		}

		public override bool Equals(object obj) {
			return false;
		}

		public override int GetHashCode() {
			return 0;
		}
	}
}
