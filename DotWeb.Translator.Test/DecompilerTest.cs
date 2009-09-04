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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DotWeb.Translator.Test.Properties;
using System.Reflection;
using DotWeb.Translator.Generator.JavaScript;

namespace DotWeb.Translator.Test
{
	[TestClass]
	public class DecompilerTest
	{
		public DecompilerTest() {
			CSharpCompiler compiler = new CSharpCompiler();
			this.compiledAssembly = compiler.CompileSource(Resources.SourceTests, Assembly.GetExecutingAssembly());
			this.sourceTestsCompiledType = this.compiledAssembly.GetType("H8.SourceTests");
		}

		[TestMethod]
		public void HelloWorld() {
			this.TestMethod("HelloWorld", Resources.SourceTests_HelloWorld);
		}

		[TestMethod]
		public void WhileLoop() {
			this.TestMethod("WhileLoop", Resources.SourceTests_WhileLoop);
		}

		[TestMethod]
		public void ForLoop() {
			this.TestMethod("ForLoop", Resources.SourceTests_ForLoop);
		}

		[TestMethod]
		public void DoWhileLoop() {
			this.TestMethod("DoWhileLoop", Resources.SourceTests_DoWhileLoop);
		}

		[TestMethod]
		public void WhileBreakLoop() {
			this.TestMethod("WhileBreakLoop", Resources.SourceTests_WhileBreakLoop);
		}

		[TestMethod]
		public void WhileCondBreakLoop() {
			this.TestMethod("WhileCondBreakLoop", Resources.SourceTests_WhileCondBreakLoop);
		}

		[TestMethod]
		public void If() {
			this.TestMethod("If", Resources.SourceTests_If);
		}

		[TestMethod]
		public void IfElse() {
			this.TestMethod("IfElse", Resources.SourceTests_IfElse);
		}

		[TestMethod]
		public void IfIf() {
			this.TestMethod("IfIf", Resources.SourceTests_IfIf);
		}

		[TestMethod]
		public void Cifuentes() {
			this.TestMethod("Cifuentes", Resources.SourceTests_Cifuentes);
		}

		[TestMethod]
		public void EnumArray() {
			this.TestMethod("EnumArray", Resources.SourceTests_EnumArray);
		}

		[TestMethod]
		public void EmitInnerClass() {
			this.TestType("H8.SourceTests+InnerClassTest", Resources.SourceTests_EmitInnerClass);
		}

		[TestMethod]
		public void EmitOuterClass() {
			this.TestType("H8.OuterClassTest", Resources.SourceTests_EmitOuterClass);
		}

		[TestMethod]
		public void CreateInnerObject() {
			this.TestMethod("CreateInnerObject", Resources.SourceTests_CreateInnerObject);
		}

		[TestMethod]
		public void CreateOuterObject() {
			this.TestMethod("CreateOuterObject", Resources.SourceTests_CreateOuterObject);
		}

		[TestMethod]
		public void TakeParameters() {
			this.TestMethod("TakeParameters", Resources.SourceTests_TakeParameters);
		}

		[TestMethod]
		public void Switch() {
			this.TestMethod("Switch", Resources.SourceTests_Switch);
		}

		[TestMethod]
		public void AnonymousType() {
			this.TestMethod("AnonymousType", Resources.SourceTests_AnonymousType, true);
		}

		[TestMethod]
		public void Linq() {
			this.TestMethod("Linq", Resources.SourceTests_Linq, true);
		}

		[TestMethod]
		public void Callback() {
			this.TestMethod("Callback", Resources.SourceTests_Callback, true);
		}

		[TestMethod]
		public void CallTakeParameters() {
			this.TestMethod("CallTakeParameters", Resources.SourceTests_CallTakeParameters, true);
		}

		private void TestMethod(string methodName, string expected) {
			this.TestMethod(methodName, expected, false);
		}

		private void TestMethod(string methodName, string expected, bool followDependencies) {
			MethodInfo method = sourceTestsCompiledType.GetMethod(methodName);
			TextWriter writer = new StringWriter();
			JsCodeGenerator generator = new JsCodeGenerator(writer, false);
			TranslationContext context = new TranslationContext(generator);
			context.GenerateMethod(method, followDependencies);
			Assert.AreEqual(expected.Trim(), writer.ToString().Trim());
		}

		private void TestType(string typeName, string expected) {
			Type compiledType = this.compiledAssembly.GetType(typeName);
			TextWriter writer = new StringWriter();
			JsCodeGenerator generator = new JsCodeGenerator(writer, false);
			TranslationContext context = new TranslationContext(generator);
			context.GenerateType(compiledType);
			Assert.AreEqual(expected.Trim(), writer.ToString().Trim());
		}

		private Assembly compiledAssembly;
		private Type sourceTestsCompiledType;
	}
}
