using System;
using System.Collections.Generic;
using DotWeb.Client;

namespace DotWeb.Functional.Test.Client
{
	class List : JsScript
	{
		private TestResultView view;

		public List() {
			var sandbox = Document.getElementById("sandbox");
			this.view = new TestResultView(sandbox);

			Log.Write("List test starting");

			try {
				RunTest();
			}
			catch (Exception ex) {
				Log.Write(ex.Message);
			}
		}

		private void RunTest() {
			var list = new List<string>();
			list.Add("one");			
			list.Add("two");
			list.Add("three");

			view.AreStringsEqual("list.ToString()", "[ one,two,three ]", list);

			view.AreEqual("list.IndexOf('one')", 0, list.IndexOf("one"));
			view.AreEqual("list.IndexOf('two')", 1, list.IndexOf("two"));
			view.AreEqual("list.IndexOf('three')", 2, list.IndexOf("three"));
			view.AreEqual("list.IndexOf('none')", -1, list.IndexOf("none"));

			list.Add("two");
			view.AreStringsEqual("list.Add('two')", "[ one,two,three,two ]", list);

			list.Remove("two");
			view.AreStringsEqual("list.Remove('two')", "[ one,three,two ]", list);

			list.Clear();
			view.AreStringsEqual("list.Clear()", "[  ]", list);

			list.Add("x");
			list.Add("y");
			list.Add("z");

			view.AreStringsEqual("list.Add(x, y, z)", "[ x,y,z ]", list);
			view.AreEqual("list.Contains('x')", true, list.Contains("x"));
			view.AreEqual("list.Contains('nothere')", false, list.Contains("nothere"));

			list.Insert(0, "a");
			view.AreStringsEqual("list.Insert(0, 'a')", "[ a,x,y,z ]", list);

			list.Insert(4, "zz");
			view.AreStringsEqual("list.Insert(4, 'zz')", "[ a,x,y,z,zz ]", list);

			list.Insert(1, "b");
			view.AreStringsEqual("list.Insert(1, 'b')", "[ a,b,x,y,z,zz ]", list);

			list.Insert(2, "c");
			view.AreStringsEqual("list.Insert(2, 'c')", "[ a,b,c,x,y,z,zz ]", list);

			list.RemoveAt(2);
			view.AreStringsEqual("list.RemoveAt(2)", "[ a,b,x,y,z,zz ]", list);

			list.RemoveAt(0);
			view.AreStringsEqual("list.RemoveAt(0)", "[ b,x,y,z,zz ]", list);

			list.RemoveAt(4);
			view.AreStringsEqual("list.RemoveAt(5)", "[ b,x,y,z ]", list);

			var strArgOutOfRange = "System.ArgumentOutOfRangeException";
			view.ExpectException("list.Insert(5, 'zz')", strArgOutOfRange, () => list.Insert(5, "zz"));
			view.ExpectException("list.RemoveAt(-1)", strArgOutOfRange, () => list.RemoveAt(-1));
			view.ExpectException("list.RemoveAt(4)", strArgOutOfRange, () => list.RemoveAt(4));
			view.ExpectException("x = list[4]", strArgOutOfRange, () => { var x = list[4]; });
			view.ExpectException("list[4] = x", strArgOutOfRange, () => { list[4] = "x"; });

			var list2 = new List<int>();
			list2.Add(0);
			list2.Add(1);
			list2.Add(2);

			int i = 0;
			foreach (var x in list2) {
				Log.Write("enumerator" + i);
				view.AreEqual("enumerator" + i, i, x);
				i++;
			}
		}
	}
}
