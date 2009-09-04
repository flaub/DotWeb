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
using DotWeb.Decompiler;

namespace DotWeb.Translator.Test
{
	[TestClass]
	public class TranslationTest : TranslationTestHelper
	{
		public TranslationTest() : base(Resources.TranslationTest_Source) {
			this.sourceTestsCompiledType = this.compiledAssembly.GetType("H8.SourceTests");
		}

		[TestMethod]
		public void HelloWorld() {
			this.TestMethod(this.sourceTestsCompiledType, "HelloWorld", Resources.SourceTests_HelloWorld);
		}

		[TestMethod]
		public void WhileLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "WhileLoop", Resources.SourceTests_WhileLoop);
		}

		[TestMethod]
		public void ForLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "ForLoop", Resources.SourceTests_ForLoop);
		}

		[TestMethod]
		public void DoWhileLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "DoWhileLoop", Resources.SourceTests_DoWhileLoop);
		}

		[TestMethod]
		public void WhileBreakLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "WhileBreakLoop", Resources.SourceTests_WhileBreakLoop);
		}

		[TestMethod]
		public void WhileCondBreakLoop() {
			this.TestMethod(this.sourceTestsCompiledType, "WhileCondBreakLoop", Resources.SourceTests_WhileCondBreakLoop);
		}

		[TestMethod]
		public void If() {
			this.TestMethod(this.sourceTestsCompiledType, "If", Resources.SourceTests_If);
		}

		[TestMethod]
		public void IfElse() {
			this.TestMethod(this.sourceTestsCompiledType, "IfElse", Resources.SourceTests_IfElse);
		}

		[TestMethod]
		public void IfIf() {
			this.TestMethod(this.sourceTestsCompiledType, "IfIf", Resources.SourceTests_IfIf);
		}

		[TestMethod]
		public void Cifuentes() {
			this.TestMethod(this.sourceTestsCompiledType, "Cifuentes", Resources.SourceTests_Cifuentes);
		}

		[TestMethod]
		public void EnumArray() {
			this.TestMethod(this.sourceTestsCompiledType, "EnumArray", Resources.SourceTests_EnumArray);
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
			this.TestMethod(this.sourceTestsCompiledType, "CreateInnerObject", Resources.SourceTests_CreateInnerObject);
		}

		[TestMethod]
		public void CreateOuterObject() {
			this.TestMethod(this.sourceTestsCompiledType, "CreateOuterObject", Resources.SourceTests_CreateOuterObject);
		}

		[TestMethod]
		public void TakeParameters() {
			this.TestMethod(this.sourceTestsCompiledType, "TakeParameters", Resources.SourceTests_TakeParameters);
		}

		[TestMethod]
		public void Switch() {
			this.TestMethod(this.sourceTestsCompiledType, "Switch", Resources.SourceTests_Switch);
		}

		[TestMethod]
		public void AnonymousType() {
			this.TestMethod(this.sourceTestsCompiledType, "AnonymousType", Resources.SourceTests_AnonymousType, true);
		}

		[TestMethod]
		public void Linq() {
			this.TestMethod(this.sourceTestsCompiledType, "Linq", Resources.SourceTests_Linq, true);
		}

		[TestMethod]
		public void Callback() {
			this.TestMethod(this.sourceTestsCompiledType, "Callback", Resources.SourceTests_Callback, true);
		}

		[TestMethod]
		public void CallTakeParameters() {
			this.TestMethod(this.sourceTestsCompiledType, "CallTakeParameters", Resources.SourceTests_CallTakeParameters, true);
		}

		private Type sourceTestsCompiledType;
	}
}
