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
using System.IO;
using System.Reflection;
using DotWeb.Translator.Generator.JavaScript;
using Mono.Cecil;
using System.Linq;
using DotWeb.Utility;
using DotWeb.Utility.Cecil;
using System.Collections.Generic;

namespace DotWeb.Translator
{
	// Compile to release
	// Decompile into CodeModel
	// Generate target language
	public class TranslationEngine
	{
		private JsCodeGenerator generator;
		private DefaultAssemblyResolver resolver;

		public TranslationEngine(TextWriter writer, bool writeHeader, string path) {
			this.generator = new JsCodeGenerator(writer, writeHeader);
			this.resolver = new DefaultAssemblyResolver();
			resolver.AddSearchDirectory(path);
			Directory.SetCurrentDirectory(path);
		}

		public string[] TranslateType(TypeDefinition type) {
			var context = new TranslationContext(this.generator);
			var method = type.Constructors.GetConstructor(false, Type.EmptyTypes);
			var asmDependencies = new List<AssemblyDefinition>();
			context.GenerateMethod(method, true, asmDependencies);
			this.generator.WriteEntryPoint(type);

			string[] ret = new string[asmDependencies.Count];
			for (int i = 0; i < ret.Length; i++) {
				var asm = asmDependencies[i];
				var path = asm.MainModule.Image.FileInformation.FullName;
				ret[i] = path;
			}
			return ret;
		}

		/// <summary>
		/// Translates the specified type into javascript.
		/// Returns an array of assembly paths that this type depends on.
		/// </summary>
		/// <param name="aqtn"></param>
		/// <returns></returns>
		public string[] TranslateType(AssemblyQualifiedTypeName aqtn) {
			var asm = resolver.Resolve(aqtn.AssemblyName.FullName);
			asm.Resolver = resolver;
			asm.MainModule.LoadSymbols();
			var typeDef = asm.MainModule.Types[aqtn.TypeName];
			return TranslateType(typeDef);
		}
	}
}
