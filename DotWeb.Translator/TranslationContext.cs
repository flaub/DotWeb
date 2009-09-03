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
using DotWeb.Translator.CodeModel;
using System.Reflection;
using DotWeb.Client;
using System.Diagnostics;
using DotWeb.Utility;

namespace DotWeb.Translator
{
	class CodeNamespaceCollection : Dictionary<string, CodeNamespace> { }
	class CodeTypeDeclarationCollection : Dictionary<string, CodeTypeDeclaration> { }

	public class AssociatedProperty
	{
		public PropertyInfo Info { get; set; }
		public bool IsGetter { get; set; }
	}

	public static class MethodBaseExtensions
	{
		public static AssociatedProperty GetAssociatedProperty(this MethodBase method) {
			if (method.IsSpecialName) {
				if (method.Name.StartsWith("get_")) {
					string propName = method.Name.Substring("get_".Length);
					PropertyInfo pi = method.DeclaringType.GetProperty(propName);
					return new AssociatedProperty {
						Info = pi,
						IsGetter = true
					};
				}
				else if (method.Name.StartsWith("set_")) {
					string propName = method.Name.Substring("set_".Length);
					PropertyInfo pi = method.DeclaringType.GetProperty(propName);
					return new AssociatedProperty {
						Info = pi,
						IsGetter = false
					};
				}
			}

			return null;
		}
	}

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
			this.generator.WriteEntry(this.entryType);
		}

		public void GenerateMethod(MethodBase method) {
			var parsedMethod = Parse(method);
			this.generator.Write(parsedMethod);
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
			JsCodeAttribute js = method.GetCustomAttribute<JsCodeAttribute>();
			if (cmm.ExternalMethods.Any(x =>
				x.DeclaringType == typeof(JsNativeBase) ||
				x.DeclaringType == typeof(JsHost))) {
				if (js != null) {
					cmm.NativeCode = js.Code;
				}
				else {
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
			Console.WriteLine(method);

			ControlFlowGraph cfg = new ControlFlowGraph(method);
			Console.WriteLine(cfg);

			ControlFlowAnalyzer cfa = new ControlFlowAnalyzer(cfg);
			cfa.Structure();

			BackEnd be = new BackEnd(cfg);
			be.WriteCode();

			AssociatedProperty ap = method.GetAssociatedProperty();
			if (ap != null) {
				if (ap.IsGetter) {
					return new CodePropertyGetterMember(be.Method) {
						PropertyInfo = ap.Info
					};
				}
				else {
					return new CodePropertySetterMember(be.Method) {
						PropertyInfo = ap.Info
					};
				}
			}
			else {
				return be.Method;
			}
		}

	}
}
