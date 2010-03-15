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
using System.Collections.Generic;

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
					Console.WriteLine("break");
					break;
				}
				else {
					Console.WriteLine("else");
				}

				a--;
			}
			Console.WriteLine(a);
		}

		public void WhileBreak() {
			int i = 0;
			while (true) {
				Console.WriteLine("top");
				if (i == 10) {
					Console.WriteLine("break");
					break;
				}
				Console.WriteLine("loop");
				i++;
			}
			Console.WriteLine("exit");
		}

		public void WhileBreakBreak() {
			int i = 0;
			while (true) {
				Console.WriteLine("top");
				if (i == 10) {
					Console.WriteLine("break1");
					break;
				}
				if (i == 5) {
					Console.WriteLine("break2");
					break;
				}
				Console.WriteLine("bottom");
				i++;
			}
			Console.WriteLine("exit");
		}

		public void WhileCondBreak() {
			int i = 0;
			while (i < 9) {
				Console.WriteLine("top");
				if (i == 10) {
					Console.WriteLine("break");
					break;
				}
				Console.WriteLine("loop");
				i++;
			}
			Console.WriteLine("exit");
		}

		public void WhileContinue() {
			int i = 0;
			while (true) {
				Console.WriteLine("top");
				if (i == 10) {
					Console.WriteLine("continue");
					continue;
				}
				Console.WriteLine("bottom");
				i++;
			}
			// unreachable
		}

		public void WhileCondContinue() {
			int i = 0;
			while (i < 9) {
				Console.WriteLine("top");
				if (i == 10) {
					Console.WriteLine("continue");
					continue;
				}
				Console.WriteLine("bottom");
				i++;
			}
			Console.WriteLine("exit");
		}

		public void WhileBreakContinue() {
			int i = 0;
			while (true) {
				Console.WriteLine("top");
				if (i == 10) {
					Console.WriteLine("continue");
					continue;
				}
				if (i == 20) {
					Console.WriteLine("break");
					break;
				}
				Console.WriteLine("bottom");
				i++;
			}
			Console.WriteLine("exit");
		}

		public void ComplexLoop() {
			int i = 0;
			Console.WriteLine("enter");
			while (true) {
				Console.WriteLine("top");
				if (i < 10) {
					Console.WriteLine("i < 10");
					if (i == 1) {
						Console.WriteLine("i == 1");
						break;
					}
					if (i == 2) {
						Console.WriteLine("i == 2");
						continue;
					}
					break;
				}
				Console.WriteLine("bottom");
			}
			Console.WriteLine("return");
		}

		public void ComplexNestedLoop() {
			int i = 0;
			Console.WriteLine("enter");
			while (true) {
				Console.WriteLine("top");
				if (i < 10) {
					Console.WriteLine("i < 10");
					if (i == 1) {
						Console.WriteLine("i == 1");
						break;
					}
					if (i == 2) {
						do {
							Console.WriteLine("inner loop");
						} while (i < 4);
						break;
					}
				}
				Console.WriteLine("bottom");
			}
			Console.WriteLine("return");
		}

		public void MultiReturns() {
			int i = 0;
			Console.WriteLine("enter");
			while (i < 100) {
				Console.WriteLine("top");
				if (i == 10) {
					Console.WriteLine("return1");
					return;
				}
				if (i == 50) {
					Console.WriteLine("break");
					break;
				}
				Console.WriteLine("bottom");
			}
			Console.WriteLine("return2");
		}

		public void MultiReturns2() {
			int i = 0;
			Console.WriteLine("enter");
			while (i < 100) {
				Console.WriteLine("top");
				if (i > 10) {
					Console.WriteLine("return1");
					return;
				}
				if (i < 50) {
					Console.WriteLine("return2");
					return;
				}
				Console.WriteLine("bottom");
			}
			Console.WriteLine("return2");
		}

		public bool MultiReturns3() {
			return new Dictionary<string, string>().GetEnumerator().MoveNext();
		}

		public bool HeaderExitAndLatchExit1(int x) {
			while (true) {
				if (x < 10) {
					return true;
				}
				Console.WriteLine("loop");
				if (x > 10) {
					return false;
				}
			}
		}

		public bool HeaderExitAndLatchExit2(int x) {
			while (x >= 10) {
				Console.WriteLine("loop");
				if (x > 10) {
					return false;
				}
			}
			return true;
		}

		public bool HeaderExitAndLatchExit3(int x) {
			do {
				if (x < 10) {
					return true;
				}
				Console.WriteLine("loop");
			} while (x <= 10);
			return false;
		}

		public void EndlessLoop() {
			Console.WriteLine("enter");
			while (true) {
				Console.WriteLine("loop");
			}
			// unreachable
		}

		public void WhileTryCatchFinally(int x) {
			Console.WriteLine("enter");
			while (x < 10) {
				try {
					Console.WriteLine("try");
				}
				catch (NotImplementedException) {
					Console.WriteLine("continue");
					continue;
				}
				catch (Exception) {
					Console.WriteLine("break");
					break;
				}
				finally {
					Console.WriteLine("finally");
				}
			}
			Console.WriteLine("exit");
		}

		public void WhileIfLessOrLessBreak(int x) {
			Console.WriteLine("enter");
			int p = 0;
			while (true) {
				Console.WriteLine("top");
				if (x < 0 || 9 < x)
					break;
				Console.WriteLine("bottom");
				p++;
			}
			Console.WriteLine("exit");
		}
	}
}
