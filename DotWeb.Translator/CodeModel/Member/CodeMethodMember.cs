using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Translator.CodeModel
{
	public class CodeMethodMember : CodeTypeMember
	{
		public CodeMethodMember() {
			this.Statements = new List<CodeStatement>();
			this.Parameters = new List<CodeParameterDeclarationExpression>();
			this.ExternalMethods = new List<MethodBase>();
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeMethodMember>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeMethodMember, R>)visitor).VisitReturn(this);
		}
		#endregion

		public MethodBase Info { get; set; }
		public string Name { get { return Info.Name; } }
		public List<CodeStatement> Statements { get; set; }
		public List<CodeParameterDeclarationExpression> Parameters { get; set; }
		public List<MethodBase> ExternalMethods { get; set; }
		public bool IsGlobal { get; set; }
		public string NativeCode { get; set; }
	}
}
