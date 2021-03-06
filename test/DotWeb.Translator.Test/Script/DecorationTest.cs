﻿// Copyright 2009, Frank Laub
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
using DotWeb.Client;
using DotWeb.Client.Dom.Html;
using DotWeb.Client.Dom.Events;
using System.DotWeb;

namespace H8
{
	[JsAnonymous]
	class AnonymousClass
	{
		public int X { get; set; }
		public int y;
	}

	[JsAnonymous]
	class DynamicAnonymousClass : JsDynamic
	{
		public string id { get { return (string)this["id"]; } set { this["id"] = value; } }
	}

	// Anonymous classes can only have auto-properties
	[JsAnonymous]
	class InvalidAnonymousClass1
	{
		public int X {
			get { return 1; }
		}
	}

	// Anonymous classes cannot have methods
	[JsAnonymous]
	class InvalidAnonymousClass2
	{
		public int X { get; set; }

		public void Invalid() {
		}
	}

	class IntrinsicClass
	{
		[JsIntrinsic]
		public int Value { get; set; }
	}

	// Only auto-properties are allowed
	class InvalidIntrinsicClass
	{
		[JsIntrinsic]
		public int Value { get { return 1; } set { } }
	}

	[JsNamespace]
	class DefaultNamespaceTest
	{
		public int Value { get; set; }
	}

	[JsNamespace("Foo")]
	class FooNamespaceTest
	{
		public int Value { get; set; }
	}

	[JsCamelCase]
	class CamelCaseTest
	{
		public void CamelCase() { }

		[JsCamelCase(false)]
		public void NotCamelCase() { }
	}

	public class DecorationTests
	{
		[JsCode("alert(arg);")]
		public void TestJsCode(string arg) {
		}

		[JsMacro("{0}.jQuery({1})")]
		public extern object JQuery(string selector);

		[JsMacro("{0}.jQuery({1})")]
		public static extern object StaticJQuery(string selector);

		[JsCode("alert(jquery);")]
		public static extern void TakeJQuery(object jquery);

		public extern HtmlDocument Document {
			[JsMacro("$doc")]
			get;
		}

		public extern char this[int index] { 
			[JsMacro("{0}.charAt({1})")]
			get; 
		}

		[JsCamelCase]
		public void CamelCase() { }

		public void TestJsCamelCase() {
			var x = new CamelCaseTest();
			x.CamelCase();
			x.NotCamelCase();
			CamelCase();
		}

		public void TestJsMacro() {
			JQuery("*");
			StaticJQuery("*");
			TakeJQuery(JQuery("#id"));
			Console.WriteLine(Document.getElementById("id"));
			Console.WriteLine(this[0]);
		}

		public void TestJsAnonymous() {
			var item = new AnonymousClass {
				X = 1,
				y = 2
			};

			item.X = item.y;
			item.y = item.X;

			var array = new AnonymousClass[] {
				new AnonymousClass { X = 0, y = 0 },
				new AnonymousClass { X = 1, y = 1 },
			};

			var first = array[0];
			Console.WriteLine(first);

			var dynamic = new DynamicAnonymousClass();
			dynamic.id = "1";
		}

		public void InvalidAnonymousClass1() {
			var item = new InvalidAnonymousClass1();
		}

		public void InvalidAnonymousClass2() {
			var item = new InvalidAnonymousClass2();
		}

		public void TestJsIntrinsic() {
			var item = new IntrinsicClass {
				Value = 1
			};
			Console.Write(item.Value);
		}

		public void InvalidIntrinsicClass() {
			var item = new InvalidIntrinsicClass {
				Value = 1
			};
		}

		public void TestJsNamespace() {
			var item1 = new DefaultNamespaceTest {
				Value = 1
			};

			var item2 = new FooNamespaceTest {
				Value = item1.Value
			};

			Console.WriteLine(item2.Value);
		}

	}
}
