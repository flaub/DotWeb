// Copyright 2009-2010, Frank Laub
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
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace DotWeb.Translator.Test
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

		public Assembly CompileFile(string filename, Assembly startingReference) {
			return DoCompile(filename, GetReferences(startingReference), true).CompiledAssembly;
		}

		public CompilerResults CompileSource(string source, Assembly startingReference) {
			return DoCompile(source, GetReferences(startingReference), false);
		}

		private CompilerResults DoCompile(string source, List<Assembly> references, bool isFile) {
			CompilerParameters options = new CompilerParameters {
				//GenerateInMemory = true,
				CompilerOptions = "/nostdlib /debug:pdbonly"
			};

			foreach (var asmRef in references) {
				Console.WriteLine("Referencing: {0}", asmRef.Location);
				options.ReferencedAssemblies.Add(asmRef.Location);
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

		private List<Assembly> GetReferences(Assembly source) {
			List<Assembly> references = new List<Assembly>();
			DescendReferences(source, references);
			return references;
		}

		private void DescendReferences(Assembly asm, List<Assembly> ret) {
			if (ret.Contains(asm))
				return;

			ret.Add(asm);
			foreach (AssemblyName assName in asm.GetReferencedAssemblies()) {
				var asmRef = Assembly.Load(assName);
				DescendReferences(asmRef, ret);
			}
		}
	}
}
