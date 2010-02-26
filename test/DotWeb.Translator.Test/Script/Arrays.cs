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

using System;
using System.Collections.Generic;
using System.DotWeb;

namespace H8
{
	[JsNamespace]
	class Arrays
	{
		public void CreateIntArray() {
			var array = new int[] { 1, 2, 3 };
			Console.WriteLine(array);
		}

		public void CreateDoubleArray() {
			var array = new double[] { 1.1, 2.2, 3.3 };
			Console.WriteLine(array);
		}

		public void CreateStringArray() {
			var array = new string[] { "one", "two", "three" };
			Console.WriteLine(array);
		}

		public void CreateArrayOfArrays() {
			var inner = new int[] { 1, 2, 3 };
			var array = new Array[] { inner, inner  };
			Console.WriteLine(array);
		}

		public void EnumArray() {
			//0000: ldc.i4.4 Next
			//0001: newarr System.Int32 Next
			//0006: dup Next
			//0007: ldtoken __StaticArrayInitTypeSize=16 $$method0x6000085-1 Next
			//0012: call System.Void System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray() Call
			//0017: stloc.0 Next
			//0018: ldloc.0 Next
			//0019: stloc.2 Next
			//0020: ldc.i4.0 Next
			//0021: stloc.3 Next
			int[] array = { 1, 2, 3, 4 };
			//0022: br.s 0038 Branch
			//0038: ldloc.3 Next
			//0039: ldloc.2 Next
			//0040: ldlen Next
			//0041: conv.i4 Next
			//0042: blt.s 0024 Cond_Branch
			foreach (int item in array) {
				//0024: ldloc.2 Next
				//0025: ldloc.3 Next
				//0026: ldelem.i4 Next
				//0027: stloc.1 Next
				//0028: ldloc.1 Next
				//0029: call System.Void System.Console::WriteLine() Call
				Console.WriteLine(item);
				//0034: ldloc.3 Next
				//0035: ldc.i4.1 Next
				//0036: add Next
				//0037: stloc.3 Next
			}
			//0044: ret Return
		}
	}
}
