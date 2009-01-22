using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeVariableDeclarationStatement : CodeStatement
	{
		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeVariableDeclarationStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeVariableDeclarationStatement, R>)visitor).VisitReturn(this);
		}
		#endregion
	}
}
