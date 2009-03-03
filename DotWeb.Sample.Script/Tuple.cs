// Copyright 2009, Frank Laub
//
// This file is part of DotWeb.
//
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.

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
