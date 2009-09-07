using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client;

namespace DotWeb.Sample.Script.Test
{
	public class Sanity : JsScript
	{
		public Sanity() {
			Window.alert("OK");
		}
	}
}
