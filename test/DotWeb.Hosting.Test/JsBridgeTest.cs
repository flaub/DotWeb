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
using System.Linq;
using DotWeb.Hosting.Bridge;
using NUnit.Framework;
using Rhino.Mocks;
using System.Reflection;
using System.IO;
using System.Runtime.Remoting;

namespace DotWeb.Hosting.Test
{
	[TestFixture]
	public class JsBridgeTest
	{
		private Assembly asm;
		private Type nativeObject;

		public JsBridgeTest() {
			this.asm = Assembly.Load("Hosted-DotWeb.Hosting.Test.Script");
			this.nativeObject = this.asm.GetType("DotWeb.Hosting.Test.Script.NativeObject");
		}

		private void SimulateAction(SessionHelper session, Type nativeType, string name, JsValueType retType, ref int remoteId,
			params int[] args) {
			var action = session.DefineFunctionMessage(nativeType.GetMethod(name));
			session.InvokeFunctionMessage(action.Name, 0);
			var id = ++remoteId;
			session.OnReturnMessage(false, JsValueType.JsObject, id);

			JsValue[] wrapped = args.Select(x => new JsValue(x)).ToArray();
			session.InvokeDelegateMessage(id, wrapped);

			session.OnReturnMessage(false, retType, null);
		}

		private delegate void SessionHandler(SessionHelper session);

		private void TestHelper(IObjectFactory factory, SessionHandler handler) {
			MockRepository mocks = new MockRepository();

			ISession session = mocks.StrictMock<ISession>();
			JsBridge bridge = new JsBridge(session, factory);
			HostedMode.Host = bridge;
			SessionHelper helper = new SessionHelper(bridge, session);
			using (mocks.Ordered()) {
				handler(helper);
			}
			mocks.ReplayAll();

			bridge.DispatchForever();

			mocks.VerifyAll();
		}

