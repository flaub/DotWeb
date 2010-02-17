using System;
using DotWeb.Client;
using DotWeb.Client.Dom;

namespace DotWeb.Functional.Test.Client
{
	public class Lambda : JsScript
	{
		public Lambda() {
			Action action = () => Log.Write("Lambda");
			action();
		}
	}
}
