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
using System.IO;
using DotWeb.Translator.Generator.JavaScript;
using System.Reflection;
using DotWeb.Client;
using DotWeb.Decompiler;

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

		public void TranslateAssemblyFromFile(string filename, Assembly sourceAssembly) {
			CSharpCompiler compiler = new CSharpCompiler();
			Assembly ass = compiler.CompileFile(filename, sourceAssembly);
			TranslateAssembly(ass);
		}

		public void TranslateAssembly(Assembly assembly) {
			TranslationContext context = new TranslationContext(this.generator);
			context.AddAssembly(assembly);
			context.Generate();
		}

		public void TranslateType(Type type) {
			TranslationContext context = new TranslationContext(this.generator);
//			context.AddType(type);
//			context.Generate();
			MethodBase method = type.GetConstructor(Type.EmptyTypes);
			context.GenerateMethod(method, true);
			this.generator.WriteEntryPoint(type);
		}
	}
}
