using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodeArgumentReference : CodeExpression
	{
		public CodeArgumentReference(ParameterInfo arg) {
			this.Argument = arg;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeArgumentReference>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeArgumentReference, R>)visitor).VisitReturn(this);
		}
		#endregion

		public ParameterInfo Argument { get; set; }
	}
}
