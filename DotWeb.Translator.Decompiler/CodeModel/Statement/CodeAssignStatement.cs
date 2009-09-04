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
	// Summary:
	//     Represents a simple assignment statement.
	public class CodeAssignStatement : CodeStatement
	{
		// Summary:
		//     Initializes a new instance of the DotWeb.Translator.CodeModel.CodeAssignStatement class.
		public CodeAssignStatement() { }
	
		//
		// Summary:
		//     Initializes a new instance of the DotWeb.Translator.CodeModel.CodeAssignStatement class
		//     using the specified expressions.
		//
		// Parameters:
		//   left:
		//     The variable to assign to.
		//
		//   right:
		//     The value to assign.
		public CodeAssignStatement(CodeExpression left, CodeExpression right) {
			this.Left = left;
			this.Right = right;
		}

		// Summary:
		//     Gets or sets the expression representing the object or reference to assign
		//     to.
		//
		// Returns:
		//     A DotWeb.Translator.CodeModel.CodeExpression that indicates the object or reference to
		//     assign to.
		public CodeExpression Left { get; set; }

		//
		// Summary:
		//     Gets or sets the expression representing the object or reference to assign.
		//
		// Returns:
		//     A DotWeb.Translator.CodeModel.CodeExpression that indicates the object or reference to
		//     assign.
		public CodeExpression Right { get; set; }

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeAssignStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeAssignStatement, R>)visitor).VisitReturn(this);
		}
		#endregion
	}
}
