using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodePropertyReference : CodeExpression
	{
		public CodePropertyReference(CodeExpression target, PropertyInfo property) {
			this.TargetObject = target;
			this.Property = property;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodePropertyReference>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodePropertyReference, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression TargetObject { get; set; }
		public PropertyInfo Property { get; set; }
	}
}
