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
using Castle.Core.Interceptor;

namespace DotWeb.Sandbox
{
	interface IType
	{
		Type Type { get; }
		MethodBase ResolveMethod(MethodDefinition methodDef);
		void Close();
	}

	class Hoister
	{
		public string InputDir { get; private set; }
		public string OutputDir { get; private set; }
		public DefaultAssemblyResolver Resolver { get; private set; }
//		public AssemblyDefinition SystemAssemblyDefinition { get; private set; }

		private AssemblyBuilder asmBuilder;
		private ModuleBuilder moduleBuilder;
//		private Assembly dwSysAssembly;
		private AssemblyDefinition dwSysAssembly;

		private Dictionary<string, IType> typesByDef = new Dictionary<string, IType>();

		public Hoister(string inputDir, string outputDir) {
			this.InputDir = inputDir;
			this.OutputDir = outputDir;
			this.Resolver = new DefaultAssemblyResolver();
			this.Resolver.AddSearchDirectory(this.InputDir);

			var sysType = typeof(DotWeb.System.Object);
//			this.dwSysAssembly = sysType.Assembly;
			this.dwSysAssembly = this.Resolver.Resolve(sysType.Assembly.FullName);
			this.dwSysAssembly.MainModule.LoadSymbols();
			//this.SystemAssemblyDefinition.MainModule.FullLoad();
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
			typeProc.ProcessConstructor(false, Type.EmptyTypes);

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

		class SystemType : IType
		{
			private Hoister hoister;

			public SystemType(Hoister hoister, Type type) {
				this.hoister = hoister;
				this.Type = type;
			}

			public Type Type { get; private set; }

			public MethodBase ResolveMethod(MethodDefinition methodDef) {
				var types = this.hoister.ResolveParameterTypes(methodDef.Parameters);
				if (methodDef.IsConstructor) {
					return this.Type.GetConstructor(types);
				}
				else {
					return this.Type.GetMethod(methodDef.Name, types);
				}
			}

			public void Close() {
			}
		}

		public Type[] ResolveParameterTypes(ParameterDefinitionCollection parameters) {
			return parameters.Cast<ParameterDefinition>().Select(x => this.ResolveTypeReference(x.ParameterType)).ToArray();
		}

		public IType ProcessType(TypeReference typeRef) {
			if (typeRef.Namespace.StartsWith("System")) {
				var typeDef = typeRef.Resolve();

				if (IsDotWebInternal(typeDef)) {
				//if (typeDef.Scope.Name == "DotWeb.System.dll") {
					//var arrayType = typeRef as ArrayType;
					//if (arrayType != null) {
					//    var elementType = ResolveTypeReference(arrayType.ElementType);
					//    var type = elementType.MakeArrayType(arrayType.Rank);
					//    var sysType = new SystemType(this, type);
					//    RegisterType(typeRef, sysType);
					//    return sysType;
					//}
					//else {
						string fullName = "DotWeb." + typeRef.FullName;
						var type = this.dwSysAssembly.MainModule.Types[fullName];
						var typeProc = new TypeProcessor(this, type, this.moduleBuilder);
						RegisterType(typeRef, typeProc);
						return typeProc;
					//}
				}
				else {
					var type = Type.GetType(typeRef.FullName);
					var sysType = new SystemType(this, type);
					RegisterType(typeRef, sysType);
					return sysType;
				}
			}
			else {
				var typeProc = new TypeProcessor(this, typeRef, this.moduleBuilder);
				RegisterType(typeRef, typeProc);
				return typeProc;
			}
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
			return type.ResolveMethod(methodDef);
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
	}
}
