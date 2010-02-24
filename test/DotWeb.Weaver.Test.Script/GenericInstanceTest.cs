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
using System;
using DotWeb.Client;
using System.DotWeb;
using DotWeb.Client.Dom.Html;

namespace DotWeb.Weaver.Test.Script
{
	public class GenericType<T>
	{
		public extern T Item { get; set; }

		public bool AreEqual<U>(string name, U expected, U actual) {
			var expectedString = expected.ToString();
			Console.WriteLine(expectedString);
			var equal = expected.Equals(actual);
			Console.WriteLine(equal);
			return equal;
		}

	}

	public class GenericInstanceTest
	{
		public GenericInstanceTest() {
			this.GenericInstance = new GenericType<int>();
		}

		public GenericType<int> GenericInstance { get; private set; }
	}
}
