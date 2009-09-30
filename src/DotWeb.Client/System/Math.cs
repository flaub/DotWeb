using DotWeb.Client;
using System.Runtime.CompilerServices;

namespace DotWeb.Client.System
{
	[JsNamespace("System")]
	public static class Math
	{
		public const double E = global::System.Math.E;
		public const double PI = global::System.Math.PI;

		[JsCode("return Math.cos(a);")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Cos(double a);

		[JsCode("return Math.sin(a);")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Sin(double a);
	}
}
