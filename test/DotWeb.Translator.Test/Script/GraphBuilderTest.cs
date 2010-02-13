using System.DotWeb;
using System;

namespace H8
{
	[JsNamespace]
	class GraphBuilderTest
	{
		public void NullBlock() {
		}

		public void OneBlock() {
			Console.WriteLine("hello");
		}

		public void SimpleIf(bool x) {
			if (x) {
				Console.WriteLine("x");
			}
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
	}
}
