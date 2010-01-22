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
using DotWeb.Translator.Test.Properties;
using NUnit.Framework;
using Mono.Cecil;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class TranslationTest : TranslationTestHelper<TranslationTest>
	{
		public TranslationTest()
			: base("DotWeb.Translator.Test.Script", Resources.TranslationTest) {
			this.sourceTestsCompiledType = this.CompiledAssembly.MainModule.Types["H8.SourceTests"];
		}

		[Test]
		public void HelloWorld() {
			this.TestMethod(this.sourceTestsCompiledType, "HelloWorld", Resources.SourceTests_HelloWorld);
		}

		[Test]
		public void WhileLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "WhileLoop", Resources.SourceTests_WhileLoop);
		}

		[Test]
		public void ForLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "ForLoop", Resources.SourceTests_ForLoop);
		}

		[Test]
		public void DoWhileLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "DoWhileLoop", Resources.SourceTests_DoWhileLoop);
		}

		[Test]
		public void WhileBreakLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "WhileBreakLoop", Resources.SourceTests_WhileBreakLoop);
		}

		[Test]
		public void WhileCondBreakLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "WhileCondBreakLoop", Resources.SourceTests_WhileCondBreakLoop);
		}

		[Test]
		public void If() {
			this.TestMethod(this.sourceTestsCompiledType, "If", Resources.SourceTests_If);
		}

		[Test]
		public void IfElse() {
			this.TestMethod(this.sourceTestsCompiledType, "IfElse", Resources.SourceTests_IfElse);
		}

		[Test]
		public void IfIf() {
			this.TestMethod(this.sourceTestsCompiledType, "IfIf", Resources.SourceTests_IfIf);
		}

		[Test]
		public void Cifuentes() {
			this.TestMethod(this.sourceTestsCompiledType, "Cifuentes", Resources.SourceTests_Cifuentes);
		}

		[Test]
		public void EnumArray() {
			this.TestMethod(this.sourceTestsCompiledType, "EnumArray", Resources.SourceTests_EnumArray);
		}

		[Test]
		public void CreateInnerObject() {
			this.TestMethod(this.sourceTestsCompiledType, "CreateInnerObject", Resources.SourceTests_CreateInnerObject, true);
		}

		[Test]
		public void CreateOuterObject() {
			this.TestMethod(this.sourceTestsCompiledType, "CreateOuterObject", Resources.SourceTests_CreateOuterObject, true);
		}

		[Test]
		public void TakeParameters() {
			this.TestMethod(this.sourceTestsCompiledType, "TakeParameters", Resources.SourceTests_TakeParameters);
		}

		[Test]
		public void Switch() {
			this.TestMethod(this.sourceTestsCompiledType, "Switch", Resources.SourceTests_Switch);
		}

		[Test]
		public void AnonymousType() {
			var value = new {
				Key = "Hi",
				Value = 1
			};
			this.TestMethod(this.sourceTestsCompiledType, "AnonymousType", Resources.SourceTests_AnonymousType, true);
		}

		[Test]
		[Ignore]
		public void Linq() {
			this.TestMethod(this.sourceTestsCompiledType, "Linq", Resources.SourceTests_Linq, true);
		}

		[Test]
		public void Callback() {
			this.TestMethod(this.sourceTestsCompiledType, "Callback", Resources.SourceTests_Callback, true);
		}

		[Test]
		public void CallTakeParameters() {
			this.TestMethod(this.sourceTestsCompiledType, "CallTakeParameters", Resources.SourceTests_CallTakeParameters, true);
		}

		[Test]
		public void CallDerived() {
			this.TestMethod(this.sourceTestsCompiledType, "CallDerived", Resources.SourceTests_CallDerived, true);
		}

		[Test]
		public void Indexer() {
			this.TestMethod(this.sourceTestsCompiledType, "Indexer", Resources.SourceTests_Indexer, true);
		}

		[Test]
		public void TestGenericNested() {
			this.TestMethod(this.sourceTestsCompiledType, "TestGenericNested", Resources.SourceTests_TestGenericNested, true);
		}

		[Test]
		public void TestCompoundAnd() {
			this.TestMethod(this.sourceTestsCompiledType, "TestCompoundAnd", Resources.SourceTests_TestCompoundAnd, false);
		}

		[Test]
		public void TestCompoundNotOr() {
			this.TestMethod(this.sourceTestsCompiledType, "TestCompoundNotOr", Resources.SourceTests_TestCompoundNotOr, false);
		}

		[Test]
		public void TestCompoundNotAnd() {
			this.TestMethod(this.sourceTestsCompiledType, "TestCompoundNotAnd", Resources.SourceTests_TestCompoundNotAnd, false);
		}

		[Test]
		public void TestCompoundOr() {
			this.TestMethod(this.sourceTestsCompiledType, "TestCompoundOr", Resources.SourceTests_TestCompoundOr, false);
		}

		private TypeDefinition sourceTestsCompiledType;
	}
}
