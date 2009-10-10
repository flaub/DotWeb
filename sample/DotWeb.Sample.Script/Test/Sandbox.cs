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
// 
using DotWeb.Client;
using System;

namespace DotWeb.Sample.Script.Test
{
	public class Sandbox : JsScript
	{
		public Sandbox() {
			int x = 1;
			x++;
			//Foo("Hello");
			Console.WriteLine("Hi");
			Console.WriteLine("{0}: {1}", 1, "two");
			Console.WriteLine("{0}", 1);
			Console.WriteLine(Math.Sin(1));

			Window.alert("hi");
		}

		public void Foo(string value) {
			for (int i = 0; i < 10; i++) {
				Console.Write(i);
			}

			if (value == "Hello") {
				int y = value.Length;
				if (y == 2) {
					Console.WriteLine(y * 2);
				}
			}
			else {
				double y = value.Length * 4;
				if (y > 0) {
					Console.WriteLine(y);
				}
			}
			{
				int x = 2;
				{
					int z = 3;
					Console.WriteLine(x + z);
				}
			}
		}

		public void Bar() {
			Foo("again");
			Bar();
		}
	}
}