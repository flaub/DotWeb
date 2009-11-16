using System;
using DotWeb.Client;

namespace DotWeb.Weaver.Test.Script
{
	class TypeTest : JsScript
	{
		public int field;
		public int Property { get; set; }
		public event Action Event;

		public TypeTest() {
			this.field = 1;
		}

		public void Method() {
			if (Event != null)
				Event();
		}
	}
}
