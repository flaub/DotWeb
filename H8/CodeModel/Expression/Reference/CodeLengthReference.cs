using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeLengthReference : CodeExpression
	{
		public CodeLengthReference(CodeExpression target) {
			this.TargetObject = target;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeLengthReference>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeLengthReference, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression TargetObject { get; set; }
	}
}
