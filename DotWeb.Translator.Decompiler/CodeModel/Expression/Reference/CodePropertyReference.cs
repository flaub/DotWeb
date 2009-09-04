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

namespace DotWeb.Decompiler.CodeModel
{
	public class CodePropertyReference : CodeExpression
	{
		public enum RefType
		{
			Get,
			Set
		}

		public CodePropertyReference(CodeMethodReference method, PropertyInfo property, RefType rt) {
			this.Method = method;
			this.Property = property;
			this.ReferenceType = rt;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodePropertyReference>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodePropertyReference, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression TargetObject { get { return Method.TargetObject; } }
		public CodeMethodReference Method { get; set; }
		public PropertyInfo Property { get; set; }
		public RefType ReferenceType { get; set; }
	}
}
