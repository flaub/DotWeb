using System.DotWeb;
using DotWeb.Client;

namespace DotWeb.Weaver.Test.Script
{
	[JsNamespace]
	internal class NativeCaller : JsObject
	{
		public extern NativeCaller(object cfg);

		public extern void Start();
	}

	[JsNamespace]
	internal class NativeObject : JsObject
	{
		public extern NativeObject();

		public extern void NativeCall();
	}

	public class NativeCallback : JsScript
	{
		public NativeCallback() {
			Console.Write("Hi");

			var obj = new NativeObject();
			Console.Write(obj);

			var cfg = new Config {
				nativeObject = obj
			};
			Console.Write(cfg);

			var caller = new NativeCaller(cfg);
			Console.Write(caller);

			caller.Start();
		}

		#region Nested type: Config

		[JsAnonymous]
		private class Config
		{
			public NativeObject nativeObject { get; set; }
		}

		#endregion

		#region Nested type: Console

		class Console
		{
			[JsCode("console.log(obj);")]
			public static extern void Write(object obj);
		}

		#endregion
	}
}