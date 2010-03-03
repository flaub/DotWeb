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

			var str2 = "This is a string";
			this.view.AreStringsEqual("equality", str, str2);

			this.view.AreEqual("str.Length", 16, str.Length);
			this.view.AreEqual("str[0] == 'T'", 'T', str[0]);
			this.view.AreStringsEqual("str.Substring(10)", "string", str.Substring(10));
			this.view.AreStringsEqual("str.Substring(0, 4)", "This", str.Substring(0, 4));
			this.view.AreStringsEqual("str.Substring(5, 4)", "is a", str.Substring(5, 4));
			this.view.AreStringsEqual("str.Substring(0)", str, str.Substring(0));
			this.view.AreStringsEqual("string.Format(\"Test: {0}\")", "Test: arg0", string.Format("Test: {0}", "arg0"));
			this.view.AreStringsEqual("string.Format(\"/{0, 10}/\")", "/         1/", string.Format("/{0, 10}/", 1));
			//this.view.AreEqual("str.GetHashCode()", 0, str.GetHashCode());

		}
	}
}
