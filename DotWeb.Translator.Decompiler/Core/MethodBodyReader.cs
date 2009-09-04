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
using System.IO;

namespace DotWeb.Translator
{
	public class MethodBodyReader
	{
		private static OpCode[] singleByteOpCodes = new OpCode[0x100];
		private static OpCode[] multiByteOpCodes = new OpCode[0x100];

		static MethodBodyReader() {
			FieldInfo[] opCodeFields = typeof(OpCodes).GetFields();
			foreach (var num in Enumerable.Range(0, opCodeFields.Length)) {
				FieldInfo fieldInfo = opCodeFields[num];
				if (fieldInfo.FieldType == typeof(OpCode)) {
					OpCode code = (OpCode)fieldInfo.GetValue(null);
					ushort codeValue = (ushort)code.Value;
					if (codeValue < 0x100)
						singleByteOpCodes[(int)codeValue] = code;
					else
						multiByteOpCodes[codeValue & 0xff] = code;
				}
			}
		}

		public MethodBase Method { get; private set; }
		public MethodBody MethodBody { get; private set; }
		public List<ILInstruction> Instructions { get; private set; }
		public bool HasCases { get; private set; }

		public MethodBodyReader(MethodBase method) {
			this.Method = method;
			this.MethodBody = method.GetMethodBody();
			//			foreach (ExceptionHandlingClause item in this.MethodBody.ExceptionHandlingClauses) {
			//				item.CatchType
			//				item.TryOffset;
			//				item.TryLength;
			//				item.HandlerOffset;
			//				item.HandlerLength;
			//				item.FilterOffset;
			//				item.Flags == ExceptionHandlingClauseOptions.Clause;
			//				item.Flags == ExceptionHandlingClauseOptions.Finally;
			//			}

			this.Instructions = new List<ILInstruction>();

			MethodBody body = method.GetMethodBody();
			Module module = method.Module;
			byte[] msil = body.GetILAsByteArray();
			MemoryStream ms = new MemoryStream(msil);
			BinaryReader reader = new BinaryReader(ms);

			while (ms.Position < ms.Length) {
				OpCode op = OpCodes.Nop;
				byte value = reader.ReadByte();
				if (value == 0xfe) {
					value = reader.ReadByte();
					op = multiByteOpCodes[value];
				}
				else {
					op = singleByteOpCodes[value];
				}
				ILInstruction instruction = new ILInstruction(1) {
					Method = method,
					Code = op,
					Offset = (int)ms.Position - 1
				};
				int metadataToken = 0;
				switch (op.OperandType) {
					case OperandType.InlineBrTarget:
						metadataToken = reader.ReadInt32();
						metadataToken += (int)ms.Position;
						instruction.Operand = metadataToken;
						break;
					case OperandType.InlineField:
						metadataToken = reader.ReadInt32();
						instruction.Operand = ResolveField(metadataToken, method);
						break;
					case OperandType.InlineMethod:
						metadataToken = reader.ReadInt32();
						instruction.Operand = ResolveMember(metadataToken, method);
						break;
					case OperandType.InlineSig:
						metadataToken = reader.ReadInt32();
						instruction.Operand = module.ResolveSignature(metadataToken);
						break;
					case OperandType.InlineTok:
						metadataToken = reader.ReadInt32();
						instruction.Operand = ResolveToken(metadataToken, method);
						break;
					case OperandType.InlineType:
						metadataToken = reader.ReadInt32();
						instruction.Operand = module.ResolveType(
							metadataToken,
							method.DeclaringType.GetGenericArguments(),
							method.IsConstructor ? null : method.GetGenericArguments()
						);
						break;
					case OperandType.InlineI:
						instruction.Operand = reader.ReadInt32();
						break;
					case OperandType.InlineI8:
						instruction.Operand = reader.ReadInt64();
						break;
					case OperandType.InlineNone:
						string[] parts = op.Name.Split('.');
						if (op.OpCodeType == OpCodeType.Macro) {
							switch (parts[0]) {
								case "ldc":
									if (parts[2] == "m1")
										instruction.Operand = -1;
									else
										instruction.Operand = Convert.ToInt32(parts[2]);
									break;
								case "stloc":
								case "ldloc":
								case "ldarg":
									instruction.Operand = Convert.ToInt32(parts[1]);
									break;
								default:
									throw new InvalidOperationException(string.Format("Unknown macro: {0}", op));
							}
						}
						else if (op.OpCodeType == OpCodeType.Primitive) {
							switch (parts[0]) {
								case "conv":
									switch (parts[1]) {
										case "i4":
											instruction.Operand = typeof(int);
											break;
										case "u4":
											instruction.Operand = typeof(uint);
											break;
									}
									break;
							}
						}
						else {
							instruction.Operand = null;
						}
						break;
					case OperandType.InlineR:
						instruction.Operand = reader.ReadDouble();
						break;
					case OperandType.InlineString:
						metadataToken = reader.ReadInt32();
						instruction.Operand = module.ResolveString(metadataToken);
						break;
					case OperandType.InlineSwitch:
						int count = reader.ReadInt32();
						int[] casesAddresses = new int[count];
						for (int i = 0; i < count; i++) {
							casesAddresses[i] = reader.ReadInt32();
						}
						int[] cases = new int[count];
						for (int i = 0; i < count; i++) {
							cases[i] = (int)ms.Position + casesAddresses[i];
						}
						instruction.Operand = cases;
						HasCases = true;
						break;
					case OperandType.InlineVar:
						instruction.Operand = (int)reader.ReadUInt16();
						break;
					case OperandType.ShortInlineBrTarget:
						sbyte octet = reader.ReadSByte();
						instruction.Operand = (int)octet + (int)ms.Position;
						break;
					case OperandType.ShortInlineI:
						octet = reader.ReadSByte();
						instruction.Operand = (int)octet;
						break;
					case OperandType.ShortInlineR:
						instruction.Operand = reader.ReadSingle();
						break;
					case OperandType.ShortInlineVar:
						instruction.Operand = (int)reader.ReadByte();
						break;
					default:
						throw new InvalidOperationException(string.Format("Invalid OperandType: {0}", op.OperandType));
				}

				Instructions.Add(instruction);
			}
		}

		private object ResolveField(int metadataToken, MethodBase method) {
			Module module = method.Module;
//			if (method.IsConstructor && !method.DeclaringType.IsGenericType) {
//				return module.ResolveField(metadataToken);
//			}

			return module.ResolveField(
				metadataToken,
				method.DeclaringType.GetGenericArguments(),
				method.IsConstructor ? null : method.GetGenericArguments()
			);
		}

		private object ResolveMember(int metadataToken, MethodBase method) {
			Module module = method.Module;
//			if (method.IsConstructor)
//				return module.ResolveMember(metadataToken);

			return module.ResolveMethod(
				metadataToken,
				method.DeclaringType.GetGenericArguments(),
				method.IsConstructor ? null :  method.GetGenericArguments()
			);
		}

		private object ResolveToken(int metadataToken, MethodBase method) {
			Module module = method.Module;
			Type[] typeArgs = method.DeclaringType.GetGenericArguments();
			Type[] methodArgs = method.IsConstructor ? null : method.GetGenericArguments();
			try {
				return module.ResolveType(metadataToken, typeArgs, methodArgs);
			}
			catch {
				try {
					return module.ResolveMember(metadataToken, typeArgs, methodArgs);
				}
				catch {
					return module.ResolveSignature(metadataToken);
				}
			}
		}
	}
}
