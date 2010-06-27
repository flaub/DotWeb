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
using System.Reflection;
using DotWeb.Hosting.Bridge;
using Rhino.Mocks;

namespace DotWeb.Hosting.Test
{
	internal class SessionHelper
	{
		private readonly ISession session;

		public JsBridge Bridge { get; private set; }

		public SessionHelper(JsBridge bridge, ISession session) {
			this.Bridge = bridge;
			this.session = session;
		}

		public void OnLoadMessage(Type type) {
			var asmName = type.Assembly.FullName.Split(',')[0].TrimEnd();
			var typeSpec = string.Format("{0}, {1}, {2}", type.FullName, asmName, AppDomain.CurrentDomain.BaseDirectory);
			ReadMessage(new LoadMessage {
				TypeName = typeSpec
			});
		}

		public void OnReturnMessage(bool isException, JsValueType tag, object value) {
			ReadMessage(new ReturnMessage {
				IsException = isException,
				Value = new JsValue(tag, value)
			});
		}

		public void OnQuitMessage() { ReadMessage(new QuitMessage()); }

		public void OnInvokeMemberMessage(int targetId, DispatchIdentifier dispId, DispatchType dispatchType,
			params JsValue[] parameters) {
			ReadMessage(new InvokeMemberMessage {
				TargetId = targetId,
				//MemberId = memberId,
				DispatchId = dispId,
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

		public void ReturnMessage(JsValue value) { SendMessage(new ReturnMessage { Value = value }); }

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

		public void GetTypeResponseMessage(JsBridge bridge, object target) {
			TypeInspector inspector = new TypeInspector(bridge, target);
			SendMessage(inspector.GetTypeInfo());
		}

		private void ReadMessage(IMessage msg) { Expect.Call(session.ReceiveMessage()).Return(msg); }

		private void SendMessage(IMessage msg) { Expect.Call(() => session.SendMessage(msg)); }
	}
}