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

			Log.Write(list);
		}
	}
}
