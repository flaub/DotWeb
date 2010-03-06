using System;
using System.Collections.Generic;
using DotWeb.Client;
using System.Text;

namespace DotWeb.Functional.Test.Client
{
	class StringBuilderTest : JsScript
	{
		private TestResultView view;

		public StringBuilderTest() {
			var sandbox = Document.getElementById("sandbox");
			this.view = new TestResultView(sandbox);

			Log.Write("StringBuilderTest starting...");

			try {
				RunTest();
			}
			catch (Exception ex) {
				Log.Write(ex.Message);
			}
		}

		private void RunTest() {
			var sb = new StringBuilder();

			this.view.AreStringsEqual("empty", sb.ToString(), () => sb);

			sb.Append(true);
			this.view.AreStringsEqual("sb.Append(true)", "true", () => sb);

			sb.Append(':');
			this.view.AreStringsEqual("sb.Append(':')", "true:", () => sb);

			sb.Append('x', 2);
			this.view.AreStringsEqual("sb.Append(':')", "true:xx", () => sb);

			sb.Append("/test/", 1, 4);
			this.view.AreStringsEqual("sb.Append(\"/test/\", 1, 4)", "true:xxtest", () => sb);

			sb.AppendFormat("Test: {0}", 55);
			this.view.AreStringsEqual("sb.Append(\"Test: {0}\", 55)", "true:xxtestTest: 55", () => sb);
		}
	}
}
