using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodeFieldReference : CodeExpression
	{
		public CodeFieldReference(CodeExpression target, FieldInfo field) {
			this.TargetObject = target;
			this.Field = field;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeFieldReference>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeFieldReference, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression TargetObject { get; set; }
		public FieldInfo Field { get; set; }
	}
}
