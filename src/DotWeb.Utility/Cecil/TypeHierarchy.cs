using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

using TypeSet = System.Collections.Generic.HashSet<Mono.Cecil.TypeDefinition>;
using MethodSet = System.Collections.Generic.HashSet<Mono.Cecil.MethodDefinition>;

namespace DotWeb.Utility.Cecil
{
	public class TypeHierarchy
	{
		private IAssemblyResolver asmResolver;
		private Dictionary<TypeDefinition, TypeSet> baseToDerviedMap = new Dictionary<TypeDefinition, TypeSet>();
		private Dictionary<MethodDefinition, MethodSet> virtualMethodOverrides = new Dictionary<MethodDefinition, MethodSet>();
		private List<AssemblyDefinition> assemblies = new List<AssemblyDefinition>();

		public TypeHierarchy(IAssemblyResolver resolver) {
			this.asmResolver = resolver;
		}

		public AssemblyDefinition LoadAssembly(string asmName) {
			var asmDef = this.asmResolver.Resolve(asmName);
			if (this.assemblies.Contains(asmDef))
				return asmDef;

			foreach (TypeDefinition typeDef in asmDef.MainModule.Types) {
				if (typeDef.BaseType != null) {
					ProcessType(typeDef);
				}
			}

			foreach (AssemblyNameReference asmRef in asmDef.MainModule.AssemblyReferences) {
				var child = this.asmResolver.Resolve(asmRef);
				LoadAssembly(child.Name.FullName);
			}

			this.assemblies.AddUnique(asmDef);

			return asmDef;
		}

		public TypeSet GetSubclasses(TypeReference baseType) {
			var baseDef = baseType.Resolve();
			TypeSet result;
			if (!this.baseToDerviedMap.TryGetValue(baseDef, out result)) {
				result = new TypeSet();
				this.baseToDerviedMap.Add(baseDef, result);
			}
			return result;
		}

		public bool IsSubclassOf(TypeReference subclassType, TypeReference baseType) {
			var subclasses = GetSubclasses(baseType);
			return subclasses.Contains(subclassType.Resolve());
		}

		public MethodSet GetOverridesForVirtualMethod(MethodDefinition method) {
			if (!method.IsVirtual)
				return null;

			MethodSet result;
			if (!this.virtualMethodOverrides.TryGetValue(method, out result)) {
				result = new MethodSet();
				this.virtualMethodOverrides.Add(method, result);
			}
			return result;
		}

		private Dictionary<string, MethodDefinition> CollectVirtualMethods(TypeDefinition typeDef) {
			var virtuals = new Dictionary<string, MethodDefinition>();
			foreach (MethodDefinition method in typeDef.Methods) {
				if (method.IsVirtual && !method.IsAbstract) {
					virtuals.Add(method.GetMethodSignature(), method);
				}
			}
			return virtuals;
		}

		private void ProcessMethodOverrides(Dictionary<string, MethodDefinition> virtuals, TypeDefinition baseDef) {
			if (virtuals.Count > 0) {
				foreach (MethodDefinition baseMethod in baseDef.Methods) {
					if (baseMethod.IsVirtual) {
						MethodDefinition overridenMethod;
						if (virtuals.TryGetValue(baseMethod.GetMethodSignature(), out overridenMethod)) {
							var overrides = GetOverridesForVirtualMethod(baseMethod);
							overrides.Add(overridenMethod);
						}
					}
				}
			}
		}

		private void ProcessType(TypeDefinition typeDef) {
			var virtuals = CollectVirtualMethods(typeDef);

			var baseType = typeDef.BaseType;
			while (baseType != null) {
				var baseDef = baseType.Resolve();
				var baseSet = GetSubclasses(baseType);
				baseSet.Add(typeDef);

				ProcessMethodOverrides(virtuals, baseDef);

				baseType = baseDef.BaseType;
			}

			foreach (TypeReference iface in typeDef.Interfaces) {
				var ifaceSet = GetSubclasses(iface.Resolve());
				ifaceSet.Add(typeDef);
			}
		}
	}
}
