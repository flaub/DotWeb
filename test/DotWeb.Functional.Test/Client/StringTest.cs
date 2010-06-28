using System;
using System.Collections.Generic;
using DotWeb.Client;

namespace DotWeb.Functional.Test.Client
{
	class StringTest : TestBase
	{
		protected override void RunTest() {
			var str = "This is a string";

			AreStringsEqual("str == str", str, () => str);

			var str2 = "This is a string";
			AreStringsEqual("str == str2", str, () => str2);

			AreEqual("str.Length", 16, () => str.Length);
			AreEqual("str[0] == 'T'", 'T', () => str[0]);
			AreStringsEqual("str.Substring(10)", "string", () => str.Substring(10));
			AreStringsEqual("str.Substring(0, 4)", "This", () => str.Substring(0, 4));
			AreStringsEqual("str.Substring(5, 4)", "is a", () => str.Substring(5, 4));
			AreStringsEqual("str.Substring(0)", str, () => str.Substring(0));
			AreStringsEqual("string.Format(\"Test: {0}\")", "Test: arg0", () => string.Format("Test: {0}", "arg0"));
			AreStringsEqual("string.Format(\"/{0, 10}/\")", "/         1/", () => string.Format("/{0, 10}/", 1));
			// This only works in web-mode because we are using Mono's hashcode implementation
			AreEqual("str.GetHashCode()", 5894048900, () => str.GetHashCode());
			AreEqual("str.Contains(\"is\")", true, () => str.Contains("is"));
			AreEqual("str.Contains(\"not\")", false, () => str.Contains("not"));
			AreEqual("str.IndexOf(\"is\")", 2, () => str.IndexOf("is"));
			AreEqual("str.IndexOf(\"is\", 4)", 5, () => str.IndexOf("is", 4));
			AreEqual("str.IndexOf(\"not\")", -1, () => str.IndexOf("not"));
			AreEqual("str.LastIndexOf(\"is\")", 5, () => str.LastIndexOf("is"));
			AreEqual("str.LastIndexOf(\"not\")", -1, () => str.LastIndexOf("not"));
			AreStringsEqual("str.ToUpper()", "THIS IS A STRING", () => str.ToUpper());
			AreStringsEqual("str.ToLower()", "this is a string", () => str.ToLower());

			var str3 = "  trim  ";
			AreStringsEqual("str3", "  trim  ", () => str3);
			AreStringsEqual("str3.Trim()", "trim", () => str3.Trim());

			var parts = str.Split(' ');
			AreStringsEqual("str.Split(' ')[0]", "This", () => parts[0]);
			AreStringsEqual("str.Split(' ')[1]", "is", () => parts[1]);
			AreStringsEqual("str.Split(' ')[2]", "a", () => parts[2]);
			AreStringsEqual("str.Split(' ')[3]", "string", () => parts[3]);
		}
	}
}
