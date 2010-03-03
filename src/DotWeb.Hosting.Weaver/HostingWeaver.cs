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
using DotWeb.Utility.Cecil;

namespace DotWeb.Hosting.Weaver
{
	public class HostingWeaver : IResolver
	{
		class ConstantNames
		{
			public const string DotWebSystem = "DotWeb.System";
			public const string DotWebSystemDll = "DotWeb.System.dll";
			public const string Mscorlib = "mscorlib";
			public const string SystemCore = "System.Core";
			public const string SystemCoreDll = "System.Core.dll";
			public const string AssemblyWeavedAttribute = "AssemblyWeavedAttribute";
		}

		private bool forceBuild;
		private string inputDir;
		private string outputDir;
		private GlobalAssemblyResolver asmResolver = new GlobalAssemblyResolver();
		private Dictionary<string, ITypeResolver> modules = new Dictionary<string, ITypeResolver>();

		public HostingWeaver(string inputDir, string outputDir, string[] searchDirs, bool forceBuild) {
			this.inputDir = inputDir;
			this.outputDir = outputDir;
			this.forceBuild = forceBuild;

			this.asmResolver.AddSearchDirectory(this.inputDir);
			if (searchDirs != null) {
				foreach (var dir in searchDirs) {
					this.asmResolver.AddSearchDirectory(dir);
				}
			}

			PrepareMscorlib();
			PrepareSystemCore();
		}

		private ExternalAssembly LoadSystemAssembly(Type sysType) {
			var asm = sysType.Assembly;
			var asmName = AssemblyNameReference.Parse(asm.FullName);
			var asmDef = this.asmResolver.Resolve(asmName);
			return new ExternalAssembly(this, asm);
		}

		private void PrepareMscorlib() {
			var asm = LoadSystemAssembly(typeof(object));
			this.modules.Add(ConstantNames.Mscorlib, asm);
		}

		private void PrepareSystemCore() {
			var asm = LoadSystemAssembly(typeof(Action));
			this.modules.Add(ConstantNames.SystemCore, asm);
			this.modules.Add(ConstantNames.SystemCoreDll, asm);
		}

		private void PrepareDotWebSystem() {
			var proc = new DotWebSystemAssembly(this);
			this.modules.Add(ConstantNames.DotWebSystem, proc);
			this.modules.Add(ConstantNames.DotWebSystemDll, proc);
		}

		/// <summary>
		/// This should ONLY be called for the top level assembly,
		/// otherwise we get different resolvers and therefore different
		/// assembly definitions for the same assembly
		/// </summary>
		/// <param name="asmPath"></param>
		/// <returns></returns>
		public Assembly ProcessAssembly(string asmPath) {
			var asmDef = AssemblyFactory.GetAssembly(asmPath);
			asmDef.Resolver = this.asmResolver;

			foreach (CustomAttribute item in asmDef.CustomAttributes) {
				if (item.Constructor.DeclaringType.Name == ConstantNames.AssemblyWeavedAttribute) {
					Console.WriteLine("This assembly has already been weaved and is ready for hosted mode");
					return Assembly.LoadFrom(asmPath);
				}
			}

			return ProcessAssembly(asmDef, new HashSet<string>()).Assembly;
		}

		// depth-first recursion so that we make sure to re-weave dependant assemblies when necessary
		private IAssembly ProcessAssembly(AssemblyDefinition asmDef, HashSet<string> visited) {
			var dependencyChanged = false;
			foreach (AssemblyNameReference asmRef in asmDef.MainModule.AssemblyReferences) {
				if (visited.Contains(asmRef.Name))
					continue;

				visited.Add(asmRef.Name);

				if (this.modules.ContainsKey(asmRef.Name))
					continue;

				if (asmRef.Name == ConstantNames.DotWebSystem) {
					PrepareDotWebSystem();
					continue;
				}

				var child = this.asmResolver.Resolve(asmRef);
				var childAsm = ProcessAssembly(child, visited);
				if (childAsm is AssemblyProcessor) {
					// otherwise it'd be an ExternalAssembly and thus didn't need processing
					dependencyChanged = true;
				}
			}

			string name = asmDef.MainModule.Name;
			string altName = Path.GetFileNameWithoutExtension(name);

			string hostedName = name;
			if (!hostedName.StartsWith(AssemblyProcessor.HostedPrefix))
				hostedName = AssemblyProcessor.HostedPrefix + hostedName;

			string path = Path.Combine(this.outputDir, MakeAssemblyNameIntoFilename(hostedName));
			string srcPath = Path.Combine(this.inputDir, MakeAssemblyNameIntoFilename(name));

			if (!this.forceBuild && 
				File.Exists(path) && 
				File.GetLastWriteTime(srcPath) < File.GetLastWriteTime(path) && 
				!dependencyChanged) {
				var asm = Assembly.LoadFrom(path);
				var proc = new ExternalAssembly(this, asm);
				this.AddModule(name, altName, proc);
				return proc;
			}
			else {
				var proc = new AssemblyProcessor(this, asmDef, this.outputDir);
				this.AddModule(name, altName, proc);
				proc.ProcessModule();
				return proc;
			}
		}

