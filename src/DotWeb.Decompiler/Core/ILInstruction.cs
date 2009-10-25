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

using System;
using System.Linq;
using System.Text;
using Mono.Cecil.Cil;
using Mono.Cecil;
using System.Diagnostics;

namespace DotWeb.Decompiler.Core
{
	public static class InstructionExtensions
	{
		public static bool IsBranch(this Instruction cil) {
			return cil.OpCode.FlowControl == FlowControl.Branch ||
				cil.OpCode.FlowControl == FlowControl.Cond_Branch;
		}

		public static bool IsTwoWay(this Instruction cil) {
			return cil.OpCode.FlowControl == FlowControl.Cond_Branch &&
				cil.OpCode != OpCodes.Switch;
		}

		public static bool IsMultiWay(this Instruction cil) {
			return cil.OpCode == OpCodes.Switch;
		}

		public static string PrimitiveName(this Instruction cil) {
			return cil.OpCode.Name.Split('.').First();
		}

		public static string OffsetString(this Instruction cil) {
			return cil.Offset.ToString("0000");
		}

		public static int ResolveMacroValue(this Instruction cil) {
			Debug.Assert(cil.OpCode.OpCodeType == OpCodeType.Macro);
			var parts = cil.OpCode.Name.Split('.');
			switch (parts[0]) {
				case "ldc":
					if (parts[2] == "m1")
						return -1;
					else
						return Convert.ToInt32(parts[2]);
				case "stloc":
				case "ldloc":
				case "ldarg":
					return Convert.ToInt32(parts[1]);
				default:
					throw new InvalidOperationException(string.Format("Unknown macro: {0}", cil.OpCode));
			}
		}

		public static object ResolveOperand(this Instruction cil) {
			if (cil.OpCode.OperandType == OperandType.InlineNone &&
				cil.OpCode.OpCodeType == OpCodeType.Macro)
				return cil.ResolveMacroValue();
			return cil.Operand;
		}

		public static string DisplayString(this Instruction cil) {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}: {1}", cil.OffsetString(), cil.OpCode);
			if (cil.Operand != null) {
				switch (cil.OpCode.OperandType) {
					case OperandType.InlineField:
						var field = (FieldReference)cil.Operand;
						sb.AppendFormat(" {0} {1}::{2}", field.FieldType, field.DeclaringType, field.Name);
						break;
					case OperandType.InlineMethod:
						var method = (MethodReference)cil.Operand;
						var def = method.Resolve();
						sb.Append(" ");
						if (!def.IsStatic)
							sb.Append("instance ");
						sb.Append(method.ReturnType);
						sb.AppendFormat(" {0}::{1}()", method.DeclaringType, method.Name);
						break;
					case OperandType.ShortInlineBrTarget:
					case OperandType.InlineBrTarget:
						sb.AppendFormat(" {0}", ((Instruction)cil.Operand).OffsetString());
						break;
					case OperandType.InlineString:
						if (cil.Operand.ToString() == "\r\n") 
							sb.Append(" \"\\r\\n\"");
						else 
							sb.AppendFormat(" \"{0}\"", cil.Operand.ToString());
						break;
					case OperandType.InlineType:
					case OperandType.ShortInlineVar:
					case OperandType.InlineI:
					case OperandType.InlineI8:
					case OperandType.InlineR:
					case OperandType.ShortInlineI:
					case OperandType.ShortInlineR:
						sb.AppendFormat(" {0}", cil.Operand);
						break;
					case OperandType.InlineTok:
						if (cil.Operand is TypeReference)
							sb.AppendFormat(" {0}", ((TypeReference)cil.Operand).FullName);
						else
							sb.AppendFormat(" {0}", cil.Operand);
						break;
					case OperandType.InlineNone:
						// result += " (None)"; 
						break;
					case OperandType.InlineSwitch:
						var cases = ((Instruction[])cil.Operand).Select(x => x.OffsetString());
						sb.AppendFormat(" [{0}]", string.Join(", ", cases.ToArray()));
						break;
					default:
						sb.Append(" not supported");
						break;
				}
			}

			sb.AppendFormat(" {0}", cil.OpCode.FlowControl);
			return sb.ToString();
		}
	}

//    public class ILInstruction : Node
//    {
//        public MethodBase Method { get; set; }
//        public OpCode Code { get; set; }
//        public string OpCodeName { get { return this.Code.Name; } }
//        public string PrimitiveName { get { return this.Code.Name.Split('.').First(); } }
//        public object Operand { get; set; }
//        public byte[] OperandData { get; set; }
//        public int Offset { get; set; }

//        public string OffsetString {
//            get {
//                return Offset.ToString("0000");
//            }
//        }

//        public bool IsLoop {
//            get {
//                return this.IsBranch && (int)Operand < Offset;
//            }
//        }

//        public bool IsBranch {
//            get {
//                return Code.FlowControl == FlowControl.Branch ||
//                    Code.FlowControl == FlowControl.Cond_Branch;
//            }
//        }

//        public bool IsTwoWay {
//            get {
//                return Code.FlowControl == FlowControl.Cond_Branch && 
//                    Code != OpCodes.Switch;
//            }
//        }

//        public bool IsMultiWay {
//            get {
//                return Code == OpCodes.Switch;
//            }
//        }

//        public bool IsBrTrue {
//            get {
//                return Code == OpCodes.Brtrue_S || Code == OpCodes.Brtrue;
//            }
//        }

//        public ILInstruction(int id)
//            : base(id) {
//        }


//    }
}
