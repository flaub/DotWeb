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
using Mono.Cecil;
using System.Reflection;

namespace DotWeb.Hosting.Weaver
{
	class DotWebSystemAssembly : ITypeResolver
	{
		private IResolver resolver;
		private Assembly asm;
		private Type useSystemAttribute;
		private Dictionary<TypeReference, ExternalType> cache = new Dictionary<TypeReference, ExternalType>();

		public DotWebSystemAssembly(IResolver resolver) {
			this.resolver = resolver;
			this.asm = Assembly.Load("Hosted-DotWeb.System");
			this.useSystemAttribute = this.asm.GetType("DotWeb.System.DotWeb.UseSystemAttribute");
		}

		public IType ResolveTypeReference(TypeReference typeRef, IGenericScope genericScope) {
			ExternalType ret;
			if (this.cache.TryGetValue(typeRef, out ret)) {
				return ret;
			}

			// need to deal with the following kinds references:
			// * Foo              Simple
			// * Foo[]            ArrayType of Simple
			// * List<Foo>        GenericInstanceType of Simple
			// * List<Foo>[]      ArrayType of GenericInstanceType of Simple
			// * List<Foo[]>      GenericInstanceType of ArrayType of Simple

			if (typeRef is GenericInstanceType) {
				ret = ResolveGenericType(typeRef, (GenericInstanceType)typeRef);
			}
			else if (typeRef is ArrayType) {
				ret = ResolveArrayType(typeRef, (ArrayType)typeRef);
			}
			else {
				ret = ResolveSimpleType(typeRef);
			}

			this.cache.Add(typeRef, ret);

			return ret;
		}

		private string ConvertName(TypeReference typeRef) {
			return string.Format("DotWeb.{0}", typeRef.FullName.Replace("/", "+"));
		}

		private Type MakeArrayType(Type type, int rank) {
			if (rank == 1)
				return type.MakeArrayType();
			return type.MakeArrayType(rank);
		}

		private ExternalType ResolveArrayType(TypeReference typeRef, ArrayType arrayTypeSpec) {
			var elementType = this.resolver.ResolveTypeReference(arrayTypeSpec.ElementType, null);
			return new ExternalType(this.resolver, MakeArrayType(elementType.Type, arrayTypeSpec.Rank));
		}

		private ExternalType ResolveGenericType(TypeReference typeRef, GenericInstanceType genericTypeSpec) {
			var originalTypeRef = genericTypeSpec.GetOriginalType();
			var modifiedName = ConvertName(originalTypeRef);
			var genericType = this.asm.GetType(modifiedName);

			// The [UseSystem] attribute lives on the genericType, not the concreteType (which is generated)
			if (genericType.IsDefined(this.useSystemAttribute, false)) {
				string sysFullName = typeRef.FullName.Replace("/", "+");
				return new ExternalType(this.resolver, Type.GetType(sysFullName));
			}
			else {
				var genericArgumentRefs = genericTypeSpec.GenericArguments.Cast<TypeReference>();
				var typeArguments = genericArgumentRefs.Select(x => this.resolver.ResolveTypeReference(x, null).Type).ToArray();
				var concreteType = genericType.MakeGenericType(typeArguments);

				return new ExternalType(this.resolver, concreteType);
			}
		}

		private ExternalType ResolveSimpleType(TypeReference typeRef) {
			var modifiedName = ConvertName(typeRef);
			var type = this.asm.GetType(modifiedName);

			if (type.IsDefined(this.useSystemAttribute, false)) {
				string sysFullName = typeRef.FullName.Replace("/", "+");
				return new ExternalType(this.resolver, Type.GetType(sysFullName));
			}
			else {
				return new ExternalType(this.resolver, type);
			}
		}
	}
}
