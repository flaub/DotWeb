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
	}
}
