using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Reflection;

namespace DotWeb.Sandbox
{
	class CecilRedirection
	{
		public void Run() {
			string path = @"F:\src\git\DotWeb\build\bin\Debug\DotWeb.Sample.Script.dll";
			var asmDef = AssemblyFactory.GetAssembly(path);
			asmDef.MainModule.LoadSymbols();
			asmDef.MainModule.FullLoad();

			var sourceType = asmDef.MainModule.Types["DotWeb.Sample.Script.Test.Sandbox"];
			var sourceMethod = sourceType.Constructors[0];

			//			var targetAsmDef = AssemblyFactory.DefineAssembly("Test", AssemblyKind.Dll);
			//			var moduleDef = new ModuleDefinition("Test", targetAsmDef, true);
			//			var typeDef = new TypeDefinition("Test", "", sourceType.Attributes, sourceType.BaseType);

			//			var ctorDef = new MethodDefinition(sourceMethod.Name, sourceMethod.Attributes, sourceMethod.ReturnType.ReturnType);
			//			typeDef.Constructors.Add(ctorDef);
			//			targetAsmDef.MainModule.Types.Add(typeDef);
			//			moduleDef.Types.Add(typeDef);
			//			targetAsmDef.Modules.Add(moduleDef);

			foreach (Instruction il in sourceMethod.Body.Instructions) {
				//				ctorDef.Body.CilWorker.Append(il);
				if (il.SequencePoint != null) {
					var sp = il.SequencePoint;
					Console.WriteLine("{0}:{1}", sp.Document.Url, sp.StartLine);
				}
				Console.WriteLine("\t{0} {1}", il.OpCode, il.Operand);
			}

			asmDef.MainModule.SaveSymbols();
			string outPath = @"F:\src\git\DotWeb\build\bin\Debug\Test.dll";
			AssemblyFactory.SaveAssembly(asmDef, outPath);

			//			var asm = AssemblyFactory.CreateReflectionAssembly(asmDef);
			var asm = Assembly.LoadFile(outPath);
			var type = asm.GetType(sourceType.FullName);
			var types = asm.GetTypes();
			var obj = Activator.CreateInstance(type);
		}
	}
}
