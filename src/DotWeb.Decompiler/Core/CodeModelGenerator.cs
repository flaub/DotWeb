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
using System.Runtime.InteropServices;
using DotWeb.Decompiler.CodeModel;
using DotWeb.Utility;
using System.Diagnostics;
using Mono.Cecil.Cil;
using Mono.Cecil;
using DotWeb.Utility.Cecil;

namespace DotWeb.Decompiler.Core
{
	class CodeModelGenerator
	{
		private readonly CodeModelVirtualMachine vm;
		private readonly MethodDefinition method;
		private readonly TypeHierarchy typeHierarchy;

		private List<CodeStatement> statements;

		public CodeModelGenerator(TypeHierarchy typeHierarchy, MethodDefinition method, CodeModelVirtualMachine vm, IEnumerable<Instruction> instructions, List<CodeStatement> statements) {
			this.typeHierarchy = typeHierarchy;
			this.method = method;
			this.vm = vm;
			this.statements = statements;
			foreach (var il in instructions) {
				HandleInstruction(il);
			}
		}

		private void HandleInstruction(Instruction il) {
			switch (il.OpCode.Code) {
				#region Load
				case Code.Ldnull:
					Load(null);
					break;
				case Code.Ldstr:
					Load(il.Operand);
					break;
				case Code.Ldc_I4:
				case Code.Ldc_I4_S:
					Load(Convert.ToInt32(il.Operand));
					break;
				case Code.Ldc_I4_0:
					Load(0);
					break;
				case Code.Ldc_I4_1:
					Load(1);
					break;
				case Code.Ldc_I4_2:
					Load(2);
					break;
				case Code.Ldc_I4_3:
					Load(3);
					break;
				case Code.Ldc_I4_4:
					Load(4);
					break;
				case Code.Ldc_I4_5:
					Load(5);
					break;
				case Code.Ldc_I4_6:
					Load(6);
					break;
				case Code.Ldc_I4_7:
					Load(7);
					break;
				case Code.Ldc_I4_8:
					Load(8);
					break;
				case Code.Ldc_I4_M1:
					Load(-1);
					break;
				case Code.Ldc_I8:
					Load(Convert.ToInt64(il.Operand));
					break;
				case Code.Ldc_R4:
					Load(Convert.ToSingle(il.Operand));
					break;
				case Code.Ldc_R8:
					Load(Convert.ToDouble(il.Operand));
					break;
				case Code.Ldloc_0:
					LoadLocal(0);
					break;
				case Code.Ldloc_1:
					LoadLocal(1);
					break;
				case Code.Ldloc_2:
					LoadLocal(2);
					break;
				case Code.Ldloc_3:
					LoadLocal(3);
					break;
				case Code.Ldloc:
				case Code.Ldloc_S:
				case Code.Ldloca:
				case Code.Ldloca_S:
					LoadLocal((VariableReference)il.Operand);
					break;
				case Code.Ldtoken:
					LoadToken(il);
					break;
				case Code.Ldelem_Any:
				case Code.Ldelem_I:
				case Code.Ldelem_I1:
				case Code.Ldelem_I2:
				case Code.Ldelem_I4:
				case Code.Ldelem_I8:
				case Code.Ldelem_R4:
				case Code.Ldelem_R8:
				case Code.Ldelem_Ref:
				case Code.Ldelem_U1:
				case Code.Ldelem_U2:
				case Code.Ldelem_U4:
					LoadElement(il);
					break;
				case Code.Ldlen:
					LoadLength(il);
					break;
				case Code.Ldarg_0:
					LoadArgument(0);
					break;
				case Code.Ldarg_1:
					LoadArgument(1);
					break;
				case Code.Ldarg_2:
					LoadArgument(2);
					break;
				case Code.Ldarg_3:
					LoadArgument(3);
					break;
				case Code.Ldarg:
				case Code.Ldarg_S:
					LoadArgument(il);
					break;
				case Code.Ldfld:
					LoadField(il);
					break;
				case Code.Ldsfld:
					LoadStaticField(il);
					break;
				case Code.Ldsflda:
					LoadStaticFieldAddress(il);
					break;
				case Code.Ldftn:
					LoadMethod(il);
					break;
				#endregion
				#region Store
				case Code.Stloc_0:
					StoreLocal(0);
					break;
				case Code.Stloc_1:
					StoreLocal(1);
					break;
				case Code.Stloc_2:
					StoreLocal(2);
					break;
				case Code.Stloc_3:
					StoreLocal(3);
					break;
				case Code.Stloc:
				case Code.Stloc_S:
					StoreLocal((VariableReference)il.Operand);
					break;
				case Code.Stelem_Any:
				case Code.Stelem_I:
				case Code.Stelem_I1:
				case Code.Stelem_I2:
				case Code.Stelem_I4:
				case Code.Stelem_I8:
				case Code.Stelem_R4:
				case Code.Stelem_R8:
				case Code.Stelem_Ref:
					StoreElement(il);
					break;
				case Code.Starg:
				case Code.Starg_S:
					StoreArgument(il);
					break;
				case Code.Stfld:
					StoreField(il);
					break;
				case Code.Stsfld:
					StoreStaticField(il);
					break;
				#endregion
				#region New
				case Code.Newarr:
					NewArray(il);
					break;
				case Code.Newobj:
					NewObject(il);
					break;
				#endregion
				#region Binary Expressions
				case Code.Mul:
				case Code.Mul_Ovf:
				case Code.Mul_Ovf_Un:
					BinaryExpression(il, CodeBinaryOperator.Multiply);
					break;
				case Code.Add:
				case Code.Add_Ovf:
				case Code.Add_Ovf_Un:
					BinaryExpression(il, CodeBinaryOperator.Add);
					break;
				case Code.Sub:
				case Code.Sub_Ovf:
				case Code.Sub_Ovf_Un:
					BinaryExpression(il, CodeBinaryOperator.Subtract);
					break;
				case Code.Rem:
				case Code.Rem_Un:
					BinaryExpression(il, CodeBinaryOperator.Modulus);
					break;
				case Code.Div:
				case Code.Div_Un:
					BinaryExpression(il, CodeBinaryOperator.Divide);
					break;
				case Code.And:
					BinaryExpression(il, CodeBinaryOperator.BitwiseAnd);
					break;
				case Code.Or:
					BinaryExpression(il, CodeBinaryOperator.BitwiseOr);
					break;
				case Code.Xor:
					BinaryExpression(il, CodeBinaryOperator.ExclusiveOr);
					break;
				case Code.Shl:
					BinaryExpression(il, CodeBinaryOperator.LeftShift);
					break;
				case Code.Shr:
				case Code.Shr_Un:
					BinaryExpression(il, CodeBinaryOperator.RightShift);
					break;
				#endregion
				#region Unary Expressions
				case Code.Not:
					UnaryExpression(il, CodeUnaryOperator.Not);
					break;
				case Code.Neg:
					UnaryExpression(il, CodeUnaryOperator.Negate);
					break;
				#endregion
				#region Branch
				case Code.Beq:
				case Code.Beq_S:
					ConditionalBranch(il, CodeBinaryOperator.IdentityEquality);
					break;
				case Code.Bge:
				case Code.Bge_S:
				case Code.Bge_Un:
				case Code.Bge_Un_S:
					ConditionalBranch(il, CodeBinaryOperator.GreaterThanOrEqual);
					break;
				case Code.Bgt:
				case Code.Bgt_S:
				case Code.Bgt_Un:
				case Code.Bgt_Un_S:
					ConditionalBranch(il, CodeBinaryOperator.GreaterThan);
					break;
				case Code.Blt:
				case Code.Blt_S:
				case Code.Blt_Un:
				case Code.Blt_Un_S:
					ConditionalBranch(il, CodeBinaryOperator.LessThan);
					break;
				case Code.Ble:
				case Code.Ble_S:
				case Code.Ble_Un:
				case Code.Ble_Un_S:
					ConditionalBranch(il, CodeBinaryOperator.LessThanOrEqual);
					break;
				case Code.Bne_Un:
				case Code.Bne_Un_S:
					ConditionalBranch(il, CodeBinaryOperator.IdentityInequality);
					break;
				case Code.Brtrue:
				case Code.Brtrue_S:
					ConditionalBranch(il, true);
					break;
				case Code.Brfalse:
				case Code.Brfalse_S:
					ConditionalBranch(il, false);
					break;
				case Code.Br:
				case Code.Br_S:
					Branch(il);
					break;
				case Code.Switch:
					Switch(il);
					break;
				#endregion
				#region Comparision
				case Code.Clt:
				case Code.Clt_Un:
					Comparision(il, CodeBinaryOperator.LessThan);
					break;
				case Code.Cgt:
				case Code.Cgt_Un:
					Comparision(il, CodeBinaryOperator.GreaterThan);
					break;
				case Code.Ceq:
					Comparision(il, CodeBinaryOperator.IdentityEquality);
					break;
				#endregion
				#region Call
				case Code.Call:
					Call(il, false);
					break;
				case Code.Callvirt:
					Call(il, true);
					break;
				case Code.Ret:
					Return(il);
					break;
				#endregion
				#region Misc
				case Code.Pop:
					Pop(il);
					break;
				case Code.Dup:
					Dup(il);
					break;
				case Code.Conv_I:
				case Code.Conv_Ovf_I:
				case Code.Conv_Ovf_I_Un:
					OnConvert(typeof(IntPtr));
					break;
				case Code.Conv_I1:
				case Code.Conv_Ovf_I1:
				case Code.Conv_Ovf_I1_Un:
					OnConvert(typeof(sbyte));
					break;
				case Code.Conv_I2:
				case Code.Conv_Ovf_I2:
				case Code.Conv_Ovf_I2_Un:
					OnConvert(typeof(short));
					break;
				case Code.Conv_I4:
				case Code.Conv_Ovf_I4:
				case Code.Conv_Ovf_I4_Un:
					OnConvert(typeof(int));
					break;
				case Code.Conv_I8:
				case Code.Conv_Ovf_I8:
				case Code.Conv_Ovf_I8_Un:
					OnConvert(typeof(long));
					break;
				case Code.Conv_R_Un:
				case Code.Conv_R4:
					OnConvert(typeof(float));
					break;
				case Code.Conv_R8:
					OnConvert(typeof(double));
					break;
				case Code.Conv_U:
				case Code.Conv_Ovf_U:
				case Code.Conv_Ovf_U_Un:
					OnConvert(typeof(UIntPtr));
					break;
				case Code.Conv_U1:
				case Code.Conv_Ovf_U1:
				case Code.Conv_Ovf_U1_Un:
					OnConvert(typeof(byte));
					break;
				case Code.Conv_U2:
				case Code.Conv_Ovf_U2:
				case Code.Conv_Ovf_U2_Un:
					OnConvert(typeof(ushort));
					break;
				case Code.Conv_U4:
				case Code.Conv_Ovf_U4:
				case Code.Conv_Ovf_U4_Un:
					OnConvert(typeof(uint));
					break;
				case Code.Conv_U8:
				case Code.Conv_Ovf_U8:
				case Code.Conv_Ovf_U8_Un:
					OnConvert(typeof(ulong));
					break;
				case Code.Leave:
				case Code.Leave_S:
					Leave(il);
					break;
				case Code.Nop:
					Nop(il);
					break;
				case Code.Castclass:
					CastClass(il);
					break;
				case Code.Throw:
					Throw(il);
					break;
				case Code.Isinst:
					IsInstance(il);
					break;
				case Code.Unbox:
				case Code.Unbox_Any:
					Unbox(il);
					break;
				#endregion
				#region Unsupported/Unneeded
				case Code.Box:
					break;
				#endregion
				default:
					throw new NotImplementedException();
			}
		}

