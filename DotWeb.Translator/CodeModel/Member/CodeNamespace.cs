using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Translator.CodeModel
{
	public class CodeNamespace : CodeTypeMember
	{
		public CodeNamespace() {
			this.Types = new List<CodeTypeDeclaration>();
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeNamespace>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeNamespace, R>)visitor).VisitReturn(this);
		}
		#endregion

		public string Name { get; set; }
		public List<CodeTypeDeclaration> Types { get; set; }
	}
}