		private void AddModule(string name, string altName, ITypeResolver proc) {
			this.modules.Add(name, proc);
			if (name != altName)
				this.modules.Add(altName, proc);
		}

		private string MakeAssemblyNameIntoFilename(string name) {
			if (!name.EndsWith(".dll"))
				return name + ".dll";
			return name;
		}

		private IType ResolveTypeSpecification(TypeSpecification typeSpec, IGenericScope genericScope) {
			if (typeSpec is ArrayType) {
				var arrayType = (ArrayType)typeSpec;
				var elementProc = ResolveTypeReference(arrayType.ElementType, genericScope);
				Type realType;
				if (arrayType.Rank == 1)
					realType = elementProc.Type.MakeArrayType();
				else
					realType = elementProc.Type.MakeArrayType(arrayType.Rank);
				var externalWrapper = new ExternalType(this, realType);
				return externalWrapper;
			}

			if (typeSpec is GenericInstanceType) {
				var typeDef = typeSpec.Resolve();
				var genericTypeProc = ResolveTypeReference(typeDef, genericScope);
				var genericInstanceType = (GenericInstanceType)typeSpec;
				var genericArgumentRefs = genericInstanceType.GenericArguments.Cast<TypeReference>();
				var typeArguments = genericArgumentRefs.Select(x => ResolveTypeReference(x, genericScope).Type).ToArray();
				var concreteType = genericTypeProc.Type.MakeGenericType(typeArguments);
				if (genericTypeProc is ExternalType) {
					return new ExternalType(this, concreteType);
				}
				else {
					return new GenericType(this, (TypeProcessor)genericTypeProc, concreteType);
				}
			}

			throw new NotSupportedException();
		}

		#region IResolver Members

		public IType ResolveTypeReference(TypeReference typeRef, IGenericScope genericScope) {
			if (typeRef.FullName == Constants.Void) {
				return ExternalType.Void;
			}

			if (typeRef is TypeSpecification) {
				return ResolveTypeSpecification((TypeSpecification)typeRef, genericScope);
			}

			if (typeRef is GenericParameter) {
				var type = genericScope.ResolveGenericParameter(typeRef);
				var simpleType = new SimpleType(type);
				return simpleType;
			}

			var scope = typeRef.Scope;
			string key;
			if (scope == null)
				key = ConstantNames.Mscorlib;
			else
				key = scope.Name;
			var moduleProc = this.modules[key];
			var typeProc = moduleProc.ResolveTypeReference(typeRef, genericScope);
			return typeProc;
		}

		public MethodBase ResolveMethodReference(MethodReference methodRef, IGenericScope genericScope) {
			var type = ResolveTypeReference(methodRef.DeclaringType, genericScope);
			if (type == null)
				throw new NullReferenceException(string.Format("Could not find DeclaringType for method: {0}", methodRef.ToString()));
			return type.ResolveMethod(methodRef);
		}

		public FieldInfo ResolveFieldReference(FieldReference fieldRef, IGenericScope genericScope) {
			var fieldDef = fieldRef.Resolve();
			var type = ResolveTypeReference(fieldDef.DeclaringType, genericScope);
			if (type == null)
				throw new NullReferenceException(string.Format("Could not find DeclaringType for field: {0}", fieldRef.ToString()));
			return type.ResolveField(fieldDef);
		}

		#endregion
	}
}
