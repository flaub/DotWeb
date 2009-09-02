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
using DotWeb.Translator.CodeModel;
using System.IO;
using DotWeb.Translator.Generator.JavaScript;
using System.Reflection;
using DotWeb.Client;

namespace DotWeb.Translator
{
	// Compile to release
	// Decompile into CodeModel
	// Generate target language
	public class TranslationEngine
	{
		public TextWriter Writer { get; set; }
		private JsCodeGenerator generator;

		public TranslationEngine(TextWriter writer, bool writeHeader) {
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
			TranslationContext context = new TranslationContext(this.generator);
			//context.AddMethod(method);
			context.Generate();
		}

		public void TranslateFile(string sourceFile, Assembly sourceAssembly, string typeName, string methodName) {
			CSharpCompiler compiler = new CSharpCompiler();
			Type compiledType = compiler.CompileFile(sourceFile, GetReferences(sourceAssembly), typeName);
			MethodInfo method = compiledType.GetMethod(methodName);
			TranslationContext context = new TranslationContext(this.generator);
			//context.AddMethod(method);
			context.Generate();
		}

		public void TranslateFile(string sourceFile, Assembly sourceAssembly, string typeName) {
			CSharpCompiler compiler = new CSharpCompiler();
			Type compiledType = compiler.CompileFile(sourceFile, GetReferences(sourceAssembly), typeName);
			Translate(compiledType);
		}

		public void Translate(Assembly assembly) {
			TranslationContext context = new TranslationContext(this.generator);
			context.AddAssembly(assembly);
			context.Generate();
		}

		public void Translate(Type type) {
			TranslationContext context = new TranslationContext(this.generator);
			context.AddType(type);
			context.Generate();
		}
	}
}
