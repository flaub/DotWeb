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
// 
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
using System.Runtime.CompilerServices;

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
			public const string Mscorlib = "mscorlib";
			public const string SystemCore = "System.Core";
			public const string DotWebCoreLib = "DotWebCoreLib";
			public const string HostedPrefix = "Hosted-";
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

			var visited = new HashSet<string>();
			visited.Add(ConstantNames.Mscorlib);
			visited.Add(ConstantNames.SystemCore);
			visited.Add(ConstantNames.DotWebCoreLib);

			var tasks = new List<AssemblyDefinition>();
			GetTaskList(asmDef, visited, tasks);

			foreach (var task in tasks) {
				ProcessAssembly(task);
			}

			var outputPath = HostedPath(asmDef.Name);
			return SR.Assembly.LoadFrom(outputPath);
		}

		private string HostedName(AssemblyNameReference asmRef) {
			if (!asmRef.Name.StartsWith(ConstantNames.HostedPrefix)) {
				return ConstantNames.HostedPrefix + asmRef.Name;
			}
			return asmRef.Name;
		}

		private string InputPath(AssemblyNameReference asmRef) {
			return Path.Combine(this.inputDir, MakeAssemblyNameIntoFilename(asmRef.Name));
		}

		private string HostedPath(AssemblyNameReference asmRef) {
			var hostedName = HostedName(asmRef);
			return Path.Combine(this.outputDir, MakeAssemblyNameIntoFilename(hostedName));
		}

		private bool NeedsProcessing(AssemblyNameReference asmRef) {
			var inputPath = InputPath(asmRef);
			var outputPath = HostedPath(asmRef);
			if (!this.forceBuild && 
				File.Exists(outputPath) &&
				File.GetLastWriteTime(inputPath) < File.GetLastWriteTime(outputPath))
				return false;
			return true;
		}

		private void GetTaskList(AssemblyDefinition asmDef, HashSet<string> visited, List<AssemblyDefinition> tasks) {
			foreach (var asmRef in asmDef.MainModule.AssemblyReferences.Originals(visited, x => x.Name)) {
				var dependency = this.resolver.Resolve(asmRef);
				GetTaskList(dependency, visited, tasks);
			}

			if(NeedsProcessing(asmDef.Name))
				tasks.Add(asmDef);
		}

		private string ProcessAssembly(AssemblyDefinition asmDef) {
			RedirectAssemblyReferences(asmDef);

			var templates = PrepareTemplates(asmDef.MainModule);
			foreach (var typeDef in asmDef.MainModule.Types) {
				ProcessType(typeDef, templates);
			}

			return SaveAssembly(asmDef);
		}

		private void RedirectAssemblyReferences(AssemblyDefinition asmDef) {
			foreach (var asmRef in asmDef.MainModule.AssemblyReferences) {
				if (asmRef.Name == ConstantNames.Mscorlib || asmRef.Name == ConstantNames.SystemCore)
					continue;
				if (asmRef.Name == ConstantNames.DotWebCoreLib) {
					ReplaceAssemblyReference(asmRef, asmRefMscorlib);
				}
				else {
					asmRef.Name = HostedName(asmRef);
				}
			}
		}

		private void ReplaceAssemblyReference(AssemblyNameReference lhs, AssemblyNameReference rhs) {
			lhs.Name = rhs.Name;
			lhs.Version = rhs.Version;
			lhs.Culture = rhs.Culture;
			lhs.Hash = rhs.Hash;
			lhs.HashAlgorithm = rhs.HashAlgorithm;
			lhs.HasPublicKey = rhs.HasPublicKey;
			lhs.IsRetargetable = rhs.IsRetargetable;
			lhs.IsSideBySideCompatible = rhs.IsSideBySideCompatible;
			lhs.PublicKey = rhs.PublicKey;
			lhs.PublicKeyToken = rhs.PublicKeyToken;
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
			var name = HostedName(asmDef.Name);
			asmDef.Name.Name = name;
			asmDef.MainModule.Name = name;

			var outputPath = HostedPath(asmDef.Name);
			asmDef.Write(outputPath, new WriterParameters {
				SymbolWriterProvider = AssemblyResolver.GetPlatformWriterProvider()
			});
			return outputPath;
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

			foreach (var iface in typeDef.Interfaces) {
				ConvertCustomAttributes(iface.Resolve(), templates);
			}

			foreach (var property in typeDef.Properties) {
				ConvertCustomAttributes(property, templates);
			}

			return true;
		}

		private void ProcessMethod(MethodDefinition methodDef, Dictionary<string, MethodReference> templates) {
			ConvertCustomAttributes(methodDef, templates);

			if (methodDef.HasBody) {
				if (methodDef.Body.CodeSize == 0) {
					GenerateExternMethodBody(methodDef);
				}
				else {
					ProcessCasts(methodDef);
				}
			}
		}

		private void ProcessCasts(MethodDefinition methodDef) {
			var module = methodDef.DeclaringType.Module;
			var generator = methodDef.Body.GetILProcessor();

			var casts = methodDef.Body.Instructions.Where(x => x.OpCode == OpCodes.Castclass).ToArray();
			foreach (var cast in casts) {
				var castType = module.Import(PredefinedTypes.Object);
				var castVar = new VariableDefinition(castType);
				methodDef.Body.Variables.Add(castVar);

				var storeCast = generator.Create(OpCodes.Stloc, castVar);
				var getHost = generator.Create(OpCodes.Call, module.Import(PredefinedTypes.HostedMode_get_Host));
				var loadCast = generator.Create(OpCodes.Ldloc, castVar);
				var castMethodRef = module.Import(PredefinedTypes.IDotWebHost_Cast);
				var castMethod = new GenericInstanceMethod(castMethodRef);
				castMethod.GenericArguments.Add((TypeReference)cast.Operand);
				var callCast = generator.Create(OpCodes.Callvirt, castMethod);
				
				generator.Replace(cast, storeCast);
				generator.InsertAfter(storeCast, getHost);
				generator.InsertAfter(getHost, loadCast);
				generator.InsertAfter(loadCast, callCast);
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
			public static readonly Type JsNamespace = typeof(JsNamespaceAttribute);
			public static readonly Type JsAnonymous = typeof(JsAnonymousAttribute);
			public static readonly Type JsIntrinsic = typeof(JsIntrinsicAttribute);
			public static readonly Type JsObject = typeof(JsObjectAttribute);
			public static readonly Type JsDynamic = typeof(JsDynamicAttribute);
			public static readonly Type Extension = typeof(ExtensionAttribute);

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
				PrepareJsAttribute(JsNamespace);
				PrepareJsAttribute(JsAnonymous);
				PrepareJsAttribute(JsIntrinsic);
				PrepareJsAttribute(JsObject);
				PrepareJsAttribute(JsDynamic);
				PrepareJsAttribute(Extension);
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
