// Copyright 2009, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 

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

		public EnumProcessor(IResolver resolver, AssemblyProcessor parent, TypeDefinition typeDef, ModuleBuilder moduleBuilder) {
			this.resolver = resolver;
			this.parent = parent;
			this.typeDef = typeDef;
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
			if (this.typeDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this.resolver, this.typeDef, this.enumBuilder);
			}

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
