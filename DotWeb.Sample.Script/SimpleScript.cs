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
using System.Web;
using DotWeb.Client;
using DotWeb.Client.Dom;
using System.Diagnostics;

namespace DotWeb.Sample.Script
{
	public class SimpleScript : DotWeb.Client.JsScript
	{
		bool OnError(string msg, string url, int line) {
			this.Window.alert(msg);
			return true;
		}

		void OnCallback(object arg1, object arg2, object arg3) {
			Window.alert("OnCallback");
		}

		delegate void GenericCallback(object arg1, object arg2, object arg3);

		public SimpleScript() {
			//Window.alert("Hello world!");
			//Tuple.Callback1(new GenericCallback(this.OnCallback));
			//Tuple.Callback2(new GenericCallback(this.OnCallback));
			//int[] ints = new int[] { 1, 2, 3 };
			//int sum = Tuple.Sum(ints);
			//Console.WriteLine(sum);
			//Window.alert(sum.ToString());
			//Window.onerror = this.OnError;

			//Window.alert("TestScript");

			Config config = new Config {
				id = 666,
				value = "value"
			};
			Tuple tuple = new Tuple(config);
			int id = tuple.id;
			Console.WriteLine("id: ");
			Console.WriteLine(id);
			tuple.id = 9;
			tuple.handler = this.OnEvent;
			Console.WriteLine("before");
			tuple.fireEvent();

			Tuple.StaticMethod(2, 5);

			Tuple t2 = Tuple.Factory();
			Console.WriteLine(t2.id);

			Window.onblur = this.OnEvent;
		}

		private void OnEvent() {
			Console.WriteLine("OnEvent");
		}

		private void OnEvent(Tuple tuple, int id) {
//			Console.WriteLine(string.Format("OnEvent: {0}, {1}", tuple, id));
			Console.WriteLine(tuple.Value);
		}
	}
}
