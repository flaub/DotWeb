﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DotWeb.Hosting.Bridge;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using DotWeb.Client;
using System.Reflection;
using DotWeb.Client.Dom;
using DotWeb.Hosting.Test.Bridge;

namespace DotWeb.Hosting.Test
{
	namespace Bridge
	{
		class NativeObject : JsNativeBase
		{
			public NativeObject() { C_(); }

			public void Alert(string msg) { _(msg); }

			[JsIntrinsic]
			public GenericEventHandler onmouseover { get { return _<GenericEventHandler>(); } set { _(value); } }

			public void NativeCall() { _(); }
		}

		[JsNamespace]
		class NativeCaller : JsNativeBase
		{
			public NativeCaller(object cfg) { C_(cfg); }

			public void Start() { _(); }
		}

		[JsAnonymous]
		class Config
		{
			public NativeObject nativeObject { get; set; }
		}

		class SanityTest
		{
		}

		class ObjectWrapperTest
		{
			public const string AlertArg = "ObjectWrapperTest";

			public ObjectWrapperTest() {
				var native = new NativeObject();
				native.Alert(AlertArg);
			}
		}

		class EventHandlerTest
		{
			public const string AlertArg = "EventHandlerTest";

			public EventHandlerTest() {
				this.HasFired = false;
				this.native = new NativeObject();
				this.native.onmouseover = native_OnMouseOver;
			}

			public void native_OnMouseOver() {
				this.HasFired = true;
				this.native.Alert(AlertArg);
			}

			public bool HasFired { get; private set; }

			NativeObject native;
		}

		class NativeCallbackTest
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
	}

	[TestFixture]
	public class JsBridgeTest
	{
		[Test]
		public void TestSanity() {
			TestHelper(new ActivatorFactory(), delegate(SessionHelper session) {
				session.OnLoadMessage(typeof(SanityTest));
				session.ReturnMessage();
				session.OnQuitMessage();
			});
		}

		[Test]
		public void TestObjectWrapper() {
			TestHelper(new ActivatorFactory(), delegate(SessionHelper session) {
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
				session.OnInvokeDelegateMessage(1);

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
				TypeInspector inspector = session.GetTypeResponseMessage(typeof(Config));

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

		delegate void SessionHandler(SessionHelper session);

		private void TestHelper(IObjectFactory factory, SessionHandler handler) {
			MockRepository mocks = new MockRepository();

			ISession session = mocks.StrictMock<ISession>();
			SessionHelper helper = new SessionHelper(session);
			using (mocks.Ordered()) {
				handler(helper);
			}
			mocks.ReplayAll();

			JsBridge bridge = new JsBridge(session, factory);
			JsHost.Instance = bridge;
			bridge.DispatchForever();

			mocks.VerifyAll();
		}

		class CachingObjectFactory : IObjectFactory
		{
			private Dictionary<Type, object> cache = new Dictionary<Type, object>();

			public object CreateInstance(Type type) {
				object ret = Activator.CreateInstance(type);
				this.cache.Add(ret.GetType(), ret);
				return ret;
			}

			public object Get(Type type) {
				return this.cache[type];
			}
		}

		class SessionHelper
		{
			public SessionHelper(ISession session) {
				this.session = session;
			}

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

			public void OnQuitMessage() {
				ReadMessage(new QuitMessage());
			}

			public void OnInvokeMemberMessage(int targetId, int memberId, DispatchType dispatchType, params JsValue[] parameters) {
				ReadMessage(new InvokeMemberMessage {
					TargetId = targetId,
					MemberId = memberId,
					DispatchType = dispatchType,
					Parameters = parameters
				});
			}

			public void OnInvokeMemberMessage(int targetId, int memberId, DispatchType dispatchType) {
				ReadMessage(new InvokeMemberMessage {
					TargetId = targetId,
					MemberId = memberId,
					DispatchType = dispatchType,
					Parameters = EmptyArgs
				});
			}

			public void OnGetTypeRequestMessage(int targetId) {
				ReadMessage(new GetTypeRequestMessage {
					TargetId = targetId
				});
			}

			public void OnInvokeDelegateMessage(int targetId) {
				ReadMessage(new InvokeDelegateMessage {
					TargetId = targetId,
					Parameters = EmptyArgs
				});
			}

			public void OnInvokeDelegateMessage(int targetId, params JsValue[] parameters) {
				ReadMessage(new InvokeDelegateMessage {
					TargetId = targetId,
					Parameters = parameters
				});
			}

			public void ReturnMessage(JsValue value) {
				SendMessage(new ReturnMessage { Value = value });
			}

			public void ReturnMessage() {
				ReturnMessage(new JsValue(JsValueType.Void, null));
			}

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

			public void InvokeFunctionMessage(string name, int scope) {
				var msg = new InvokeFunctionMessage {
					Name = name,
					ScopeId = scope,
					Parameters = EmptyArgs
				};
				SendMessage(msg);
			}

			public void InvokeFunctionMessage(string name, int scope, params JsValue[] parameters) {
				var msg = new InvokeFunctionMessage {
					Name = name,
					ScopeId = scope,
					Parameters = parameters
				};
				SendMessage(msg);
			}

			public TypeInspector GetTypeResponseMessage(Type type) {
				TypeInspector inspector = new TypeInspector(type);
				SendMessage(inspector.GetTypeInfo());
				return inspector;
			}

			private void ReadMessage(IMessage msg) {
				Expect.Call(session.ReadMessage()).Return(msg);
			}

			private void SendMessage(IMessage msg) {
				Expect.Call(() => session.SendMessage(msg));
			}

			private ISession session;
			private static readonly JsValue[] EmptyArgs = new JsValue[0];
		}
	}
}