		[Test]
		public void TestSanity() {
			var loadType = asm.GetType("DotWeb.Hosting.Test.Script.SanityTest");

			TestHelper(new DefaultFactory(), delegate(SessionHelper session) {
				session.OnLoadMessage(loadType);
				session.ReturnMessage();
				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestDelegateWrapper() {
			//var ctor = NativeObject.Constructor;
			//NativeObject.TakeObject(ctor);

			var loadType = this.asm.GetType("DotWeb.Hosting.Test.Script.DelegateWrapperTest");

			int remoteId = 0;
			CachingObjectFactory factory = new CachingObjectFactory();
			TestHelper(factory, delegate(SessionHelper session) {
				session.OnLoadMessage(loadType);

				var ctor = session.DefineFunctionMessage(this.nativeObject.GetMethod("get_Constructor"));
				session.InvokeFunctionMessage(ctor.Name, 0);
				var ctorId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, ctorId);

				var method = session.DefineFunctionMessage(this.nativeObject.GetMethod("TakeObject"));
				session.InvokeFunctionMessage(method.Name, 0, new JsValue(JsValueType.JsObject, ctorId));
				session.OnReturnMessage(false, JsValueType.Void, null);

				SimulateAction(session, this.nativeObject, "GetAction0", JsValueType.Void, ref remoteId);
				SimulateAction(session, this.nativeObject, "GetAction1", JsValueType.Void, ref remoteId, 1);
				SimulateAction(session, this.nativeObject, "GetAction2", JsValueType.Void, ref remoteId, 1, 2);

				SimulateAction(session, this.nativeObject, "GetFunc0", JsValueType.Null, ref remoteId);
				SimulateAction(session, this.nativeObject, "GetFunc1", JsValueType.Null, ref remoteId, 1);
				SimulateAction(session, this.nativeObject, "GetFunc2", JsValueType.Null, ref remoteId, 1, 2);

				// return from initial ctor
				session.ReturnMessage();

				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestEventHandler() {
			var loadType = this.asm.GetType("DotWeb.Hosting.Test.Script.EventHandlerTest");
			var alertArg = (string)loadType.GetField("AlertArg").GetValue(null);
			CachingObjectFactory factory = new CachingObjectFactory();
			TestHelper(factory, delegate(SessionHelper session) {
				session.OnLoadMessage(loadType);

				// new Nativeobject();
				var ctor = session.DefineFunctionMessage(this.nativeObject.GetConstructor(Type.EmptyTypes));
				session.InvokeFunctionMessage(ctor.Name, 0);
				// return the scopeId for the newly created native object
				session.OnReturnMessage(false, JsValueType.JsObject, 1);

				// nativeObject.onmouseover = native_OnMouseOver;
				var method = session.DefineFunctionMessage(this.nativeObject.GetMethod("set_onmouseover"));
				session.InvokeFunctionMessage(method.Name, 1, new JsValue(JsValueType.Delegate, 1));
				session.OnReturnMessage(false, JsValueType.Void, null);

				// return from initial ctor
				session.ReturnMessage();

				// simulate an event firing
				session.OnInvokeDelegateMessage(1, new JsValue(JsValueType.JsObject, 2));

				// nativeObject.Alert();
				var alert = session.DefineFunctionMessage(this.nativeObject.GetMethod("Alert"));
				session.InvokeFunctionMessage(alert.Name, 1, new JsValue(alertArg));
				session.OnReturnMessage(false, JsValueType.Void, null);

				// return from event handler
				session.ReturnMessage();

				session.OnQuitMessage();
			});

			//EventHandlerTest test = (EventHandlerTest)factory.Get(typeof(EventHandlerTest));
			//Assert.IsTrue(test.HasFired);
		}

		[Test]
		public void TestNativeCallback() {
			// Let's say the native js code looked like:
			//function NativeCaller(config) {
			//    for(var key in config){
			//        this[key] = config[key];
			//    }
			//};

			//NativeCaller.prototype.Start = function() { 
			//    this.nativeObject.NativeCall(); 
			//};

			//function NativeObject() {
			//};

			//NativeObject.prototype.NativeCall = function() {
			//    alert('OK');
			//};

			CachingObjectFactory factory = new CachingObjectFactory();
			int localId = 0;
			int remoteId = 0;
			var loadType = this.asm.GetType("DotWeb.Hosting.Test.Script.NativeCallbackTest");
			var nativeCaller = this.asm.GetType("DotWeb.Hosting.Test.Script.NativeCaller");
			var configType = this.asm.GetType("DotWeb.Hosting.Test.Script.Config");
			var cfg = Activator.CreateInstance(configType);
			TestHelper(factory, delegate(SessionHelper session) {
				session.OnLoadMessage(loadType);

				// new Nativeobject();
				var ctor = session.DefineFunctionMessage(this.nativeObject.GetConstructor(Type.EmptyTypes));
				session.InvokeFunctionMessage(ctor.Name, 0);
				// return the scopeId for the newly created native object
				var nativeObjectId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, nativeObjectId);

				//var caller = new NativeCaller(cfg);
				var ctor2 = session.DefineFunctionMessage(nativeCaller.GetConstructor(new Type[] { typeof(object) }));
				var cfgId = ++localId;
				session.InvokeFunctionMessage(ctor2.Name, 0, new JsValue(JsValueType.Object, cfgId));

				// the ctor for NativeCaller() will grab the nativeObject from the cfg passed in
				session.OnGetTypeRequestMessage(cfgId);

				session.GetTypeResponseMessage(session.Bridge, cfg);

				session.OnInvokeMemberMessage(cfgId, new DispatchIdentifier("nativeObject"), DispatchType.PropertyGet);

				// give back the nativeObject handle
				session.ReturnMessage(new JsValue(JsValueType.JsObject, nativeObjectId));

				// return the scopeId for the newly created native object
				var nativeCallerId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, nativeCallerId);

				//caller.Start();
				var method = session.DefineFunctionMessage(nativeCaller.GetMethod("Start"));
				session.InvokeFunctionMessage(method.Name, nativeCallerId);
				session.OnReturnMessage(false, JsValueType.Void, null);

				// return from initial ctor
				session.ReturnMessage();

				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestObjectWrapper() {
			var loadType = this.asm.GetType("DotWeb.Hosting.Test.Script.ObjectWrapperTest");
			string argValue = (string)loadType.GetField("AlertArg").GetValue(null);
			TestHelper(new DefaultFactory(), delegate(SessionHelper session) {
				session.OnLoadMessage(loadType);

				// new Nativeobject();
				var ctor = session.DefineFunctionMessage(this.nativeObject.GetConstructor(Type.EmptyTypes));
				session.InvokeFunctionMessage(ctor.Name, 0);
				// return the scopeId for the newly created native object
				session.OnReturnMessage(false, JsValueType.JsObject, 1);

				// nativeObject.Alert();
				var alert = session.DefineFunctionMessage(this.nativeObject.GetMethod("Alert"));
				session.InvokeFunctionMessage(alert.Name, 1, new JsValue(argValue));
				session.OnReturnMessage(false, JsValueType.Void, null);

				session.ReturnMessage();
				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestCastInterface() {
			var loadType = this.asm.GetType("DotWeb.Hosting.Test.Script.CastInterfaceTest");
			var asmClient = Assembly.Load("Hosted-DotWeb.Client");
			var jsScriptType = asmClient.GetType("DotWeb.Client.JsScript");
			var windowType = asmClient.GetType("DotWeb.Client.Dom.Window");
			var documentType = asmClient.GetType("DotWeb.Client.Dom.Document");
			var htmlElementType = asmClient.GetType("DotWeb.Client.Dom.Html.HtmlElement");
			var nodeType = asmClient.GetType("DotWeb.Client.Dom.Node");

			TestHelper(new DefaultFactory(), delegate(SessionHelper session) {
				int localId = 0;
				int remoteId = 0;
				session.OnLoadMessage(loadType);

				//var element = Window.document.getElementById("box");
				
				//var window = Window;
				var window = session.DefineFunctionMessage(jsScriptType.GetMethod("get_Window"));
				session.InvokeFunctionMessage(window.Name, 0);
				var windowId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, windowId);

				// var doc = window.document;
				var document = session.DefineFunctionMessage(windowType.GetMethod("get_document"));
				session.InvokeFunctionMessage(document.Name, windowId);
				var documentId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, documentId);

				// var element = doc.getElementById("box");
				var getElement = session.DefineFunctionMessage(documentType.GetMethod("getElementById"));
				session.InvokeFunctionMessage(getElement.Name, documentId, new JsValue("box"));
				var boxId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, boxId);

				// var box = (HtmlDivElement)element;
				// internally does a Cast() on the bridge, would be nice to test this

				// var div = (HtmlDivElement)doc.createElement("div");
				var createElement = session.DefineFunctionMessage(documentType.GetMethod("createElement"));
				session.InvokeFunctionMessage(createElement.Name, documentId, new JsValue("div"));
				var divId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, divId);

				// box.appendChild(div);
				var appendChild = session.DefineFunctionMessage(nodeType.GetMethod("appendChild"));
				session.InvokeFunctionMessage(appendChild.Name, boxId, new JsValue(JsValueType.JsObject, divId));
				var nodeId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, nodeId);

				//box.onmouseover = box_OnMouseOver;
				var setHandler = session.DefineFunctionMessage(htmlElementType.GetMethod("set_onmouseover"));
				session.InvokeFunctionMessage(setHandler.Name, boxId, new JsValue(JsValueType.Delegate, ++localId));
				session.OnReturnMessage(false, JsValueType.Void, null);

				session.ReturnMessage();
				session.OnQuitMessage();
			});
		}
	}
}