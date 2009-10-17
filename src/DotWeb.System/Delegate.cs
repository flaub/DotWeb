using System.Runtime.CompilerServices;

#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
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

	[UseSystem]
	public class MulticastDelegate : Delegate
	{
	}
}
