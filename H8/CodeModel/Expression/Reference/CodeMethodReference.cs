using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodeMethodReference : CodeExpression
	{
		public CodeMethodReference(CodeExpression target, MethodBase method) {
			this.TargetObject = target;
			this.Info = method;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeMethodReference>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeMethodReference, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression TargetObject { get; set; }
		public MethodBase Info { get; set; }
	}
}
