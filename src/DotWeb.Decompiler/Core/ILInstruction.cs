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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace DotWeb.Decompiler.Core
{
	class ILInstruction : Node
	{
		public MethodBase Method { get; set; }
		public OpCode Code { get; set; }
		public string OpCodeName { get { return this.Code.Name; } }
		public string PrimitiveName { get { return this.Code.Name.Split('.').First(); } }
		public object Operand { get; set; }
		public byte[] OperandData { get; set; }
		public int Offset { get; set; }

		public string OffsetString {
			get {
				return Offset.ToString("0000");
			}
		}

		public bool IsLoop {
			get {
				return this.IsBranch && (int)Operand < Offset;
			}
		}

		public bool IsBranch {
			get {
				return Code.FlowControl == FlowControl.Branch ||
					Code.FlowControl == FlowControl.Cond_Branch;
			}
		}

		public bool IsTwoWay {
			get {
				return Code.FlowControl == FlowControl.Cond_Branch && 
					Code != OpCodes.Switch;
			}
		}

		public bool IsMultiWay {
			get {
				return Code == OpCodes.Switch;
			}
		}

		public bool IsBrTrue {
			get {
				return Code == OpCodes.Brtrue_S || Code == OpCodes.Brtrue;
			}
		}

		public ILInstruction(int id)
			: base(id) {
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}: {1}", OffsetString, Code);
			if (Operand != null) {
				switch (Code.OperandType) {
					case OperandType.InlineField:
						System.Reflection.FieldInfo field = ((System.Reflection.FieldInfo)Operand);
						sb.AppendFormat(" {0} {1}::{2}", field.FieldType, field.ReflectedType, field.Name);
						break;
					case OperandType.InlineMethod:
						MethodBase method = Operand as MethodBase;
						sb.Append(" ");
						if (!method.IsStatic) 
							sb.Append("instance ");
						MethodInfo mi = method as MethodInfo;
						if (mi != null)
							sb.Append(mi.ReturnType);
						else
							sb.Append("void");
						sb.AppendFormat(" {0}::{1}()", method.ReflectedType, method.Name);
						break;
					case OperandType.ShortInlineBrTarget:
					case OperandType.InlineBrTarget:
						sb.AppendFormat(" {0}", ((int)Operand).ToString("0000"));
						break;
					case OperandType.InlineString:
						if (Operand.ToString() == "\r\n") sb.Append(" \"\\r\\n\"");
						else sb.AppendFormat(" \"{0}\"", Operand.ToString());
						break;
					case OperandType.InlineType:
					case OperandType.ShortInlineVar:
					case OperandType.InlineI:
					case OperandType.InlineI8:
					case OperandType.InlineR:
					case OperandType.ShortInlineI:
					case OperandType.ShortInlineR:
						sb.AppendFormat(" {0}", Operand);
						break;
					case OperandType.InlineTok:
						if (Operand is Type)
							sb.AppendFormat(" {0}", ((Type)Operand).FullName); 
						else
							sb.AppendFormat(" {0}", Operand);
						break;
					case OperandType.InlineNone:
//						result += " (None)"; 
						break;
					case OperandType.InlineSwitch:
						var cases = ((int[])Operand).Select(x => x.ToString());
						sb.AppendFormat(" [{0}]", string.Join(", ", cases.ToArray()));
						break;
					default: 
						sb.Append(" not supported"); 
						break;
				}
			}

			sb.AppendFormat(" {0}", Code.FlowControl);
			return sb.ToString();
		}
	}
}
