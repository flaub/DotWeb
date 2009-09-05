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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Translator.Generator.JavaScript;
using System.Reflection;
using DotWeb.Client;
using System.Diagnostics;
using DotWeb.Utility;
using DotWeb.Decompiler.CodeModel;
using DotWeb.Decompiler;

namespace DotWeb.Translator
{
	class CodeNamespaceCollection : Dictionary<string, CodeNamespace> { }
	class CodeTypeDeclarationCollection : Dictionary<string, CodeTypeDeclaration> { }

	public class TranslationContext
	{
		CodeNamespaceCollection namespaces = new CodeNamespaceCollection();
		CodeTypeDeclarationCollection types = new CodeTypeDeclarationCollection();
		List<CodeTypeDeclaration> depthFirstTypes = new List<CodeTypeDeclaration>();
		JsCodeGenerator generator;
		CodeNamespace nsDefault;
		CodeTypeDeclaration entryType;

		public TranslationContext(JsCodeGenerator generator) {
			this.generator = generator;

			this.nsDefault = new CodeNamespace { Name = "" };
			this.namespaces.Add(nsDefault.Name, nsDefault);
		}

		public void Generate() {
			foreach (CodeNamespace ns in this.namespaces.Values) {
				this.generator.WriteNamespaceDecl(ns);
			}

			foreach (CodeTypeDeclaration type in this.depthFirstTypes) {
				this.generator.Write(type);
			}

			Debug.Assert(this.entryType != null);
			this.generator.WriteEntryPoint(this.entryType.Type);
		}

		public void GenerateMethod(MethodBase method, bool followDependencies) {
			//var externalTypes = new List<Type>();
			//foreach (var external in parsedMethod.ExternalMethods) {
			//    externalTypes.AddUnique(external.DeclaringType);
			//}
			if (followDependencies) {
				GenerateMethod(method, new List<Type>(), new List<MethodBase>());
			}
			else {
				var parsedMethod = Parse(method); 
				this.generator.Write(parsedMethod);
			}
		}

		private void GenerateMethod(MethodBase method, List<Type> typesCache, List<MethodBase> methodsCache) {
			if (method.GetMethodBody() != null) {
				var parsedMethod = Parse(method);
				foreach (var external in parsedMethod.ExternalMethods) {
					var externalType = external.DeclaringType;
					if (IsEmittable(externalType)) {
						if (!typesCache.Contains(externalType)) {
							CodeNamespace ns = GetNamespace(externalType);
							this.generator.WriteNamespaceDecl(ns);
							this.generator.WriteTypeConstructor(externalType);
							typesCache.Add(externalType);
						}
						if (!methodsCache.Contains(external)) {
							GenerateMethod(external, typesCache, methodsCache);
						}
					}
				}
				this.generator.Write(parsedMethod);
			}
			methodsCache.Add(method);
		}

		public void GenerateType(Type type) {
			var parsedType = Parse(type);
			this.generator.Write(parsedType);
		}

		public void AddAssembly(Assembly assembly) {
			Dictionary<string, CodeNamespace> namespaces = new Dictionary<string, CodeNamespace>();
			CodeNamespace nsDefault = new CodeNamespace {
				Name = ""
			};
			namespaces.Add(nsDefault.Name, nsDefault);

			foreach (Type type in assembly.GetTypes()) {
				if (type.IsSubclassOf(typeof(Delegate)))
					continue;
				if (type.FullName.Contains("PrivateImplementation"))
					continue;
				CodeTypeDeclaration def = Parse(type);

				if (def.Type.Namespace == null) {
					nsDefault.Types.Add(def);
				}
				else {
					CodeNamespace ns;
					if (!namespaces.TryGetValue(def.Type.Namespace, out ns)) {
						ns = new CodeNamespace {
							Name = def.Type.Namespace
						};
						namespaces.Add(def.Type.Namespace, ns);
					}
					ns.Types.Add(def);
				}
			}

			foreach (CodeNamespace ns in namespaces.Values) {
				this.generator.Write(ns);
			}
		}

		private CodeNamespace GetNamespace(Type type) {
			CodeNamespace ns;
			if (type.Namespace == null) {
				ns = this.nsDefault;
			}
			else {
				if (!namespaces.TryGetValue(type.Namespace, out ns)) {
					ns = new CodeNamespace { Name = type.Namespace };
					namespaces.Add(ns.Name, ns);
				}
			}
			return ns;
		}

