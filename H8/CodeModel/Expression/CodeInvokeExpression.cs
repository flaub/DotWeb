using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodeInvokeExpression : CodeExpression
	{
		public CodeInvokeExpression() {
			this.Parameters = new List<CodeExpression>();
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeInvokeExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeInvokeExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeMethodReference Method { get; set; }
		public List<CodeExpression> Parameters { get; set; }
	}
}
