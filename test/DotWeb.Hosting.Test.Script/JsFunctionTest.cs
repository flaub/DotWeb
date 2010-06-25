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
using DotWeb.Client;
using System.DotWeb;
using DotWeb.Client.Dom;
using System;

namespace DotWeb.Hosting.Test.Script
{
	public class CrashTestDummy
	{
		public const string JsCode = "alert('hi');";

		public CrashTestDummy() { }
		public CrashTestDummy(int x) { }
		public int TestProperty { get; set; }

		[JsCode(JsCode)]
		public void TestJsCode() { }

		[JsMacro("{0}.alert({1})")]
		public void TestJsMacro(string arg) { }

		public extern Window Window {
			[JsMacro("$wnd")]
			get;
		}

		[JsCamelCase]
		public void TestJsCamelCaseMethod() { }

		[JsCamelCase]
		public bool TestJsCamelCaseProperty { get; set; }

		public void TestNoArgs() { }
		public void TestOneArg(int x) { }
		public void TestTwoArgs(int x, int y) { }

		public void TestMethod() { }

		public static void TestStatic() { }

		public object this[string name] {
			get {
				return null;
			}
			set {
			}
		}
	}

	[JsNamespace]
	public class DefaultNamespace
	{
		public void TestNoArgs() { }
	}

	[JsNamespace]
	public class FooNamespace
	{
		public void TestNoArgs() { }
	}

}
