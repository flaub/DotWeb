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
