using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodePropertyMember : CodeTypeMember
	{
		public CodePropertyMember(PropertyInfo info) {
			this.Info = info;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodePropertyMember>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodePropertyMember, R>)visitor).VisitReturn(this);
		}
		#endregion

		public PropertyInfo Info { get; set; }
		public string Name { get { return Info.Name; } }
	}
}
