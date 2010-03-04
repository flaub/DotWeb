using System;
using DotWeb.Client;
using System.Collections;

namespace DotWeb.Functional.Test.Client
{
	class HashtableTest : JsScript
	{
		private TestResultView view;

		public HashtableTest() {
			var sandbox = Document.getElementById("sandbox");
			this.view = new TestResultView(sandbox);

			Log.Write("HashtableTest starting...");

			try {
				RunTest();
			}
			catch (Exception ex) {
				Log.Write(ex.Message);
			}
		}

		private void RunTest() {
			var hashtable = new Hashtable();

			this.view.AreStringsEqual("empty", "", hashtable);
			this.view.AreEqual("hashtable.Count == 0", 0, hashtable.Count);

			hashtable.Add("key", "value");
			this.view.AreStringsEqual("hashtable.Add(\"key\", \"value\")", "", hashtable);
		}
	}
}
