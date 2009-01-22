using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeIndexerExpression : CodeExpression
	{
		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeIndexerExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeIndexerExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public List<CodeExpression> Indices { get; set; }
		public CodeExpression TargetObject { get; set; }
	}
}
