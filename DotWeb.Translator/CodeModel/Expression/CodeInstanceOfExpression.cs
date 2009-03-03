using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public class CodeInstanceOfExpression : CodeExpression
	{
		public CodeInstanceOfExpression(Type target, CodeExpression expression) {
			this.TargetType = target;
			this.Expression = expression;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeInstanceOfExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeInstanceOfExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public Type TargetType { get; set; }
		public CodeExpression Expression { get; set; }
	}
}