		private void AddStatment(CodeStatement stmt) {
			this.statements.Add(stmt);
		}

		private void Unbox(Instruction il) {
			PushCastExpression((TypeReference)il.Operand);
		}

		private void Pop(Instruction il) {
			CodeExpression exp = Pop();
			if (exp is CodeObjectCreateExpression ||
				exp is CodeInvokeExpression) {
				AddStatment(new CodeExpressionStatement(exp));
			}
			else {
				throw new NotSupportedException(exp.ToString());
			}
		}

		private void Nop(Instruction il) {
//			var stmt = new CodeCommentStatement("nop");
//			this.AddStatment(stmt);
		}

		private void Return(Instruction il) {
			var ret = new CodeReturnStatement();
			if (vm.Stack.Any())
				ret.Expression = Pop();
			AddStatment(ret);
		}

		private CodeExpression GetTargetObject(MethodDefinition method) {
			if (method.HasThis) {
				return Pop();
			}
			else {
				return new CodeTypeReference(method.DeclaringType);
			}
		}

		private void CallMethod(Instruction il, MethodDefinition method, bool isVirtual) {
			CodeInvokeExpression expr = new CodeInvokeExpression();
			expr.Parameters = PopRange(method.Parameters.Count);

			CodeExpression targetObject = GetTargetObject(method);

			if (method.IsVirtual) {
				if (!isVirtual && targetObject is CodeThisReference) {
					targetObject = new CodeBaseReference();
				}
				var overrides = this.typeHierarchy.GetOverridesForVirtualMethod(method);
				foreach (var overridenMethod in overrides) {
					this.vm.ExternalMethods.Add(overridenMethod);
				}
			}
			this.vm.ExternalMethods.Add(method);
			
			expr.Method = new CodeMethodReference(targetObject, method);

			if (method.IsConstructor || method.ReturnType.ReturnType.FullName == Constants.Void) {
				CodeExpressionStatement stmt = new CodeExpressionStatement(expr);
				AddStatment(stmt);
			}
			else {
				Push(expr);
			}
		}

