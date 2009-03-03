using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public class CodeVariableReference : CodeExpression
	{
		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeVariableReference>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeVariableReference, R>)visitor).VisitReturn(this);
		}
		#endregion

		public int Index { get; set; }
		public string Name { get; set; }
	}
}
