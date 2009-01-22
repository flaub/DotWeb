using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeIfStatement : CodeStatement
	{
		public CodeIfStatement() {
			this.TrueStatements = new List<CodeStatement>();
			this.FalseStatements = new List<CodeStatement>();
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeIfStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeIfStatement, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression Condition { get; set; }
		public List<CodeStatement> TrueStatements { get; set; }
		public List<CodeStatement> FalseStatements { get; set; }
	}
}
