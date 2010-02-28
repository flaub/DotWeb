using System;
using System.Collections.Generic;
using DotWeb.Client;

namespace DotWeb.Functional.Test.Client
{
	class StringTest : JsScript
	{
		private TestResultView view;

		public StringTest() {
			var sandbox = Document.getElementById("sandbox");
			this.view = new TestResultView(sandbox);

			Log.Write("StringTest starting...");

			try {
				RunTest();
			}
			catch (Exception ex) {
				Log.Write(ex.Message);
			}
		}

		private void RunTest() {
			var str = "This is a string";

			this.view.AreStringsEqual("self equality", str, str);
			this.view.AreEqual("str.Length", 16, str.Length);
			this.view.AreEqual("str[0] == 'T'", 'T', str[0]);
			//this.view.AreEqual("str.GetHashCode()", 0, str.GetHashCode());
		}
	}
}
