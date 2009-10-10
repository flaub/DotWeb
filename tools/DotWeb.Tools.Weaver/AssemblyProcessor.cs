using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using SR = System.Reflection;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using System.IO;

using CecilOpCode = Mono.Cecil.Cil.OpCode;
using CecilOpCodes = Mono.Cecil.Cil.OpCodes;

using SysOpCode = System.Reflection.Emit.OpCode;
using SysOpCodes = System.Reflection.Emit.OpCodes;
using DotWeb.Utility;

namespace DotWeb.Tools.Weaver
{
	interface IType
	{
		Type Type { get; }
		MethodBase ResolveMethod(MethodDefinition methodDef);
		FieldInfo ResolveField(FieldDefinition fieldDef);
		void Close();
	}

	public class AssemblyProcessor : IResolver
	{
		public string InputDir { get; private set; }
		public string OutputDir { get; private set; }
		public DefaultAssemblyResolver Resolver { get; private set; }

		private AssemblyDefinition asmDef;
		private AssemblyBuilder asmBuilder;
		private ModuleBuilder moduleBuilder;
//		private AssemblyDefinition dwSysAssembly;

		private Dictionary<string, IType> typesByDef = new Dictionary<string, IType>();

		public AssemblyProcessor(string inputDir, string outputDir) {
			this.InputDir = inputDir;
			this.OutputDir = outputDir;
			this.Resolver = new DefaultAssemblyResolver();
			this.Resolver.AddSearchDirectory(this.InputDir);

//			var sysType = typeof(DotWeb.System.Object);
//			this.dwSysAssembly = this.Resolver.Resolve(sysType.Assembly.FullName);
//			this.dwSysAssembly.MainModule.LoadSymbols();
		}

		public void ProcessAssembly(string asmPath) {
			this.asmDef = AssemblyFactory.GetAssembly(asmPath);
//			var asmDef = this.Resolver.Resolve(asmQualifiedTypeName.AssemblyName.FullName);
			asmDef.MainModule.LoadSymbols();

			var ext = Path.GetExtension(asmPath);
			var asmName = new AssemblyName(asmDef.Name.FullName);
			string fileName = asmName.Name + ext;

			this.asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save, this.OutputDir);
			this.moduleBuilder = asmBuilder.DefineDynamicModule(fileName, fileName, true);

			foreach (TypeDefinition typeDef in asmDef.MainModule.Types) {
				if (typeDef.Name == Constants.ModuleType)
					continue;

				IType item;
				if (!this.typesByDef.TryGetValue(typeDef.FullName, out item)) {
					item = ProcessType(typeDef);
				}
				var typeProc = (TypeProcessor)item;
				typeProc.ProcessAll();
			}

			this.asmBuilder.Save(fileName);
		}

		public string ProcessEntry(AssemblyQualifiedTypeName asmQualifiedTypeName) {
			var asmDef = this.Resolver.Resolve(asmQualifiedTypeName.AssemblyName.FullName);
			asmDef.MainModule.LoadSymbols();
			//asmDef.MainModule.FullLoad();

			var startType = asmDef.MainModule.Types[asmQualifiedTypeName.TypeName];

			var asmName = new AssemblyName("Hosted-" + asmQualifiedTypeName.AssemblyName.FullName);
			string fileName = asmName.Name + ".dll";

			this.asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save, this.OutputDir);
			this.moduleBuilder = asmBuilder.DefineDynamicModule(fileName, fileName, true);

			var typeProc = (TypeProcessor)ProcessType(startType);
			var ctor = startType.Constructors.GetConstructor(false, Type.EmptyTypes);
			typeProc.ProcessConstructor(ctor);

			foreach (var item in this.typesByDef) {
				item.Value.Close();
			}

			this.asmBuilder.Save(fileName);

