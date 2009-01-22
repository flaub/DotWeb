using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeCommentStatement : CodeStatement
	{
		public CodeCommentStatement(string comment) {
			this.Comment = comment;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeCommentStatement>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeCommentStatement, R>)visitor).VisitReturn(this);
		}
		#endregion

		public string Comment { get; set; }
	}
}
