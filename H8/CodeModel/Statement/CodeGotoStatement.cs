using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeGotoStatement : CodeStatement
	{
		public CodeGotoStatement(string label) {
			this.Label = label;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeGotoStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeGotoStatement, R>)visitor).VisitReturn(this);
		}
		#endregion

		public string Label { get; set; }
	}
}
