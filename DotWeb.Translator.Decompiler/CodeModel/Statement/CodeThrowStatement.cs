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

namespace DotWeb.Translator.CodeModel
{
	public class CodeThrowStatement : CodeStatement
	{
		public CodeThrowStatement(CodeExpression expression) {
			this.Expression = expression;
		}
		
		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeThrowStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeThrowStatement, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression Expression { get; set; }
	}
}
