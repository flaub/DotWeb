using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twinkie;

public class Config
{
	public int Id { get; set; }
	public string Value { get; set; }
}

public delegate void Handler(int id);

public class Tuple : JsNativeBase
{
	public Tuple(object config) { _(config); }

	public int id {
		get { return (int)_(); }
		set { _(value); }
	}

	public object Value {
		[JavaScript("return this.getValue();")]
		get { return _(); }
		[JavaScript("this.setValue(value);")]
		set { _(value); }
	}

	public Handler handler {
		get { return (Handler)_(); }
		set { _(value); }
	}

	public void fireEvent() { _(); }

	public static void StaticMethod(int x, int y) { S_(x, y); }
}
