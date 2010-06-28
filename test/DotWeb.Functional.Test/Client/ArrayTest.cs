using System;
using System.Collections.Generic;
using DotWeb.Client;

namespace DotWeb.Functional.Test.Client
{
	class ArrayTest : TestBase
	{
		protected override void RunTest() {
			var array = new int[] { 1, 2, 3 };

			AreEqual("identity", array, () => array);
		}
	}
}
