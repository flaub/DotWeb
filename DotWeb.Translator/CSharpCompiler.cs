using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace DotWeb.Translator
{
	public class CompilerException : Exception
	{
		public List<CompilerError> Errors { get; private set; }

		public static string CreateMessage(CompilerErrorCollection errors) {
			StringBuilder sb = new StringBuilder();
			foreach (CompilerError error in errors) {
				sb.AppendFormat("   {0}", error);
				sb.AppendLine();
			}
			return sb.ToString();
		}

		public CompilerException(CompilerErrorCollection errors) : base(CreateMessage(errors)) {
			this.Errors = new List<CompilerError>(errors.Cast<CompilerError>());
		}
	}

	public class CSharpCompiler
	{
		private CSharpCodeProvider cscp;

		public CSharpCompiler() {
			var providerOptions = new Dictionary<string, string>();
			providerOptions.Add("CompilerVersion", "v3.5");
			this.cscp = new CSharpCodeProvider(providerOptions);
		}

		public Assembly CompileFile(string filename, List<Assembly> references) {
			return DoCompile(filename, references, true).CompiledAssembly;
		}

		public Type CompileFile(string filename, List<Assembly> references, string typeName) {
			return CompileFile(filename, references).GetType(typeName);
		}

		public Assembly CompileSource(string source, List<Assembly> references) {
			return DoCompile(source, references, false).CompiledAssembly;
		}

		public Type CompileSource(string source, List<Assembly> references, string typeName) {
			return CompileSource(source, references).GetType(typeName);
		}

		private CompilerResults DoCompile(string source, List<Assembly> references, bool isFile) {
			CompilerParameters options = new CompilerParameters {
				GenerateInMemory = true
			};

			foreach (Assembly assRef in references) {
				Console.WriteLine("Referencing: {0}", assRef.Location);
				options.ReferencedAssemblies.Add(assRef.Location);
			}

			CompilerResults results;
			if (isFile)
				results = this.cscp.CompileAssemblyFromFile(options, source);
			else
				results = this.cscp.CompileAssemblyFromSource(options, source);

			if (results.Errors.Count > 0) {
				Console.WriteLine("Errors building {0}", results.PathToAssembly);
				foreach (CompilerError error in results.Errors) {
					Console.WriteLine("   {0}", error);
					Console.WriteLine();
				}
				throw new CompilerException(results.Errors);
			}
			return results;
		}
	}
}
