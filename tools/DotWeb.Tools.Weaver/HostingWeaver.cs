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
		private AssemblyBuilder asmBuilder;
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

		public void ProcessAssembly(string asmPath, string fileName) {
			var asmDef = AssemblyFactory.GetAssembly(asmPath);

			foreach (CustomAttribute item in asmDef.CustomAttributes) {
				if (item.Constructor.DeclaringType.Name == "AssemblyWeavedAttribute") {
					Console.WriteLine("This assembly has already been weaved and is ready for hosted mode");
					return;
				}
			}

			var asmName = new AssemblyName(asmDef.Name.FullName);
			//var ext = Path.GetExtension(asmPath);
			//string fileName = asmName.Name + ext;

			this.asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save, this.outputDir);
//			var moduleBuilder = this.asmBuilder.DefineDynamicModule(asmDef.Name.Name, fileName, true);

			ProcessAssembly(asmDef);

			if (asmDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this, asmDef, asmBuilder);
			}

			var type = typeof(AssemblyWeavedAttribute);
			var ctor = type.GetConstructor(Type.EmptyTypes);
			this.asmBuilder.SetCustomAttribute(new CustomAttributeBuilder(ctor, new object[0]));

			this.asmBuilder.Save(fileName);
		}

		private void ProcessAssembly(AssemblyDefinition asmDef) {
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

			var asmProc = new AssemblyProcessor(this, asmDef, this.asmBuilder);
			string name = asmDef.MainModule.Name;
			string altName = Path.GetFileNameWithoutExtension(name);
			this.modules.Add(name, asmProc);
			if (name != altName)
				this.modules.Add(altName, asmProc);

			asmProc.ProcessModule();
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
			//var methodDef = methodRef.Resolve();
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