		private void CallGetter(Instruction il, MethodDefinition method, PropertyReference pi) {
			this.vm.ExternalMethods.Add(method);
			var args = method.Parameters;
			if (args.Count == 0) {
				var targetObject = GetTargetObject(method);
				CodeMethodReference methodRef = new CodeMethodReference(targetObject, method);
				CodePropertyReference expr = new CodePropertyReference(methodRef, pi, CodePropertyReference.RefType.Get);
				Push(expr);
			}
			else {
				CodeIndexerExpression expr = new CodeIndexerExpression();
				expr.Indices = PopRange(args.Count);
				expr.TargetObject = GetTargetObject(method);
				Push(expr);
			}
		}

		private void CallSetter(Instruction il, MethodDefinition method, PropertyReference pi) {
			this.vm.ExternalMethods.Add(method);
			var args = method.Parameters;
			if (args.Count == 1) {
				CodeExpression rhs = Pop();
				var targetObject = GetTargetObject(method);
				CodeMethodReference methodRef = new CodeMethodReference(targetObject, method);
				CodePropertyReference lhs = new CodePropertyReference(methodRef, pi, CodePropertyReference.RefType.Set);

				AddAssignment(lhs, rhs);
			}
			else {
				CodeIndexerExpression lhs = new CodeIndexerExpression();
				lhs.Indices = PopRange(args.Count);
				CodeExpression rhs = lhs.Indices[lhs.Indices.Count - 1];
				lhs.Indices.Remove(rhs);
				lhs.TargetObject = GetTargetObject(method);

				AddAssignment(lhs, rhs);
			}
		}

