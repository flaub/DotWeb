using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public enum CodeUnaryOperator
	{
		Increment,
		Decrement,
		Positive,
		Negate,
		Not,
		BitwiseComplement
	}

	public class CodeUnaryExpression : CodeExpression
	{
		public CodeUnaryExpression(CodeExpression expression, CodeUnaryOperator op) {
			this.Expression = expression;
			this.Operator = op;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeUnaryExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeUnaryExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression Expression { get; set; }
		public CodeUnaryOperator Operator { get; set; }

		public override CodeExpression Invert() {
			switch (Operator) {
				case CodeUnaryOperator.Not:
					return this.Expression;
				default:
					return this;
			}
		}
	}
}
