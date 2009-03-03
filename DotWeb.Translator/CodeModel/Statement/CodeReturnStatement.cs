using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public class CodeReturnStatement : CodeStatement
	{
		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeReturnStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeReturnStatement, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression Expression { get; set; }
	}
}