		private void Call(Instruction il, bool isVirtual) {
			var method = (MethodReference)il.Operand;
			var def = method.Resolve();

			var ap = def.GetMonoAssociatedProperty();
			if (ap != null) {
				Debug.Assert(ap.Definition != null);
				if (ap.IsGetter) {
					CallGetter(il, def, ap.Definition);
				}
				else {
					CallSetter(il, def, ap.Definition);
				}
			}
			else {
				CallMethod(il, def, isVirtual);
			}
		}

		private TypeReference Import(Type type) {
			return this.method.DeclaringType.Module.Import(type);
		}

		private void OnConvert(Type type) {
			PushCastExpression(Import(type));
		}

		private void LoadArgument(Instruction il) {
			PushArgumentReference((ParameterReference)il.Operand);
		}

		private void LoadArgument(int index) {
			PushArgumentReference(index);
		}

		private void LoadMethod(Instruction il) {
			var method = (MethodReference)il.Operand;
			CodeTypeReference type = new CodeTypeReference(method.DeclaringType);
			CodeMethodReference expr = new CodeMethodReference(type, method);
			this.vm.ExternalMethods.Add(method);
			Push(expr);
		}

		private void LoadField(Instruction il) {
			var field = (FieldReference)il.Operand;
			CodeExpression targetObject = Pop();
			CodeFieldReference expr = new CodeFieldReference(targetObject, field);
			Push(expr);
		}

