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
using DotWeb.Client.Dom;

namespace H8
{
	class OuterClassTest
	{
		public string Text { get; set; }

		public int Value {
			get { return this.m_value; }
			set { this.m_value = value; }
		}

		public OuterClassTest() { }
		public OuterClassTest(string text, int value) {
			this.Text = text;
			this.Value = value;
		}

		private int m_value;
	}

	class Base
	{
		public int X { get; set; }

		public void BaseMethod() {
		}
	}

	class Derived : Base
	{
		private int id = NextId();

		private static int counter = 0;
		private static int NextId() {
			return counter++;
		}

		public Derived() {
		}

		public void DerviedMethod() {
			BaseMethod();
		}
	}

	class IndexerTest
	{
		[JsIntrinsic]
		public object this[string name] {
			get { return null; }
			set { }
		}
	}

	class Generic<T>
	{
		class Nested
		{
			class Inner
			{
				public void Foo() { }
			}

			public void Foo() {
				var x = new Inner();
				x.Foo();
			}
		}

		class Nested<Y>
		{
			class Inner<A, B>
			{
				public void Foo() { }
			}

			public void Foo() {
				var x = new Inner<int, int>();
				x.Foo();
			}
		}

		public void Foo() {
			var x = new Nested();
			x.Foo();

			var y = new Nested<int>();
			y.Foo();
		}
	}

	public class SourceTests
	{
		/// <summary>
		/// .method public hidebysig instance void  HelloWorld() cil managed
		/// {
		///  // Code size       13 (0xd)
		///  .maxstack  8
		///  IL_0000:  nop
		///  IL_0001:  ldstr      "Hello World!"
		///  IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
		///  IL_000b:  nop
		///  IL_000c:  ret
		/// } // end of method Program::HelloWorld
		/// </summary>
		public void HelloWorld() {
			Console.WriteLine("Hello World!");
		}


		public void Cifuentes() {
			//0000: ldc.i4.5 Next
			//0001: stloc.0 Next
			int x = 5;
			//0002: ldloc.0 Next
			//0003: ldc.i4.5 Next
			//0004: mul Next
			//0005: stloc.1 Next
			int y = x * 5;
			//0006: ldloc.0 Next
			//0007: ldloc.1 Next
			//0008: bge.s 0030 Cond_Branch
			if (x < y) {
				//0010: ldloc.0 Next
				//0011: ldloc.1 Next
				//0012: mul Next
				//0013: stloc.0 Next
				x = x * y;
				//0014: ldloc.0 Next
				//0015: ldc.i4.2 Next
				//0016: mul Next
				//0017: ldloc.1 Next
				//0018: bgt.s 0026 Cond_Branch
				if ((x * 2) <= y) {
					//0020: ldloc.1 Next
					//0021: ldc.i4.3 Next
					//0022: shl Next
					//0023: stloc.1 Next
					y = y << 3;
					//0024: br.s 0030 Branch
				}
				else {
					//0026: ldloc.0 Next
					//0027: ldc.i4.3 Next
					//0028: shl Next
					//0029: stloc.0 Next
					x = x << 3;
				}
			}
			//0030: ldc.i4.0 Next
			//0031: stloc.2 Next
			int a = 0;

			//0032: br.s 0070 Branch
			//0070: ldloc.2 Next
			//0071: ldc.i4.s 10 Next
			//0073: blt.s 0034 Cond_Branch
			while (a < 10) {
				//0034: ldloc.2 Next
				//0035: stloc.3 Next
				int b = a;
				do {
					//0036: ldloc.3 Next
					//0037: ldc.i4.1 Next
					//0038: add Next
					//0039: stloc.3 Next
					b++;
					//0040: ldstr "{0}, {1}" Next
					//0045: ldloc.2 Next
					//0046: box System.Int32 Next
					//0051: ldloc.3 Next
					//0052: box System.Int32 Next
					//0057: call System.Void System.Console::WriteLine() Call
					Console.WriteLine("{0}, {1}", a, b);
					//0062: ldloc.3 Next
					//0063: ldc.i4.5 Next
					//0064: blt.s 0036 Cond_Branch
				} while (b < 5);
				//0066: ldloc.2 Next
				//0067: ldc.i4.1 Next
				//0068: add Next
				//0069: stloc.2 Next
				a++;
			}
			//0075: ldloc.0 Next
			//0076: ldloc.1 Next
			//0077: blt.s 0085 Cond_Branch
			//0079: ldloc.1 Next
			//0080: ldc.i4.2 Next
			//0081: mul Next
			//0082: ldloc.0 Next
			//0083: ble.s 0096 Cond_Branch
			if ((x < y) || ((y * 2) > x)) {
				//0085: ldloc.0 Next
				//0086: ldloc.1 Next
				//0087: add Next
				//0088: ldc.i4.s 10 Next
				//0090: sub Next
				//0091: stloc.0 Next
				x = x + y - 10;
				//0092: ldloc.1 Next
				//0093: ldc.i4.2 Next
				//0094: div Next
				//0095: stloc.1 Next
				y = y / 2;
			}
		}

