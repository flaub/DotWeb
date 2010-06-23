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
using System.Linq;
using System.Collections.Generic;
using DotWeb.Utility.Cecil;
using DotWeb.Utility;
using System.Resources;
using System.Diagnostics;
using System.Text;

namespace DotWeb.Translator.Test
{
	public abstract class TranslationTestHelper
	{
		protected TypeSystem typeSystem;
		protected DotWeb.Utility.Cecil.GlobalAssemblyResolver resolver;

		protected TranslationTestHelper(string asmName, string src)
			: this(asmName, src, false) {
		}

		protected TranslationTestHelper(string asmName, string src, bool isDebug) {
			var compiler = new CSharpCompiler();
			var asm = Assembly.Load(asmName);
			var result = compiler.CompileSource(src, asm, isDebug);

			this.resolver = new DotWeb.Utility.Cecil.GlobalAssemblyResolver();

			var dir = Path.GetDirectoryName(result.PathToAssembly);
			var compiledAsmName = Path.GetFileNameWithoutExtension(result.PathToAssembly);
	
			this.resolver.AddSearchDirectory(dir);

			this.typeSystem = new TypeSystem(this.resolver);
			this.CompiledAssembly = this.typeSystem.LoadAssembly(compiledAsmName);

			//this.CompiledAssembly.MainModule.LoadSymbols();
			var pathToPdb = Path.Combine(dir, compiledAsmName + ".pdb");
			File.Delete(pathToPdb);

			File.Delete(result.PathToAssembly);
		}

		protected void TestMethod(string typeName, string methodName, string expected) {
			var type = this.CompiledAssembly.MainModule.GetType(typeName);
			TestMethod(type, methodName, expected);
		}

		protected void TestMethod(TypeDefinition type, string methodName, string expected) {
			TestMethod(type, methodName, expected, false);
		}

		protected void TestMethod(string typeName, string methodName, string expected, bool followDependencies) {
			var type = this.CompiledAssembly.MainModule.GetType(typeName);
			TestMethod(type, methodName, expected, followDependencies);
		}

		protected void TestMethod(TypeDefinition type, string methodName, string expected, bool followDependencies) {
			string result = GenerateMethod(type, methodName, followDependencies);
			string rhs = result.Trim();

			if (expected == null) {
				Console.WriteLine("Actual:");
				Console.WriteLine(rhs);

				Assert.Fail("Expected is null");
				return;
			}

			Console.WriteLine("Expected:");
			Console.WriteLine(expected);

			Console.WriteLine("Actual:");
			Console.WriteLine(rhs);

			var tr = new TestResult(expected.Trim(), rhs);
			tr.Process();
		}

		class TestResult
		{
			private StringReader lhsReader;
			private StringReader rhsReader;
			private int lhsLineNumber;

			private string lhsLine;
			private string rhsLine;

			public TestResult(string expected, string actual) {
				this.lhsReader = new StringReader(expected);
				this.rhsReader = new StringReader(actual);
			}

			public void Process() {
				this.lhsLineNumber = 1;
				while (true) {
					this.lhsLine = lhsReader.ReadLine();
					this.rhsLine = rhsReader.ReadLine();
					if (lhsLine == null && rhsLine == null)
						break;

					ProcessLine();
				}
			}

			private void ProcessLine() {
				if (this.lhsLine.StartsWith("//>")) {
					var incPath = lhsLine.Substring(3).Replace('$', '_').Replace('.', '_').Trim();
					ProcessInclude(incPath);

					this.lhsLine = lhsReader.ReadLine();
					this.lhsLineNumber++;
					ProcessLine();
					return;
				}

				Assert.AreEqual(this.lhsLine, this.rhsLine, string.Format("Line: {0}", this.lhsLineNumber++));
			}

			private void ProcessInclude(string incPath) {
				var inc = Resources.CommonMethods.ResourceManager.GetString(incPath);
				if (inc == null)
					Assert.Fail("Missing include: {0}, Line: {1}", incPath, this.lhsLineNumber);

				var incReader = new StringReader(inc);
				int incLineNumber = 1;
				while (true) {
					var incLine = incReader.ReadLine();
					if (incLine == null)
						break;

					Assert.AreEqual(incLine, this.rhsLine, string.Format("{0}> Line: {1}, from Line: {2}", incPath, incLineNumber++, this.lhsLineNumber));

					this.rhsLine = this.rhsReader.ReadLine();
				}
			}
		}

		protected string GenerateMethod(TypeDefinition type, string methodName, bool followDependencies) {
			var method = type.GetMethods(methodName).First();
			TextWriter writer = new StringWriter();
			var generator = new JsCodeGenerator(this.typeSystem, writer, false);
			var context = new TranslationContext(this.typeSystem, generator);
			var asmDependencies = new List<AssemblyDefinition>();
			context.GenerateMethod(method, followDependencies, asmDependencies);
			return writer.ToString();
		}

		protected AssemblyDefinition CompiledAssembly;
	}

	public abstract class TestBase : TranslationTestHelper
	{
		protected TypeDefinition sourceCompiledType;
		protected ResourceManager resource;

		public TestBase(string asmName, string typeName, ResourceManager resource, string source, bool isDebug)
			: base(asmName, resource.GetString(source), isDebug) {
			this.resource = resource;
			this.sourceCompiledType = this.CompiledAssembly.MainModule.GetType(typeName);
		}

		public TestBase(string asmName, string typeName, ResourceManager resource, string source)
			: this(asmName, typeName, resource, source, false) {
		}

		public void RunTestWithDependencies() {
			var frame = new StackFrame(1);
			var name = frame.GetMethod().Name;
			this.TestMethod(this.sourceCompiledType, name, resource.GetString(name), true);
		}

		public void RunTest() {
			var frame = new StackFrame(1);
			var name = frame.GetMethod().Name;
			this.TestMethod(this.sourceCompiledType, name, resource.GetString(name));
		}
	}
}
