using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public class CodeExpressionStatement : CodeStatement
	{
		public CodeExpressionStatement() {
		}

		public CodeExpressionStatement(CodeExpression expression) {
			this.Expression = expression;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeExpressionStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeExpressionStatement, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression Expression { get; set; }
	}
}
