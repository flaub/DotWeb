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
