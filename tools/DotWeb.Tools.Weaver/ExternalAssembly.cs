using System;
using System.Collections.Generic;
using System.Reflection;
using Mono.Cecil;

namespace DotWeb.Tools.Weaver
{
	class ExternalAssembly : ITypeResolver
	{
		private IResolver resolver;
		private Assembly asm;
		private Dictionary<TypeReference, ExternalType> cache = new Dictionary<TypeReference, ExternalType>();

		public ExternalAssembly(IResolver resolver, Assembly asm) {
			this.resolver = resolver;
			this.asm = asm;
		}

		public IType ResolveTypeReference(TypeReference typeRef) {
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
