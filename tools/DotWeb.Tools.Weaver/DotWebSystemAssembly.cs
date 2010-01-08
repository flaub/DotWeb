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

namespace DotWeb.Tools.Weaver
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

		public IType ResolveTypeReference(TypeReference typeRef) {
			var key = typeRef;
			ExternalType ret;
			if (this.cache.TryGetValue(key, out ret)) {
				return ret;
			}

			GenericInstanceType genericType = null;
			if (typeRef is GenericInstanceType) {
				genericType = (GenericInstanceType)typeRef;
				var original = typeRef.GetOriginalType();
				typeRef = original;
			}

			string fullName = typeRef.FullName.Replace("/", "+");
			var modifiedName = "DotWeb." + fullName;
			var type = this.asm.GetType(modifiedName);
			if (type == null)
				throw new NullReferenceException(string.Format("Could not find Type: {0}, for {1}", modifiedName, typeRef.ToString()));

			if (genericType != null) {
				var genericArgs = genericType.GenericArguments.Cast<TypeReference>();
				var genericTypes = genericArgs.Select(x => this.resolver.ResolveTypeReference(x).Type).ToArray();
				type = type.MakeGenericType(genericTypes);
			}

			var elementalType = type;
			var arrayType = typeRef as ArrayType;
			if (arrayType != null) {
				// we don't need to resolve this type because we can assume that only other system types
				// are referenced in DotWeb.System.
				string modifiedElementName = "DotWeb." + arrayType.ElementType.FullName;
				elementalType = this.asm.GetType(modifiedElementName);
			}

			if (elementalType.IsDefined(this.useSystemAttribute, false)) {
				ret = new ExternalType(this.resolver, Type.GetType(fullName));
			}
			else {
				ret = new ExternalType(this.resolver, type);
			}

			this.cache.Add(key, ret);

			return ret;
		}
	}
}
