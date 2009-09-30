using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Sandbox
{
	class Program
	{
		static void Main(string[] args) {
			string appBasePath = @"F:\src\git\DotWeb\build\bin\Debug";
			string appRelativeSearchPath = @"Hosted";
			var domain = AppDomain.CreateDomain("DotWeb Hosted-Mode", null, appBasePath, appRelativeSearchPath, false);

			//var asmName = "DotWeb.Sample.Script";
			//var typeName = "DotWeb.Sample.Script.Test.Sanity";
			domain.DoCallBack(OtherDomain);
		}

		static void OtherDomain() {
			//var asmName = "DotWeb.Sample.Script";
			var typeName = "DotWeb.Sample.Script.Test.Sandbox";
			var asmFile = @"F:\src\git\DotWeb\build\bin\Debug\Hosted-DotWeb.Sample.Script.dll";

			//var asm = domain.Load(asmName);
			//var script = asm.CreateInstance(typeName);

			var domain = AppDomain.CurrentDomain;
			domain.AssemblyLoad += new AssemblyLoadEventHandler(domain_AssemblyLoad);
			domain.AssemblyResolve += new ResolveEventHandler(domain_AssemblyResolve);
			domain.TypeResolve += new ResolveEventHandler(domain_TypeResolve);
			var handle = domain.CreateInstanceFrom(asmFile, typeName);
			//var handle = domain.CreateInstance(asmName, typeName);
			var obj = handle.Unwrap();
		}

		static Assembly domain_TypeResolve(object sender, ResolveEventArgs args) {
			var asmFile = @"F:\src\git\DotWeb\build\bin\Debug\Hosted\DotWeb.Client.dll";
			return Assembly.LoadFrom(asmFile);
		}

		static Assembly domain_AssemblyResolve(object sender, ResolveEventArgs args) {
			var asmFile = @"F:\src\git\DotWeb\build\bin\Debug\Hosted\DotWeb.Client.dll";
			return Assembly.LoadFrom(asmFile);
		}

		static void domain_AssemblyLoad(object sender, AssemblyLoadEventArgs args) {
			Console.WriteLine(args.LoadedAssembly);
		}
	}
}
