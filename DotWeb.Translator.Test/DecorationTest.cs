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
using DotWeb.Decompiler;
using System.Reflection;
using DotWeb.Translator.Test.Properties;
using DotWeb.Client;

namespace DotWeb.Translator.Test
{
	/// <summary>
	/// Summary description for DecorationTest
	/// </summary>
	[TestClass]
	public class DecorationTest : TranslationTestHelper
	{
		public DecorationTest()
			: base(Resources.DecorationTest_Source) {
			this.compiledType = this.compiledAssembly.GetType("H8.DecorationTests");
		}

		[TestMethod]
		public void TestJsCode() {
			TestMethod(this.compiledType, "TestJsCode", Resources.DecorationTest_JsCode);
		}

		[TestMethod]
		public void TestJsAnonymous() {
			TestMethod(this.compiledType, "TestJsAnonymous", Resources.DecorationTest_JsAnonymous, true);
		}

		[TestMethod]
		public void TestJsIntrinsic() {
			TestMethod(this.compiledType, "TestJsIntrinsic", Resources.DecorationTest_JsIntrinsic, true);
		}

		[TestMethod]
		public void TestJsNamespace() {
			TestMethod(this.compiledType, "TestJsNamespace", Resources.DecorationTest_JsNamespace, true);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidAnonymousUsageException))]
		public void InvalidAnonymousClass1() {
			GenerateMethod(this.compiledType, "InvalidAnonymousClass1", true);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidAnonymousUsageException))]
		public void InvalidAnonymousClass2() {
			GenerateMethod(this.compiledType, "InvalidAnonymousClass2", true);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidIntrinsicUsageException))]
		public void InvalidIntrinsicClass() {
			GenerateMethod(this.compiledType, "InvalidIntrinsicClass", true);
		}

		private Type compiledType;
	}
}
