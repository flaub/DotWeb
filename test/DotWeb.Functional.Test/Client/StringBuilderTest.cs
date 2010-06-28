using System;
using System.Collections.Generic;
using DotWeb.Client;
using System.Text;

namespace DotWeb.Functional.Test.Client
{
	class StringBuilderTest : TestBase
	{
		protected override void RunTest() {
			var sb = new StringBuilder();

			AreStringsEqual("empty", sb.ToString(), () => sb);

			sb.Append(true);
			AreStringsEqual("sb.Append(true)", "true", () => sb);

			sb.Append(':');
			AreStringsEqual("sb.Append(':')", "true:", () => sb);

			sb.Append('x', 2);
			AreStringsEqual("sb.Append(':')", "true:xx", () => sb);

			sb.Append("/test/", 1, 4);
			AreStringsEqual("sb.Append(\"/test/\", 1, 4)", "true:xxtest", () => sb);

			sb.AppendFormat("Test: {0}", 55);
			AreStringsEqual("sb.Append(\"Test: {0}\", 55)", "true:xxtestTest: 55", () => sb);
		}
	}
}
