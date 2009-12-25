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
using Mono.Cecil;
using System.IO;
using System.Reflection;

namespace DotWeb.Utility
{
	static class AssemblyNameReferenceExtensions
	{
		public static void CopyFrom(this AssemblyNameReference tgt, AssemblyNameReference src) {
			tgt.Culture = src.Culture;
			tgt.Flags = src.Flags;
			tgt.Hash = src.Hash;
			tgt.HashAlgorithm = src.HashAlgorithm;
			tgt.Name = src.Name;
			tgt.PublicKey = src.PublicKey;
			tgt.PublicKeyToken = src.PublicKeyToken;
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

		public void FixupReferences(string assemblyPath) {
			string filename = Path.GetFileName(assemblyPath);
			string tgtPath = Path.Combine(this.outputPath, filename);

			var asm = AssemblyFactory.GetAssembly(assemblyPath);
			asm.MainModule.LoadSymbols();

			foreach (AssemblyNameReference item in asm.MainModule.AssemblyReferences) {
				if (item.Name == DotWebSystem) {
					item.CopyFrom(this.mscorlibRef);
					break;
				}
			}

			asm.MainModule.SaveSymbols(this.outputPath);
			AssemblyFactory.SaveAssembly(asm, tgtPath);
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

			string srcPath = Path.Combine(this.outputPath, assemblyName + DllSuffix);
			if (!File.Exists(srcPath)) {
				// assume it's a system/gac assembly
				ret = AssemblyNameReference.Parse(assemblyName);
				if (cache != null) {
					cache.Add(assemblyName, ret);
				}
				return ret;
			}

			var asm = AssemblyFactory.GetAssembly(srcPath);

			ret = asm.Name;

			string altName = Prefix + ret.Name;
			var filename = altName + DllSuffix;
			string tgtPath = Path.Combine(this.outputPath, filename);

			// check to see if the target already exists
			bool doAnalysis = true;
			if (File.Exists(tgtPath)) {
				var dtSource = File.GetLastWriteTime(srcPath);
				var dtTarget = File.GetLastWriteTime(tgtPath);

				// only analyze the source if source is newer
				//if (dtSource < dtTarget) {
				//    ret.Name = altName;
				//    doAnalysis = false;
				//}
			}

			if (doAnalysis) {
				bool dirty = FixupAssemblyReferences(asm.MainModule.AssemblyReferences, cache);
				if (dirty) {
					ret.Name = altName;
					asm.MainModule.LoadSymbols();
					asm.MainModule.SaveSymbols(this.outputPath);
					AssemblyFactory.SaveAssembly(asm, tgtPath);
				}
			}

			if (cache != null) {
				cache.Add(assemblyName, ret);
			}
			return ret;
		}
	}
}
