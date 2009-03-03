using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Translator.CodeModel
{
	public class CodeParameterDeclarationExpression : CodeExpression
	{
		public CodeParameterDeclarationExpression(ParameterInfo pi) {
			Info = pi;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeParameterDeclarationExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeParameterDeclarationExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public ParameterInfo Info { get; set; }
		public string Name { get { return Info.Name; } }
	}
}