		private void LoadStaticField(Instruction il) {
			var field = (FieldReference)il.Operand;
			CodeTypeReference typeRef = new CodeTypeReference(field.DeclaringType);
			CodeFieldReference expr = new CodeFieldReference(typeRef, field);
			Push(expr);
		}

		private void LoadStaticFieldAddress(Instruction il) {
			LoadStaticField(il);
		}

		private void LoadLocal(VariableReference variable) {
			Push(new CodeVariableReference(variable));
		}

		private void LoadLocal(int index) {
			var arg = this.method.Body.Variables[index];
			LoadLocal(arg);
		}

		private void Load(object value) {
			PushLiteral(value);
		}

		private void LoadLength(Instruction il) {
			var targetObject = Pop();
			Push(new CodeLengthReference(targetObject));
		}

		private void LoadElement(Instruction il) {
			var index = Pop();
			var target = Pop();
			var expr = new CodeArrayIndexerExpression(target, index);
			Push(expr);
		}

		private int[] ConvertInitialValue(byte[] data) {
			int elementSize = Marshal.SizeOf(typeof(int));
			var array = new int[data.Length / elementSize];
			for (int i = 0; i < array.Length; i++) {
				array[i] = BitConverter.ToInt32(data, i * elementSize);
			}
			return array;
		}

		private void LoadToken(Instruction il) {
			if (il.Operand is FieldReference) {
				var fi = (FieldReference)il.Operand;
				var def = fi.Resolve();
				if (def.IsStatic) {
					// FIXME: filter this for only int[] initialization
					int[] array = ConvertInitialValue(def.InitialValue);
					CodePrimitiveExpression expr = new CodePrimitiveExpression(array);
					Push(expr);
					return;
				}
			}

			throw new NotImplementedException();
		}

		private void StoreElement(Instruction il) {
			var value = Pop();
			var index = Pop();
			var array = Pop();

			CodeArrayIndexerExpression lhs = new CodeArrayIndexerExpression(array, index);
			AddAssignment(lhs, value);
		}

		private void StoreArgument(Instruction il) {
			PushArgumentReference((ParameterReference)il.Operand);
			AddAssignment(Pop(), Pop());
		}

		private void StoreLocal(int index) {
			var arg = this.method.Body.Variables[index];
			StoreLocal(arg);
		}

		private void StoreLocal(VariableReference variable) {
			CodeVariableReference lhs = new CodeVariableReference(variable);
			CodeExpression rhs = Pop();
			AddAssignment(lhs, rhs);
		}

		private void StoreField(Instruction il) {
			var field = (FieldReference)il.Operand;
			CodeExpression rhs = Pop();
			CodeExpression targetObject = Pop();
			CodeFieldReference lhs = new CodeFieldReference(targetObject, field);
			AddAssignment(lhs, rhs);
		}

		private void StoreStaticField(Instruction il) {
			var field = (FieldReference)il.Operand;
			CodeTypeReference typeRef = new CodeTypeReference(field.DeclaringType);
			CodeFieldReference lhs = new CodeFieldReference(typeRef, field);
			CodeExpression rhs = Pop();
			AddAssignment(lhs, rhs);
		}

		private void BinaryExpression(Instruction il, CodeBinaryOperator op) {
			CodeExpression rhs = Pop();
			CodeExpression lhs = Pop();
			CodeBinaryExpression expr = new CodeBinaryExpression(lhs, op, rhs);
			Push(expr);
		}

		private void UnaryExpression(Instruction il, CodeUnaryOperator op) {
			CodeExpression operand = Pop();
			CodeUnaryExpression expr = new CodeUnaryExpression(operand, op);
			Push(expr);
		}

