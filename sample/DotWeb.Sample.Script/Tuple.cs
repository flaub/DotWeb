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
using System.Runtime.CompilerServices;
using System.DotWeb;

namespace DotWeb.Sample.Script
{
	[JsNamespace]
	[JsAnonymous]
	public class Config
	{
		public int id;
		public string value;
	}

	public delegate void ITupleHandler(ITuple tuple, int id);

//	[ClassInterface(typeof(TupleClass))]
	public interface ITuple
	{
		TupleClass Class { get; }

		object Value { get; set; }

		ITupleHandler handler { set; }
		void fireEvent();
	}

	public interface TupleClass
	{
		ITuple Constructor(object config);

		int Sum(int[] args);
		void StaticMethod(int x, int y);
		ITuple Factory();

		void Callback1(Delegate cb);
		void Callback2(Delegate cb);
	}

	[JsNamespace]
	public class Tuple
	{
		public extern Tuple();

		public extern Tuple(object config);

		public extern int id { get; set; }

		public extern object Value {
			[JsCode("return this.value;")]
			get;

			[JsCode("this.value;")]
			set;
		}

		public delegate void Handler(Tuple tuple, int id);
		public extern Handler handler { set; }

		public extern void fireEvent();

		public static extern int Sum(int[] args);
		public static extern void StaticMethod(int x, int y);
		public static extern Tuple Factory();

		public static extern void Callback1(Delegate cb);
		public static extern void Callback2(Delegate cb);
	}
}
