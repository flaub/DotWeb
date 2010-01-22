using System;
using System.Collections.Generic;
using DotWeb.Client;

namespace DotWeb.Functional.Test.Client
{
	class List : JsScript
	{
		public List() {
			var sandbox = Document.getElementById("sandbox");
			var view = new TestResultView(sandbox);

			Log.Write("List test starting");

			var list = new List<string>();
			list.Add("one");
			list.Add("two");
			list.Add("three");

			view.AddRow("list.ToString()", "[ one,two,three ]", list);

			view.AddRow("list.IndexOf('one')", 0, list.IndexOf("one"));
			view.AddRow("list.IndexOf('two')", 1, list.IndexOf("two"));
			view.AddRow("list.IndexOf('three')", 2, list.IndexOf("three"));
			view.AddRow("list.IndexOf('none')", -1, list.IndexOf("none"));

			list.Add("two");
			view.AddRow("list.Add('two')", "[ one,two,three,two ]", list);

			list.Remove("two");
			view.AddRow("list.Remove('two')", "[ one,three,two ]", list);
		}
	}
}
