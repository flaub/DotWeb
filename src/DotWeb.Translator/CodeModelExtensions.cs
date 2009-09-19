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

namespace DotWeb.Translator
{
	static class CodeModelExtensions
	{
		public static bool HasBase(this Type type) {
			if (type.BaseType == typeof(object) ||
				type.BaseType == typeof(JsNativeBase)) {
				return false;
			}
			return true;
		}

		public static bool IsFieldLike(this CodePropertyReference cpr) {
			return
				cpr.Property.IsIntrinsic() ||
				cpr.Property.DeclaringType.IsAnonymous() ||
				cpr.Property.DeclaringType.IsSubclassOf(typeof(JsNativeBase));
		}

		private static bool IsAutoImplemented(CodeFieldReference field, PropertyInfo property) {
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
					if(IsAutoImplemented(field, cpm.PropertyInfo))
						return true;
				}
				var assign = first as CodeAssignStatement;
				if (assign != null) {
					var field = assign.Right as CodeFieldReference;
					if (IsAutoImplemented(field, cpm.PropertyInfo))
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
					if (IsAutoImplemented(field, cpm.PropertyInfo))
						return true;
				}
			}
			return false;
		}

		public static bool HasJsCode(this MethodBase method) {
			return method.IsDefined(typeof(JsCodeAttribute), false);
		}

		public static bool HasJsInlineCode(this MethodBase method) {
			return method.IsDefined(typeof(JsInlineCodeAttribute), false);
		}

		public static bool IsAnonymous(this Type type) {
			return type.IsDefined(typeof(JsAnonymousAttribute), false);
		}

		public static bool IsIntrinsic(this PropertyInfo pi) {
			return pi.IsDefined(typeof(JsIntrinsicAttribute), false);
		}

		private static string GetAutomaticBackingFieldName(PropertyInfo property) {
			return string.Format("<{0}>k__BackingField", property.Name);
		}
	}
}
