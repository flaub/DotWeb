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
using System.Linq;
using DotWeb.Client;
using System.DotWeb;
using System.Collections.Generic;
using DotWeb.Client.Dom.Events;
using DotWeb.Client.Dom.Html;

namespace H8
{
	public class SystemTests
	{
		class Base
		{
			public virtual void Foo() { }
		}

		class Derived : Base
		{
			public override void Foo() {
				base.Foo();
				this.Foo();
			}
		}

		interface Interface
		{
			void Foo();
		}
		 
		class Impl : Interface
 		{
			public void Foo() { }

			public void CallFoo() {
				this.Foo();
			}
		}

		class CtorChain
		{
			public CtorChain() : this(55) { }
			public CtorChain(int x) { }
		}

		public void TestBase() {
			Base x = new Base();
			x.Foo();
		}

		public void TestDerived() {
			Derived x = new Derived();
			x.Foo();
		}

		public void TestDerivedThruBase() {
			Base x = new Derived();
			x.Foo();
		}

		public void TestDerivedThruBaseIndirect() {
			Derived x = new Derived();
			UseBase(x);
		}

		public void CallThisInterfaceMethod() {
			var x = new Impl();
			x.CallFoo();
		}

		private void UseBase(Base x) {
			x.Foo();
		}

		public void TestList() {
			var list = new List<string>();
			list.Add("one");
			Console.WriteLine(list.ToString());

			var index = list.IndexOf("one");
			Console.WriteLine(index);

			list.Remove("two");
		}

		public void TestListEnumerator() {
			var list = new List<string>();
			foreach (var item in list) {
				Console.WriteLine(item);
			}
		}

		public void TestGenericMethod() {
			var list = new List<string>();
			list.Add("one");
			AreEqual("IndexOf", 0, list.IndexOf("one"));
		}

		private void AreEqual<T>(string name, T expected, T actual) {
			var expectedString = expected.ToString();
			var equal = expected.Equals(actual);
			Console.WriteLine(equal);
		}

		public void CastInterface() {
			var element = Global.Document.getElementById("box");
			var box = (HtmlDivElement)element;
			box.onmouseover = box_OnMouseOver;
		}

		private void box_OnMouseOver(MouseEvent evt) {
		}

		public void TestJsArray() {
			var array = new JsArray();
			if (JsArray.IsArray(array)) {
				var part = array.Slice(0, 1);
				Console.WriteLine(part.Join(","));
			}

			var result1 = array.Splice(0, 0);
			var result2 = array.Splice(0, 0, 1);
			var result3 = array.Splice(0, 0, 1, "two");
			var x = new JsArray(1, 2);
			Console.WriteLine(x[0]);
			x[1] = 1;
		}

		public void TestString() {
			var str = "This is a test";
			Console.WriteLine(str.Length);
			var test = str.Substring(9);
			Console.WriteLine(test);
			//Console.WriteLine(string.Format("Test: {0}", "arg0"));
		}

		public void TestCtorChain() {
			new CtorChain();
		}

		private void TakeInt(int x) { }
		private void TakeFloat(float x) { }
		private void TakeDouble(double x) { }

		public void TestCastPrimitive(int i, float f, double d) {
			TakeInt(i);
			TakeInt((int)f);
			TakeInt((int)d);
			TakeInt(i * i);
			TakeInt((int)(i * f));
			TakeInt((int)(i * d));
			TakeInt((int)(f * f));
			TakeInt((int)(f * d));
			TakeInt((int)(d * d));
			TakeFloat(i);
			TakeFloat(f);
			TakeFloat((float)d);
			TakeFloat(i * i);
			TakeFloat(i * f);
			TakeFloat((float)(i * d));
			TakeFloat(f * f);
			TakeFloat((float)(f * d));
			TakeFloat((float)(d * d));
			TakeDouble(i);
			TakeDouble(f);
			TakeDouble(d);
			TakeDouble(i * i);
			TakeDouble(i * f);
			TakeDouble(i * d);
			TakeDouble(f * f);
			TakeDouble(f * d);
			TakeDouble(d * d);
		}
	}
}
