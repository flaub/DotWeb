using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client;

namespace DotWeb.Sample.Script
{
	[JsNamespace()]
	[JsAnonymous]
	public class Config : JsAccessible
	{
		private int m_id;
		private string m_value;

		[JsIntrinsic]
		public int id {
			get { return this.m_id; }
			set { this.m_id = value; }
		}

		[JsIntrinsic]
		public string value {
			get { return this.m_value; }
			set { this.m_value = value; }
		}
	}

	[JsNamespace()]
	public class Tuple : JsNativeBase
	{
		public Tuple() { }
		public Tuple(object config) { C_(config); }

		public int id {
			get { return _<int>(); }
			set { _(value); }
		}

		public object Value {
			[JsCode("return this.value;")]
			get { return _<object>(); }
			[JsCode("this.value;")]
			set { _(value); }
		}

		public delegate void Handler(Tuple tuple, int id);
		public Handler handler {
			set { _(value); }
		}

		public void fireEvent() { _(); }

		public static int Sum(int[] args) { return S_<int>(args); }
		public static void StaticMethod(int x, int y) { S_(x, y); }
		public static Tuple Factory() { return S_<Tuple>(); }

		public static void Callback1(Delegate cb) { S_(cb); }
		public static void Callback2(Delegate cb) { S_(cb); }
	}
}
