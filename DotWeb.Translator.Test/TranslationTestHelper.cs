using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using DotWeb.Translator.Generator.JavaScript;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotWeb.Decompiler;

namespace DotWeb.Translator.Test
{
	public abstract class TranslationTestHelper
	{
		protected TranslationTestHelper(string src) {
			CSharpCompiler compiler = new CSharpCompiler();
			this.compiledAssembly = compiler.CompileSource(src, Assembly.GetExecutingAssembly());
		}

		protected void TestMethod(string typeName, string methodName, string expected) {
			Type type = this.compiledAssembly.GetType(typeName);
			TestMethod(type, methodName, expected);
		}

		protected void TestMethod(Type type, string methodName, string expected) {
			this.TestMethod(type, methodName, expected, false);
		}

		protected void TestMethod(string typeName, string methodName, string expected, bool followDependencies) {
			Type type = this.compiledAssembly.GetType(typeName);
			TestMethod(type, methodName, expected, followDependencies);
		}

		protected void TestMethod(Type type, string methodName, string expected, bool followDependencies) {
			MethodInfo method = type.GetMethod(methodName);
			TextWriter writer = new StringWriter();
			JsCodeGenerator generator = new JsCodeGenerator(writer, false);
			TranslationContext context = new TranslationContext(generator);
			context.GenerateMethod(method, followDependencies);
			Assert.AreEqual(expected.Trim(), writer.ToString().Trim());
		}

		protected void TestType(string typeName, string expected) {
			Type compiledType = this.compiledAssembly.GetType(typeName);
			TextWriter writer = new StringWriter();
			JsCodeGenerator generator = new JsCodeGenerator(writer, false);
			TranslationContext context = new TranslationContext(generator);
			context.GenerateType(compiledType);
			Assert.AreEqual(expected.Trim(), writer.ToString().Trim());
		}

		protected Assembly compiledAssembly;
	}
}
