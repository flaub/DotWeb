// Copyright 2010, Frank Laub
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

using System.DotWeb;
using System;

namespace H8
{
	[JsNamespace]
	class Conditionals
	{
		public int ReturnTernary(int a) {
			return a > 10 ? 12 : 42;
		}

		public int ReturnNestedTernary(int a) {
			return (a < 0 ? (a < 100 ? 12 : 24) : (a > 0 ? 10 : 42));
		}

		public void SimpleIf(int a) {
			if (a == 12) {
				a = 14;
			}
		}

		public void SimpleIfIf(int a) {
			if (a == 12) {
				a = 14;
			}

			if (a == 13) {
				a = 15;
			}
		}

		public void SimpleIfElse(int a) {
			if (a == 12) {
				a = 42;
			}
			else {
				a = 128;
			}
			Console.WriteLine(1);
		}

		public void SimpleIfElseIf() {
			int i = 0;
			if (i == 1) {
				Console.WriteLine("True");
			}
			else if (i == 2) {
				Console.WriteLine("False");
			}
			Console.WriteLine(i);
		}


		public int SimpleIfOr(bool x, bool y) {
			int ret = 0;
			if (x || y) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int SimpleIfNotOr(bool x, bool y) {
			int ret = 0;
			if (!x || y) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int SimpleIfOrNot(bool x, bool y) {
			int ret = 0;
			if (x || !y) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int SimpleIfNotOrNot(bool x, bool y) {
			int ret = 0;
			if (!x || !y) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int SimpleIfAnd(bool x, bool y) {
			int ret = 0;
			if (x && y) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfGreaterAnd(int x, int y) {
			int ret = 0;
			if (x > 1 && y > 1) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfLessAnd(int x, int y) {
			int ret = 0;
			if (x < 1 && y < 1) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfGreaterOr(int x, int y) {
			int ret = 0;
			if (x > 1 || y > 1) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfLessOr(int x, int y) {
			int ret = 0;
			if (x < 1 || y < 1) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfLessAndGreater(int x, int y) {
			int ret = 0;
			if (x < 1 && y > 1) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfGreaterAndLess(int x, int y) {
			int ret = 0;
			if (x > 1 && y < 1) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int SimpleIfNotAnd(bool x, bool y) {
			int ret = 0;
			if (!x && y) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int SimpleIfAndNot(bool x, bool y) {
			int ret = 0;
			if (x && !y) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int SimpleIfNotAndNot(bool x, bool y) {
			int ret = 0;
			if (!x && !y) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public string NullCoalesce(string s) {
			return s ?? "nil";
		}

		public int IfOrOr(bool x, bool y, bool z) {
			int ret = 0;
			if (x || y || z) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfAndOr(bool x, bool y, bool z) {
			int ret = 0;
			if (x && y || z) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfOrAnd(bool x, bool y, bool z) {
			int ret = 0;
			if (x || y && z) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public int IfAndAnd(bool x, bool y, bool z) {
			int ret = 0;
			if (x && y && z) {
				ret = 1;
			}
			else {
				ret = 2;
			}
			ret++;
			return ret;
		}

		public void Switch(int x) {
			Console.WriteLine("enter");
			switch (x) {
				case 0:
					Console.WriteLine("Zero");
					break;
				case 1:
				case 2:
					Console.WriteLine("One & Two");
					break;
				default:
					Console.WriteLine("default");
					break;
			}
			Console.WriteLine("exit");
		}

		private bool foundFirst = false;
		private object item = null;
	
		public bool IfNotAndCall(object element, int i, JsArray array) {
			if (!this.foundFirst && JsObject.StrictEquals(this.item, element)) {
				this.foundFirst = true;
				return false;
			}
			return true;
		}
	}
}
