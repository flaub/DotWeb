using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Translator.CodeModel
{
	public class CodePropertyReference : CodeExpression
	{
		public enum RefType
		{
			Get,
			Set
		}

		public CodePropertyReference(CodeExpression target, PropertyInfo property, RefType rt) {
			this.TargetObject = target;
			this.Property = property;
			this.ReferenceType = rt;
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
		public RefType ReferenceType { get; set; }
	}
}
