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

			if (type.IsDefined(this.useSystemAttribute, false)) {
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
