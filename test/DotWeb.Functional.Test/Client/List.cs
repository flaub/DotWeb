using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Functional.Test.Client
{
	class List
	{
		public List() {
			Log.Write("List test starting");

			var list = new List<string>();
			list.Add("one");
			list.Add("two");
			list.Add("three");

			Log.Write(list);

			Log.Write(list.IndexOf("one"));
			Log.Write(list.IndexOf("three"));
			Log.Write(list.IndexOf("none"));
		}
	}
}
