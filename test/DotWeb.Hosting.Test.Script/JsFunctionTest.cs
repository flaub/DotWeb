using DotWeb.Client;
using System.DotWeb;

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

		public object this[string name] {
			get {
				return null;
			}
			set {
			}
		}
	}

	[JsNamespace]
	public class DefaultNamespace
	{
		public void TestNoArgs() { }
	}

	[JsNamespace]
	public class FooNamespace
	{
		public void TestNoArgs() { }
	}

}
