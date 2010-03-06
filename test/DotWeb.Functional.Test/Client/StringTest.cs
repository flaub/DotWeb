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

			this.view.AreStringsEqual("str == str", str, () => str);

			var str2 = "This is a string";
			this.view.AreStringsEqual("str == str2", str, () => str2);

			this.view.AreEqual("str.Length", 16, () => str.Length);
			this.view.AreEqual("str[0] == 'T'", 'T', () => str[0]);
			this.view.AreStringsEqual("str.Substring(10)", "string", () => str.Substring(10));
			this.view.AreStringsEqual("str.Substring(0, 4)", "This", () => str.Substring(0, 4));
			this.view.AreStringsEqual("str.Substring(5, 4)", "is a", () => str.Substring(5, 4));
			this.view.AreStringsEqual("str.Substring(0)", str, () => str.Substring(0));
			this.view.AreStringsEqual("string.Format(\"Test: {0}\")", "Test: arg0", () => string.Format("Test: {0}", "arg0"));
			this.view.AreStringsEqual("string.Format(\"/{0, 10}/\")", "/         1/", () => string.Format("/{0, 10}/", 1));
			// This only works in web-mode because we are using Mono's hashcode implementation
			this.view.AreEqual("str.GetHashCode()", 5894048900, () => str.GetHashCode());
			this.view.AreEqual("str.Contains(\"is\")", true, () => str.Contains("is"));
			this.view.AreEqual("str.Contains(\"not\")", false, () => str.Contains("not"));
			this.view.AreEqual("str.IndexOf(\"is\")", 2, () => str.IndexOf("is"));
			this.view.AreEqual("str.IndexOf(\"is\", 4)", 5, () => str.IndexOf("is", 4));
			this.view.AreEqual("str.IndexOf(\"not\")", -1, () => str.IndexOf("not"));
			this.view.AreEqual("str.LastIndexOf(\"is\")", 5, () => str.LastIndexOf("is"));
			this.view.AreEqual("str.LastIndexOf(\"not\")", -1, () => str.LastIndexOf("not"));
			this.view.AreStringsEqual("str.ToUpper()", "THIS IS A STRING", () => str.ToUpper());
			this.view.AreStringsEqual("str.ToLower()", "this is a string", () => str.ToLower());

			var str3 = "  trim  ";
			this.view.AreStringsEqual("str3", "  trim  ", () => str3);
			this.view.AreStringsEqual("str3.Trim()", "trim", () => str3.Trim());

			var parts = str.Split(' ');
			this.view.AreStringsEqual("str.Split(' ')[0]", "This", () => parts[0]);
			this.view.AreStringsEqual("str.Split(' ')[1]", "is", () => parts[1]);
			this.view.AreStringsEqual("str.Split(' ')[2]", "a", () => parts[2]);
			this.view.AreStringsEqual("str.Split(' ')[3]", "string", () => parts[3]);
		}
	}
}
