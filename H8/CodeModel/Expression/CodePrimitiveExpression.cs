using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodePrimitiveExpression : CodeExpression
	{
		public CodePrimitiveExpression(object value) {
			this.Value = value;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodePrimitiveExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodePrimitiveExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public object Value { get; set; }
	}
}
