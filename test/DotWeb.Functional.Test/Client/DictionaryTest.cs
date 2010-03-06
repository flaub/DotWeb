using System;
using DotWeb.Client;
using System.Collections.Generic;

namespace DotWeb.Functional.Test.Client
{
	class DictionaryTest : JsScript
	{
		private TestResultView view;

		public DictionaryTest() {
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
			var dict = new Dictionary<string, string>();

			this.view.AreStringsEqual("empty", "{}", () => dict);
			this.view.AreEqual("hashtable.Count == 0", 0, () => dict.Count);

			dict.Add("key", "value");
			this.view.AreStringsEqual("hashtable.Add(\"key\", \"value\")", "", () => dict);
		}
	}
}
