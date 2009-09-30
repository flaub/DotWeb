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
using System.Reflection;
using System.IO;
using DotWeb.Translator.Generator.JavaScript;
using DotWeb.Decompiler;
using NUnit.Framework;
using Mono.Cecil;

namespace DotWeb.Translator.Test
{
	public abstract class TranslationTestHelper<TDerived> where TDerived : TranslationTestHelper<TDerived>
	{
//		protected AssemblyDefinition CompiledAssemblyDef;

		protected TranslationTestHelper(string asmName, string src) {
			if (cachedAssembly == null) {
				var compiler = new CSharpCompiler();
				var asm = Assembly.Load(asmName);
				var result = compiler.CompileSource(src, asm);
				//this.CompiledAssemblyDef = AssemblyFactory.GetAssembly(result.PathToAssembly);
				//this.CompiledAssembly = compiler.CompileSource(src, asm);
				this.CompiledAssembly = result.CompiledAssembly;
				cachedAssembly = this.CompiledAssembly;
			}
			else {
				this.CompiledAssembly = cachedAssembly;
			}
		}

		protected void TestMethod(string typeName, string methodName, string expected) {
			Type type = this.CompiledAssembly.GetType(typeName);
			TestMethod(type, methodName, expected);
		}

		protected void TestMethod(Type type, string methodName, string expected) {
			TestMethod(type, methodName, expected, false);
		}

		protected void TestMethod(string typeName, string methodName, string expected, bool followDependencies) {
			Type type = this.CompiledAssembly.GetType(typeName);
			TestMethod(type, methodName, expected, followDependencies);
		}

		protected void TestMethod(Type type, string methodName, string expected, bool followDependencies) {
			string result = GenerateMethod(type, methodName, followDependencies);
			string lhs = expected.Trim();
			string rhs = result.Trim();

			Console.WriteLine("Expected:");
			Console.WriteLine(lhs);

			Console.WriteLine("Actual:");
			Console.WriteLine(rhs);

			Assert.AreEqual(lhs, rhs);
		}

		protected string GenerateMethod(Type type, string methodName, bool followDependencies) {
			MethodInfo method = type.GetMethod(methodName);
			TextWriter writer = new StringWriter();
			var generator = new JsCodeGenerator(writer, false);
			var context = new TranslationContext(generator);
			context.GenerateMethod(method, followDependencies);
			return writer.ToString();
		}

		protected Assembly CompiledAssembly;

		private static Assembly cachedAssembly;
	}
}
