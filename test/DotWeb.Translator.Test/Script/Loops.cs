using System.DotWeb;
using System;

namespace H8
{
	[JsNamespace]
	class Loops
	{
		public void SimpleFor(int a) {
			for (int i = 0; i < 10; i++) {
				a++;
			}
		}

		public void SimpleDoWhile(int a) {
			Console.WriteLine(a);
			do {
				a++;
				Console.WriteLine(a);
			} while (a < 100);
			Console.WriteLine(a);
		}

		public void SimpleWhile(int a) {
			Console.WriteLine(a);
			while (a < 100) {
				a++;
				Console.WriteLine(a);
			}
			Console.WriteLine(a);
		}

		public void NestedDoWhile(int a) {
			while (a < 100) {
				do {
					a *= 10;
				} while (a < 10);
				a += 2;
			}
		}

		public void BreakInWhile(int a) {
			while (a < 100) {
				if (a == 12) {
					Console.WriteLine(a);
					break;
				}
				else
					Console.WriteLine(a);

				a--;
			}
			Console.WriteLine(a);
		}

		public void WhileBreak() {
			int i = 0;
			while (true) {
				if (i == 10) {
					Console.WriteLine(i);
					break;
				}
				Console.WriteLine(i);
				i++;
			}
			Console.WriteLine(i);
		}

		public void WhileCondBreak() {
			int i = 0;
			while (i < 9) {
				if (i == 10) {
					Console.WriteLine(i);
					break;
				}
				Console.WriteLine(i);
				i++;
			}
			Console.WriteLine(i);
		}
	}
}
