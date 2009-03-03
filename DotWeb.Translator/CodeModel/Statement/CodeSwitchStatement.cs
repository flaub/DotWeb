using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public class CodeCase
	{
		public CodeCase() {
			this.Statements = new List<CodeStatement>();
			this.Expressions = new List<CodeExpression>();
		}

		public List<CodeExpression> Expressions { get; set; }
		public List<CodeStatement> Statements { get; set; }
	}

	public class CodeSwitchStatement : CodeStatement
	{
		public CodeSwitchStatement() {
			this.Cases = new List<CodeCase>();
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeSwitchStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeSwitchStatement, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression Expression { get; set; }
		public List<CodeCase> Cases { get; set; }
	}
}
