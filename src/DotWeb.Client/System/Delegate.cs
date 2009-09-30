
using System.Runtime.CompilerServices;

namespace DotWeb.Client.System
{
	[JsNamespace("System")]
	public class Delegate
	{
		//public static Delegate Combine(params Delegate[] delegates) {
		//    return null;
		//}

		[JsCode("throw 'Not Supported';")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern global::System.Delegate Combine(global::System.Delegate a, global::System.Delegate b);

		[JsCode("throw 'Not Supported';")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern global::System.Delegate Remove(global::System.Delegate source, global::System.Delegate value);
	}

	public class MulticastDelegate : Delegate
	{
	}
}
