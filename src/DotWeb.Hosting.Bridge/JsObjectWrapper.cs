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

namespace DotWeb.Hosting.Bridge
{
	class JsObjectWrapper : IJsWrapper
	{
		private readonly JsBridge bridge;
		private readonly object target;
		private readonly TypeInspector inspector;

		public JsObjectWrapper(JsBridge bridge, object target) {
			this.bridge = bridge;
			this.target = target;
			this.inspector = new TypeInspector(target);
		}

		public MemberInfo GetMember(int id) {
			return this.inspector.GetMember(id);
		}

		delegate R GenericDelegate<R>();
		delegate R GenericDelegate<R, T1>(T1 arg1);
		delegate R GenericDelegate<R, T1, T2>(T1 arg1, T2 arg2);
		delegate R GenericDelegate<R, T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
		delegate R GenericDelegate<R, T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

		private Type CreateTypeForMethod(MethodInfo method) {
			ParameterInfo[] paramaterInfos = method.GetParameters();
			string name = string.Format("GenericDelegate`{0}", paramaterInfos.Length + 1);
			Type type = this.GetType().GetNestedType(name, BindingFlags.NonPublic);
			var genericTypes = new List<Type>();
			genericTypes.Add(method.ReturnType);
			genericTypes.AddRange(paramaterInfos.Select(x => x.ParameterType));
			Type baked = type.MakeGenericType(genericTypes.ToArray());
			return baked;
		}

		public object Invoke(int id, DispatchType dispType, JsValue[] jsArgs, out Type returnType) {
			MemberInfo member = GetMember(id);
			Debug.WriteLine(string.Format("{0}, {1}.{2}", dispType, this.target, member.Name));
			if (member is MethodInfo && dispType == DispatchType.PropertyGet) {
				var method = (MethodInfo)member;
				Type delType = CreateTypeForMethod(method);
				Delegate del = Delegate.CreateDelegate(delType, this.target, method);
				returnType = delType;
				return del;
			}

			object[] args = this.bridge.UnwrapParameters(jsArgs, dispType, member);
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
				returnType = typeof(void);
				pi.SetValue(this.target, args.First(), null);
			}
			throw new NotSupportedException();
		}

		public GetTypeResponseMessage GetTypeInfo() {
			return this.inspector.GetTypeInfo();
		}
	}
}
