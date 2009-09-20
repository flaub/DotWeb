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
using DotWeb.Client.Dom;
using DotWeb.Client;
using DotWeb.Client.Dom.Events;

namespace DotWeb.Sample.Script
{
	public class SimpleScript : JsScript
	{
		public SimpleScript() {
			Config config = new Config {
				id = 666,
				value = "value"
			};
			
			Tuple tuple = new Tuple(config);
			int id = tuple.id;
			Log("id: ");
			Log(id);
			tuple.id = 9;
			tuple.handler = this.OnEvent;
			Log("before");
			tuple.fireEvent();

			Tuple.StaticMethod(2, 5);

			Tuple t2 = Tuple.Factory();
			Log(t2.id);

			Window.onblur = this.OnEvent;
		}

		private void OnEvent(Event evt) {
			Log(evt);
		}

		private void OnEvent(Tuple tuple, int id) {
//			Console.WriteLine(string.Format("OnEvent: {0}, {1}", tuple, id));
			Log(tuple.Value);
		}
	}
}