		public void EnumArray() {
			//0000: ldc.i4.4 Next
			//0001: newarr System.Int32 Next
			//0006: dup Next
			//0007: ldtoken __StaticArrayInitTypeSize=16 $$method0x6000085-1 Next
			//0012: call System.Void System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray() Call
			//0017: stloc.0 Next
			//0018: ldloc.0 Next
			//0019: stloc.2 Next
			//0020: ldc.i4.0 Next
			//0021: stloc.3 Next
			int[] array = { 1, 2, 3, 4 };
			//0022: br.s 0038 Branch
			//0038: ldloc.3 Next
			//0039: ldloc.2 Next
			//0040: ldlen Next
			//0041: conv.i4 Next
			//0042: blt.s 0024 Cond_Branch
			foreach (int item in array) {
				//0024: ldloc.2 Next
				//0025: ldloc.3 Next
				//0026: ldelem.i4 Next
				//0027: stloc.1 Next
				//0028: ldloc.1 Next
				//0029: call System.Void System.Console::WriteLine() Call
				Console.WriteLine(item);
				//0034: ldloc.3 Next
				//0035: ldc.i4.1 Next
				//0036: add Next
				//0037: stloc.3 Next
			}
			//0044: ret Return
		}

		class InnerClassTest
		{
			public string Text { get; set; }
			public int Value { get; set; }

			public InnerClassTest() { }
			public InnerClassTest(string text, int value) {
				this.Text = text;
				this.Value = value;
			}
		}

		public void CreateInnerObject() {
			//0000: ldstr "Test1" Next
			//0005: ldc.i4.1 Next
			//0006: newobj instance void H8.SourceTests+InnerClassTest::.ctor() Call
			//0011: stloc.0 Next
			//0012: newobj instance void H8.SourceTests+InnerClassTest::.ctor() Call
			//0017: stloc.2 Next
			//0018: ldloc.2 Next
			//0019: ldstr "Test2" Next
			//0024: callvirt instance System.Void H8.SourceTests+InnerClassTest::set_Text() Call
			//0029: ldloc.2 Next
			//0030: ldc.i4.2 Next
			//0031: callvirt instance System.Void H8.SourceTests+InnerClassTest::set_Value() Call
			//0036: ldloc.2 Next
			//0037: stloc.1 Next
			//0038: ldstr "{0}, {1}" Next
			//0043: ldloc.0 Next
			//0044: callvirt instance System.String H8.SourceTests+InnerClassTest::get_Text() Call
			//0049: ldloc.0 Next
			//0050: callvirt instance System.Int32 H8.SourceTests+InnerClassTest::get_Value() Call
			//0055: box System.Int32 Next
			//0060: call System.Void System.Console::WriteLine() Call
			//0065: ldstr "{0}, {1}" Next
			//0070: ldloc.1 Next
			//0071: callvirt instance System.String H8.SourceTests+InnerClassTest::get_Text() Call
			//0076: ldloc.1 Next
			//0077: callvirt instance System.Int32 H8.SourceTests+InnerClassTest::get_Value() Call
			//0082: box System.Int32 Next
			//0087: call System.Void System.Console::WriteLine() Call
			//0092: ret Return
			InnerClassTest test1 = new InnerClassTest("Test1", 1);
			InnerClassTest test2 = new InnerClassTest {
				Text = "Test2",
				Value = 2
			};
			Console.WriteLine("{0}, {1}", test1.Text, test1.Value);
			Console.WriteLine("{0}, {1}", test2.Text, test2.Value);
		}

