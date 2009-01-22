using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace H8.CodeModel
{
	public class CodeEventMember : CodeTypeMember
	{
		public CodeEventMember(EventInfo info) {
			this.Info = info;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeEventMember>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeEventMember, R>)visitor).VisitReturn(this);
		}
		#endregion

		public EventInfo Info { get; set; }
		public string Name { get { return Info.Name; } }
	}
}
