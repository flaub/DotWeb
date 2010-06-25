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

		public static bool IsCamelCase(MemberReference memberRef) {
			var provider = GetProvider(memberRef);
			if (provider == null)
				return false;
			var ret = GetBooleanFromAttribute(provider, JsCamelCase);
			if (ret.HasValue)
				return ret.Value;
			return GetBooleanFromAttribute(memberRef.DeclaringType.Resolve(), JsCamelCase) ?? false;
		}

		public static bool IsAnonymous(TypeReference type) {
			return IsDefined(type.Resolve(), JsAnonymous);
		}

		public static bool IsJsObject(TypeReference typeRef) {
			while (typeRef != null) {
				var typeDef = typeRef.Resolve();
				if (IsDefined(typeDef, JsObject))
					return true;
				typeRef = typeDef.BaseType;
			}
			return false;
		}

		public static bool IsIntrinsic(PropertyDefinition propertyDef) {
			return
				IsDefined(propertyDef, JsInstrinsic) ||
				IsDefined(propertyDef.DeclaringType.Resolve(), JsInstrinsic);
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
				return provider.CustomAttributes.SingleOrDefault(x => x.AttributeType.FullName == typeName);
			}
			return null;
		}

		private static bool IsDefined(ICustomAttributeProvider provider, string typeName) {
			if (provider.HasCustomAttributes) {
				return provider.CustomAttributes.Any(x => x.AttributeType.FullName == typeName);
			}
			return false;
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

		private const string JsNamespace = "System.JsNamespaceAttribute";
		private const string JsCode = "System.JsCodeAttribute";
		private const string JsMacro = "System.JsMacroAttribute";
		private const string JsInstrinsic = "System.JsIntrinsicAttribute";
		private const string JsCamelCase = "System.JsCamelCaseAttribute";
		private const string JsAnonymous = "System.JsAnonymousAttribute";
		private const string JsAugment = "System.JsAugmentAttribute";
		private const string JsObject = "System.JsObjectAttribute";
		private const string JsName = "System.JsNameAttribute";
	}
}
