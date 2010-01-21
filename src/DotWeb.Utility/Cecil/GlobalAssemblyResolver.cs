using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace DotWeb.Utility.Cecil
{
	public class GlobalAssemblyResolver : BaseAssemblyResolver
	{
		private Dictionary<string, AssemblyDefinition> cache = new Dictionary<string, AssemblyDefinition>();

		public override AssemblyDefinition Resolve(AssemblyNameReference name) {
			AssemblyDefinition ret;
			if (!cache.TryGetValue(name.FullName, out ret)) {
				ret = base.Resolve(name);
				this.cache.Add(ret.Name.FullName, ret);
				if (ret.Name.FullName != name.FullName) {
					this.cache.Add(name.FullName, ret);
				}
				ret.Resolver = this;
			}
			return ret;
		}
	}

}
