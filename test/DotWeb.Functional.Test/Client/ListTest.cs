using System;
using System.Collections.Generic;
using DotWeb.Client;

namespace DotWeb.Functional.Test.Client
{
	class ListTest : TestBase
	{
		protected override void RunTest() {
			var list = new List<string>();
			list.Add("one");
			list.Add("two");
			list.Add("three");

			AreStringsEqual("list.ToString()", "[ one,two,three ]", () => list);

			AreEqual("list.IndexOf('one')", 0, () => list.IndexOf("one"));
			AreEqual("list.IndexOf('two')", 1, () => list.IndexOf("two"));
			AreEqual("list.IndexOf('three')", 2, () => list.IndexOf("three"));
			AreEqual("list.IndexOf('none')", -1, () => list.IndexOf("none"));

			list.Add("two");
			AreStringsEqual("list.Add('two')", "[ one,two,three,two ]", () => list);

			list.Remove("two");
			AreStringsEqual("list.Remove('two')", "[ one,three,two ]", () => list);

			list.Clear();
			AreStringsEqual("list.Clear()", "[  ]", () => list);

			list.Add("x");
			list.Add("y");
			list.Add("z");

			AreStringsEqual("list.Add(x, y, z)", "[ x,y,z ]", () => list);
			AreEqual("list.Contains('x')", true, () => list.Contains("x"));
			AreEqual("list.Contains('nothere')", false, () => list.Contains("nothere"));

			list.Insert(0, "a");
			AreStringsEqual("list.Insert(0, 'a')", "[ a,x,y,z ]", () => list);

			list.Insert(4, "zz");
			AreStringsEqual("list.Insert(4, 'zz')", "[ a,x,y,z,zz ]", () => list);

			list.Insert(1, "b");
			AreStringsEqual("list.Insert(1, 'b')", "[ a,b,x,y,z,zz ]", () => list);

			list.Insert(2, "c");
			AreStringsEqual("list.Insert(2, 'c')", "[ a,b,c,x,y,z,zz ]", () => list);

			list.RemoveAt(2);
			AreStringsEqual("list.RemoveAt(2)", "[ a,b,x,y,z,zz ]", () => list);

			list.RemoveAt(0);
			AreStringsEqual("list.RemoveAt(0)", "[ b,x,y,z,zz ]", () => list);

			list.RemoveAt(4);
			AreStringsEqual("list.RemoveAt(5)", "[ b,x,y,z ]", () => list);

			var strArgOutOfRange = "System.ArgumentOutOfRangeException";
			ExpectException("list.Insert(5, 'zz')", strArgOutOfRange, () => list.Insert(5, "zz"));
			ExpectException("list.RemoveAt(-1)", strArgOutOfRange, () => list.RemoveAt(-1));
			ExpectException("list.RemoveAt(4)", strArgOutOfRange, () => list.RemoveAt(4));
			ExpectException("x = list[4]", strArgOutOfRange, () => { var x = list[4]; });
			ExpectException("list[4] = x", strArgOutOfRange, () => { list[4] = "x"; });

			var list2 = new List<int>();
			list2.Add(0);
			list2.Add(1);
			list2.Add(2);

			int i = 0;
			foreach (var x in list2) {
				Log.Write("enumerator" + i);
				AreEqual("enumerator" + i, i, () => x);
				i++;
			}
		}
	}
}
