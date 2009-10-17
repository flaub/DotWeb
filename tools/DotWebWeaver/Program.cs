using System;
using System.Linq;
using DotWeb.Tools.Weaver;
using System.IO;

namespace DotWebWeaver
{
	class Program
	{
		static void Main(string[] args) {
			if (args.Length != 2) {
				Console.WriteLine("Usage: DotWebWeaver <inputPath> <outputPath>");
				return;
			}

			string inputPath = args[0];
			string outputPath = args[1];

			string inputDir = Path.GetDirectoryName(inputPath);
			string outputDir = Path.GetDirectoryName(outputPath);
			string fileName = Path.GetFileName(outputPath);

			var weaver = new HostingWeaver(inputDir, outputDir);
			weaver.ProcessAssembly(inputPath);
		}
	}
}
