using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

using TypeSet = System.Collections.Generic.HashSet<Mono.Cecil.TypeDefinition>;
using MethodSet = System.Collections.Generic.HashSet<Mono.Cecil.MethodDefinition>;
//using TypeInfoSet = System.Collections.Generic.HashSet<DotWeb.Utility.Cecil.TypeHierarchy.TypeInfo>;

namespace DotWeb.Utility.Cecil
{
	public class TypeHierarchy
	{
		//public class TypeInfo
		//{
		//    public TypeDefinition Definition { get; set; }
		//    public TypeSet DerivedTypes { get; private set; }
		//    public Dictionary<MethodDefinition, MethodSet> VirtualMethods { get; private set; }

		//    public override bool Equals(object obj) {
		//        return this.Definition.Equals(obj);
		//    }

		//    public override int GetHashCode() {
		//        return this.Definition.GetHashCode();
		//    }
		//}

		private GlobalAssemblyResolver asmResolver = new GlobalAssemblyResolver();
		private Dictionary<TypeDefinition, TypeSet> baseToDerviedMap = new Dictionary<TypeDefinition, TypeSet>();
		private Dictionary<MethodDefinition, MethodSet> virtualMethodOverrides = new Dictionary<MethodDefinition, HashSet<MethodDefinition>>();

		public TypeHierarchy(string searchPath) {
			if (searchPath != null) {
				this.asmResolver.AddSearchDirectory(searchPath);
			}
		}

		private string GetStableKey(TypeReference typeRef) {
			if (typeRef is ArrayType) {
				return typeRef.FullName;
			}

			return typeRef.Resolve().FullName;
		}

		public AssemblyDefinition LoadAssembly(string asmName) {
			var asmDef = this.asmResolver.Resolve(asmName);
			foreach (TypeDefinition typeDef in asmDef.MainModule.Types) {
				if (typeDef.BaseType != null) {
					ProcessType(typeDef);
				}
			}
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
