using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Hosting.Bridge
{
	class JsArrayWrapper : IJsAccessible
	{
		JsBridge bridge;
		Array target;
		Type elementType;

		public JsArrayWrapper(JsBridge bridge, Array target) {
			this.bridge = bridge;
			this.target = target;
			this.elementType = target.GetType().GetElementType();
		}

		public object Invoke(int id, DispatchType dispType, JsValue[] args) {
			if (id == this.target.Length) {
				if (dispType == DispatchType.PropertyGet) {
					return this.target.Length;
				}
				else {
					throw new NotSupportedException();
				}
			}

			if (id >= 0 && id < this.target.Length) {
				if (dispType == DispatchType.PropertyGet) {
					return this.target.GetValue(id);
				}
				else if (dispType == DispatchType.PropertySet) {
					object value = this.bridge.UnwrapValue(args.First(), this.elementType);
					this.target.SetValue(value, id);
					return null;
				}
			}

			throw new NotSupportedException();
		}

		public GetTypeResponseMessage GetTypeInfo() {
			GetTypeResponseMessage msg = new GetTypeResponseMessage {
				IndexerLength = this.target.Length,
				Members = new List<TypeMemberInfo>()
			};

			TypeMemberInfo tmi = new TypeMemberInfo {
				Name = "length",
				MemberId = this.target.Length,
				DispatchType = DispatchType.PropertyGet
			};
			msg.Members.Add(tmi);
			return msg;
		}
	}
}
