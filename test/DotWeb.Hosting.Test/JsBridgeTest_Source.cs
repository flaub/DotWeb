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

using System;
using DotWeb.Client;
using DotWeb.Client.Dom;
using DotWeb.Client.Dom.Events;
using DotWeb.Client.Dom.Html;

namespace DotWeb.Hosting.Test
{
	namespace Bridge
	{
		internal class NativeObject : JsNativeBase
		{
			public NativeObject() { C_(); }

			[JsIntrinsic]
			public GenericEventHandler onmouseover { get { return _<GenericEventHandler>(); } set { _(value); } }

			public static Delegate Constructor { get { return S_<Delegate>(); } }
			public void Alert(string msg) { _(msg); }
			public void NativeCall() { _(); }

			public static void TakeObject(object arg) { S_(arg); }

			public static Action GetAction0() { return S_<Action>(); }
			public static Action<object> GetAction1() { return S_<Action<object>>(); }
			public static Action<object, object> GetAction2() { return S_<Action<object, object>>(); }

			public static Func<object> GetFunc0() { return S_<Func<object>>(); }
			public static Func<object, object> GetFunc1() { return S_<Func<object, object>>(); }
			public static Func<object, object, object> GetFunc2() { return S_<Func<object, object, object>>(); }
		}

		[JsNamespace]
		internal class NativeCaller : JsNativeBase
		{
			public NativeCaller(object cfg) { C_(cfg); }

			public void Start() { _(); }
		}

		[JsAnonymous]
		internal class Config
		{
			public NativeObject nativeObject { get; set; }
		}

		internal class SanityTest { }

		internal class ObjectWrapperTest
		{
			public const string AlertArg = "ObjectWrapperTest";

			public ObjectWrapperTest() {
				var native = new NativeObject();
				native.Alert(AlertArg);
			}
		}

		internal class EventHandlerTest
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

		internal class NativeCallbackTest
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

		internal class DelegateWrapperTest
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

		class CastInterfaceTest : JsScript
		{
			public CastInterfaceTest() {
				var element = Window.document.getElementById("box");
				var box = JsRuntime.Cast<HtmlDivElement>(element);
				box.onmouseover = box_OnMouseOver;
			}

			private void box_OnMouseOver(MouseEvent evt) {
			}
		}
	}
}