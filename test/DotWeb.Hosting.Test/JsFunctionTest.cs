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
// 
using System;
using System.Reflection;
using DotWeb.Client;
using DotWeb.Hosting.Bridge;
using NUnit.Framework;
using DotWeb.Hosting.Test.Script;
using System.IO;

namespace DotWeb.Hosting.Test
{
	[TestFixture]
	public class JsFunctionTest
	{
		private void AssertJsFunction(JsFunction function, string name, string parameters, string body) {
			Assert.AreEqual(name, function.Name);
			Assert.AreEqual(parameters, function.Parameters);
			Assert.AreEqual(body, function.Body);
		}

		private void RunTest(Type type, string methodName, string name, string parameters, string body) {
			var method = type.GetMethod(methodName);
			RunTest(method, name, parameters, body);
		}

		private void RunTest(string methodName, string name, string parameters, string body) {
			RunTest(typeof(CrashTestDummy), methodName, name, parameters, body);
		}

		private void RunTest(MethodBase method, string name, string parameters, string body) {
			var function = new JsFunction(method);
			AssertJsFunction(function, name, parameters, body);
		}

		[Test]
		public void TestConstructor() {
			RunTest(
				typeof (CrashTestDummy).GetConstructor(Type.EmptyTypes),
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$$ctor$0",
				"",
				"return new DotWeb.Hosting.Test.Script.CrashTestDummy();");
			RunTest(
				typeof (CrashTestDummy).GetConstructor(new[] {typeof (int)}),
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$$ctor$1",
				"x",
				"return new DotWeb.Hosting.Test.Script.CrashTestDummy(x);");
		}

		[Test]
		public void TestJsCode() {
			RunTest(
				"TestJsCode",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$TestJsCode",
				"",
				CrashTestDummy.JsCode);
		}

		[Test]
		public void TestJsNamespace() {
			RunTest(
				"TestNoArgs",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$TestNoArgs",
				"",
				"return this.TestNoArgs();");
			RunTest(
				typeof (DefaultNamesapce),
				"TestNoArgs",
				"__DotWeb_Hosting_Test_Script_DefaultNamesapce$TestNoArgs",
				"",
				"return this.TestNoArgs();");
			RunTest(
				typeof (FooNamesapce),
				"TestNoArgs",
				"__DotWeb_Hosting_Test_Script_FooNamesapce$TestNoArgs",
				"",
				"return this.TestNoArgs();");
		}

		[Test]
		public void TestMethod() {
			RunTest(
				"TestMethod",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$TestMethod",
				"",
				"return this.TestMethod();");
		}

		[Test]
		public void TestParameters() {
			RunTest(
				"TestNoArgs",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$TestNoArgs",
				"",
				"return this.TestNoArgs();");
			RunTest(
				"TestOneArg",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$TestOneArg",
				"x",
				"return this.TestOneArg(x);");
			RunTest(
				"TestTwoArgs",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$TestTwoArgs",
				"x, y",
				"return this.TestTwoArgs(x, y);");
		}

		[Test]
		public void TestPropertyGetter() {
			RunTest(
				"get_TestProperty",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$get_TestProperty",
				"",
				"return this.TestProperty;");
		}

		[Test]
		public void TestPropertySetter() {
			RunTest(
				"set_TestProperty",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$set_TestProperty",
				"value",
				"this.TestProperty = value;");
		}

		[Test]
		public void TestStaticMethod() {
			RunTest(
				"TestStatic",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$TestStatic",
				"",
				"return DotWeb.Hosting.Test.Script.CrashTestDummy.TestStatic();");
		}

		[Test]
		public void TestIndexer() {
			RunTest(
				"get_Item",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$get_Item",
				"name",
				"return this[name];");

			RunTest(
				"set_Item",
				"__DotWeb_Hosting_Test_Script_CrashTestDummy$set_Item",
				"name, value",
				"this[name] = value;");
		}

	}
}