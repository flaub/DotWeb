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
using System.Reflection;
using System.Diagnostics;
using DotWeb.Client;

namespace DotWeb.Hosting.Bridge
{
	class JsObjectWrapper : JsWrapperBase, IJsWrapper
	{
		private readonly object target;
		private readonly TypeInspector inspector;

		public JsObjectWrapper(JsBridge bridge, object target) : base(bridge) {
			this.target = target;
			this.inspector = new TypeInspector(bridge, target);
		}

		public MemberInfo GetMember(int id) {
			return this.inspector.GetMember(id);
		}

		public MemberInfo GetMember(string name) {
			//return this.inspector.GetMember(id);
			if (name == "ToString")
				return null;

			if (name == "toString")
				name = "ToString";

			return this.target.GetType().GetMember(name).SingleOrDefault();
		}

		public object Invoke(DispatchIdentifier id, DispatchType dispType, JsValue[] jsArgs, out Type returnType) {
			MemberInfo member = GetMember(id.AsString);
			if (member == null) {
				returnType = typeof(void);
				return null;
			}

			Debug.WriteLine(string.Format("{0}, {1}.{2}", dispType, this.target, member.Name));
			if (member is MethodInfo && dispType == DispatchType.PropertyGet) {
				var method = (MethodInfo)member;
				return GetMethodAsProperty((MethodInfo)member, this.target, out returnType);
			}

			var args = this.bridge.UnwrapParameters(jsArgs, dispType, member);
			if (dispType.IsMethod()) {
				var method = (MethodBase)member;
				returnType = method.IsConstructor ? method.DeclaringType : ((MethodInfo)method).ReturnType;
				return method.Invoke(this.target, args);
			}

			if (dispType.IsPropertyGet()) {
				var pi = (PropertyInfo)member;
				returnType = pi.PropertyType;
				return pi.GetValue(this.target, null);
			}

			if (dispType.IsPropertyPut()) {
				var pi = (PropertyInfo)member;
				pi.SetValue(this.target, args.First(), null);
				returnType = typeof(void);
				return null;
			}
			throw new NotSupportedException();
		}

		public GetTypeResponseMessage GetTypeInfo() {
			return this.inspector.GetTypeInfo();
		}
	}
}
