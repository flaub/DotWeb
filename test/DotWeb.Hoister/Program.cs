using System;
using System.Reflection;
using System.IO;
using DotWeb.Utility;

namespace DotWeb.Hoister
{
	class Program
	{
		const string HostedDirName = "Hosted";

		static void Main(string[] args) {
			if (args.Length != 1) {
				string exe = Path.GetFileName(Assembly.GetEntryAssembly().Location);
				Console.Error.WriteLine("Usage: {0} <AssemblyName>", exe);
				Environment.Exit(-1);
			}

			string path = args[0];
			string dir = Path.GetDirectoryName(path);
			//string hostedDir = Path.Combine(dir, HostedDirName);
			//if (!Directory.Exists(hostedDir)) {
			//    Directory.CreateDirectory(hostedDir);
			//}

			string assemblyName = Path.GetFileNameWithoutExtension(path);

//			Environment.CurrentDirectory = dir;
			var fixup = new AssemblyReferenceFixup(dir);
			fixup.FixupReferences(assemblyName, false);
		}
	}
}
