using DotWeb.Client;
using DotWeb.Client.Dom;
using System;
using DotWeb.Client.Dom.Events;
using DotWeb.Client.Dom.Html;
using System.DotWeb;

namespace DotWeb.Hosting.Test.Script
{
	public class NativeObject : JsObject
	{
		public extern NativeObject();

		[JsIntrinsic]
		public extern GenericEventHandler onmouseover { get; set; }

		public static extern Delegate Constructor { get; }
		public extern void Alert(string msg);
		public extern void NativeCall();

		public static extern void TakeObject(object arg);

		public static extern Action GetAction0();
		public static extern Action<object> GetAction1();
		public static extern Action<object, object> GetAction2();

		public static extern Func<object> GetFunc0();
		public static extern Func<object, object> GetFunc1();
		public static extern Func<object, object, object> GetFunc2();
	}

	[JsNamespace]
	public class NativeCaller : JsObject
	{
		public extern NativeCaller(object cfg);

		public extern void Start();
	}

	[JsAnonymous]
	public class Config
	{
		public NativeObject nativeObject { get; set; }
	}

	public class SanityTest { }

	public class ObjectWrapperTest
	{
		public const string AlertArg = "ObjectWrapperTest";

		public ObjectWrapperTest() {
			var native = new NativeObject();
			native.Alert(AlertArg);
		}
	}

	public class EventHandlerTest
	{
		public const string AlertArg = "EventHandlerTest";
		private NativeObject native;

		public EventHandlerTest() {
			HasFired = false;
			native = new NativeObject();
			native.onmouseover = native_OnMouseOver;
		}

		public bool HasFired { get; private set; }

		public void native_OnMouseOver(Event evt) {
			HasFired = true;
			native.Alert(AlertArg);
		}
	}

	public class NativeCallbackTest
	{
		public NativeCallbackTest() {
			var obj = new NativeObject();

			var cfg = new Config {
				nativeObject = obj
			};

			var caller = new NativeCaller(cfg);
			caller.Start();
		}
	}

	public class DelegateWrapperTest
	{
		public DelegateWrapperTest() {
			var ctor = NativeObject.Constructor;
			NativeObject.TakeObject(ctor);
			NativeObject.GetAction0()();
			NativeObject.GetAction1()(1);
			NativeObject.GetAction2()(1, 2);
			NativeObject.GetFunc0()();
			NativeObject.GetFunc1()(1);
			NativeObject.GetFunc2()(1, 2);
		}
	}

	public class CastInterfaceTest : JsScript
	{
		public CastInterfaceTest() {
			var element = Window.document.getElementById("box");
			var box = (HtmlDivElement)element;
			box.onmouseover = box_OnMouseOver;
		}

		private void box_OnMouseOver(MouseEvent evt) {
		}
	}
}
