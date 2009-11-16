using System;

namespace DotWeb.Weaver.Test.Script
{
	class Base
	{
	}

	class Derived : Base
	{
	}

	class CastTest
	{
		public void Test() {
			Base baseObj = new Derived();
			var derived = (Derived)baseObj;
			Console.WriteLine(derived);
		}
	}
}
