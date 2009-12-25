// Copyright 2009, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 
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

		public static extern void ExpandOnto(object obj);
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
			var window = Window;
			var doc = window.document;
			var element = doc.getElementById("box");
			var box = (HtmlDivElement)element;

			var div = (HtmlDivElement)doc.createElement("div");
			box.appendChild(div);

			box.onmouseover = box_OnMouseOver;
		}

		private void box_OnMouseOver(MouseEvent evt) {
		}
	}

	public class Expando : JsDynamic
	{
	}

	public class JsDynamicTest 
	{
		public JsDynamicTest() {
			var expando = new Expando();

			var serverSide = 1;
			expando["server"] = serverSide;
			NativeObject.TakeObject(expando["server"]);

			NativeObject.ExpandOnto(expando);

			var clientSide = expando["client"];
			NativeObject.TakeObject(expando["client"]);
		}
	}
}
