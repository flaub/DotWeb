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
using DotWeb.Utility.Cecil;

namespace DotWeb.Translator
{
	static class CodeModelExtensions
	{
		public static bool HasBase(this TypeDefinition type) {
			if (TypeHelper.IsEquivalent(type.BaseType, typeof(object)) ||
				TypeHelper.IsEquivalent(type.BaseType, TypeHelper.Names.JsObject))
				return false;
			return true;
		}

		public static bool IsFieldLike(this CodePropertyReference cpr) {
			return
				AttributeHelper.IsIntrinsic(cpr.Property) ||
				AttributeHelper.IsAnonymous(cpr.Property.DeclaringType) ||
				TypeHelper.IsSubclassOf(cpr.Property.DeclaringType, TypeHelper.Names.JsObject)
			;
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

		private static string GetAutomaticBackingFieldName(PropertyDefinition property) {
			return string.Format("<{0}>k__BackingField", property.Name);
		}
	}
}
