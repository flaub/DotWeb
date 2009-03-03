using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public class CodeTypeReference : CodeExpression
	{
		public CodeTypeReference(Type type) {
			this.Type = type;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeTypeReference>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeTypeReference, R>)visitor).VisitReturn(this);
		}
		#endregion

		public Type Type { get; set; }
	}
}
