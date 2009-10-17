using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using CecilOpCode = Mono.Cecil.Cil.OpCode;
using CecilOpCodes = Mono.Cecil.Cil.OpCodes;

using SysOpCode = System.Reflection.Emit.OpCode;
using SysOpCodes = System.Reflection.Emit.OpCodes;

namespace DotWeb.Tools.Weaver
{
	class OperandTypeNames
	{
		public const string Byte = "Byte";
		public const string SByte = "SByte";
		public const string Double = "Double";
		public const string Float = "Single";
		public const string Int = "Int32";
		public const string Short = "Int16";
		public const string Long = "Int64";
		public const string String = "String";
		public const string MethodReference = "MethodReference";
		public const string MethodDefinition = "MethodDefinition";
		public const string FieldReference = "FieldReference";
		public const string FieldDefinition = "FieldDefinition";
		public const string TypeReference = "TypeReference";
		public const string TypeDefinition = "TypeDefinition";
		public const string VariableDefinition = "VariableDefinition";
		public const string ParameterDefinition = "ParameterDefinition";
		public const string Instruction = "Instruction";
	}

	class OpCodeConverter
	{
		static Dictionary<short, SysOpCode> dict = new Dictionary<short, SysOpCode>();
		static OpCodeConverter() {
			var type = typeof(SysOpCodes);
			var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
			foreach (var field in fields) {
				SysOpCode code = (SysOpCode)field.GetValue(null);
				dict.Add(code.Value, code);
			}
		}

		public static SysOpCode Convert(CecilOpCode src) {
			return dict[src.Value];
		}
	}

}
