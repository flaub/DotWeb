﻿// Copyright 2010, Frank Laub
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
	class VirtualsDictionary
	{
		private Dictionary<string, MethodDefinition> methods = new Dictionary<string, MethodDefinition>();

		public MethodDefinition FindMethodBySignature(MethodDefinition methodDef) {
			MethodDefinition virtualMethod = null;
			if (!this.methods.TryGetValue(methodDef.GetMethodSignature(), out virtualMethod)) {
				if (!this.methods.TryGetValue(methodDef.GetMethodSignatureWithTypeName(), out virtualMethod)) {
					//Debug.Fail("Missing base method for virtual");
					return null;
				}
			}
			return virtualMethod;
		}

		public void CollectVirtualMethods(TypeDefinition typeDef) {
			foreach (MethodDefinition method in typeDef.Methods) {
				if (method.IsVirtual && !method.IsAbstract) {
					// use raw method signature for key, to make sure it's unique in the case of
					// overriden methods with the same method name, which can happen if the 'new' 
					// keyword is used on a method definition
					this.methods.Add(method.GetMethodSignature(), method);
				}

				//if (method.HasOverrides) {
				//    Debug.Assert(method.IsVirtual);
				//    foreach (MethodReference overrideRef in method.Overrides) {
				//        var overrideDef = overrideRef.Resolve();
				//        var signature = overrideDef.GetMethodSignature();
				//        virtuals.Add(signature, overrideDef);
				//    }
				//}
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

		private void ProcessMethodOverrides(VirtualsDictionary virtuals, TypeDefinition baseDef) {
			if (virtuals.Count > 0) {
				foreach (MethodDefinition baseMethod in baseDef.Methods) {
					if (baseMethod.IsVirtual) {
						var overridenMethod = virtuals.FindMethodBySignature(baseMethod);
						if (overridenMethod != null) {
							var overrides = GetOverridesForVirtualMethod(baseMethod);
							overrides.Add(overridenMethod);
						}
					}
				}
			}
		}

		private void ProcessType(TypeDefinition typeDef) {
			var virtuals = new VirtualsDictionary();
			virtuals.CollectVirtualMethods(typeDef);

			var baseType = typeDef.BaseType;
			while (baseType != null) {
				var baseDef = baseType.Resolve();
				var baseSet = GetSubclasses(baseType);
				baseSet.Add(typeDef);

				ProcessMethodOverrides(virtuals, baseDef);

				ProcessInterfaces(virtuals, baseDef);

				baseType = baseDef.BaseType;
			}

			ProcessInterfaces(virtuals, typeDef);

			foreach (TypeDefinition nested in typeDef.NestedTypes) {
				ProcessType(nested);
			}
		}

		private void ProcessInterfaces(VirtualsDictionary virtuals, TypeDefinition typeDef) {
			foreach (TypeReference iface in typeDef.Interfaces) {
				var ifaceDef = iface.Resolve();
				var ifaceSet = GetSubclasses(ifaceDef);
				ifaceSet.Add(typeDef);

				ProcessMethodOverrides(virtuals, ifaceDef);
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
