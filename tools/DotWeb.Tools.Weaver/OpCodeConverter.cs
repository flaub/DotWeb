// Copyright 2009, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 

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
