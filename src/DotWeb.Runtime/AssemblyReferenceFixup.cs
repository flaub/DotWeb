using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.IO;

namespace DotWeb.Hoister
{
	static class AssemblyNameReferenceExtensions
	{
		public static void CopyFrom(this AssemblyNameReference tgt, AssemblyNameReference src) {
			tgt.Culture = src.Culture;
			tgt.Flags = src.Flags;
			tgt.Hash = src.Hash;
			tgt.HashAlgorithm = src.HashAlgorithm;
			tgt.Name = src.Name;
			tgt.PublicKeyToken = src.PublicKeyToken;
			tgt.PublicKey = src.PublicKey;
			tgt.Version = src.Version;
		}
	}

	public class AssemblyReferenceFixup
	{
		public const string Prefix = "Hosted-";
		public const string DotWebSystem = "DotWeb.System";
		public const string DllSuffix = ".dll";

		private string outputPath;
		private AssemblyNameReference mscorlibRef;
		private IAssemblyResolver resolver = new DefaultAssemblyResolver();

		public AssemblyReferenceFixup(string outputPath) {
			this.outputPath = outputPath;
			var asm = typeof(object).Assembly;
			this.mscorlibRef = AssemblyNameReference.Parse(asm.FullName);
		}

		private bool FixupAssemblyReferences(AssemblyNameReferenceCollection refs, Dictionary<string, AssemblyNameReference> cache) {
			bool dirty = false;
			foreach (AssemblyNameReference item in refs) {
				if (item.Name == DotWebSystem) {
					item.CopyFrom(this.mscorlibRef);
					dirty = true;
				}
				else if (cache != null) {
					var src = FixupReferences(item.Name, cache);
					if (src.Name != item.Name) {
						item.CopyFrom(src);
						dirty = true;
					}
				}
			}
			return dirty;
		}

		public AssemblyNameReference FixupReferences(string assemblyName, bool followDependencies) {
			Dictionary<string, AssemblyNameReference> cache = null;
			if (followDependencies)
				cache = new Dictionary<string, AssemblyNameReference>();

			return FixupReferences(assemblyName, cache);
		}

		private AssemblyNameReference FixupReferences(string assemblyName, Dictionary<string, AssemblyNameReference> cache) {
			AssemblyNameReference ret;
			if (cache != null && cache.TryGetValue(assemblyName, out ret)) {
				return ret;
			}

			var asm = this.resolver.Resolve(assemblyName);
			ret = asm.Name;

			bool dirty = FixupAssemblyReferences(asm.MainModule.AssemblyReferences, cache);
			if (dirty) {
				string altName = Prefix + ret.Name;
				ret.Name = altName;

				var filename = altName + DllSuffix;
				string path = Path.Combine(this.outputPath, filename);

				//asm.MainModule.SaveSymbols(this.outputPath);
				AssemblyFactory.SaveAssembly(asm, path);
			}

			if (cache != null) {
				cache.Add(assemblyName, ret);
			}
			return ret;
		}
	}
}
