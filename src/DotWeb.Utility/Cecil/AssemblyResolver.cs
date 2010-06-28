// Copyright 2010, Frank Laub
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

using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.IO;
using System.Text;
using Mono.Cecil.Cil;
using System.Reflection;

namespace DotWeb.Utility.Cecil
{
	public abstract class BaseAssemblyResolver : IAssemblyResolver
	{
		static readonly bool on_mono = Type.GetType("Mono.Runtime") != null;

		readonly List<string> directories;
		readonly List<string> gac_paths;

		private ISymbolReaderProvider provider;

		protected Dictionary<string, string> asmPaths = new Dictionary<string, string>();

		public void AddSearchDirectory(string directory) {
			directories.Add(directory);
		}

		public void RemoveSearchDirectory(string directory) {
			directories.Remove(directory);
		}

		public virtual AssemblyDefinition Resolve(string fullName) {
			return Resolve(AssemblyNameReference.Parse(fullName));
		}

		protected BaseAssemblyResolver() {
			directories = new List<string> { ".", "bin" };
			gac_paths = GetGacPaths();
			this.provider = GetPlatformReaderProvider();
		}

		static readonly string symbol_kind = Type.GetType("Mono.Runtime") != null ? "Mdb" : "Pdb";

		private static ISymbolReaderProvider GetPlatformReaderProvider() {
			var type = GetPlatformType(string.Format("Mono.Cecil.{0}.{0}ReaderProvider", symbol_kind));
			if (type == null)
				return null;

			return (ISymbolReaderProvider)Activator.CreateInstance(type);
		}

		public static ISymbolWriterProvider GetPlatformWriterProvider() {
			var type = GetPlatformType(string.Format("Mono.Cecil.{0}.{0}WriterProvider", symbol_kind));
			if (type == null)
				return null;

			return (ISymbolWriterProvider)Activator.CreateInstance(type);
		}

		private static Type GetPlatformType(string fullname) {
			var cecil_name = typeof(AssemblyDefinition).Assembly.GetName();
			var name = new AssemblyName {
				Name = "Mono.Cecil." + symbol_kind,
				Version = cecil_name.Version,
			};
			name.SetPublicKeyToken(cecil_name.GetPublicKeyToken());

			var assembly = Assembly.Load(name);
			if (assembly != null)
				return assembly.GetType(fullname);
			return null;
		}

		public AssemblyDefinition GetAssembly(string file, bool readSymbols) {
			var readerParameters = new ReaderParameters {
				AssemblyResolver = this,
				SymbolReaderProvider = readSymbols ? this.provider : null
			};

			var asmDef = ModuleDefinition.ReadModule(file, readerParameters).Assembly;
			this.asmPaths.Add(asmDef.Name.Name, file);
			return asmDef;
		}

		public virtual AssemblyDefinition Resolve(AssemblyNameReference name) {
			var assembly = SearchDirectory(name, directories);
			if (assembly != null)
				return assembly;

			var framework_dir = Path.GetDirectoryName(typeof(object).Module.FullyQualifiedName);

			if (IsZero(name.Version)) {
				assembly = SearchDirectory(name, new[] { framework_dir });
				if (assembly != null)
					return assembly;
			}

			if (name.Name == "mscorlib") {
				assembly = GetCorlib(name);
				if (assembly != null)
					return assembly;
			}

			assembly = GetAssemblyInGac(name);
			if (assembly != null)
				return assembly;

			assembly = SearchDirectory(name, new[] { framework_dir });
			if (assembly != null)
				return assembly;

			throw new FileNotFoundException("Could not resolve: " + name);
		}

		AssemblyDefinition SearchDirectory(AssemblyNameReference name, IEnumerable<string> directories) {
			var extensions = new[] { ".exe", ".dll" };
			foreach (var directory in directories) {
				foreach (var extension in extensions) {
					string file = Path.Combine(directory, name.Name + extension);
					if (File.Exists(file))
						return GetAssembly(file, true);
				}
			}

			return null;
		}

		static bool IsZero(Version version) {
			return version.Major == 0 && version.Minor == 0 && version.Build == 0 && version.Revision == 0;
		}

