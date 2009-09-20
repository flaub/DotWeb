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
using DotWeb.Client;
using DotWeb.Client.Dom;
using DotWeb.Client.Dom.Html;
using DotWeb.Hosting.Bridge;
using DotWeb.Hosting.Test.Bridge;
using NUnit.Framework;
using Rhino.Mocks;
using DotWeb.Hosting.Test.Script;

namespace DotWeb.Hosting.Test
{
	[TestFixture]
	public class JsBridgeTest
	{
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

		class SimpleStorage : IJsHostStorage
		{
			private IJsHost host;

			public SimpleStorage(IJsHost host) {
				this.host = host;
			}

			public IJsHost Host {
				get { return this.host; }
			}
		}

		private void TestHelper(IObjectFactory factory, SessionHandler handler) {
			MockRepository mocks = new MockRepository();

			ISession session = mocks.StrictMock<ISession>();
			JsBridge bridge = new JsBridge(session, factory);
			var storage = new SimpleStorage(bridge);
			JsHost.Storage = storage;
			SessionHelper helper = new SessionHelper(bridge, session);
			using (mocks.Ordered()) {
				handler(helper);
			}
			mocks.ReplayAll();

			bridge.DispatchForever();

			mocks.VerifyAll();
		}

		[Test]
		public void TestDelegateWrapper() {
			//			var ctor = NativeObject.Constructor;
			//			NativeObject.TakeObject(ctor);

			int remoteId = 0;
			CachingObjectFactory factory = new CachingObjectFactory();
			TestHelper(factory, delegate(SessionHelper session) {
				Type nativeType = typeof(NativeObject);
				session.OnLoadMessage(typeof(DelegateWrapperTest));

				var ctor = session.DefineFunctionMessage(nativeType.GetMethod("get_Constructor"));
				session.InvokeFunctionMessage(ctor.Name, 0);
				var ctorId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, ctorId);

				var method = session.DefineFunctionMessage(nativeType.GetMethod("TakeObject"));
				session.InvokeFunctionMessage(method.Name, 0, new JsValue(JsValueType.JsObject, ctorId));
				session.OnReturnMessage(false, JsValueType.Void, null);

				SimulateAction(session, nativeType, "GetAction0", JsValueType.Void, ref remoteId);
				SimulateAction(session, nativeType, "GetAction1", JsValueType.Void, ref remoteId, 1);
				SimulateAction(session, nativeType, "GetAction2", JsValueType.Void, ref remoteId, 1, 2);

				SimulateAction(session, nativeType, "GetFunc0", JsValueType.Null, ref remoteId);
				SimulateAction(session, nativeType, "GetFunc1", JsValueType.Null, ref remoteId, 1);
				SimulateAction(session, nativeType, "GetFunc2", JsValueType.Null, ref remoteId, 1, 2);

				// return from initial ctor
				session.ReturnMessage();

				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestEventHandler() {
			CachingObjectFactory factory = new CachingObjectFactory();
			TestHelper(factory, delegate(SessionHelper session) {
				Type nativeType = typeof(NativeObject);
				session.OnLoadMessage(typeof(EventHandlerTest));

				// new Nativeobject();
				var ctor = session.DefineFunctionMessage(nativeType.GetConstructor(Type.EmptyTypes));
				session.InvokeFunctionMessage(ctor.Name, 0);
				// return the scopeId for the newly created native object
				session.OnReturnMessage(false, JsValueType.JsObject, 1);

				// nativeObject.onmouseover = native_OnMouseOver;
				var method = session.DefineFunctionMessage(nativeType.GetMethod("set_onmouseover"));
				session.InvokeFunctionMessage(method.Name, 1, new JsValue(JsValueType.Delegate, 1));
				session.OnReturnMessage(false, JsValueType.Void, null);

				// return from initial ctor
				session.ReturnMessage();

				// simulate an event firing
				session.OnInvokeDelegateMessage(1, new JsValue(JsValueType.JsObject, 2));

				// nativeObject.Alert();
				var alert = session.DefineFunctionMessage(nativeType.GetMethod("Alert"));
				session.InvokeFunctionMessage(alert.Name, 1, new JsValue(EventHandlerTest.AlertArg));
				session.OnReturnMessage(false, JsValueType.Void, null);

				// return from event handler
				session.ReturnMessage();

				session.OnQuitMessage();
			});

			EventHandlerTest test = (EventHandlerTest)factory.Get(typeof(EventHandlerTest));
			Assert.IsTrue(test.HasFired);
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
			TestHelper(factory, delegate(SessionHelper session) {
				Type nativeType = typeof(NativeObject);
				session.OnLoadMessage(typeof(NativeCallbackTest));

				// new Nativeobject();
				var ctor = session.DefineFunctionMessage(nativeType.GetConstructor(Type.EmptyTypes));
				session.InvokeFunctionMessage(ctor.Name, 0);
				// return the scopeId for the newly created native object
				var nativeObjectId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, nativeObjectId);

				//var caller = new NativeCaller(cfg);
				Type nativeCallerType = typeof(NativeCaller);
				var ctor2 = session.DefineFunctionMessage(nativeCallerType.GetConstructor(new Type[] { typeof(object) }));
				var cfgId = ++localId;
				session.InvokeFunctionMessage(ctor2.Name, 0, new JsValue(JsValueType.Object, cfgId));

				// the ctor for NativeCaller() will grab the nativeObject from the cfg passed in
				session.OnGetTypeRequestMessage(cfgId);

				var cfg = new Config();
				session.GetTypeResponseMessage(session.Bridge, cfg);

				session.OnInvokeMemberMessage(cfgId, new DispatchIdentifier("nativeObject"), DispatchType.PropertyGet);

				// give back the nativeObject handle
				session.ReturnMessage(new JsValue(JsValueType.JsObject, nativeObjectId));

				// return the scopeId for the newly created native object
				var nativeCallerId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, nativeCallerId);

				//caller.Start();
				var method = session.DefineFunctionMessage(nativeCallerType.GetMethod("Start"));
				session.InvokeFunctionMessage(method.Name, nativeCallerId);
				session.OnReturnMessage(false, JsValueType.Void, null);

				// return from initial ctor
				session.ReturnMessage();

				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestObjectWrapper() {
			TestHelper(new DefaultFactory(), delegate(SessionHelper session) {
				Type nativeType = typeof(NativeObject);
				session.OnLoadMessage(typeof(ObjectWrapperTest));

				// new Nativeobject();
				var ctor = session.DefineFunctionMessage(nativeType.GetConstructor(Type.EmptyTypes));
				session.InvokeFunctionMessage(ctor.Name, 0);
				// return the scopeId for the newly created native object
				session.OnReturnMessage(false, JsValueType.JsObject, 1);

				// nativeObject.Alert();
				var alert = session.DefineFunctionMessage(nativeType.GetMethod("Alert"));
				session.InvokeFunctionMessage(alert.Name, 1, new JsValue(ObjectWrapperTest.AlertArg));
				session.OnReturnMessage(false, JsValueType.Void, null);

				session.ReturnMessage();
				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestSanity() {
			TestHelper(new DefaultFactory(), delegate(SessionHelper session) {
				session.OnLoadMessage(typeof(SanityTest));
				session.ReturnMessage();
				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestCastInterface() {
			TestHelper(new DefaultFactory(), delegate(SessionHelper session) {
				int localId = 0;
				int remoteId = 0;
				session.OnLoadMessage(typeof(CastInterfaceTest));

				//var element = Window.document.getElementById("box");
				var window = session.DefineFunctionMessage(typeof(JsScript).GetMethod("get_Window"));
				var windowId = ++remoteId;
				session.InvokeFunctionMessage(window.Name, 0);
				session.OnReturnMessage(false, JsValueType.JsObject, windowId);

				var document = session.DefineFunctionMessage(typeof(Window).GetMethod("get_document"));
				var documentId = ++remoteId;
				session.InvokeFunctionMessage(document.Name, windowId);
				session.OnReturnMessage(false, JsValueType.JsObject, documentId);

				var getElement = session.DefineFunctionMessage(typeof(Document).GetMethod("getElementById"));
				var elementId = ++remoteId;
				session.InvokeFunctionMessage(getElement.Name, documentId, new JsValue("box"));
				session.OnReturnMessage(false, JsValueType.JsObject, elementId);

				//var box = JsRuntime.Cast<HtmlDivElement>(element);
				
				//box.onmouseover = box_OnMouseOver;
				var setHandler = session.DefineFunctionMessage(typeof(HtmlElement).GetMethod("set_onmouseover"));
				session.InvokeFunctionMessage(setHandler.Name, elementId, new JsValue(JsValueType.Delegate, ++localId));
				session.OnReturnMessage(false, JsValueType.Void, null);

				session.ReturnMessage();
				session.OnQuitMessage();
			});
		}
	}
}