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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

using TypeSet = System.Collections.Generic.HashSet<Mono.Cecil.TypeDefinition>;
using MethodSet = System.Collections.Generic.HashSet<Mono.Cecil.MethodDefinition>;
using System.Diagnostics;

namespace DotWeb.Utility.Cecil
{
	public class VirtualsDictionary
	{
		private HashSet<MethodDefinition> methods = new HashSet<MethodDefinition>();

		public static MethodReference NormalizeMethod(GenericInstanceType declaringType, MethodReference methodRef) {
			var typeDef = declaringType.Resolve();
			var genericTypesByName = new Dictionary<string, TypeReference>();
			for (int i = 0; i < declaringType.GenericArguments.Count; i++) {
				var genericArgument = declaringType.GenericArguments[i];
				var genericParameter = typeDef.GenericParameters[i];
				genericTypesByName.Add(genericParameter.Name, genericArgument);
			}

			var returnType = methodRef.ReturnType;
			if (returnType is GenericParameter) {
				// try to resolve the type based on the context of the declaringType
				returnType = genericTypesByName[returnType.Name];
			}

			var reference = new MethodReference(methodRef.Name, returnType);
			reference.DeclaringType = methodRef.DeclaringType;
			foreach (ParameterDefinition parameter in methodRef.Parameters) {
				var parameterType = parameter.ParameterType;
				var genericParameter = parameterType as GenericParameter;
				if (genericParameter != null) {
					TypeReference found;
					if (genericTypesByName.TryGetValue(genericParameter.Name, out found)) {
						parameterType = found;
					}
				}
				reference.Parameters.Add(new ParameterDefinition(parameterType));
			}

			return reference;
		}

		public MethodDefinition FindMethodBySignature(TypeReference typeRef, MethodReference methodToFind) {
			var genericInstanceType = typeRef as GenericInstanceType;
			if (genericInstanceType != null) {
				methodToFind = NormalizeMethod(genericInstanceType, methodToFind);
			}

			var methodToFindSig = methodToFind.GetMethodSignature();
			var methodToFindSigWithTypeName = methodToFind.GetMethodSignatureWithTypeName();

			foreach (var virtualMethod in this.methods) {
				var sig = virtualMethod.GetMethodSignature();
				if (sig == methodToFindSig ||
					sig == methodToFindSigWithTypeName) {
					return virtualMethod;
				}
			}

			return null;
		}

		public void CollectVirtualMethods(TypeDefinition typeDef) {
			foreach (MethodDefinition method in typeDef.Methods) {
				if (method.IsVirtual && !method.IsAbstract) {
					this.methods.Add(method);
				}
			}
		}

		public int Count { get { return this.methods.Count; } }
	}

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
		private HashSet<AssemblyDefinition> assemblies = new HashSet<AssemblyDefinition>();
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

			this.assemblies.Add(asmDef);

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

		public bool IsDelegate(TypeReference typeRef) {
			return IsSubclassOf(typeRef, this.TypeDefinitionCache.Delegate);
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

		private void ProcessMethodOverrides(VirtualsDictionary virtuals, TypeReference baseRef) {
			if (virtuals.Count > 0) {
				var baseDef = baseRef.Resolve();
				foreach (MethodDefinition baseMethod in baseDef.Methods) {
					if (baseMethod.IsVirtual) {
						var overridenMethod = virtuals.FindMethodBySignature(baseRef, baseMethod);
						if (overridenMethod != null) {
							var overrides = GetOverridesForVirtualMethod(baseMethod);
							overrides.Add(overridenMethod);
						}
					}
				}
			}
		}

		private void ProcessInterfaces(VirtualsDictionary virtuals, TypeReference typeRef) {
			var typeDef = typeRef.Resolve();
			foreach (TypeReference iface in typeDef.Interfaces) {
				var ifaceDef = iface.Resolve();
				var ifaceSet = GetSubclasses(ifaceDef);
				ifaceSet.Add(typeDef);
				ProcessMethodOverrides(virtuals, iface);
			}
		}

		public void ProcessType(TypeDefinition typeDef) {
			var virtuals = new VirtualsDictionary();
			virtuals.CollectVirtualMethods(typeDef);

			var baseType = typeDef.BaseType;
			while (baseType != null) {
				var baseSet = GetSubclasses(baseType);
				baseSet.Add(typeDef);

				ProcessMethodOverrides(virtuals, baseType);

				ProcessInterfaces(virtuals, baseType);

				var baseDef = baseType.Resolve();
				baseType = baseDef.BaseType;
			}

			ProcessInterfaces(virtuals, typeDef);

			foreach (var nestedType in typeDef.NestedTypes) {
				ProcessType(nestedType);
			}
		}

		public TypeDefinition GetTypeDefinition(string typeName) {
			return this.asmSystem.MainModule.GetType(typeName);
		}

		public TypeDefinition GetTypeDefinition(Type type) {
			return GetTypeDefinition(type.FullName);
		}

		public static Type GetReflectionType(TypeReference type) {
			switch (type.FullName) {
				case "System.Boolean":
					return typeof(Boolean);
				case "System.Byte":
					return typeof(Byte);
				case "System.Char":
					return typeof(Char);
				case "System.Double":
					return typeof(Double);
				case "System.Enum":
					return typeof(Enum);
				case "System.Int16":
					return typeof(Int16);
				case "System.Int32":
					return typeof(Int32);
				case "System.Int64":
					return typeof(Int64);
				case "System.IntPtr":
					return typeof(IntPtr);
				case "System.Object":
					return typeof(Object);
				case "System.SByte":
					return typeof(SByte);
				case "System.Single":
					return typeof(Single);
				case "System.String":
					return typeof(String);
				case "System.Type":
					return typeof(Type);
				case "System.UInt16":
					return typeof(UInt16);
				case "System.UInt32":
					return typeof(UInt32);
				case "System.UInt64":
					return typeof(UInt64);
				case "System.UIntPtr":
					return typeof(UIntPtr);
				case "System.Void":
					return typeof(void);
				case ConstantTypeNames.Delegate:
					return typeof(Delegate);
				default:
					return typeof(object);
			}
		}

		public bool IsEquivalent(TypeReference typeRef, Type reflectionType) {
			if (typeRef == null)
				return false;

			var def = GetTypeDefinition(reflectionType);
			return IsEquivalent(typeRef, def);
		}

		public bool IsEquivalent(TypeReference lhs, TypeReference rhs) {
			return (lhs.Resolve() == rhs.Resolve());
		}

		public bool IsDefined(ICustomAttributeProvider provider, string attributeTypeName) {
			TypeReference attributeType = asmSystem.MainModule.GetType(attributeTypeName);
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
