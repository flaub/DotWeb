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

		public void TryCatchFinally(bool x) {
			Console.WriteLine("enter");
			try {
				Console.WriteLine("try begin");
				if (x) {
					throw new NotImplementedException();
				}
				Console.WriteLine("try end");
			}
			catch (NotImplementedException ex) {
				Console.WriteLine("NotImplementedException: " + ex.Message);
			}
			catch (Exception ex) {
				Console.WriteLine("Exception: " + ex.Message);
			}
			finally {
				Console.WriteLine("finally");
			}
			Console.WriteLine("exit");
		}

		public void ArgumentException() {
			try {
				throw new ArgumentException();
			}
			catch (ArgumentException ex) {
				Console.WriteLine(ex.Message);
			}
		}
	}
}
