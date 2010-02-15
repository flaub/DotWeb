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
using System.Reflection;
using Mono.Cecil;

namespace DotWeb.Hosting.Weaver
{
	class ExternalAssembly : IAssembly
	{
		private IResolver resolver;
		private Assembly asm;
		private Dictionary<TypeReference, ExternalType> cache = new Dictionary<TypeReference, ExternalType>();

		public Assembly Assembly { get { return this.asm; } }

		public ExternalAssembly(IResolver resolver, Assembly asm) {
			this.resolver = resolver;
			this.asm = asm;
		}

		public IType ResolveTypeReference(TypeReference typeRef, IGenericScope genericScope) {
			ExternalType ret;
			if (!this.cache.TryGetValue(typeRef, out ret)) {
				string fullName = typeRef.FullName.Replace("/", "+");
				var type = this.asm.GetType(fullName);
				ret = new ExternalType(this.resolver, type);
				if (ret == null)
					throw new NullReferenceException(string.Format("Could not find Type: {0}", typeRef.ToString()));
				this.cache.Add(typeRef, ret);
			}
			return ret;
		}
	}
}
