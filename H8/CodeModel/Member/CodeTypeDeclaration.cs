using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public class CodeTypeDeclaration : CodeTypeMember
	{
		public CodeTypeDeclaration() {
			this.Methods = new List<CodeMethodMember>();
			this.Fields = new List<CodeFieldMember>();
			this.Events = new List<CodeEventMember>();
			this.Properties = new List<CodePropertyMember>();
			this.ExternalTypes = new List<Type>();
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeTypeDeclaration>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeTypeDeclaration, R>)visitor).VisitReturn(this);
		}
		#endregion

		public Type Type { get; set; }
		public string Name { get { return this.Type.Name; } }

		public List<CodeMethodMember> Methods { get; set; }
		public List<CodeFieldMember> Fields { get; set; }
		public List<CodeEventMember> Events { get; set; }
		public List<CodePropertyMember> Properties { get; set; }
		public List<Type> ExternalTypes { get; set; }
	}
}
