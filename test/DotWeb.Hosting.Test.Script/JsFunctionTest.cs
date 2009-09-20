using DotWeb.Client;

namespace DotWeb.Hosting.Test.Script
{

	public class CrashTestDummy
	{
		public const string JsCode = "alert('hi');";

		public CrashTestDummy() { }
		public CrashTestDummy(int x) { }
		public int TestProperty { get; set; }

		[JsCode(JsCode)]
		public void TestJsCode() { }

		public void TestNoArgs() { }
		public void TestOneArg(int x) { }
		public void TestTwoArgs(int x, int y) { }

		public void TestMethod() { }

		public static void TestStatic() { }
	}

	[JsNamespace]
	public class DefaultNamesapce
	{
		public void TestNoArgs() { }
	}

	[JsNamespace]
	public class FooNamesapce
	{
		public void TestNoArgs() { }
	}

}
