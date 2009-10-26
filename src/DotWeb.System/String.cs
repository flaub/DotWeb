
#if HOSTED_MODE
using ThisType = DotWeb.System.String;
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using ThisType = System.String;
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
	public class String
	{
		public int Length { get; private set; }

		public extern static ThisType Format(string format, params object[] args);

		[JsCode("return str0 + str1 + str2;")]
		public static extern ThisType Concat(string str0, string str1, string str2);

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

//#if HOSTED_MODE
//        public String(string str) {
//        }

//        public static implicit operator String(string str) {
//            return null;
//        }

//        public static implicit operator string(String str) {
//            return null;
//        }
//#endif
	}
}
