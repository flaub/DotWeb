using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SR = System.Reflection;
using DotWeb.Utility;
using DotWeb.Utility.Cecil;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace DotWeb.Hosting.Weaver
{
	/// <summary>
	/// The weaver needs to complete two tasks:
	/// 1) Patch extern methods to hook them into the host
	/// 2) Modify dependant assembly references to weaved ones
	/// 
	/// An additional requirement is that a valid .pdb file is produced along with the weaved assembly
	/// The end result should be an assembly that can be hosted in the debugger
	/// </summary>

	public class SimpleWeaver
	{
		class ConstantNames
		{
			public const string DotWebSystem = "DotWeb.System";
			public const string DotWebSystemDll = "DotWeb.System.dll";
			public const string Mscorlib = "mscorlib";
			public const string SystemCore = "System.Core";
			public const string SystemCoreDll = "System.Core.dll";
			public const string AssemblyWeavedAttribute = "AssemblyWeavedAttribute";
			public const string CommonLanguageRuntimeLibrary = "CommonLanguageRuntimeLibrary";
		}

		private bool forceBuild;
		private string inputDir;
		private string outputDir;
		private AssemblyResolver resolver = new AssemblyResolver();
		private AssemblyNameReference asmRefMscorlib = AssemblyNameReference.Parse(typeof(object).Assembly.FullName);

		public SimpleWeaver(string inputDir, string outputDir, string[] searchDirs, bool forceBuild) {
			this.inputDir = inputDir;
			this.outputDir = outputDir;
			this.forceBuild = forceBuild;

			this.resolver.AddSearchDirectory(this.inputDir);
			if (searchDirs != null) {
				foreach (var dir in searchDirs) {
					this.resolver.AddSearchDirectory(dir);
				}
			}
		}

		public SR.Assembly ProcessAssembly(string asmPath) {
			var asmDef = this.resolver.GetAssembly(asmPath, true);
			foreach (var item in asmDef.CustomAttributes) {
				if (item.Constructor.DeclaringType.Name == ConstantNames.AssemblyWeavedAttribute) {
					Console.WriteLine("This assembly has already been weaved and is ready for hosted mode");
					return SR.Assembly.LoadFrom(asmPath);
				}
			}

			var visited = new HashSet<string>();
			visited.Add("mscorlib");
			visited.Add("System.Core");
			visited.Add("DotWebCoreLib");

			var path = ProcessAssembly(asmDef, visited);
			return SR.Assembly.LoadFrom(path);
		}

		const string HostedPrefix = "Hosted-";

		private string ProcessAssembly(AssemblyDefinition asmDef, HashSet<string> visited) {
			var asmRefs = asmDef.MainModule.AssemblyReferences;
			foreach (var asmRef in asmRefs.Originals(visited, x => x.Name)) {
				var child = this.resolver.Resolve(asmRef);
				ProcessAssembly(child, visited);
			}

			foreach (var asmRef in asmRefs) {
				if (asmRef.Name == "mscorlib")
					continue;
				if (asmRef.Name == "System.Core")
					continue;
				if (asmRef.Name == "DotWebCoreLib") {
					asmRef.Name = asmRefMscorlib.Name;
					asmRef.Version = asmRefMscorlib.Version;
					asmRef.Culture = asmRefMscorlib.Culture;
					asmRef.Hash = asmRefMscorlib.Hash;
					asmRef.HashAlgorithm = asmRefMscorlib.HashAlgorithm;
					asmRef.HasPublicKey = asmRefMscorlib.HasPublicKey;
					asmRef.IsRetargetable = asmRefMscorlib.IsRetargetable;
					asmRef.IsSideBySideCompatible = asmRefMscorlib.IsSideBySideCompatible;
					asmRef.PublicKey = asmRefMscorlib.PublicKey;
					asmRef.PublicKeyToken = asmRefMscorlib.PublicKeyToken;
				}
				else {
					var name = asmRef.Name;
					if (!name.StartsWith(HostedPrefix)) {
						name = HostedPrefix + name;
						asmRef.Name = name;
					}
				}
			}

			var templates = PrepareTemplates(asmDef.MainModule);
			foreach (var typeDef in asmDef.MainModule.Types) {
				ProcessType(typeDef, templates);
			}

			return SaveAssembly(asmDef);
		}

		private Dictionary<string, MethodReference> PrepareTemplates(ModuleDefinition module) {
			var templates = new Dictionary<string, MethodReference>();
			foreach (var ctor in PredefinedTypes.JsAttributes) {
				var methodRef = module.Import(ctor);
				templates.Add(methodRef.ToString(), methodRef);
			}
			return templates;
		}

		private string SaveAssembly(AssemblyDefinition asmDef) {
			string name = asmDef.Name.Name;
			if (!name.StartsWith(HostedPrefix)) {
				name = HostedPrefix + name;
				asmDef.Name.Name = name;
				asmDef.MainModule.Name = name;
			}

			string path = Path.Combine(this.outputDir, MakeAssemblyNameIntoFilename(name));
			asmDef.Write(path, new WriterParameters {
				SymbolWriterProvider = AssemblyResolver.GetPlatformWriterProvider()
			});
			return path;
		}

		private string MakeAssemblyNameIntoFilename(string name) {
			if (!name.EndsWith(".dll"))
				return name + ".dll";
			return name;
		}

		class CustomAttributePair
		{
			public CustomAttribute OldAttribute;
			public CustomAttribute NewAttribute;
		}

		private void CopyCollection<T>(Collection<T> from, Collection<T> into) {
			foreach (var item in from) {
				into.Add(item);
			}
		}

		private void ConvertCustomAttributes(ICustomAttributeProvider provider, Dictionary<string, MethodReference> templates) {
			if (provider.HasCustomAttributes) {
				var list = new List<CustomAttributePair>();
				foreach (var oldAttr in provider.CustomAttributes) {
					MethodReference ctor;
					if (templates.TryGetValue(oldAttr.Constructor.ToString(), out ctor)) {
						var newAttr = new CustomAttribute(ctor);
						CopyCollection(oldAttr.ConstructorArguments, newAttr.ConstructorArguments);
						CopyCollection(oldAttr.Properties, newAttr.Properties);
						CopyCollection(oldAttr.Fields, newAttr.Fields);

						var pair = new CustomAttributePair {
							OldAttribute = oldAttr,
							NewAttribute = newAttr
						};

						list.Add(pair);
					}
				}

				foreach (var pair in list) {
					provider.CustomAttributes.Remove(pair.OldAttribute);
					provider.CustomAttributes.Add(pair.NewAttribute);
				}
			}
		}

		private bool ProcessType(TypeDefinition typeDef, Dictionary<string, MethodReference> templates) {
			ConvertCustomAttributes(typeDef, templates);

			foreach (var nestedType in typeDef.NestedTypes) {
				ProcessType(nestedType, templates);
			}

			foreach (var method in typeDef.Methods) {
				ProcessMethod(method, templates);
			}

			foreach (var field in typeDef.Fields) {
				ConvertCustomAttributes(field, templates);
			}

			return true;
		}

		private void ProcessMethod(MethodDefinition methodDef, Dictionary<string, MethodReference> templates) {
			ConvertCustomAttributes(methodDef, templates);

			var ns = methodDef.DeclaringType.Namespace;
			if (ns.StartsWith("System")) {
//				return ResolveWithThisType(methodDef);
			}

			if (methodDef.HasBody) {
				//if (methodDef.Body == null) {
				//    methodDef.Body = new MethodBody(methodDef);
				//}

				if (methodDef.Body.CodeSize == 0) {
					GenerateExternMethodBody(methodDef);
				}
			}
		}

		static class PredefinedTypes
		{
			public static readonly Type Arguments = typeof(object[]);
			public static readonly Type Object = typeof(object);
			public static readonly Type MethodBase = typeof(SR.MethodBase);
			public static readonly Type IDotWebHost = typeof(IDotWebHost);
			public static readonly Type HostedMode = typeof(HostedMode);

			public static readonly SR.MethodInfo HostedMode_get_Host;
			public static readonly SR.MethodInfo IDotWebHost_Invoke;
			public static readonly SR.MethodInfo IDotWebHost_Cast;
			public static readonly SR.MethodInfo MethodBase_GetCurrentMethod;
			public static readonly SR.ConstructorInfo Object_ctor;

			public static readonly Type JsCode = typeof(JsCodeAttribute);
			public static readonly Type JsMacro = typeof(JsMacroAttribute);
			public static readonly Type JsAugment = typeof(JsAugmentAttribute);
			public static readonly Type JsCamelCase = typeof(JsCamelCaseAttribute);
			public static readonly Type JsName = typeof(JsNameAttribute);

			public static readonly List<SR.ConstructorInfo> JsAttributes = new List<SR.ConstructorInfo>();

			static PredefinedTypes() {
				HostedMode_get_Host = HostedMode.GetMethod("get_Host");
				IDotWebHost_Invoke = IDotWebHost.GetMethod("Invoke");
				IDotWebHost_Cast = IDotWebHost.GetMethod("Cast");
				MethodBase_GetCurrentMethod = MethodBase.GetMethod("GetCurrentMethod");
				Object_ctor = Object.GetConstructor(Type.EmptyTypes);

				PrepareJsAttribute(JsCode);
				PrepareJsAttribute(JsMacro);
				PrepareJsAttribute(JsAugment);
				PrepareJsAttribute(JsCamelCase);
				PrepareJsAttribute(JsName);
			}

			private static void PrepareJsAttribute(Type type) {
				foreach (var ctor in type.GetConstructors()) {
					JsAttributes.Add(ctor);
				}
			}
		}

		private void GenerateExternMethodBody(MethodDefinition methodDef) {
			var module = methodDef.DeclaringType.Module;
			var generator = methodDef.Body.GetILProcessor();

			bool needsReturn = (methodDef.ReturnType.FullName != "System.Void");

			// constructors need to call their base class so that 'this' is initialized!
			// however, we don't want to call the real ctor, because it might not be setup at this time
			// also, the hosting bridge doesn't need to be called twice when calling the ctor on a dervied type.
			// thus, we'll just call the System.Object..ctor() instead, to appease .NET's reflection
			if (methodDef.IsConstructor) {
				generator.Emit(OpCodes.Ldarg_0);
				generator.Emit(OpCodes.Call, module.Import(PredefinedTypes.Object_ctor));
			}

			// __method = MethodBase.GetCurrentMethod();
			var methodBaseType = module.Import(PredefinedTypes.MethodBase);
			var methodVar = new VariableDefinition("__method", methodBaseType);
			methodDef.Body.Variables.Add(methodVar);

			generator.Emit(OpCodes.Call, module.Import(PredefinedTypes.MethodBase_GetCurrentMethod));
			generator.Emit(OpCodes.Stloc, methodVar);

			// var args = new object[argCount];
			var argsType = module.Import(PredefinedTypes.Arguments);
			var argsVar = new VariableDefinition("__args", argsType);
			methodDef.Body.Variables.Add(argsVar);

			var argCount = methodDef.Parameters.Count;
			generator.Emit(OpCodes.Ldc_I4, argCount);
			generator.Emit(OpCodes.Newarr, module.Import(PredefinedTypes.Object));
			generator.Emit(OpCodes.Stloc, argsVar);

			for (int i = 0; i < argCount; i++) {
				// __args[i] = <argument[i]>;
				generator.Emit(OpCodes.Ldloc, argsVar);
				generator.Emit(OpCodes.Ldc_I4, i);
				var arg = methodDef.Parameters[i];
				generator.Emit(OpCodes.Ldarg, arg);
				if (arg.ParameterType.IsValueType) {
					generator.Emit(OpCodes.Box, arg.ParameterType);
				}
				generator.Emit(OpCodes.Stelem_Ref);
			}

			// __ret = HostedMode.Host.Invoke(this|null, __method, __args); 
			generator.Emit(OpCodes.Call, module.Import(PredefinedTypes.HostedMode_get_Host));

			if (methodDef.IsStatic)
				generator.Emit(OpCodes.Ldnull);
			else
				generator.Emit(OpCodes.Ldarg_0);

			generator.Emit(OpCodes.Ldloc, methodVar);
			generator.Emit(OpCodes.Ldloc, argsVar);
			generator.Emit(OpCodes.Callvirt, module.Import(PredefinedTypes.IDotWebHost_Invoke));

			if (needsReturn) {
				var retVar = new VariableDefinition("__ret", module.Import(PredefinedTypes.Object));
				methodDef.Body.Variables.Add(retVar);

				// return __ret;
				generator.Emit(OpCodes.Stloc, retVar);
				generator.Emit(OpCodes.Ldloc, retVar);

				if (methodDef.ReturnType.IsValueType) {
					generator.Emit(OpCodes.Unbox_Any, methodDef.ReturnType);
				}
			}
			else {
				generator.Emit(OpCodes.Pop);
			}

			generator.Emit(OpCodes.Ret);
		}
	}
}
