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
			return GetStringFromAttribute(typeRef.Resolve(), JsNamespace);
		}

		public static string GetJsAugment(TypeReference typeRef) {
			return GetStringFromAttribute(typeRef.Resolve(), JsAugment);
		}

		public static string GetJsName(MemberReference memberRef) {
			var provider = GetProvider(memberRef);
			if (provider == null)
				return null;
			return GetStringFromAttribute(provider, JsName);
		}

		public static bool IsCamelCase(MemberReference memberRef, TypeSystem typeSystem) {
			var provider = GetProvider(memberRef);
			if (provider == null)
				return false;
			var ret = GetBooleanFromAttribute(provider, JsCamelCase);
			if (ret.HasValue)
				return ret.Value;
			return GetBooleanFromAttribute(memberRef.DeclaringType.Resolve(), JsCamelCase) ?? false;
		}

		public static bool IsAnonymous(TypeReference type, TypeSystem typeSystem) {
			var typeDef = typeSystem.GetTypeDefinition(JsAnonymous);
			return typeSystem.IsDefined(type.Resolve(), typeDef);
		}

		public static bool IsIntrinsic(PropertyDefinition propertyDef, TypeSystem typeSystem) {
			var typeDef = typeSystem.GetTypeDefinition(JsInstrinsic);
			return
				typeSystem.IsDefined(propertyDef, typeDef) ||
				typeSystem.IsDefined(propertyDef.DeclaringType.Resolve(), typeDef);
		}

		private static string GetStringFromAttribute(ICustomAttributeProvider provider, string attributeName) {
			var customAttr = FindByName(provider, attributeName);
			if (customAttr == null)
				return null;

			var args = customAttr.ConstructorArguments;
			if (args.Count == 1)
				return (string)args[0].Value;
			return "";
		}

		private static bool? GetBooleanFromAttribute(ICustomAttributeProvider provider, string attributeName) {
			var customAttr = FindByName(provider, attributeName);
			if (customAttr == null)
				return null;

			var args = customAttr.ConstructorArguments;
			if (args.Count == 1)
				return (bool)args[0].Value;
			return true;
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
			var propertyDef = memberRef as PropertyDefinition;
			if (propertyDef != null) {
				return propertyDef;
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
