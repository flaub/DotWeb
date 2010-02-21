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
using System.Collections.Generic;
using System.DotWeb;
using System;

namespace DotWeb.Weaver.Test.Script
{
	class ExceptionTest
	{
		public void SimpleTryCatch() {
			Console.WriteLine("start");
			try {
				Console.WriteLine("try");
			}
			catch (NotImplementedException ex) {
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
			Console.WriteLine("end");
		}

		public void SimpleTryFinally() {
			Console.WriteLine("start");
			try {
				Console.WriteLine("try");
			}
			finally {
				Console.WriteLine("finally");
			}
			Console.WriteLine("end");
		}

		public void SimpleTryCatchFinally() {
			Console.WriteLine("start");
			try {
				Console.WriteLine("try");
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
			finally {
				Console.WriteLine("finally");
			}
			Console.WriteLine("end");
		}

		public void NestedTry() {
			Console.WriteLine("start");
			try {
				Console.WriteLine("try1");
				try {
					Console.WriteLine("try2");
				}
				finally {
					Console.WriteLine("finally2");
				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
			finally {
				Console.WriteLine("finally1");
			}
			Console.WriteLine("end");
		}

		public void TryInCatch() {
			Console.WriteLine("start");
			try {
				Console.WriteLine("try1");
			}
			catch (Exception) {
				try {
					Console.WriteLine("try2");
				}
				finally {
					Console.WriteLine("finally2");
				}
			}
			finally {
				Console.WriteLine("finally1");
			}
			Console.WriteLine("end");
		}
	}
}
