using System;
using System.Collections.Generic;
using DotWeb.Client;

namespace DotWeb.Functional.Test.Client
{
	class ArrayTest : JsScript
	{
		private TestResultView view;

		public ArrayTest() {
			var sandbox = Document.getElementById("sandbox");
			this.view = new TestResultView(sandbox);

			Log.Write("ArrayTest starting...");

			try {
				RunTest();
			}
			catch (Exception ex) {
				Log.Write(ex.Message);
			}
		}

		private void RunTest() {
			var array = new int[] { 1, 2, 3 };

			this.view.AreEqual("identity", array, array);
		}
	}
}
