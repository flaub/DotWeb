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
using System.Linq;
using System.Text;
using Mono.Cecil;
using DotWeb.Utility.Cecil;

namespace DotWeb.Translator
{
	public static class AttributeHelper
	{
		public static string GetJsCode(MethodDefinition method) {
			return GetStringFromAttribute(method, JsCode);
		}

		public static string GetJsMacro(MethodDefinition method) {
			return GetStringFromAttribute(method, JsMacro);
		}

		public static string GetJsNamespace(TypeReference typeRef) {
			return GetStringFromAttribute(typeRef, JsNamespace);
		}

		public static string GetJsAugment(TypeReference typeRef) {
			return GetStringFromAttribute(typeRef, JsAugment);
		}

		public static string GetJsName(MemberReference memberRef) {
			var provider = GetProvider(memberRef);
			if (provider == null)
				return null;
			return GetStringFromAttribute(provider, JsName);
		}

		public static bool IsCamelCase(MemberReference memberRef, TypeSystem typeSystem) {
			if (IsCamelCase((ICustomAttributeProvider)memberRef.DeclaringType, typeSystem))
				return true;
			var provider = GetProvider(memberRef);
			if (provider == null)
				return false;
			return IsCamelCase(provider, typeSystem);
		}

		public static bool IsAnonymous(TypeReference type, TypeSystem typeSystem) {
			var typeDef = typeSystem.GetTypeDefinition(JsAnonymous);
			return typeSystem.IsDefined(type.Resolve(), typeDef);
		}

		public static bool IsIntrinsic(PropertyReference propertyRef, TypeSystem typeSystem) {
			var typeDef = typeSystem.GetTypeDefinition(JsInstrinsic);
			return
				typeSystem.IsDefined(propertyRef.Resolve(), typeDef) ||
				typeSystem.IsDefined(propertyRef.DeclaringType.Resolve(), typeDef);
		}

		private static string GetStringFromAttribute(ICustomAttributeProvider provider, string attributeName) {
			var customAttr = FindByName(provider, attributeName);
			if (customAttr != null) {
				var args = customAttr.ConstructorParameters;
				if (args.Count == 1)
					return (string)args[0];
				return "";
			}
			return null;
		}

		private static bool IsCamelCase(ICustomAttributeProvider provider, TypeSystem typeSystem) {
			var customAttr = FindByName(provider, JsCamelCase);
			if (customAttr == null)
				return false;

			if (customAttr.ConstructorParameters.Count == 0)
				return true;

			var enabled = customAttr.Properties["Enabled"];
			return (bool)enabled;
		}

		private static CustomAttribute FindByName(ICustomAttributeProvider provider, string typeName) {
			if (provider.HasCustomAttributes) {
				foreach (CustomAttribute item in provider.CustomAttributes) {
					if (item.Constructor.DeclaringType.FullName == typeName)
						return item;
				}
			}
			return null;
		}

		private static ICustomAttributeProvider GetProvider(MemberReference memberRef) {
			var fieldRef = memberRef as FieldReference;
			if (fieldRef != null) {
				return fieldRef.Resolve();
			}
			var methodRef = memberRef as MethodReference;
			if (methodRef != null) {
				return methodRef.Resolve();
			}
			var propertyRef = memberRef as PropertyReference;
			if (propertyRef != null) {
				return propertyRef.Resolve();
			}
			return null;
		}

		private const string JsNamespace = "System.DotWeb.JsNamespaceAttribute";
		private const string JsCode = "System.DotWeb.JsCodeAttribute";
		private const string JsMacro = "System.DotWeb.JsMacroAttribute";
		private const string JsInstrinsic = "System.DotWeb.JsIntrinsicAttribute";
		private const string JsCamelCase = "System.DotWeb.JsCamelCaseAttribute";
		private const string JsAnonymous = "System.DotWeb.JsAnonymousAttribute";
		private const string JsAugment = "System.DotWeb.JsAugmentAttribute";
		private const string JsName = "System.DotWeb.JsNameAttribute";
	}
}
