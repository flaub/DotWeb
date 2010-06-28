using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client;

namespace DotWeb.Functional.Test.Client
{
	public abstract class TestBase : JsScript
	{
		private TestResultView view;

		public TestBase() {
			var sandbox = Document.getElementById("sandbox");
			this.view = new TestResultView(sandbox);

			Log.Write(this.GetTypeName() +  " starting...");

			try {
				RunTest();
			}
			catch (Exception ex) {
				Log.Write(ex.Message);
			}

			Log.Write(this.GetTypeName() + " finished");
		}

		protected abstract void RunTest();

		protected void AreStringsEqual(string name, string expected, Func<object> func) {
			try {
				var actual = func();
				var str = actual.ToString();
				this.view.AddRow(name, expected, str, expected == str);
			}
			catch (Exception ex) {
				this.view.AddRow(name, expected, ex.ToString(), false);
			}
		}

		protected void AreEqual(string name, object expected, Func<object> func) {
			var expectedString = expected.ToString();
			try {
				var actual = func();
				this.view.AddRow(name, expectedString, actual.ToString(), expected.Equals(actual));
			}
			catch (Exception ex) {
				this.view.AddRow(name, expectedString, ex.ToString(), false);
			}
		}

		protected void ExpectException(string name, string expectedException, Action action) {
			try {
				action();
				this.view.AddRow(name, expectedException, "<None>", false);
			}
			catch (Exception ex) {
				var actualException = ex.GetTypeName();
				this.view.AddRow(name, expectedException, actualException, expectedException == actualException);
			}
		}
	}
}
