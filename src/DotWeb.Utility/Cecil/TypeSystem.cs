using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

using TypeSet = System.Collections.Generic.HashSet<Mono.Cecil.TypeDefinition>;
using MethodSet = System.Collections.Generic.HashSet<Mono.Cecil.MethodDefinition>;

namespace DotWeb.Utility.Cecil
{
	public class TypeSystem
	{
		public static class Names
		{
			public const string DotWebSystem = "DotWeb.System";
			public const string DllSuffix = ".dll";
		}

		public TypeDefinitionCache TypeDefinitionCache { get; private set; }

		private IAssemblyResolver asmResolver;
		private Dictionary<TypeDefinition, TypeSet> baseToDerviedMap = new Dictionary<TypeDefinition, TypeSet>();
		private Dictionary<MethodDefinition, MethodSet> virtualMethodOverrides = new Dictionary<MethodDefinition, MethodSet>();
		private List<AssemblyDefinition> assemblies = new List<AssemblyDefinition>();
		private AssemblyDefinition asmSystem;

		public TypeSystem(IAssemblyResolver resolver) {
			this.asmResolver = resolver;
			this.asmSystem = this.asmResolver.Resolve(Names.DotWebSystem);
			this.TypeDefinitionCache = new TypeDefinitionCache(this);
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

		public TypeDefinition GetTypeDefinition(string typeName) {
			return this.asmSystem.MainModule.Types[typeName];
		}

		public TypeDefinition GetTypeDefinition(Type type) {
			return GetTypeDefinition(type.FullName);
		}

		public static Type GetReflectionType(TypeReference type) {
			switch (type.FullName) {
				case Constants.Boolean:
					return typeof(Boolean);
				case Constants.Byte:
					return typeof(Byte);
				case Constants.Char:
					return typeof(Char);
				case Constants.Double:
					return typeof(Double);
				case Constants.Enum:
					return typeof(Enum);
				case Constants.Int16:
					return typeof(Int16);
				case Constants.Int32:
					return typeof(Int32);
				case Constants.Int64:
					return typeof(Int64);
				case Constants.IntPtr:
					return typeof(IntPtr);
				case Constants.Object:
					return typeof(Object);
				case Constants.SByte:
					return typeof(SByte);
				case Constants.Single:
					return typeof(Single);
				case Constants.String:
					return typeof(String);
				case Constants.Type:
					return typeof(Type);
				case Constants.UInt16:
					return typeof(UInt16);
				case Constants.UInt32:
					return typeof(UInt32);
				case Constants.UInt64:
					return typeof(UInt64);
				case Constants.UIntPtr:
					return typeof(UIntPtr);
				case Constants.Void:
					return typeof(void);
				case ConstantTypeNames.Delegate:
					return typeof(Delegate);
				default:
					return typeof(object);
			}
		}

		//public static string GetScopeName(IMetadataScope scope) {
		//    string name = scope.Name;
		//    if (name.EndsWith(Names.DllSuffix)) {
		//        var index = name.Length - Names.DllSuffix.Length;
		//        return name.Substring(0, index);
		//    }
		//    return name;
		//}

		public bool IsEquivalent(TypeReference typeRef, Type reflectionType) {
			if (typeRef == null)
				return false;

			var def = GetTypeDefinition(reflectionType);
			return IsEquivalent(typeRef, def);
		}

		public bool IsEquivalent(TypeReference lhs, TypeReference rhs) {
			return (lhs.Resolve() == rhs.Resolve());
		}
		//    if (lhs == null || rhs == null)
		//        return false;

		//    var lhsDef = lhs.Resolve();
		//    var rhsDef = rhs.Resolve();

		//    string lhsScopeName = GetScopeName(lhsDef.Scope);
		//    string rhsScopeName = GetScopeName(rhsDef.Scope);
		//    return lhsScopeName == rhsScopeName && lhsDef.MetadataToken == rhsDef.MetadataToken;
		//}

		//public bool IsEquivalent(TypeReference lhs, string typeName) {
		//    TypeReference rhs = asmSystem.MainModule.Types[typeName];
		//    if (lhs == null || rhs == null)
		//        return false;

		//    return IsEquivalent(lhs, rhs);
		//}

		public bool IsDefined(ICustomAttributeProvider provider, string attributeTypeName) {
			TypeReference attributeType = asmSystem.MainModule.Types[attributeTypeName];
			return IsDefined(provider, attributeType);
		}

		public bool IsDefined(ICustomAttributeProvider provider, TypeReference attributeType) {
			foreach (CustomAttribute item in provider.CustomAttributes) {
				if (IsEquivalent(item.Constructor.DeclaringType, attributeType))
					return true;
			}
			return false;
		}

	}
}
