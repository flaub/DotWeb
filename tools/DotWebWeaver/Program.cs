using System;
using System.Collections.Generic;
using System.Linq;
using DotWeb.Tools.Weaver;
using DotWeb.Utility;
using System.Reflection;
using System.IO;

namespace DotWebWeaver
{
	class Program
	{
		static void Main(string[] args) {
			if (args.Length != 1) {
				Console.WriteLine("Usage: DotWebWeaver <assemblyPath>");
				return;
			}

			string path = args.First();
			string dir = Path.GetDirectoryName(path);

			var asmProc = new AssemblyProcessor(dir, dir);
			asmProc.ProcessAssembly(path);
		}
	}
}
