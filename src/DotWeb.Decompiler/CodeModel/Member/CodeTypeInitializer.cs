// Copyright 2010, Frank Laub
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
using DotWeb.Decompiler.Core;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace DotWeb.Decompiler.CodeModel
{
	public class CodeTypeInitializer : CodeMethodMember
	{
		public CodeTypeInitializer(CodeMethodMember method) {
			this.Definition = method.Definition;
			this.Statements = method.Statements;
			this.Parameters = method.Parameters;
			this.ExternalMethods = method.ExternalMethods;
			this.NativeCode = method.NativeCode;
			this.DefaultStaticFields = new List<FieldDefinition>();
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeTypeInitializer>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeTypeInitializer, R>)visitor).VisitReturn(this);
		}
		#endregion

		public List<FieldDefinition> DefaultStaticFields { get; set; }
	}
}
