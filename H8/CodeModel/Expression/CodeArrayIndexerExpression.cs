using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeArrayIndexerExpression : CodeExpression
	{
		public CodeArrayIndexerExpression(CodeExpression target, params CodeExpression[] indices) {
			TargetObject = target;
			Indices = new List<CodeExpression>(indices);
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeArrayIndexerExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeArrayIndexerExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression TargetObject { get; set; }
		public List<CodeExpression> Indices { get; set; }
	}
}
