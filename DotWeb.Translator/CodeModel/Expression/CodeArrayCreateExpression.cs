using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public class CodeArrayCreateExpression : CodeExpression
	{
		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeArrayCreateExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeArrayCreateExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression SizeExpression { get; set; }
		public Type Type { get; set; }
	}
}
