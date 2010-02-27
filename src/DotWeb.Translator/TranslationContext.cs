// Copyright 2009, Frank Laub
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
using DotWeb.Client;
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
				var typesCache = new List<TypeDefinition>();
				GenerateMethod(
					method,
					typesCache, 
					new List<MethodDefinition>(), 
					new List<string>());

				foreach (var type in typesCache) {
					var asm = type.Module.Assembly;
					asmDependencies.AddUnique(asm);
				}
			}
			else {
				var parsedMethod = Parse(method);
				this.generator.Write(parsedMethod);
			}
		}

		private void GenerateMethod(
			MethodDefinition method, 
			List<TypeDefinition> typesCache, 
			List<MethodDefinition> methodsCache, 
			List<string> namespaceCache) {

			// to deal with recursive methods, add to the cache before processing
			methodsCache.Add(method);

			var parsedMethod = Parse(method);
			foreach (var external in parsedMethod.ExternalMethods) {
				var def = external.Resolve();
				if (IsEmittable(def)) {
					if (!methodsCache.Contains(def)) {
						GenerateMethod(def, typesCache, methodsCache, namespaceCache);
					}
				}
			}

			var type = parsedMethod.Definition.DeclaringType;
			GenerateTypeDecl(type, typesCache, namespaceCache);

			this.generator.Write(parsedMethod);
		}

		private void GenerateNamespace(TypeDefinition type, List<string> namespaceCache) {
			string ns = JsPrinter.GetNamespace(type);
			if (!string.IsNullOrEmpty(ns)) {
				if (!namespaceCache.Contains(ns)) {
					CodeNamespace cns = new CodeNamespace { Name = ns };
					this.generator.WriteNamespaceDecl(cns);
					namespaceCache.Add(ns);
				}
			}
		}

		private void GenerateTypeDecl(TypeDefinition type, List<TypeDefinition> typesCache, List<string> namespaceCache) {
			if (!typesCache.Contains(type)) {
				var baseType = type.BaseType.Resolve();
				if (IsEmittable(baseType)) {
					GenerateTypeDecl(baseType, typesCache, namespaceCache);
				}

				//GenerateNamespace(type, namespaceCache);
				this.generator.WriteTypeConstructor(type);
				typesCache.Add(type);
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

			if (!method.HasBody || method.Body.Instructions.Count == 0) {
				string msg = string.Format(
					"{0}\nA method marked extern must either have [JsCode], [JsMacro], or be declared in a type derived from JsObject.",
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
			if (type.IsInterface)
				return false;

			if (this.typeSystem.IsEquivalent(type, typeof(object)))
				return false;

			if (this.typeSystem.IsSubclassOf(type, this.typeSystem.TypeDefinitionCache.JsObject))
				return false;

			if (this.typeSystem.IsSubclassOf(type, this.typeSystem.TypeDefinitionCache.Delegate))
				return false;

			if (AttributeHelper.IsAnonymous(type, this.typeSystem)) {
				// FIXME:
				//if (!type.IsSubclassOf(typeof(JsDynamicBase))) {
				//    ValidateJsAnonymousType(type);
				//}
				return false;
			}

			return true;
		}

		private bool IsEmittable(MethodDefinition method) {
			if (AttributeHelper.GetJsMacro(method) != null)
				return false;

			var type = method.DeclaringType;
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
