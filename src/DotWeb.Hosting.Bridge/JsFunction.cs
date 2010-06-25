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
using System.Linq;
using System.Reflection;
using DotWeb.Utility;
using System.Collections.Generic;

namespace DotWeb.Hosting.Bridge
{
	public class JsFunction
	{
		public string Name { get; set; }
		public string Parameters { get; set; }
		public string Body { get; set; }

		public JsFunction(MethodBase method) {
			var jsMacro = method.GetCustomAttribute<JsMacroAttribute>();
			if (jsMacro != null) {
				this.Body = GenerateInlineBody(method, jsMacro.Code);
			}
			else {
				var js = method.GetCustomAttribute<JsCodeAttribute>();
				this.Body = js == null ? GenerateFunctionBody(method) : js.Code;
			}

			Type type = method.DeclaringType;
			string typeName = type.FullName.Replace(".", "_").Replace("+", "$");
			this.Name = string.Format("__{0}${1}", typeName, method.Name.Replace(".", "$"));
			var members = type.GetMember(method.Name);
			if (members.Length > 1) {
				this.Name += string.Format("${0}", IndexOfMember(members, method));
			}
			this.Parameters = GetArgsString(method);
		}

		private int IndexOfMember(MemberInfo[] members, MethodBase method) {
			for (int i = 0; i < members.Length; i++) {
				var item = members[i];
				if (item == method)
					return i;
			}
			return -1;
		}

		private string GetTarget(MethodBase method) {
			return method.IsStatic ? GetTypeName(method) : "this";
		}

		private string GetTypeName(MethodBase method) {
			Type type = method.DeclaringType;
			var ns = type.GetCustomAttribute<JsNamespaceAttribute>();
			string target;
			if (ns != null) {
				if (string.IsNullOrEmpty(ns.Namespace)) {
					target = type.Name;
				}
				else {
					target = string.Format("{0}.{1}", ns.Namespace, type.Name);
				}
			}
			else {
				target = type.FullName;
			}
			return target;
		}

		private string GetArgsString(MethodBase method) {
			ParameterInfo[] parameters = method.GetParameters();
			string[] argNames = parameters.Select(x => x.Name).ToArray();
			string args = string.Join(", ", argNames);
			return args;
		}

		private string CallGetter(PropertyInfo property, MethodBase method) {
			ParameterInfo[] args = method.GetParameters();
			string target = GetTarget(method);
			if (args.Length == 1) {
				return string.Format("return {0}[{1}];", target, args.First().Name);
			}
			else if (args.Length == 0) {
				return string.Format("return {0}.{1};", target, GetMemberName(property));
			}
			throw new NotSupportedException();
		}

		private string CallSetter(PropertyInfo property, MethodBase method) {
			ParameterInfo[] args = method.GetParameters();
			string target = GetTarget(method);
			if (args.Length == 2) {
				return string.Format("{0}[{1}] = value;", target, args.First().Name);
			}
			else if (args.Length == 1) {
				return string.Format("{0}.{1} = value;", target, GetMemberName(property));
			}
			throw new NotSupportedException();
		}

		private string CallConstructor(MethodBase method) {
			string target = GetTypeName(method);
			string args = GetArgsString(method);
			return string.Format("return new {0}({1});", target, args);
		}

		private string GetMemberName(MemberInfo member) {
			string name = member.Name;
			if (member.IsDefined(typeof(JsCamelCaseAttribute), false) ||
				member.DeclaringType.IsDefined(typeof(JsCamelCaseAttribute), false)) {
				char[] chars = name.ToCharArray();
				chars[0] = Char.ToLower(chars[0]);
				name = new string(chars);
			}
			return name;
		}

		private string CallMethod(MethodBase method) {
			string name = GetMemberName(method);
			string target = GetTarget(method);
			string args = GetArgsString(method);
			return string.Format("return {0}.{1}({2});", target, name, args);
		}

		private string GenerateFunctionBody(MethodBase method) {
			var property = method.GetReflectedAssociatedProperty();
			if (property != null) {
				if (property.IsGetter) {
					return CallGetter(property.Info, method);
				}
				else {
					return CallSetter(property.Info, method);
				}
			}

			if (method is ConstructorInfo) {
				return CallConstructor(method);
			}
			return CallMethod(method);
		}

		private string GenerateInlineBody(MethodBase method, string format) {
			var args = new List<string>();
			args.Add("this");
			args.AddRange(method.GetParameters().Select(x => x.Name));
			return "return " + string.Format(format, args.ToArray()) + ";";
		}
	}
}
