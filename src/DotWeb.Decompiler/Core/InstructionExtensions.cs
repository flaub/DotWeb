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

		public static bool IsLeave(this Instruction cil) {
			return cil.OpCode == OpCodes.Leave || cil.OpCode == OpCodes.Leave_S;
		}

		public static string PrimitiveName(this Instruction cil) {
			return cil.OpCode.Name.Split('.').First();
		}

		public static string OffsetString(this Instruction cil) {
			return cil.Offset.ToString("0000");
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
					case OperandType.InlineI:
					case OperandType.InlineI8:
					case OperandType.InlineR:
					case OperandType.InlineVar:
					case OperandType.InlineSig:
					case OperandType.InlineArg:
					case OperandType.ShortInlineI:
					case OperandType.ShortInlineR:
					case OperandType.ShortInlineVar:
					case OperandType.ShortInlineArg:
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
					case OperandType.InlinePhi:
					default:
						sb.Append(" not supported");
						break;
				}
			}

			sb.AppendFormat(" <{0}>", cil.OpCode.FlowControl);
			return sb.ToString();
		}
	}
}
