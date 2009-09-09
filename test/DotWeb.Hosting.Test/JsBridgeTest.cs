using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DotWeb.Hosting.Bridge;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace DotWeb.Hosting.Test
{
	class Script
	{
	}

	[TestFixture]
	public class JsBridgeTest
	{
		[Test]
		public void TestBridge() {
			MockRepository mocks = new MockRepository();

			ISession session = mocks.StrictMock<ISession>();
			using (mocks.Ordered()) {
				ReadMessage(session, new LoadMessage {
					TypeName = typeof(Script).AssemblyQualifiedName
				});

				JsValue value = new JsValue(JsValueType.Void, null);
				ReturnMessage retMsg = new ReturnMessage { Value = value };

				SendMessage(session, retMsg);
			}
			mocks.ReplayAll();

			JsBridge bridge = new JsBridge(session);
			bridge.DispatchForever();

			mocks.VerifyAll();
		}

		private void ReadMessage(ISession session, IMessage msg) {
			Expect.Call(session.ReadMessage()).Return(msg);
		}

		private void SendMessage(ISession session, IMessage msg) {
			Expect.Call(() => session.SendMessage(msg));
		}
	}
}