			string outPath = Path.Combine(this.OutputDir, fileName);
			return outPath;
		}

		private string GetTypeKey(TypeReference typeRef) {
//			if (typeRef.Scope.Name.StartsWith("DotWeb.System")) {
//				return "DotWeb." + typeRef.FullName;
//			}
			return typeRef.FullName;
//			var scope = Path.GetFileNameWithoutExtension(typeRef.Scope.Name);
//			return string.Format("{0}, {1}", typeRef.FullName, scope);
		}

		private IType ResolveType(TypeReference typeRef) {
			IType type;
			string key = GetTypeKey(typeRef);
			if (!this.typesByDef.TryGetValue(key, out type)) {
				type = ProcessType(typeRef);
			}

			return type;
		}

		internal IType ProcessType(TypeReference typeRef) {
			if (typeRef.Scope == this.asmDef.MainModule) {
				// internal reference
				var typeProc = new TypeProcessor(this, typeRef, this.moduleBuilder);
				RegisterType(typeRef, typeProc);
				return typeProc;
			}
			else {
				// external reference
				var type = Type.GetType(typeRef.FullName);
				var extType = new ExternalType(this, type);
				RegisterType(typeRef, extType);
				return extType;
			}

			//if (typeRef.Namespace.StartsWith("System")) {
			//    var typeDef = typeRef.Resolve();

			//    if (IsDotWebInternal(typeDef)) {
			//    //if (typeDef.Scope.Name == "DotWeb.System.dll") {
			//        //var arrayType = typeRef as ArrayType;
			//        //if (arrayType != null) {
			//        //    var elementType = ResolveTypeReference(arrayType.ElementType);
			//        //    var type = elementType.MakeArrayType(arrayType.Rank);
			//        //    var sysType = new SystemType(this, type);
			//        //    RegisterType(typeRef, sysType);
			//        //    return sysType;
			//        //}
			//        //else {
			//            string fullName = "DotWeb." + typeRef.FullName;
			//            var type = this.dwSysAssembly.MainModule.Types[fullName];
			//            var typeProc = new TypeProcessor(this, type, this.moduleBuilder);
			//            RegisterType(typeRef, typeProc);
			//            return typeProc;
			//        //}
			//    }
			//    else {
			//        var type = Type.GetType(typeRef.FullName);
			//        var sysType = new SystemType(this, type);
			//        RegisterType(typeRef, sysType);
			//        return sysType;
			//    }
			//}
			//else {
			//    var typeProc = new TypeProcessor(this, typeRef, this.moduleBuilder);
			//    RegisterType(typeRef, typeProc);
			//    return typeProc;
			//}
		}

		private void RegisterType(TypeReference typeRef, IType typeProc) {
			string key = GetTypeKey(typeRef);
			this.typesByDef.Add(key, typeProc);
		}

		private bool IsDotWebInternal(TypeReference typeRef) {
			foreach (CustomAttribute item in typeRef.CustomAttributes) {
				if (item.Constructor.DeclaringType.Name == "DotWebInternal") {
					return true;
				}
			}
			return false;
		}

		public Type[] ResolveParameterTypes(ParameterDefinitionCollection parameters) {
			return parameters.Cast<ParameterDefinition>().Select(x => this.ResolveTypeReference(x.ParameterType)).ToArray();
		}

		public Type ResolveTypeReference(TypeReference typeRef) {
			if (typeRef.FullName == Constants.Void) {
				return typeof(void);
			}
			var type = ResolveType(typeRef);
			return type.Type;
		}

		public MethodBase ResolveMethodReference(MethodReference methodRef) {
			var methodDef = methodRef.Resolve();
			var type = ResolveType(methodDef.DeclaringType);
			if (type == null)
				throw new NullReferenceException(string.Format("Could not find DeclaringType for method: {0}", methodRef.ToString()));
			return type.ResolveMethod(methodDef);
		}

		public FieldInfo ResolveFieldReference(FieldReference fieldRef) {
			var fieldDef = fieldRef.Resolve();
			var type = ResolveType(fieldDef.DeclaringType);
			if (type == null)
				throw new NullReferenceException(string.Format("Could not find DeclaringType for field: {0}", fieldRef.ToString()));
			return type.ResolveField(fieldDef);
		}
	}
}
