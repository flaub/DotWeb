using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using System.IO;
using DotWeb.Utility;
using System.Diagnostics;

namespace DotWeb.Tools.Weaver
{
	public class AssemblyProcessor : ITypeResolver
	{
		private IResolver resolver;
		private AssemblyDefinition asmDef;
		private ModuleDefinition moduleDef;
		private ModuleBuilder moduleBuilder;

		private Dictionary<string, IType> typesByDef = new Dictionary<string, IType>();
		private List<IType> pendingCloses = new List<IType>();

		public AssemblyProcessor(IResolver resolver, AssemblyDefinition asmDef, AssemblyBuilder asmBuilder) {
			this.resolver = resolver;
			this.asmDef = asmDef;
			this.moduleDef = asmDef.MainModule;
			this.moduleDef.LoadSymbols();
			var asmName = asmDef.Name.Name;
			string fileName = asmName + ".dll";
			this.moduleBuilder = asmBuilder.DefineDynamicModule(asmName, fileName, true);
		}

		public void ProcessModule() {
			foreach (TypeDefinition typeDef in this.moduleDef.Types) {
				if (typeDef.Name == Constants.ModuleType)
					continue;

				IType item;
				if (!this.typesByDef.TryGetValue(typeDef.FullName, out item)) {
					item = ProcessType(typeDef);
				}

				item.Process();
			}

			foreach (var item in this.pendingCloses) {
				item.Close();
			}
		}

		//public string ProcessEntry(AssemblyQualifiedTypeName asmQualifiedTypeName) {
		//    this.asmDef = this.asmResolver.Resolve(asmQualifiedTypeName.AssemblyName.FullName);
		//    this.moduleDef = this.asmDef.MainModule;
		//    this.moduleDef.LoadSymbols();
		//    //asmDef.MainModule.FullLoad();

		//    var startType = asmDef.MainModule.Types[asmQualifiedTypeName.TypeName];

		//    var asmName = new AssemblyName("Hosted-" + asmQualifiedTypeName.AssemblyName.FullName);
		//    string fileName = asmName.Name + ".dll";

		//    this.asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save, this.OutputDir);
		//    this.moduleBuilder = asmBuilder.DefineDynamicModule(fileName, fileName, true);

		//    var typeProc = (TypeProcessor)ProcessType(startType);
		//    var ctor = startType.Constructors.GetConstructor(false, Type.EmptyTypes);
		//    typeProc.ProcessConstructor(ctor);

		//    foreach (var item in this.typesByDef) {
		//        item.Value.Close();
		//    }

		//    this.asmBuilder.Save(fileName);

		//    string outPath = Path.Combine(this.OutputDir, fileName);
		//    return outPath;
		//}

		private string GetTypeKey(TypeReference typeRef) {
//			if (typeRef.Scope.Name.StartsWith("DotWeb.System")) {
//				return "DotWeb." + typeRef.FullName;
//			}
			return typeRef.FullName;
//			var scope = Path.GetFileNameWithoutExtension(typeRef.Scope.Name);
//			return string.Format("{0}, {1}", typeRef.FullName, scope);
		}

		public IType ResolveTypeReference(TypeReference typeRef) {
			IType type;
			string key = GetTypeKey(typeRef);
			if (!this.typesByDef.TryGetValue(key, out type)) {
				type = ProcessType(typeRef);
			}

			return type;
		}

		private IType ProcessType(TypeReference typeRef) {
			var typeDef = typeRef.Resolve();
			if (typeDef.IsEnum) {
				var enumProc = new EnumProcessor(this.resolver, this, typeRef, this.moduleBuilder);
				RegisterType(typeRef, enumProc);
				return enumProc;
			}
			else {
				var typeProc = new TypeProcessor(this.resolver, this, typeRef, this.moduleBuilder);
				RegisterType(typeRef, typeProc);
				return typeProc;
			}
		}

		private void RegisterType(TypeReference typeRef, IType type) {
			string key = GetTypeKey(typeRef);
			this.typesByDef.Add(key, type);
		}

		internal void QueueClose(TypeProcessor type) {
			if (!this.pendingCloses.Contains(type))
				this.pendingCloses.Add(type);
		}
	}
}
