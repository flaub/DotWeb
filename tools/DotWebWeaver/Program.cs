using System;
using System.Linq;
using DotWeb.Tools.Weaver;
using System.IO;

namespace DotWebWeaver
{
	class Program
	{
		static void Main(string[] args) {
			if (args.Length < 2) {
				Console.WriteLine("Usage: DotWebWeaver <inputPath> <outputPath> <searchDir,searchDir>");
				return;
			}

			string inputPath = args[0];
			string outputPath = args[1];
			string[] searchDirs = null;
			if (args.Length == 3)
				searchDirs = args[2].Split(',');

			string inputDir = Path.GetDirectoryName(inputPath);
			string outputDir = Path.GetDirectoryName(outputPath);

			var weaver = new HostingWeaver(inputDir, outputDir, searchDirs);
			weaver.ProcessAssembly(inputPath);
		}
	}
}
