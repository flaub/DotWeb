using System;
using DotWeb.Client;
using DotWeb.Client.Dom;

namespace DotWeb.Functional.Test.Client
{
	public class Sanity : JsScript
	{
		public Sanity() {
			Window.alert("Hello World!");
		}
	}
}
