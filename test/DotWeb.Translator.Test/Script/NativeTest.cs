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
using DotWeb.Client;

namespace H8
{
	[JsNamespace]
	[JsAnonymous]
	public class Config
	{
		public int id;
		public string value;
	}

	[JsNamespace]
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
	}

	public class NativeTest
	{
		public void TestTuple() {
			Config config = new Config {
				id = 666,
				value = "value"
			};
			Tuple tuple = new Tuple(config);
			int id = tuple.id;
			Console.WriteLine(id);
			tuple.id = 9;
		}
	}
}
