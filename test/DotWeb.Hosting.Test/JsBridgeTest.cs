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
using System.Reflection;
using DotWeb.Client;
using DotWeb.Client.Dom;
using DotWeb.Hosting.Bridge;
using DotWeb.Hosting.Test.Bridge;
using NUnit.Framework;
using Rhino.Mocks;

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

		internal class SanityTest {}

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

			public void native_OnMouseOver() {
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
	}

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

		private void TestHelper(IObjectFactory factory, SessionHandler handler) {
			MockRepository mocks = new MockRepository();

			ISession session = mocks.StrictMock<ISession>();
			JsBridge bridge = new JsBridge(session, factory);
			JsHost.Instance = bridge;
			SessionHelper helper = new SessionHelper(session);
			using (mocks.Ordered()) {
				handler(helper);
			}
			mocks.ReplayAll();

			bridge.DispatchForever();

			mocks.VerifyAll();
		}

		private class SessionHelper
		{
			private readonly ISession session;
			public SessionHelper(ISession session) { this.session = session; }

			public void OnLoadMessage(Type type) {
				ReadMessage(new LoadMessage {
					TypeName = type.AssemblyQualifiedName
				});
			}

			public void OnReturnMessage(bool isException, JsValueType tag, object value) {
				ReadMessage(new ReturnMessage {
					IsException = isException,
					Value = new JsValue(tag, value)
				});
			}

			public void OnQuitMessage() { ReadMessage(new QuitMessage()); }

			public void OnInvokeMemberMessage(int targetId, int memberId, DispatchType dispatchType, params JsValue[] parameters) {
				ReadMessage(new InvokeMemberMessage {
					TargetId = targetId,
					MemberId = memberId,
					DispatchType = dispatchType,
					Parameters = parameters
				});
			}

			public void OnGetTypeRequestMessage(int targetId) {
				ReadMessage(new GetTypeRequestMessage {
					TargetId = targetId
				});
			}

			public void OnInvokeDelegateMessage(int targetId, params JsValue[] parameters) {
				ReadMessage(new InvokeDelegateMessage {
					TargetId = targetId,
					Parameters = parameters
				});
			}

			public void ReturnMessage(JsValue value) { SendMessage(new ReturnMessage {Value = value}); }

			public void ReturnMessage() { ReturnMessage(new JsValue(JsValueType.Void, null)); }

			public JsFunction DefineFunctionMessage(MethodBase method) {
				JsFunction function = new JsFunction(method);
				DefineFunctionMessage msgDef = new DefineFunctionMessage {
					Name = function.Name,
					Parameters = function.Parameters,
					Body = function.Body
				};
				SendMessage(msgDef);
				return function;
			}

			public void InvokeFunctionMessage(string name, int scope, params JsValue[] parameters) {
				var msg = new InvokeFunctionMessage {
					Name = name,
					ScopeId = scope,
					Parameters = parameters
				};
				SendMessage(msg);
			}

			public void InvokeDelegateMessage(int targetId, params JsValue[] parameters) {
				SendMessage(new InvokeDelegateMessage {
					TargetId = targetId,
					Parameters = parameters
				});
			}

			public void GetTypeResponseMessage(object target) {
				TypeInspector inspector = new TypeInspector(target);
				SendMessage(inspector.GetTypeInfo());
			}

			private void ReadMessage(IMessage msg) { Expect.Call(session.ReceiveMessage()).Return(msg); }

			private void SendMessage(IMessage msg) { Expect.Call(() => session.SendMessage(msg)); }
		}

		[Test]
		public void TestDelegateWrapper() {
			//			var ctor = NativeObject.Constructor;
			//			NativeObject.TakeObject(ctor);

			int remoteId = 0;
			CachingObjectFactory factory = new CachingObjectFactory();
			TestHelper(factory, delegate(SessionHelper session) {
				Type nativeType = typeof (NativeObject);
				session.OnLoadMessage(typeof (DelegateWrapperTest));

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
				Type nativeType = typeof (NativeObject);
				session.OnLoadMessage(typeof (EventHandlerTest));

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
				session.OnInvokeDelegateMessage(1);

				// nativeObject.Alert();
				var alert = session.DefineFunctionMessage(nativeType.GetMethod("Alert"));
				session.InvokeFunctionMessage(alert.Name, 1, new JsValue(EventHandlerTest.AlertArg));
				session.OnReturnMessage(false, JsValueType.Void, null);

				// return from event handler
				session.ReturnMessage();

				session.OnQuitMessage();
			});

			EventHandlerTest test = (EventHandlerTest) factory.Get(typeof (EventHandlerTest));
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
				Type nativeType = typeof (NativeObject);
				session.OnLoadMessage(typeof (NativeCallbackTest));

				// new Nativeobject();
				var ctor = session.DefineFunctionMessage(nativeType.GetConstructor(Type.EmptyTypes));
				session.InvokeFunctionMessage(ctor.Name, 0);
				// return the scopeId for the newly created native object
				var nativeObjectId = ++remoteId;
				session.OnReturnMessage(false, JsValueType.JsObject, nativeObjectId);

				//var caller = new NativeCaller(cfg);
				Type nativeCallerType = typeof (NativeCaller);
				var ctor2 = session.DefineFunctionMessage(nativeCallerType.GetConstructor(new Type[] {typeof (object)}));
				var cfgId = ++localId;
				session.InvokeFunctionMessage(ctor2.Name, 0, new JsValue(JsValueType.Object, cfgId));

				// the ctor for NativeCaller() will grab the nativeObject from the cfg passed in
				session.OnGetTypeRequestMessage(cfgId);

				var cfg = new Config();
				TypeInspector inspector = new TypeInspector(cfg);
				session.GetTypeResponseMessage(cfg);

				int memberId = inspector.GetMemberId("nativeObject");
				session.OnInvokeMemberMessage(cfgId, memberId, DispatchType.PropertyGet);

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
			TestHelper(new ActivatorFactory(), delegate(SessionHelper session) {
				Type nativeType = typeof (NativeObject);
				session.OnLoadMessage(typeof (ObjectWrapperTest));

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
			TestHelper(new ActivatorFactory(), delegate(SessionHelper session) {
				session.OnLoadMessage(typeof (SanityTest));
				session.ReturnMessage();
				session.OnQuitMessage();
			});
		}
	}
}