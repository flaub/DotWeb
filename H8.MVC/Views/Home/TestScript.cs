using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotWeb.Core;

public class Config : JsAccessible
{
	private int m_id;
	private string m_value;

	public int id {
		get {
			return this.m_id;
		}
		set {
			this.m_id = value;
		}
	}

	public string value {
		get {
			return this.m_value;
		}
		set {
			this.m_value = value;
		}
	}
}

public delegate void Handler(Tuple tuple, int id);

public class Tuple : JsNativeBase
{
	public Tuple() { }
	public Tuple(object config) { C_(config); }

	public int id {
		get { return _<int>(); }
		set { _(value); }
	}

	public object Value {
		[JavaScript("return this.getValue();")]
		get { return _<object>(); }
		[JavaScript("this.setValue(value);")]
		set { _(value); }
	}

	public Handler handler {
		get { return _<Handler>(); }
		set { _(value); }
	}

	public void fireEvent() { _(); }

	public static void StaticMethod(int x, int y) { S_(x, y); }
	public static Tuple Factory() { return S_<Tuple>(); }
}

namespace H8.MVC.Views.Home
{
	public class TestScript : MarshalByRefObject
	{
		public TestScript() {
			Config config = new Config {
				id = 666,
				value = "value"
			};
			Tuple tuple = new Tuple(config);
			int id = tuple.id;
			tuple.id = 9;
			tuple.handler = this.OnEvent;
			Console.WriteLine("before");
			tuple.fireEvent();
			Console.WriteLine(id);

			Tuple.StaticMethod(2, 5);

			Tuple t2 = Tuple.Factory();
			Console.WriteLine(t2.id);
		}

		private void OnEvent(Tuple tuple, int id) {
			Console.WriteLine("OnEvent: {0}, {1}", tuple, id);
		}
	}
}
