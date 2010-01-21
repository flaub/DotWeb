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
using System.Collections.Generic;
using System.Reflection;
using DotWeb.System.DotWeb;

namespace DotWeb.Hosting.Bridge
{
	public class TypeInspector
	{
		private Dictionary<string, int> idsByName = new Dictionary<string, int>();
		private List<MemberInfo> members = new List<MemberInfo>();
		private Type targetType;
		private JsBridge bridge;

		public TypeInspector(JsBridge bridge, object target) {
			this.bridge = bridge;
			this.targetType = target.GetType();

			//if (target is JsDynamic) {
			//    CollectDynamicMembers((JsDynamic)target);
			//}
			//else {
				CollectMembers();
			//}
		}

		public MemberInfo GetMember(int id) { return members[id]; }

		public int GetMemberId(string name) { return idsByName[name]; }

		public GetTypeResponseMessage GetTypeInfo() {
			GetTypeResponseMessage msg = new GetTypeResponseMessage {
				IndexerLength = 0,
				Members = new List<TypeMemberInfo>()
			};

			foreach (KeyValuePair<string, int> item in idsByName) {
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
					//MemberId = item.Value,
					DispatchType = dt
				};
				msg.Members.Add(tmi);
			}

			return msg;
		}

		private void CollectMembers() {
			foreach (MemberInfo info in targetType.GetMembers()) {
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

				string name = GetName(info.Name);
				idsByName.Add(name, members.Count);
				members.Add(info);
			}
		}

		//private void CollectDynamicMembers(object target) {
		//    var properties = this.bridge.GetDynamicPropertyMap(target);
		//    foreach (var item in properties) {
		//        var property = targetType.GetProperty(item.Key);
		//        string name = GetName(property.Name);
		//        idsByName.Add(name, members.Count);
		//        members.Add(property);
		//    }
		//}

		private string GetName(string name) {
			if (name.EndsWith("_")) {
				return name.Substring(0, name.Length - 1);
			}
			return name;
		}
	}
}