		public void CreateOuterObject() {
			OuterClassTest test1 = new OuterClassTest("Test1", 1);
			OuterClassTest test2 = new OuterClassTest {
				Text = "Test2",
				Value = 2
			};
			Console.WriteLine("{0}, {1}", test1.Text, test1.Value);
			Console.WriteLine("{0}, {1}", test2.Text, test2.Value);
		}

		//public void Linq() {
		//    //0000: ldstr "ABCDE99F-J74-12-89A" Next
		//    //0005: stloc.0 Next
		//    //0006: ldloc.0 Next
		//    //0007: ldsfld System.Func`2[System.Char,System.Boolean] H8.SourceTests::CS$<>9__CachedAnonymousMethodDelegate2 Next
		//    //0012: brtrue.s 0031 Cond_Branch
		//    //0014: ldnull Next
		//    //0016: ldftn System.Boolean H8.SourceTests::<Linq>b__1() Next
		//    //0021: newobj instance void System.Func`2[System.Char,System.Boolean]::.ctor() Call
		//    //0026: stsfld System.Func`2[System.Char,System.Boolean] H8.SourceTests::CS$<>9__CachedAnonymousMethodDelegate2 Next
		//    //0031: ldsfld System.Func`2[System.Char,System.Boolean] H8.SourceTests::CS$<>9__CachedAnonymousMethodDelegate2 Next
		//    //0036: call System.Collections.Generic.IEnumerable`1[System.Char] System.Linq.Enumerable::Where() Call
		//    //0041: stloc.1 Next
		//    //0042: ldloc.1 Next
		//    //0043: callvirt instance System.Collections.Generic.IEnumerator`1[System.Char] System.Collections.Generic.IEnumerable`1[System.Char]::GetEnumerator() Call
		//    //0048: stloc.3 Next
		//    //0049: br.s 0064 Branch
		//    //0051: ldloc.3 Next
		//    //0052: callvirt instance System.Char System.Collections.Generic.IEnumerator`1[System.Char]::get_Current() Call
		//    //0057: stloc.2 Next
		//    //0058: ldloc.2 Next
		//    //0059: call System.Void System.Console::WriteLine() Call
		//    //0064: ldloc.3 Next
		//    //0065: callvirt instance System.Boolean System.Collections.IEnumerator::MoveNext() Call
		//    //0070: brtrue.s 0051 Cond_Branch
		//    //0072: leave.s 0084 Branch
		//    //0074: ldloc.3 Next
		//    //0075: brfalse.s 0083 Cond_Branch
		//    //0077: ldloc.3 Next
		//    //0078: callvirt instance System.Void System.IDisposable::Dispose() Call
		//    //0083: endfinally Return
		//    //0084: ret Return
		//    string str = "ABCDE99F-J74-12-89A";
		//    var query = from ch in str
		//                where Char.IsDigit(ch)
		//                select ch;

		//    foreach (var item in query) {
		//        Console.WriteLine(item);
		//    }
		//}

		public delegate void SimpleDelegate();
		public event SimpleDelegate SimpleEvent;

		public double TakeParameters(string str, int value, double[] rad, bool flag) {
			Console.WriteLine(str);
			double x = Math.Sin(rad[value] * (Math.PI / 2.0));
			return Math.Cos(x);
		}

		public void CallTakeParameters() {
			double result = TakeParameters("Hi", 1, new double[] { 1.0, 2.0 }, true);
			Console.WriteLine(result);
		}

