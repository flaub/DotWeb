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
	/// <summary>
	/// Summary description for DecorationTest
	/// </summary>
	[TestFixture]
	public class DecorationTest : TranslationTestHelper<DecorationTest>
	{
		public DecorationTest()
			: base("DotWeb.Translator.Test.Script", Resources.DecorationTest) {
			this.compiledType = this.CompiledAssembly.MainModule.Types["H8.DecorationTests"];
		}

		[Test]
		public void TestJsCode() {
			TestMethod(this.compiledType, "TestJsCode", Resources.DecorationTest_JsCode);
		}

		[Test]
		public void TestJsAnonymous() {
			TestMethod(this.compiledType, "TestJsAnonymous", Resources.DecorationTest_JsAnonymous, true);
		}

		[Test]
		public void TestJsIntrinsic() {
			TestMethod(this.compiledType, "TestJsIntrinsic", Resources.DecorationTest_JsIntrinsic, true);
		}

		[Test]
		public void TestJsNamespace() {
			TestMethod(this.compiledType, "TestJsNamespace", Resources.DecorationTest_JsNamespace, true);
		}

		//[Test]
		//[ExpectedException(typeof(InvalidAnonymousUsageException))]
		//public void InvalidAnonymousClass1() {
		//    GenerateMethod(this.compiledType, "InvalidAnonymousClass1", true);
		//}

		//[Test]
		//[ExpectedException(typeof(InvalidAnonymousUsageException))]
		//public void InvalidAnonymousClass2() {
		//    GenerateMethod(this.compiledType, "InvalidAnonymousClass2", true);
		//}

		//[Test]
		//[ExpectedException(typeof(InvalidIntrinsicUsageException))]
		//public void InvalidIntrinsicClass() {
		//    GenerateMethod(this.compiledType, "InvalidIntrinsicClass", true);
		//}

		[Test]
		public void TestCastInterface() {
			TestMethod(this.compiledType, "TestCastInterface", Resources.DecorationTest_CastInterface, true);
		}

		private TypeDefinition compiledType;
	}
}
