using System;

namespace DotWeb.Hoister.Test
{
	public class Simple
	{
		public void Foo() {
		}
	}

//	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class JsCodeAttribute : Attribute
	{
		//public string Code { get; private set; }

		//public JsCodeAttribute(string code) {
		//    this.Code = code;
		//}
	}
}
