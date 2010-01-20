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

namespace DotWeb.Weaver.Test.Script
{
	class ArrayTest
	{
		public int[] fieldArray;
		public string[] PropertyArray { get; set; }

		public ArrayTest[] typeArray;

		public List<ArrayTest> list = null;

		public List<ArrayTest>[] arrayOfLists = null;

		public List<ArrayTest[]> listOfArrays = null;

		public ArrayTest() {
			this.fieldArray = new int[4];
			this.fieldArray[0] = 1;
			this.typeArray = new ArrayTest[1];
			this.typeArray[0] = this;
		}
	}
}
