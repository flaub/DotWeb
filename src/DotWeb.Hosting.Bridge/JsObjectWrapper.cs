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
using DotWeb.Client;
using System.Diagnostics;
using System.Reflection.Emit;

namespace DotWeb.Hosting.Bridge
{
	class JsObjectWrapper : IJsAccessible
	{
		JsBridge bridge;
		object target;
		Type targetType;
		MemberInfo[] members;
		Dictionary<string, int> idsByName = new Dictionary<string, int>();

		public JsObjectWrapper(JsBridge bridge, object target) {
			this.bridge = bridge;
			this.target = target;
			this.targetType = target.GetType();

			CollectMembers();
		}

		private void CollectMembers() {
			List<MemberInfo> infos = new List<MemberInfo>();
			foreach (MemberInfo info in this.targetType.GetMembers()) {
				if (info.DeclaringType == typeof(object) && info.Name != "ToString") {
					continue;
				}

				if (info is MethodInfo) {
					MethodInfo mi = (MethodInfo)info;
					if (mi.IsSpecialName && mi.Name.StartsWith("get_") || mi.Name.StartsWith("set_"))
						continue;
				}
				if (info is ConstructorInfo || info is FieldInfo) {
					continue;
				}

//				if (info.Name == "ToString") {
//					this.idsByName.Add("toString", infos.Count);
//				}
				this.idsByName.Add(info.Name, infos.Count);
				infos.Add(info);
			}
			this.members = infos.ToArray();
		}

		public MemberInfo GetMember(int id) {
			return this.members[id];
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
			List<Type> genericTypes = new List<Type>();
			genericTypes.Add(method.ReturnType);
			genericTypes.AddRange(paramaterInfos.Select(x => x.ParameterType));
			Type baked = type.MakeGenericType(genericTypes.ToArray());
			return baked;
		}

		public object Invoke(int id, DispatchType dispType, JsValue[] jsArgs) {
			MemberInfo member = GetMember(id);
			Debug.WriteLine(string.Format("Invoke: {0}, {1} on {2}", dispType, member, this.target));
			if (member is MethodInfo && dispType == DispatchType.PropertyGet) {
				MethodInfo mi = member as MethodInfo;
				Type delType = CreateTypeForMethod(mi);
				Delegate del = Delegate.CreateDelegate(delType, this.target, mi);
				return del;
			}

			object[] args = this.bridge.UnwrapParameters(jsArgs, dispType, member);
			if (dispType.IsMethod()) {
				MethodBase method = member as MethodBase;
				return method.Invoke(this.target, args);
			}
			else if (dispType.IsPropertyGet()) {
				PropertyInfo pi = member as PropertyInfo;
				return pi.GetValue(this.target, null);
			}
			else if (dispType.IsPropertyPut()) {
				PropertyInfo pi = member as PropertyInfo;
				pi.SetValue(this.target, args.First(), null);
			}
			return null;
		}

		public GetTypeResponseMessage GetTypeInfo() {
			GetTypeResponseMessage msg = new GetTypeResponseMessage {
				IndexerLength = 0,
				Members = new List<TypeMemberInfo>()
			};

			foreach (KeyValuePair<string, int> item in this.idsByName) {
				MemberInfo mi = GetMember(item.Value);

				DispatchType dt;
				if (mi is MethodInfo) {
					dt = DispatchType.Method;
				}
				else if (mi is PropertyInfo) {
					dt = DispatchType.PropertyGet | DispatchType.PropertySet;
				}
				else {
					throw new InvalidOperationException();
				}

				TypeMemberInfo tmi = new TypeMemberInfo {
					Name = item.Key,
					MemberId = item.Value,
					DispatchType = dt
				};
				msg.Members.Add(tmi);
			}

			return msg;
		}
	}
}
