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
using System.Reflection;
using DotWeb.Client;
using DotWeb.Utility;
using DotWeb.Decompiler.CodeModel;
using DotWeb.Decompiler;

namespace DotWeb.Translator
{
	using CodeNamespaceCollection = Dictionary<string, CodeNamespace>;
	using CodeTypeDeclarationCollection = Dictionary<string, CodeTypeDeclaration>;

	public class TranslationContext
	{
		JsCodeGenerator generator;

		public TranslationContext(JsCodeGenerator generator) {
			this.generator = generator;
		}

		public void GenerateMethod(MethodBase method, bool followDependencies) {
			if (followDependencies) {
				GenerateMethod(method, new List<Type>(), new List<MethodBase>(), new List<string>());
			}
			else {
				var parsedMethod = Parse(method);
				this.generator.Write(parsedMethod);
			}
		}

		private MethodBase FindCorrespondingMethodFrom(MethodBase method, Type type) {
			var args = method.GetParameters();
			var types = args.Select(x => x.ParameterType).ToArray();

			if (method is ConstructorInfo) {
				return type.GetConstructor(types);
			}

			//MethodInfo info = (MethodInfo)method;
			//if (info.IsGenericMethod) {
			//    method = info.GetGenericMethodDefinition();
			//    args = method.GetParameters();
			//    types = args.Select(x => x.ParameterType).ToArray();
			//}

			return type.GetMethod(method.Name, types);
		}

		private void GenerateMethod(MethodBase method, List<Type> typesCache, List<MethodBase> methodsCache, List<string> namespaceCache) {
			var type = method.DeclaringType;
			if (type.FullName.StartsWith("System.")) {
				var newTypeName = string.Format("DotWeb.Client.{0}, DotWeb.Client", type.FullName);
				type = Type.GetType(newTypeName);
				if(type == null)
					throw new NullReferenceException(string.Format("Could not find type: {0}", method.DeclaringType));

				var found = FindCorrespondingMethodFrom(method, type);
				if (found == null)
					throw new NullReferenceException(string.Format("Could not find method: {0} on {1}", method, method.DeclaringType));

				method = found;
			}

			var parsedMethod = Parse(method);
			foreach (var external in parsedMethod.ExternalMethods) {
				if (IsEmittable(external)) {
					if (!methodsCache.Contains(external)) {
						GenerateMethod(external, typesCache, methodsCache, namespaceCache);
					}
				}
			}

			//var type = parsedMethod.Info.DeclaringType;
			GenerateTypeDecl(type, typesCache, namespaceCache);

			this.generator.Write(parsedMethod);
			methodsCache.Add(method);
		}

		private void GenerateNamespace(string name, List<string> namespaceCache) {
			StringBuilder sb = new StringBuilder();
			string[] parts = name.Split('.');
			foreach (string part in parts) {
				if (sb.Length > 0) {
					sb.Append(".");
				}
				sb.Append(part);

				string namespacePart = sb.ToString();

				if (!namespaceCache.Contains(namespacePart)) {
					CodeNamespace ns = new CodeNamespace { Name = namespacePart };
					this.generator.WriteNamespaceDecl(ns);
					namespaceCache.Add(namespacePart);
				}
			}
		}

		private void GenerateNamespace(Type type, List<string> namespaceCache) {
			string ns = JsPrinter.GetNamespace(type);
			if (!string.IsNullOrEmpty(ns)) {
				//GenerateNamespace(type.Namespace, namespaceCache);
				if (!namespaceCache.Contains(ns)) {
					CodeNamespace cns = new CodeNamespace { Name = ns };
					this.generator.WriteNamespaceDecl(cns);
					namespaceCache.Add(ns);
				}
			}
		}

		private void GenerateTypeDecl(Type type, List<Type> typesCache, List<string> namespaceCache) {
			if (!typesCache.Contains(type)) {
				Type baseType = type.BaseType;
				if (IsEmittable(baseType)) {
					GenerateTypeDecl(baseType, typesCache, namespaceCache);
				}

				GenerateNamespace(type, namespaceCache);
				this.generator.WriteTypeConstructor(type);
				typesCache.Add(type);
			}
		}

		private CodeMethodMember Parse(MethodBase method) {
			JsCodeAttribute js = method.GetCustomAttribute<JsCodeAttribute>();
			if (js != null) {
				var ret = new CodeMethodMember(method) {
					NativeCode = js.Code
				};
				return ret;
			}
			return MethodDecompiler.Parse(method);
		}

		private void ValidateJsAnonymousType(Type type) {
			// two things to check for:
			// 1. Properties may only be auto-implemented
			// 2. Methods are not allowed

			foreach (var method in type.GetMethods(BindingFlagsForMembers)) {
				var ap = method.GetAssociatedProperty();
				if (ap == null) {
					// FIXME: exceptions
					//throw new InvalidAnonymousUsageException(type);
				}

				var cmm = Parse(method);
				if (ap.IsGetter) {
					var getter = (CodePropertyGetterMember)cmm;
					if (!getter.IsAutoImplemented()) {
						// FIXME: exceptions
						//throw new InvalidAnonymousUsageException(type);
					}
				}
				else {
					var setter = (CodePropertySetterMember)cmm;
					if (!setter.IsAutoImplemented()) {
						// FIXME: exceptions
						//throw new InvalidAnonymousUsageException(type);
					}
				}
			}
		}

		private bool IsEmittable(Type type) {
			// FIXME: need a better way to filter out mscorlib, et. al.
//			if (type.Namespace != null && type.Namespace.StartsWith("System"))
//				return false;

			if (type.IsInterface)
				return false;

			if (type == typeof(object))
				return false;

			if (type.IsSubclassOf(typeof(JsNativeBase)))
				return false;

			if (type.IsSubclassOf(typeof(Delegate)))
				return false;

			if (type.IsAnonymous()) {
				if (!type.IsSubclassOf(typeof(JsDynamicBase))) {
					ValidateJsAnonymousType(type);
				}
				return false;
			}

			return true;
		}

		private bool IsEmittable(MethodBase method) {
			var type = method.DeclaringType;
			return IsEmittable(type);
		}

		const BindingFlags BindingFlagsForMembers =
			BindingFlags.DeclaredOnly |
			BindingFlags.Public |
			BindingFlags.NonPublic |
			BindingFlags.Instance |
			BindingFlags.Static;

	}
}
