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
	public class TranslationTest : TranslationTestHelper
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
		public void SwitchInsideWhile() {
			this.TestMethod(this.sourceTestsCompiledType, "SwitchInsideWhile", Resources.SwitchInsideWhile);
		}

		private TypeDefinition sourceTestsCompiledType;
	}
}
