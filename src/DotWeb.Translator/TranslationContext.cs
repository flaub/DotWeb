﻿// Copyright 2009, Frank Laub
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
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DotWeb.Translator.Generator.JavaScript;
using DotWeb.Utility;
using DotWeb.Decompiler.CodeModel;
using DotWeb.Decompiler;
using Mono.Cecil;
using DotWeb.Utility.Cecil;

namespace DotWeb.Translator
{
	using CodeNamespaceCollection = Dictionary<string, CodeNamespace>;
	using CodeTypeDeclarationCollection = Dictionary<string, CodeTypeDeclaration>;

	public class TranslationContext
	{
		private JsCodeGenerator generator;
		private TypeSystem typeSystem;

		public TranslationContext(TypeSystem typeSystem, JsCodeGenerator generator) {
			this.typeSystem = typeSystem;
			this.generator = generator;
		}

		public void GenerateMethod(
			MethodDefinition method, 
			bool followDependencies, 
			List<AssemblyDefinition> asmDependencies) {
			if (followDependencies) {
				var typesCache = new TypesCache(asmDependencies);
				var methodsCache = new List<MethodDefinition>();
				GenerateMethod(method, typesCache, methodsCache);
			}
			else {
				var parsedMethod = Parse(method);
				this.generator.Write(parsedMethod);
			}
		}

		private void GenerateMethod(MethodDefinition method, TypesCache typesCache, List<MethodDefinition> methodsCache) {
			// we still need to process virtual methods even if they aren't emittable
			if (method.IsVirtual) {
				var overrides = this.typeSystem.GetOverridesForVirtualMethod(method);
				foreach (var overridenMethod in overrides) {
					var overridenType = overridenMethod.DeclaringType;
					if (typesCache.HasVisited(overridenType)) {
						GenerateMethod(overridenMethod, typesCache, methodsCache);
					}
				}
			}

			if (methodsCache.Contains(method))
				return;

			// to deal with recursive methods, add to the cache before processing
			methodsCache.Add(method);
			typesCache.AddVisited(method.DeclaringType);

			if (IsEmittable(method)) {
				var parsedMethod = Parse(method);
				foreach (var external in parsedMethod.ExternalMethods) {
					var externalDef = external.Resolve();
					GenerateMethod(externalDef, typesCache, methodsCache);
				}

				var type = parsedMethod.Definition.DeclaringType;
				GenerateTypeDecl(type, typesCache);

				this.generator.Write(parsedMethod);
			}
		}

		private void GenerateTypeDecl(TypeDefinition type, TypesCache typesCache) {
			if (!typesCache.HasEmitted(type)) {
				var baseType = type.BaseType.Resolve();
				if (IsEmittable(baseType)) {
					GenerateTypeDecl(baseType, typesCache);
				}

				this.generator.WriteTypeConstructor(type);
				var staticCtor = type.GetStaticConstructor();
				if (staticCtor != null) {
					var staticCtorMethod = MethodDecompiler.ParseStaticConstructor(this.typeSystem, staticCtor);
					if (staticCtorMethod.Statements.Any() || !string.IsNullOrEmpty(staticCtorMethod.NativeCode)) {
						this.generator.WriteStaticConstructor(staticCtorMethod);
					}
				}
				typesCache.AddEmitted(type);
			}
		}

		class TypesCache
		{
			private List<AssemblyDefinition> asmDependencies;
			private List<TypeDefinition> visited = new List<TypeDefinition>();
			private List<TypeDefinition> emitted = new List<TypeDefinition>();

			public TypesCache(List<AssemblyDefinition> asmDependencies) {
				this.asmDependencies = asmDependencies;
			}

			public bool HasVisited(TypeDefinition type) {
				return this.visited.Contains(type);
			}

			public bool HasEmitted(TypeDefinition type) {
				return this.emitted.Contains(type);
			}

			public void AddVisited(TypeDefinition type) {
				this.visited.AddUnique(type);
			}

			public void AddEmitted(TypeDefinition type) {
				this.emitted.Add(type);
				this.asmDependencies.AddUnique(type.Module.Assembly);
			}
		}

		private CodeMethodMember Parse(MethodDefinition method) {
			string jsCode = AttributeHelper.GetJsCode(method);
			if (jsCode != null) {
				var ret = new CodeMethodMember(method) {
					NativeCode = jsCode
				};
				return ret;
			}

			if (!method.HasBody || method.Body.CodeSize == 0) {
				string msg = string.Format(
					"{0}\nA method marked extern must have [JsCode], [JsMacro], or declared in a type with [JsObject].",
					method
				);
				throw new MissingMethodException(msg);
			}

			return MethodDecompiler.Parse(this.typeSystem, method);
		}

		//private void ValidateJsAnonymousType(Type type) {
		//    // two things to check for:
		//    // 1. Properties may only be auto-implemented
		//    // 2. Methods are not allowed

		//    foreach (var method in type.GetMethods(BindingFlagsForMembers)) {
		//        var ap = method.GetAssociatedProperty();
		//        if (ap == null) {
		//            // FIXME: exceptions
		//            //throw new InvalidAnonymousUsageException(type);
		//        }

		//        var cmm = Parse(method);
		//        if (ap.IsGetter) {
		//            var getter = (CodePropertyGetterMember)cmm;
		//            if (!getter.IsAutoImplemented()) {
		//                // FIXME: exceptions
		//                //throw new InvalidAnonymousUsageException(type);
		//            }
		//        }
		//        else {
		//            var setter = (CodePropertySetterMember)cmm;
		//            if (!setter.IsAutoImplemented()) {
		//                // FIXME: exceptions
		//                //throw new InvalidAnonymousUsageException(type);
		//            }
		//        }
		//    }
		//}

		private bool IsEmittable(TypeDefinition type) {
			if (type.IsInterface ||
				TypeSystem.IsSystemObject(type) ||
				AttributeHelper.IsJsObject(type) ||
				TypeSystem.IsDelegate(type))
				return false;

			if (AttributeHelper.IsAnonymous(type)) {
				// FIXME:
				//if (!type.IsSubclassOf(typeof(JsDynamicBase))) {
				//    ValidateJsAnonymousType(type);
				//}
				return false;
			}

			return true;
		}

		private bool IsEmittable(MethodDefinition method) {
			if (method.IsAbstract)
				return false;

			if (AttributeHelper.GetJsMacro(method) != null) {
				return false;
			}

			if (AttributeHelper.GetJsCode(method) != null) {
				return true;
			}

			var type = method.DeclaringType;

			if (!method.HasBody || method.Body.CodeSize == 0) {
				if (AttributeHelper.GetJsAugment(type) != null) {
					return false;
				}
			}

			return IsEmittable(type);
		}

		//const BindingFlags BindingFlagsForMembers =
		//    BindingFlags.DeclaredOnly |
		//    BindingFlags.Public |
		//    BindingFlags.NonPublic |
		//    BindingFlags.Instance |
		//    BindingFlags.Static;

	}
}