		private void Comparision(Instruction il, CodeBinaryOperator op) {
			CodeExpression rhs = Pop();
			CodeExpression lhs = Pop();
			CodeBinaryExpression expr = new CodeBinaryExpression(lhs, op, rhs);
			Push(expr);
		}

		private void ConditionalBranch(Instruction il, CodeBinaryOperator op) {
			CodeExpression rhs = Pop();
			CodeExpression lhs = Pop();
			CodeBinaryExpression condition = new CodeBinaryExpression(lhs, op, rhs);
			CodeExpressionStatement stmt = new CodeExpressionStatement(condition);
			AddStatment(stmt);
		}

		private void ConditionalBranch(Instruction il, bool test) {
			CodePrimitiveExpression rhs = new CodePrimitiveExpression(test);
			CodeExpression lhs = Pop();
			CodeBinaryExpression condition = new CodeBinaryExpression(
				lhs, CodeBinaryOperator.IdentityEquality, rhs);
			CodeExpressionStatement stmt = new CodeExpressionStatement(condition);
			AddStatment(stmt);
		}

		private void Branch(Instruction il) {
			CodeGotoStatement stmt = new CodeGotoStatement((Instruction)il.Operand);
			AddStatment(stmt);
		}

		private void NewArray(Instruction il) {
			CodeExpression count = Pop();
			var type = (TypeReference)il.Operand;
			CodeArrayCreateExpression expr = new CodeArrayCreateExpression {
				SizeExpression = count,
				Type = type
			};
			Push(expr);
		}

		private void NewObject(Instruction il) {
			var ctor = (MethodReference)il.Operand;
			this.vm.ExternalMethods.Add(ctor);

			CodeObjectCreateExpression expr = new CodeObjectCreateExpression {
				Constructor = ctor
			};
			expr.Parameters = PopRange(ctor.Parameters.Count);

			Push(expr);
		}

		private void Dup(Instruction il) {
			var exp = Peek();
			Push(exp);
		}

		private void Leave(Instruction il) {
			Debug.Assert(false);
			CodeGotoStatement stmt = new CodeGotoStatement((Instruction)il.Operand);
			AddStatment(stmt);
		}

		private void CastClass(Instruction il) {
			PushCastExpression((TypeReference)il.Operand);
		}

		private void Throw(Instruction il) {
			CodeExpression obj = Pop();
			CodeThrowStatement stmt = new CodeThrowStatement(obj);
			AddStatment(stmt);
		}

		private void Switch(Instruction il) {
			CodeExpression expr = Pop();
			CodeSwitchStatement stmt = new CodeSwitchStatement {
				Expression = expr
			};
			AddStatment(stmt);
		}

		private void IsInstance(Instruction il) {
			CodeExpression obj = Pop();
			var type = (TypeReference)il.Operand;
			CodeExpression expr = new CodeInstanceOfExpression(type, obj);
			Push(expr);
		}

		#region Helpers

		private void AddAssignment(CodeExpression lhs, CodeExpression rhs) {
			AddStatment(new CodeAssignStatement(lhs, rhs));
		}

		private void PushArgumentReference(ParameterReference arg) {
			Push(new CodeArgumentReference(arg));
		}

		private void PushArgumentReference(int index) {
			if (this.method.HasThis) {
				if (index == 0) {
					Push(new CodeThisReference());
					return;
				}
				index--;
			}
			Push(new CodeArgumentReference(this.method.Parameters[index]));
		}

		private void PushCastExpression(TypeReference type) {
			Push(new CodeCastExpression(type, Pop()));
		}

		private void PushLiteral(object value) {
			Push(new CodePrimitiveExpression(value));
		}

		private void Push(CodeExpression expr) {
			vm.Stack.Push(expr);
		}

		private CodeExpression Pop() {
			return vm.Stack.Pop();
		}

		private CodeExpression Peek() {
			return vm.Stack.Peek();
		}

		private List<CodeExpression> PopRange(int count) {
			var args = new List<CodeExpression>();
			for (int i = 0; i < count; i++) {
				args.Insert(0, Pop());
			}
			return args;
		}

		#endregion
	}
}
