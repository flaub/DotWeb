using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DotWeb.Decompiler.Core;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.IO;

using CecilOpCode = Mono.Cecil.Cil.OpCode;
using CecilOpCodes = Mono.Cecil.Cil.OpCodes;

using SysOpCode = System.Reflection.Emit.OpCode;
using SysOpCodes = System.Reflection.Emit.OpCodes;
using DotWeb.Utility;
using Castle.Core.Interceptor;
using DotWeb.Hosting;

namespace DotWeb.Sandbox
{
	public class Program
	{
		static void Main(string[] args) {
			ReadCecilWriteDotNet();
		}

		class HostHarness : IDotWebHost
		{
			public delegate object InvokeHandler(object scope, object method, object[] args);
			public delegate object CastHandler(object obj);

			public InvokeHandler Invoker { get; set; }
			public CastHandler Caster { get; set; }

			public object Invoke(object scope, object method, object[] args) {
				if (Invoker != null)
					return Invoker(scope, method, args);
				throw new NotImplementedException();
			}

			public T Cast<T>(object obj) {
				if (Caster != null) {
					var ret = Caster(obj);
					return (T)ret;
				}
				throw new NotImplementedException();
			}
		}

		static void ReadCecilWriteDotNet() {
			HostedMode.Host = new HostHarness {
				Invoker = delegate(object scope, object method, object[] args) {
					return null;
				}
			};

			//string asmPath = "DotWeb.Weaver.Test.Script.dll";
			//weaver.ProcessAssembly(asmPath);

			//var dir = @"F:\src\git\DotWeb\build\bin\Debug";
			//var hoister = new Hoister(dir, dir);
			//var str = "DotWeb.Sample.Script.Test.Sandbox, DotWeb.Sample.Script";
			//var asmQualifiedTypeName = new AssemblyQualifiedTypeName(str);
			//var hosted = hoister.ProcessEntry(asmQualifiedTypeName);

			//var asm = Assembly.LoadFile(hosted);
			//var types = asm.GetTypes();
			//var type = asm.GetType(asmQualifiedTypeName.TypeName);
			//try {
			//    var obj = Activator.CreateInstance(type);
			//}
			//catch (TargetInvocationException ex) {
			//    throw ex.InnerException;
			//}
		}

#if false
		static void HostedModeAppDomain() {
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
#endif
	}
}
