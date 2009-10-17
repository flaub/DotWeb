using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Mono.Cecil;
using System.Reflection.Emit;
using SR = System.Reflection;

namespace DotWeb.Tools.Weaver
{
	class EnumProcessor : IType
	{
		private IResolver resolver;
		private AssemblyProcessor parent;
		private TypeDefinition typeDef;
		private EnumBuilder enumBuilder;

		public EnumProcessor(IResolver resolver, AssemblyProcessor parent, TypeReference typeRef, ModuleBuilder moduleBuilder) {
			this.resolver = resolver;
			this.parent = parent;
			this.typeDef = typeRef.Resolve();
			var attributes = (SR.TypeAttributes)this.typeDef.Attributes & System.Reflection.TypeAttributes.VisibilityMask;

			var valueField = typeDef.Fields[0];
			var valueType = this.resolver.ResolveTypeReference(valueField.FieldType).Type;

			this.enumBuilder = moduleBuilder.DefineEnum(this.typeDef.FullName, attributes, valueType);
		}

		#region IType Members

		public Type Type {
			get { return this.enumBuilder; }
		}

		public MethodBase ResolveMethod(MethodReference methodRef) {
			throw new NotImplementedException();
		}

		public FieldInfo ResolveField(FieldDefinition fieldDef) {
			throw new NotImplementedException();
		}

		public void Close() {
			this.enumBuilder.CreateType();
		}

		public void Process() {
			foreach (FieldDefinition fieldDef in this.typeDef.Fields) {
				if (fieldDef.HasConstant) {
					this.enumBuilder.DefineLiteral(fieldDef.Name, fieldDef.Constant);
				}
			}

			Close();
		}

		#endregion
	}
}
