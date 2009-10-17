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
		private string inputDir;
		private string outputDir;
		private DefaultAssemblyResolver asmResolver = new DefaultAssemblyResolver();
		private Dictionary<string, ITypeResolver> modules = new Dictionary<string, ITypeResolver>();

		public HostingWeaver(string inputDir, string outputDir) {
			this.inputDir = inputDir;
			this.outputDir = outputDir;
			this.asmResolver.AddSearchDirectory(this.inputDir);

			PrepareMscorlib();
		}

		private void PrepareMscorlib() {
			var sysType = typeof(object);
			var asm = sysType.Assembly;
			var asmName = AssemblyNameReference.Parse(asm.FullName);

			var asmDef = this.asmResolver.Resolve(asmName);
			var extAsm = new ExternalAssembly(this, asm);
			this.modules.Add("mscorlib", extAsm);
		}

		private void PrepareDotWebSystem() {
			var proc = new DotWebSystemAssembly(this);
			this.modules.Add("DotWeb.System", proc);
			this.modules.Add("DotWeb.System.dll", proc);
		}

		public Assembly ProcessAssembly(string asmPath) {
			var asmDef = AssemblyFactory.GetAssembly(asmPath);

			foreach (CustomAttribute item in asmDef.CustomAttributes) {
				if (item.Constructor.DeclaringType.Name == "AssemblyWeavedAttribute") {
					Console.WriteLine("This assembly has already been weaved and is ready for hosted mode");
					return Assembly.LoadFrom(asmPath);
				}
			}

			//string name = Path.GetFileNameWithoutExtension(fileName);
			//var asmName = new AssemblyName(name);
			//var ext = Path.GetExtension(asmPath);
			//string fileName = asmName.Name + ext;

//			this.asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave, this.outputDir);
//			var moduleBuilder = this.asmBuilder.DefineDynamicModule(asmDef.Name.Name, fileName, true);

			return ProcessAssembly(asmDef);
		}

		private Assembly ProcessAssembly(AssemblyDefinition asmDef) {
			foreach (AssemblyNameReference asmRef in asmDef.MainModule.AssemblyReferences) {
				if (this.modules.ContainsKey(asmRef.Name))
					continue;

				if (asmRef.Name == "DotWeb.System") {
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
				key = "mscorlib";
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