		public void AddType(Type type) {
			if (!type.IsSubclassOf(typeof(JsAccessible)))
				return;
			if (type == typeof(JsNativeBase))
				return;
			if (this.types.ContainsKey(type.FullName))
				return;

			CodeNamespace ns = GetNamespace(type);
			CodeTypeDeclaration def = Parse(type);
			this.types.Add(def.FullName, def);
			ns.Types.Add(def);

			if (this.entryType == null)
				this.entryType = def;

			foreach (Type dependency in def.ExternalTypes) {
				Debug.WriteLine(string.Format("{0} Depends on {1}", type, dependency));
				AddType(dependency);
			}

			this.depthFirstTypes.AddUnique(def);
		}

		public void AddMethod(CodeTypeDeclaration decl, MethodBase method) {
			//AssociatedProperty ap = method.GetAssociatedProperty();
			//if (ap != null && ap.Info.IsDefined(typeof(JsIntrinsicAttribute), false)) {
			//    return;
			//}

			CodeMethodMember cmm = Parse(method);
			if (cmm.ExternalMethods.Any(x =>
				x.DeclaringType == typeof(JsNativeBase) ||
				x.DeclaringType == typeof(JsHost))) {
				if (cmm.NativeCode == null) {
					// generate native code from method sig
					JsFunction function = new JsFunction(method);
					cmm.NativeCode = function.Body;
					return;
				}
			}
			else {
				foreach (MethodBase external in cmm.ExternalMethods) {
					if (external.DeclaringType != decl.Type) {
						decl.ExternalTypes.AddUnique(external.DeclaringType);
					}
				}
			}

			decl.Methods.Add(cmm);
		}

		public void AddMethod(MethodBase method) {
			CodeTypeDeclaration typeDecl;
			if (!this.types.TryGetValue(method.DeclaringType.FullName, out typeDecl)) {
				typeDecl = new CodeTypeDeclaration {
					Type = method.DeclaringType
				};
				this.types.Add(typeDecl.FullName, typeDecl);
			}

			AddMethod(typeDecl, method);
		}

		const BindingFlags BindingFlagsForMembers =
			BindingFlags.DeclaredOnly |
			BindingFlags.Public |
			BindingFlags.NonPublic |
			BindingFlags.Instance |
			BindingFlags.Static;

		public CodeTypeDeclaration Parse(Type type) {
			CodeTypeDeclaration def = new CodeTypeDeclaration {
				Type = type
			};

			def.ExternalTypes.AddUnique(type.BaseType);

			foreach (MethodInfo mi in type.GetMethods(BindingFlagsForMembers)) {
				AddMethod(def, mi);
			}

			foreach (ConstructorInfo ci in type.GetConstructors(BindingFlagsForMembers)) {
				AddMethod(def, ci);
			}

			foreach (FieldInfo fi in type.GetFields(BindingFlagsForMembers)) {
				if (fi.MemberType == MemberTypes.Event)
					continue;
				CodeFieldMember field = new CodeFieldMember(fi);
				def.Fields.Add(field);
			}

			foreach (EventInfo ei in type.GetEvents(BindingFlagsForMembers)) {
				CodeEventMember evt = new CodeEventMember(ei);
				def.Events.Add(evt);
			}

			foreach (PropertyInfo pi in type.GetProperties(BindingFlagsForMembers)) {
				CodePropertyMember property = new CodePropertyMember(pi);
				def.Properties.Add(property);
			}

			return def;
		}

		public CodeMethodMember Parse(MethodBase method) {
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
					throw new InvalidAnonymousUsageException(type);
				}

				var cmm = Parse(method);
				if (ap.IsGetter) {
					var getter = (CodePropertyGetterMember)cmm;
					if (!getter.IsAutoImplemented()) {
						throw new InvalidAnonymousUsageException(type);
					}
				}
				else {
					var setter = (CodePropertySetterMember)cmm;
					if (!setter.IsAutoImplemented()) {
						throw new InvalidAnonymousUsageException(type);
					}
				}
			}
		}

		private bool IsEmittable(Type type) {
			// FIXME: need a better way to filter out mscorlib, et. al.
			if (type.Namespace != null && type.Namespace.StartsWith("System"))
				return false;

			if (type == typeof(object))
				return false;

			if (type == typeof(JsAccessible))
				return false;

			if (type.IsSubclassOf(typeof(JsNativeBase)))
				return false;

			if (type.IsSubclassOf(typeof(Delegate)))
				return false;

			if (type.IsAnonymous()) {
				ValidateJsAnonymousType(type);
				return false;
			}

			return true;
		}
	}
}
