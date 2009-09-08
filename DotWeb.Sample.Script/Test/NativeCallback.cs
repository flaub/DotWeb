using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client;
using DotWeb.Client.Dom;

namespace DotWeb.Sample.Script.Test
{
	[JsNamespace]
	class NativeCaller : JsNativeBase
	{
		public NativeCaller(object cfg) { C_(cfg); }

		public void Start() { _(); }
	}

	[JsNamespace]
	class NativeObject : JsNativeBase
	{
		public NativeObject() { C_(); }

		public void NativeCall() { _(); }
	}

	public class NativeCallback : JsScript
	{
		class Console
		{
			[JsCode("console.log(obj);")]
			public static void Write(object obj) { JsHost.S_(obj); }
		}

		[JsAnonymous]
		class Config
		{
			public NativeObject nativeObject { get; set; }
		}

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
	}
}
