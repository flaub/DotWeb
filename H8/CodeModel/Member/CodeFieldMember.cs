using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodeFieldMember : CodeTypeMember
	{
		public CodeFieldMember(FieldInfo info) {
			this.Info = info;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeFieldMember>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeFieldMember, R>)visitor).VisitReturn(this);
		}
		#endregion

		public FieldInfo Info { get; set; }
		public string Name { get { return Info.Name; } }
	}
}
