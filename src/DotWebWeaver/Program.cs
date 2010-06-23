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
using System.Linq;
using System.IO;
using DotWeb.Hosting.Weaver;

namespace DotWebWeaver
{
	class Program
	{
		static void Main(string[] args) {
			if (args.Length < 1) {
				Console.WriteLine("Usage: DotWebWeaver <inputPath> [<searchDir,searchDir>]");
				return;
			}

			string inputPath = args[0];
			string[] searchDirs = null;
			if (args.Length == 2)
				searchDirs = args[1].Split(',');

			string inputDir = Path.GetDirectoryName(inputPath);
			Console.WriteLine("Weaving {0}", inputPath);

			var weaver = new SimpleWeaver(inputDir, inputDir, searchDirs, false);
			weaver.ProcessAssembly(inputPath);
		}
	}
}
