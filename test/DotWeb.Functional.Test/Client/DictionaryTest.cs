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

			Log.Write("DictionaryTest starting...");

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
			this.view.AreEqual("dict.Count == 0", 0, () => dict.Count);
			this.view.AreStringsEqual("dict.Add(\"key\", \"value\")", "{key: value}", () => {
				dict.Add("key", "value");
				return dict;
			});
			this.view.AreStringsEqual("dict.Add(\"other\", \"other\")", "{key: value, other: other}", () => {
				dict.Add("other", "other");
				return dict;
			});

			this.view.AreStringsEqual("dict.Clear()", "{}", () => {
				dict.Clear();
				return dict;
			});
		}
	}
}
