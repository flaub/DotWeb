using System;
using System.IO;
using System.Reflection;

namespace H8.CLI
{
	class Program
	{
		static void Main(string[] args) {
			string input = args[0];
			string output = args[1];
			Translator translator = new Translator(new StreamWriter(output), true);
			translator.TranslateFile(input, Assembly.GetExecutingAssembly());
		}
	}
}