		AssemblyDefinition GetCorlib(AssemblyNameReference reference) {
			var version = reference.Version;
			var corlib = typeof(object).Assembly.GetName();

			if (corlib.Version == version || IsZero(version))
				return GetAssembly(typeof(object).Module.FullyQualifiedName, false);

			var path = Directory.GetParent(
				Directory.GetParent(
					typeof(object).Module.FullyQualifiedName).FullName
				).FullName;

			if (on_mono) {
				if (version.Major == 1)
					path = Path.Combine(path, "1.0");
				else if (version.Major == 2) {
					if (version.MajorRevision == 5)
						path = Path.Combine(path, "2.1");
					else
						path = Path.Combine(path, "2.0");
				}
				else if (version.Major == 4)
					path = Path.Combine(path, "4.0");
				else
					throw new NotSupportedException("Version not supported: " + version);
			}
			else {
				switch (version.Major) {
					case 1:
						if (version.MajorRevision == 3300)
							path = Path.Combine(path, "v1.0.3705");
						else
							path = Path.Combine(path, "v1.0.5000.0");
						break;
					case 2:
						path = Path.Combine(path, "v2.0.50727");
						break;
					case 4:
						path = Path.Combine(path, "v4.0.30319");
						break;
					default:
						throw new NotSupportedException("Version not supported: " + version);
				}
			}

			var file = Path.Combine(path, "mscorlib.dll");
			if (File.Exists(file))
				return GetAssembly(file, false);

			return null;
		}

		static List<string> GetGacPaths() {
			if (on_mono)
				return GetDefaultMonoGacPaths();

			var paths = new List<string>(2);
			var windir = Environment.GetEnvironmentVariable("WINDIR");
			if (windir == null)
				return paths;

			paths.Add(Path.Combine(windir, "assembly"));
			paths.Add(Path.Combine(windir, Path.Combine("Microsoft.NET", "assembly")));
			return paths;
		}

		static List<string> GetDefaultMonoGacPaths() {
			var paths = new List<string>(1);
			var gac = GetCurrentMonoGac();
			if (gac != null)
				paths.Add(gac);

			var gac_paths_env = Environment.GetEnvironmentVariable("MONO_GAC_PREFIX");
			if (string.IsNullOrEmpty(gac_paths_env))
				return paths;

			var prefixes = gac_paths_env.Split(Path.PathSeparator);
			foreach (var prefix in prefixes) {
				if (string.IsNullOrEmpty(prefix))
					continue;

				var gac_path = Path.Combine(Path.Combine(Path.Combine(prefix, "lib"), "mono"), "gac");
				if (Directory.Exists(gac_path) && !paths.Contains(gac))
					paths.Add(gac_path);
			}

			return paths;
		}

		static string GetCurrentMonoGac() {
			return Path.Combine(Directory.GetParent(typeof(object).Module.FullyQualifiedName).FullName, "gac");
		}

		AssemblyDefinition GetAssemblyInGac(AssemblyNameReference reference) {
			if (reference.PublicKeyToken == null || reference.PublicKeyToken.Length == 0)
				return null;

			if (on_mono)
				return GetAssemblyInMonoGac(reference);

			return GetAssemblyInNetGac(reference);
		}

		AssemblyDefinition GetAssemblyInMonoGac(AssemblyNameReference reference) {
			for (int i = 0; i < gac_paths.Count; i++) {
				var gac_path = gac_paths[i];
				var file = GetAssemblyFile(reference, string.Empty, gac_path);
				if (File.Exists(file))
					return GetAssembly(file, false);
			}

			return null;
		}

		AssemblyDefinition GetAssemblyInNetGac(AssemblyNameReference reference) {
			var gacs = new[] { "GAC_MSIL", "GAC_32", "GAC" };
			var prefixes = new[] { string.Empty, "v4.0_" };

			for (int i = 0; i < 2; i++) {
				for (int j = 0; j < gacs.Length; j++) {
					var gac = Path.Combine(gac_paths[i], gacs[j]);
					var file = GetAssemblyFile(reference, prefixes[i], gac);
					if (Directory.Exists(gac) && File.Exists(file))
						return GetAssembly(file, false);
				}
			}

			return null;
		}

		static string GetAssemblyFile(AssemblyNameReference reference, string prefix, string gac) {
			var gac_folder = new StringBuilder();
			gac_folder.Append(prefix);
			gac_folder.Append(reference.Version);
			gac_folder.Append("__");
			for (int i = 0; i < reference.PublicKeyToken.Length; i++)
				gac_folder.Append(reference.PublicKeyToken[i].ToString("x2"));

			return Path.Combine(
				Path.Combine(
					Path.Combine(gac, reference.Name), gac_folder.ToString()),
				reference.Name + ".dll");
		}
	}

	public class AssemblyResolver : BaseAssemblyResolver
	{
		private Dictionary<string, AssemblyDefinition> cache = new Dictionary<string, AssemblyDefinition>();

		public override AssemblyDefinition Resolve(AssemblyNameReference name) {
			// TODO: support side-by-side versions later
			AssemblyDefinition ret;
			if (!cache.TryGetValue(name.Name, out ret)) {
				ret = base.Resolve(name);
				this.cache.Add(name.Name, ret);
			}
			return ret;
		}

		public string GetAbsolutePath(AssemblyNameReference asmRef) {
			return this.asmPaths[asmRef.Name];
		}
	}

}
