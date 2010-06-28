using System;
using DotWeb.Client;
using DotWeb.Client.Dom;

namespace DotWeb.Functional.Test.Client
{
	public class Sanity : TestBase
	{
		protected override void RunTest() {
			Log.Write("Hello World!");
		}
	}
}
