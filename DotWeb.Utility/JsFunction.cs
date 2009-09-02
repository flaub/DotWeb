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
using DotWeb.Client;
using System.Reflection;

namespace DotWeb.Utility
{
	public class JsFunction
	{
		public string Name { get; set; }
		public string Parameters { get; set; }
		public string Body { get; set; }
		public int FunctionId { get; set; }

		public JsFunction(MethodBase method) {
			JsCodeAttribute js = method.GetCustomAttribute<JsCodeAttribute>();
			if (js == null) {
				this.Body = GenerateFunctionBody(method);
			}
			else {
				this.Body = js.Code;
			}

			string type = method.DeclaringType.FullName.Replace(".", "_").Replace("+", "$");
			this.Name = string.Format("__{0}${1}", type, method.Name.Replace(".", "$"));
			this.Parameters = GetArgsString(method);
		}

		private string GetTarget(MethodBase method) {
			if (method.IsStatic) {
				return GetTypeName(method);
			}
			else {
				return "this";
			}
		}

		private string GetTypeName(MethodBase method) {
			Type type = method.DeclaringType;
			JsNamespaceAttribute ns = type.GetCustomAttribute<JsNamespaceAttribute>();
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

		private string CallGetter(MethodBase method) {
			ParameterInfo[] args = method.GetParameters();
			if (args.Length == 0) {
				string propName = method.Name.Substring("get_".Length);
				string target = GetTarget(method);
				return string.Format("return {0}.{1};", target, propName);
			}
			else {
				throw new NotSupportedException();
			}
		}

		private string CallSetter(MethodBase method) {
			ParameterInfo[] args = method.GetParameters();
			if (args.Length == 1) {
				string propName = method.Name.Substring("set_".Length);
				string target = GetTarget(method);
				return string.Format("{0}.{1} = value;", target, propName);
			}
			else {
				throw new NotSupportedException();
			}
		}

		private string CallConstructor(MethodBase method) {
			string target = GetTypeName(method);
			string args = GetArgsString(method);
			return string.Format("return new {0}({1});", target, args);
		}

		private string CallMethod(MethodBase method) {
			string name = method.Name;
			string target = GetTarget(method);
			string args = GetArgsString(method);
			return string.Format("return {0}.{1}({2});", target, name, args);
		}

		private string GenerateFunctionBody(MethodBase method) {
			if (method.IsSpecialName) {
				if (method.Name.StartsWith("get_")) {
					return CallGetter(method);
				}
				else if (method.Name.StartsWith("set_")) {
					return CallSetter(method);
				}
			}

			if (method is ConstructorInfo) {
				return CallConstructor(method);
			}
			else {
				return CallMethod(method);
			}
		}

	}
}
