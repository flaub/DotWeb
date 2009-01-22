using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodeObjectCreateExpression : CodeExpression
	{
		public CodeObjectCreateExpression() {
			Parameters = new List<CodeExpression>();
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeObjectCreateExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeObjectCreateExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public ConstructorInfo Constructor { get; set; }
		public Type Type { get { return this.Constructor.DeclaringType; } }
		public List<CodeExpression> Parameters { get; set; }
	}
}
