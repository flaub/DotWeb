using System;
using DotWeb.Client;
using System.Collections.Generic;

namespace DotWeb.Functional.Test.Client
{
	class DictionaryTest : TestBase
	{
		protected override void RunTest() {
			var dict = new Dictionary<string, string>();

			AreStringsEqual("empty", "{}", () => dict);
			AreEqual("dict.Count == 0", 0, () => dict.Count);
			AreStringsEqual("dict.Add(\"key\", \"value\")", "{key: value}", () => {
				dict.Add("key", "value");
				return dict;
			});
			AreStringsEqual("dict.Add(\"other\", \"other\")", "{key: value, other: other}", () => {
				dict.Add("other", "other");
				return dict;
			});

			AreStringsEqual("dict.Clear()", "{}", () => {
				dict.Clear();
				return dict;
			});
		}
	}
}