		public void Callback(SimpleDelegate del) {
			if (del != null)
				del();

			if (SimpleEvent != null)
				SimpleEvent();

			SimpleEvent += new SimpleDelegate(SourceTests_SimpleEvent);
		}

		public void SourceTests_SimpleEvent() {
			throw new NotImplementedException();
		}

		public void TryCatch() {
			try {
				Console.WriteLine("Try this");
			}
			catch (SystemException ex) {
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}

		public void AnonymousType() {
			var value = new {
				Key = "Hi",
				Value = 1
			};
			Console.WriteLine("{0}: {1}", value.Key.Length, value.Value);
		}

		public void CallDerived() {
			Derived derived = new Derived();
			derived.DerviedMethod();
			derived.BaseMethod();
		}

		public void Indexer() {
			var indexer = new IndexerTest();
			indexer["Test"] = 1;
			var value = indexer["Test"];
			Console.WriteLine(value);
		}

		public void TestGenericNested() {
			var x = new Generic<int>();
			x.Foo();
		}

		public void SwitchInsideWhile(int x) {
			Console.WriteLine("enter");
			while (x > 10) {
				Console.WriteLine("head");
				switch (x) {
					case 0:
						Console.WriteLine("Zero: return");
						return;
					case 1:
					case 2:
						Console.WriteLine("One & Two");
						break;
					case 3:
						Console.WriteLine("Three: continue");
						continue;
					default:
						Console.WriteLine("default");
						break;
				}
				Console.WriteLine("tail");
			}
			Console.WriteLine("exit");
		}

		public void GitHub_Issue3() {
			new jQuery13.jQueryTest(Global.Document);
		}

		public void GitHub_Issue4() {
			Action action = () => Global.Window.alert("test");
			action();
		}

		public void GitHub_Issue5() {
			new GitHub_Issue5.Class1();
		}

		public void GitHub_Issue6(bool x) {
			Console.WriteLine("enter");
			try {
				Console.WriteLine("try begin");
				if (x) {
					throw new NotImplementedException();
				}
				Console.WriteLine("try end");
			}
			catch (NotImplementedException ex) {
				Console.WriteLine("NotImplementedException: " + ex.Message);
			}
			catch (Exception ex) {
				Console.WriteLine("Exception: " + ex.Message);
			}
			finally {
				Console.WriteLine("finally");
			}
			Console.WriteLine("exit");
		}

		public void NestedTry() {
			Console.WriteLine("enter");
			try {
				Console.WriteLine("outer try");
				try {
					Console.WriteLine("inner try");
				}
				finally {
					Console.WriteLine("inner finally");
				}
				Console.WriteLine("inner follow");
			}
			finally {
				Console.WriteLine("outer finally");
			}
			Console.WriteLine("exit");
		}

		public void ComplexNestedTry(int x) {
			Console.WriteLine("enter");
			try {
				Console.WriteLine("outer try");
				try {
					Console.WriteLine("inner try");
				}
				finally {
					Console.WriteLine("inner finally");
				}
				Console.WriteLine("inner follow");
				if (x == 10) {
					Console.WriteLine("x == 10");
				}
			}
			finally {
				Console.WriteLine("outer finally");
			}
			Console.WriteLine("exit");
		}

		public void TryInsideCatch() {
			Console.WriteLine("enter");
			try {
				Console.WriteLine("try1");
			}
			catch (Exception) {
				Console.WriteLine("catch");
				try {
					Console.WriteLine("try2");
				}
				finally {
					Console.WriteLine("finally");
				}
				Console.WriteLine("try2 follow");
			}
			Console.WriteLine("exit");
		}
	}
}

namespace jQuery13
{
	[JsNamespace]
	[JsIntrinsic]
	public class jQueryTest : JsObject
	{
		public extern jQueryTest(Document document);
	}
}

namespace GitHub_Issue5
{
	public class Class1
	{
		public void Call(Action action) {
			action();
		}

		public Class1() {
			Call(() => Global.Window.alert("test"));
		}
	}
}