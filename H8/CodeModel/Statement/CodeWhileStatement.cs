using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeWhileStatement : CodeLoopStatement
	{
		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeWhileStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeWhileStatement, R>)visitor).VisitReturn(this);
		}
		#endregion
	}
}
