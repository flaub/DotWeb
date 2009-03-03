using System;
using System.IO;
using System.Reflection;

namespace DotWeb.Translator.CLI
{
	class Program
	{
		static void Main(string[] args) {
			string input = args[0];
			string output = args[1];
			TranslationEngine translator = new TranslationEngine(new StreamWriter(output), true);
			translator.TranslateFile(input, Assembly.GetExecutingAssembly());
		}
	}
}
