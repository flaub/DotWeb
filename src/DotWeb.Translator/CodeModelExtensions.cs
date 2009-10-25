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
using DotWeb.Client;
using DotWeb.Decompiler.CodeModel;
using System.Reflection;
using Mono.Cecil;
using System.Diagnostics;

namespace DotWeb.Translator
{
	public static class TypeOf
	{
		public static TypeDefinition Convert(Type type) {
			return null;
		}
	}

	static class CodeModelExtensions
	{
		public static bool HasBase(this TypeDefinition type) {
			//if (type.BaseType == typeof(object) /* FIXME: ||
			//	type.BaseType == typeof(JsNativeBase)*/) {
			//	return false;
			//}
			//return true;
			return false;
		}

		public static bool IsFieldLike(this CodePropertyReference cpr) {
			Debug.Assert(false);
			return false;
			//return
			//    cpr.Property.IsIntrinsic() ||
			//    cpr.Property.DeclaringType.IsAnonymous() /* FIXME: ||
			//    cpr.Property.DeclaringType.IsSubclassOf(typeof(JsNativeBase))*/
			//;
		}

		private static bool IsAutoImplemented(CodeFieldReference field, PropertyDefinition property) {
			if (field != null && field.TargetObject is CodeThisReference) {
				if (field.Field.Name == GetAutomaticBackingFieldName(property))
					return true;
			}
			return false;
		}

		public static bool IsAutoImplemented(this CodePropertyGetterMember cpm) {
			if (cpm.Statements.Count >= 1) {
				var first = cpm.Statements.First();
				var ret = first as CodeReturnStatement;
				if (ret != null) {
					var field = ret.Expression as CodeFieldReference;
					if(IsAutoImplemented(field, cpm.Property))
						return true;
				}
				var assign = first as CodeAssignStatement;
				if (assign != null) {
					var field = assign.Right as CodeFieldReference;
					if (IsAutoImplemented(field, cpm.Property))
						return true;
				}
			}
			return false;
		}

		public static bool IsAutoImplemented(this CodePropertySetterMember cpm) {
			if (cpm.Statements.Count >= 1) {
				var first = cpm.Statements.First() as CodeAssignStatement;
				if (first != null) {
					var field = first.Left as CodeFieldReference;
					if (IsAutoImplemented(field, cpm.Property))
						return true;
				}
			}
			return false;
		}

		public static bool HasJsCode(this MethodDefinition method) {
//			FIXME: return method.IsDefined(typeof(JsCodeAttribute), false);
			return false;
		}

		public static bool IsAnonymous(this TypeReference type) {
			//FIXME: return type.IsDefined(typeof(JsAnonymousAttribute), false);
//			TypeReference typeRef = new TypeReference(name, ns, scope, valueType);
			return false;
		}

		public static bool IsSubclassOf(this TypeReference type, TypeReference other) {
			Debug.Assert(false);
			return false;
		}

		public static bool IsDefined(this TypeDefinition type, TypeReference attributeType) {
			foreach (CustomAttribute item in type.CustomAttributes) {
				if (item.Constructor.DeclaringType == attributeType)
					return true;
			}
			return false;
		}

		public static bool IsIntrinsic(this PropertyReference pi) {
			return false;
			// FIXME:
			//return
			//    pi.IsDefined(typeof(JsIntrinsicAttribute), false) ||
			//    pi.DeclaringType.IsDefined(typeof(JsIntrinsicAttribute), false);
		}

		private static string GetAutomaticBackingFieldName(PropertyDefinition property) {
			return string.Format("<{0}>k__BackingField", property.Name);
		}
	}
}
