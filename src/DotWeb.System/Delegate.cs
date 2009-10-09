using System.Runtime.CompilerServices;
using System.DotWeb;

#if HOSTED_MODE
namespace DotWeb.System
#else
namespace System
#endif
{
	public class Delegate
	{
		//public static Delegate Combine(params Delegate[] delegates) {
		//    return null;
		//}

		[JsCode("throw 'Not Supported';")]
		public static extern Delegate Combine(Delegate a, Delegate b);

		[JsCode("throw 'Not Supported';")]
		public static extern Delegate Remove(Delegate source, Delegate value);
	}

	public class MulticastDelegate : Delegate
	{
	}
}
