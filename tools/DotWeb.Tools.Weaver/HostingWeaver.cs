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
using System.IO;
using System.Diagnostics;
using DotWeb.Hosting;

namespace DotWeb.Tools.Weaver
{
	public class HostingWeaver : IResolver
	{
		class ConstantNames
		{
			public const string DotWebSystem = "DotWeb.System";
			public const string DotWebSystemDll = "DotWeb.System.dll";
			public const string Mscorlib = "mscorlib";
			public const string AssemblyWeavedAttribute = "AssemblyWeavedAttribute";
		}

		private string inputDir;
		private string outputDir;
		private DefaultAssemblyResolver asmResolver = new DefaultAssemblyResolver();
		private Dictionary<string, ITypeResolver> modules = new Dictionary<string, ITypeResolver>();
		private static ExternalAssembly asmMscorlib;

		public HostingWeaver(string inputDir, string outputDir, string[] searchDirs) {
			this.inputDir = inputDir;
			this.outputDir = outputDir;

			this.asmResolver.AddSearchDirectory(this.inputDir);
			if (searchDirs != null) {
				foreach (var dir in searchDirs) {
					this.asmResolver.AddSearchDirectory(dir);
				}
			}

			PrepareMscorlib();
		}

		private void PrepareMscorlib() {
			if (asmMscorlib == null) {
				var sysType = typeof(object);
				var asm = sysType.Assembly;
				var asmName = AssemblyNameReference.Parse(asm.FullName);

				var asmDef = this.asmResolver.Resolve(asmName);
				asmMscorlib = new ExternalAssembly(this, asm);
			}
			this.modules.Add(ConstantNames.Mscorlib, asmMscorlib);
		}

		private void PrepareDotWebSystem() {
			var proc = new DotWebSystemAssembly(this);
			this.modules.Add(ConstantNames.DotWebSystem, proc);
			this.modules.Add(ConstantNames.DotWebSystemDll, proc);
		}

		public Assembly ProcessAssembly(string asmPath) {
			var asmDef = AssemblyFactory.GetAssembly(asmPath);

			foreach (CustomAttribute item in asmDef.CustomAttributes) {
				if (item.Constructor.DeclaringType.Name == ConstantNames.AssemblyWeavedAttribute) {
					Console.WriteLine("This assembly has already been weaved and is ready for hosted mode");
					return Assembly.LoadFrom(asmPath);
				}
			}

			return ProcessAssembly(asmDef);
		}

		private Assembly ProcessAssembly(AssemblyDefinition asmDef) {
			foreach (AssemblyNameReference asmRef in asmDef.MainModule.AssemblyReferences) {
				if (this.modules.ContainsKey(asmRef.Name))
					continue;

				if (asmRef.Name == ConstantNames.DotWebSystem) {
					PrepareDotWebSystem();
					continue;
				}

				var child = this.asmResolver.Resolve(asmRef);
				ProcessAssembly(child);
			}

			var asmProc = new AssemblyProcessor(this, asmDef, this.outputDir);
			string name = asmDef.MainModule.Name;
			string altName = Path.GetFileNameWithoutExtension(name);
			this.modules.Add(name, asmProc);
			if (name != altName)
				this.modules.Add(altName, asmProc);

			return asmProc.ProcessModule();
		}

		private IType ResolveType(TypeReference typeRef) {
			var scope = typeRef.Scope;
			string key;
			if (scope == null)
				key = ConstantNames.Mscorlib;
			else
				key = scope.Name;
			var moduleProc = this.modules[key];
			var typeProc = moduleProc.ResolveTypeReference(typeRef);
			return typeProc;
		}

		#region IResolver Members

		public IType ResolveTypeReference(TypeReference typeRef) {
			if (typeRef.FullName == Constants.Void) {
				return ExternalType.Void;
			}
			return ResolveType(typeRef);
		}

		public MethodBase ResolveMethodReference(MethodReference methodRef) {
			var type = ResolveType(methodRef.DeclaringType);
			if (type == null)
				throw new NullReferenceException(string.Format("Could not find DeclaringType for method: {0}", methodRef.ToString()));
			return type.ResolveMethod(methodRef);
		}

		public FieldInfo ResolveFieldReference(FieldReference fieldRef) {
			var fieldDef = fieldRef.Resolve();
			var type = ResolveType(fieldDef.DeclaringType);
			if (type == null)
				throw new NullReferenceException(string.Format("Could not find DeclaringType for field: {0}", fieldRef.ToString()));
			return type.ResolveField(fieldDef);
		}

		#endregion
	}
}
