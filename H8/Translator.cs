using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H8.CodeModel;
using System.IO;
using H8.Generator.JavaScript;
using System.Reflection;
using H8.Support;

namespace H8
{
	// Compile to release
	// Decompile into CodeModel
	// Generate target language
	public class Translator
	{
		public TextWriter Writer { get; set; }
		private CodeMethodMember entryPoint = null; 
		private JsCodeGenerator generator;

		public Translator(TextWriter writer, bool writeHeader) {
			this.Writer = writer;
			this.generator = new JsCodeGenerator(this.Writer, writeHeader);
		}

		public List<Assembly> GetReferences(Assembly source) {
			List<Assembly> references = new List<Assembly>();
			DescendReferences(source, references);
			return references;
		}

		public void DescendReferences(Assembly ass, List<Assembly> ret) {
			if (ret.Contains(ass))
				return;

			ret.Add(ass);
			foreach (AssemblyName assName in ass.GetReferencedAssemblies()) {
				Assembly assRef = Assembly.Load(assName);
				DescendReferences(assRef, ret);
			}
		}

		public void TranslateFile(string sourceFile, Assembly sourceAssembly) {
			CSharpCompiler compiler = new CSharpCompiler();
			Assembly ass = compiler.CompileFile(sourceFile, GetReferences(sourceAssembly));
			Translate(ass);
		}

		public void TranslateSource(string source, Assembly sourceAssembly, string typeName, string methodName) {
			CSharpCompiler compiler = new CSharpCompiler();
			Type compiledType = compiler.CompileSource(source, GetReferences(sourceAssembly), typeName);
			MethodInfo method = compiledType.GetMethod(methodName);
			CodeMethodMember cmm = Parse(compiledType, method);
			this.generator.Write(cmm);
		}

		public void TranslateFile(string sourceFile, Assembly sourceAssembly, string typeName, string methodName) {
			CSharpCompiler compiler = new CSharpCompiler();
			Type compiledType = compiler.CompileFile(sourceFile, GetReferences(sourceAssembly), typeName);
			MethodInfo method = compiledType.GetMethod(methodName);
			CodeMethodMember cmm = Parse(compiledType, method);
			this.generator.Write(cmm);
		}

		public void TranslateFile(string sourceFile, Assembly sourceAssembly, string typeName) {
			CSharpCompiler compiler = new CSharpCompiler();
			Type compiledType = compiler.CompileFile(sourceFile, GetReferences(sourceAssembly), typeName);
			Translate(compiledType);
		}

		public void Translate(Assembly assembly) {
			Dictionary<string, CodeNamespace> namespaces = new Dictionary<string, CodeNamespace>();
			CodeNamespace nsDefault = new CodeNamespace {
				Name = ""
			};
			namespaces.Add(nsDefault.Name, nsDefault);

			foreach (Type type in assembly.GetTypes()) {
				if(type.IsSubclassOf(typeof(Delegate)))
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

			if (this.entryPoint != null) {
				this.generator.Write(this.entryPoint);
			}
		}

		public void Translate(Type type) {
			CodeNamespace ns = new CodeNamespace {
				Name = type.Namespace,
			};
			CodeTypeDeclaration def = Parse(type);
			ns.Types.Add(def);

			this.generator.Write(ns);
		}

		public CodeTypeDeclaration Parse(Type type) {
			CodeTypeDeclaration def = new CodeTypeDeclaration {
				Type = type
			};

			BindingFlags flags =
				BindingFlags.DeclaredOnly |
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.Instance |
				BindingFlags.Static;
			foreach (MethodInfo mi in type.GetMethods(flags)) {
				CodeMethodMember method = Parse(type, mi);
				if (mi.IsDefined(typeof(EntryPointAttribute), true)) {
					if (this.entryPoint != null)
						throw new InvalidOperationException("EntryPoint already defined");
					this.entryPoint = method;
					this.entryPoint.IsGlobal = true;
				}
				else {
					def.Methods.Add(method);
				}
			}
			foreach (ConstructorInfo ci in type.GetConstructors(flags)) {
				CodeMethodMember method = Parse(type, ci);
				def.Methods.Add(method);
				foreach (MethodBase external in method.ExternalMethods) {
					def.ExternalTypes.AddUnique(external.DeclaringType);
				}
			}

			foreach (FieldInfo fi in type.GetFields(flags)) {
				if (fi.MemberType == MemberTypes.Event)
					continue;
				CodeFieldMember field = new CodeFieldMember(fi);
				def.Fields.Add(field);
			}

			foreach (EventInfo ei in type.GetEvents(flags)) {
				CodeEventMember evt = new CodeEventMember(ei);
				def.Events.Add(evt);
			}

			foreach (PropertyInfo pi in type.GetProperties(flags)) {
				CodePropertyMember property = new CodePropertyMember(pi);
				def.Properties.Add(property);
			}

			return def;
		}

		public CodeMethodMember Parse(Type type, MethodBase mi) {
			Console.WriteLine(mi);

			ControlFlowGraph cfg = new ControlFlowGraph(mi);
			Console.WriteLine(cfg);

			ControlFlowAnalyzer cfa = new ControlFlowAnalyzer(cfg);
			cfa.Structure();

			BackEnd be = new BackEnd(cfg);
			be.WriteCode();

//			Console.WriteLine("Depends");
//			foreach (MethodBase method in cfg.ExternalMethods) {
//				Console.WriteLine(method);
//			}
//			Console.WriteLine();

			return be.Method;
		}

		public void Depends() {
//			DependencyAnalyzer da = new DependencyAnalyzer();
//			CSharpCompiler compiler = new CSharpCompiler();
//			Type compiledType = compiler.CompileFile("", "SourceTests");

//			MethodInfo method = compiledType.GetMethod(methodName);
//			CodeMethodMember cmm = Parse(compiledType, method);
//			this.generator.Write(cmm);
			//			da.AnalyzeMethod();
		}
	}
}
