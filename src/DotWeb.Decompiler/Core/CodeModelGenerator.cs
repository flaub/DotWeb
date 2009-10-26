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

namespace DotWeb.Decompiler.Core
{
	class CodeModelGenerator
	{
		private readonly CodeModelVirtualMachine vm;
		private readonly MethodDefinition method;

		public List<CodeStatement> Statements { get; private set; }

		public CodeModelGenerator(MethodDefinition method, CodeModelVirtualMachine vm, IEnumerable<Instruction> instructions) {
			this.method = method;
			this.vm = vm;
			Statements = new List<CodeStatement>();
			foreach (var il in instructions) {
				HandleInstruction(il);
			}
		}

		private void HandleInstruction(Instruction il) {
			switch (il.PrimitiveName()) {
				#region Load
				case "ldc":
				case "ldstr":
				case "ldnull":
					Load(il);
					break;
				case "ldloc":
					LoadLocal(il);
					break;
				case "ldloca":
					LoadLocalAddress(il);
					break;
				case "ldtoken":
					LoadToken(il);
					break;
				case "ldelem":
					LoadElement(il);
					break;
				case "ldlen":
					LoadLength(il);
					break;
				case "ldarg":
					LoadArgument(il);
					break;
				case "ldfld":
					LoadField(il);
					break;
				case "ldsfld":
					LoadStaticField(il);
					break;
				case "ldsflda":
					LoadStaticFieldAddress(il);
					break;
				case "ldftn":
					LoadMethod(il);
					break;
				#endregion
				#region Store
				case "stloc":
					StoreLocal(il);
					break;
				case "stelem":
					StoreElement(il);
					break;
				case "starg":
					StoreArgument(il);
					break;
				case "stfld":
					StoreField(il);
					break;
				case "stsfld":
					StoreStaticField(il);
					break;
				#endregion
				#region New
				case "newarr":
					NewArray(il);
					break;
				case "newobj":
					NewObject(il);
					break;
				#endregion
				#region Binary Expressions
				case "mul":
					BinaryExpression(il, CodeBinaryOperator.Multiply);
					break;
				case "add":
					BinaryExpression(il, CodeBinaryOperator.Add);
					break;
				case "sub":
					BinaryExpression(il, CodeBinaryOperator.Subtract);
					break;
				case "rem":
					BinaryExpression(il, CodeBinaryOperator.Modulus);
					break;
				case "div":
					BinaryExpression(il, CodeBinaryOperator.Divide);
					break;
				case "and":
					BinaryExpression(il, CodeBinaryOperator.BitwiseAnd);
					break;
				case "or":
					BinaryExpression(il, CodeBinaryOperator.BitwiseOr);
					break;
				case "xor":
					BinaryExpression(il, CodeBinaryOperator.ExclusiveOr);
					break;
				case "shl":
					BinaryExpression(il, CodeBinaryOperator.LeftShift);
					break;
				case "shr":
					BinaryExpression(il, CodeBinaryOperator.RightShift);
					break;
				#endregion
				#region Unary Expressions
				case "not":
					UnaryExpression(il, CodeUnaryOperator.Not);
					break;
				case "neg":
					UnaryExpression(il, CodeUnaryOperator.Negate);
					break;
				#endregion
				#region Branch
				case "beq":
					ConditionalBranch(il, CodeBinaryOperator.IdentityEquality);
					break;
				case "bge":
					ConditionalBranch(il, CodeBinaryOperator.GreaterThanOrEqual);
					break;
				case "bgt":
					ConditionalBranch(il, CodeBinaryOperator.GreaterThan);
					break;
				case "blt":
					ConditionalBranch(il, CodeBinaryOperator.LessThan);
					break;
				case "ble":
					ConditionalBranch(il, CodeBinaryOperator.LessThanOrEqual);
					break;
				case "bne":
					ConditionalBranch(il, CodeBinaryOperator.IdentityInequality);
					break;
				case "brtrue":
					ConditionalBranch(il, true);
					break;
				case "brfalse":
					ConditionalBranch(il, false);
					break;
				case "br":
					Branch(il);
					break;
				case "switch":
					Switch(il);
					break;
				#endregion
				#region Comparision
				case "clt":
					Comparision(il, CodeBinaryOperator.LessThan);
					break;
				case "cgt":
					Comparision(il, CodeBinaryOperator.GreaterThan);
					break;
				case "ceq":
					Comparision(il, CodeBinaryOperator.IdentityEquality);
					break;
				#endregion
				#region Call
				case "call":
				case "callvirt":
					Call(il);
					break;
				case "calli":
					throw new NotImplementedException();
				case "ret":
					Return(il);
					break;
				#endregion
				#region Misc
				case "pop":
					Pop(il);
					break;
				case "dup":
					Dup(il);
					break;
				case "conv":
					Convert(il);
					break;
				case "leave":
					Leave(il);
					break;
				case "nop":
					Nop(il);
					break;
				case "castclass":
					CastClass(il);
					break;
				case "throw":
					Throw(il);
					break;
				case "isinst":
					IsInstance(il);
					break;
				case "break":
					throw new NotImplementedException();
				#endregion
				#region Unsupported/Unneeded
				case "box":
				case "unbox":
					break;
				#endregion
				default:
					throw new NotImplementedException();
			}
		}

		private void AddStatment(CodeStatement stmt, Instruction il) {
			this.Statements.Add(stmt);
		}

		private void Pop(Instruction il) {
			CodeExpression exp = vm.Stack.Pop();
			if (exp is CodeObjectCreateExpression ||
				exp is CodeInvokeExpression) {
				AddStatment(new CodeExpressionStatement(exp), il);
			}
			else {
				throw new NotSupportedException(exp.ToString());
			}
		}

		private void Nop(Instruction il) {
			CodeCommentStatement stmt = new CodeCommentStatement("nop");
			this.AddStatment(stmt, il);
		}

		private void Return(Instruction il) {
			CodeReturnStatement ret = new CodeReturnStatement();
			if (vm.Stack.Any())
				ret.Expression = vm.Stack.Pop();
			AddStatment(ret, il);
		}

		private CodeExpression GetTargetObject(MethodDefinition method, Instruction il) {
			CodeExpression targetObject;
			if (method.IsStatic) {
				targetObject = new CodeTypeReference(method.DeclaringType);
			}
			else {
				targetObject = vm.Stack.Pop();
			}
			return targetObject;
		}

		private void CallMethod(Instruction il, MethodDefinition method) {
			CodeInvokeExpression expr = new CodeInvokeExpression();
			CollectArgs(method.Parameters, expr.Parameters);

			CodeExpression targetObject = GetTargetObject(method, il);
			expr.Method = new CodeMethodReference(targetObject, method);

			if (method.IsConstructor || method.ReturnType.ReturnType.FullName == Constants.Void) {
				CodeExpressionStatement stmt = new CodeExpressionStatement(expr);
				AddStatment(stmt, il);
			}
			else {
				vm.Stack.Push(expr);
			}
		}

		private void CallGetter(Instruction il, MethodDefinition method, PropertyReference pi) {
			var args = method.Parameters;
			if (args.Count == 0) {
				var targetObject = GetTargetObject(method, il);
				CodeMethodReference methodRef = new CodeMethodReference(targetObject, method);
				CodePropertyReference expr = new CodePropertyReference(methodRef, pi, CodePropertyReference.RefType.Get);
				vm.Stack.Push(expr);
			}
			else {
				CodeIndexerExpression expr = new CodeIndexerExpression();
				CollectArgs(args, expr.Indices);
				expr.TargetObject = GetTargetObject(method, il);
				vm.Stack.Push(expr);
			}
		}

		private void CallSetter(Instruction il, MethodDefinition method, PropertyReference pi) {
			var args = method.Parameters;
			if (args.Count == 1) {
				CodeExpression rhs = vm.Stack.Pop();
				var targetObject = GetTargetObject(method, il);
				CodeMethodReference methodRef = new CodeMethodReference(targetObject, method);
				CodePropertyReference lhs = new CodePropertyReference(methodRef, pi, CodePropertyReference.RefType.Set);
	
				CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
				AddStatment(stmt, il);
			}
			else {
				CodeIndexerExpression lhs = new CodeIndexerExpression();
				CollectArgs(args, lhs.Indices);
				CodeExpression rhs = lhs.Indices[lhs.Indices.Count - 1];
				lhs.Indices.Remove(rhs);
				lhs.TargetObject = GetTargetObject(method, il);
				CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
				AddStatment(stmt, il);
			}
		}

		private void Call(Instruction il) {
			var method = (MethodReference)il.Operand;
			var def = method.Resolve();
			this.vm.ExternalMethods.Add(method);

			var ap = def.GetAssociatedProperty();
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
				CallMethod(il, def);
			}
		}

		private void Convert(Instruction il) {
			CodeExpression value = vm.Stack.Pop();
			var targetType = (TypeReference)il.Operand;
			CodeCastExpression expr = new CodeCastExpression(targetType, value);
			vm.Stack.Push(value);
		}

		private void LoadArgument(Instruction il) {
			int index = (int)il.ResolveOperand();
			if (!this.method.IsStatic) {
				if (index == 0) {
					CodeExpression thisExp = new CodeThisReference();
					vm.Stack.Push(thisExp);
					return;
				}
				index--;
			}

			var args = method.Parameters;
			var arg = args[index];
			CodeExpression expr = new CodeArgumentReference(arg);
			vm.Stack.Push(expr);
		}

		private void LoadMethod(Instruction il) {
			var method = (MethodReference)il.Operand;
			CodeTypeReference type = new CodeTypeReference(method.DeclaringType);
			CodeMethodReference expr = new CodeMethodReference(type, method);
			this.vm.ExternalMethods.Add(method);
			vm.Stack.Push(expr);
		}

		private void LoadField(Instruction il) {
			var field = (FieldReference)il.Operand;
			CodeExpression targetObject = vm.Stack.Pop();
			CodeFieldReference expr = new CodeFieldReference(targetObject, field);
			vm.Stack.Push(expr);
		}

		private void LoadStaticField(Instruction il) {
			var field = (FieldReference)il.Operand;
			CodeTypeReference typeRef = new CodeTypeReference(field.DeclaringType);
			CodeFieldReference expr = new CodeFieldReference(typeRef, field);
			vm.Stack.Push(expr);
		}

		private void LoadStaticFieldAddress(Instruction il) {
			LoadStaticField(il);
		}

		private void LoadLocal(Instruction il) {
			int index = (int)il.ResolveOperand();
			CodeVariableReference expr = new CodeVariableReference {
				Index = index
			};
			vm.Stack.Push(expr);
		}

		private void LoadLocalAddress(Instruction il) {
			int index = (int)il.ResolveOperand();
			CodeVariableReference expr = new CodeVariableReference {
				Index = index
			};
			vm.Stack.Push(expr);
		}

		private void Load(Instruction il) {
			CodePrimitiveExpression expr = new CodePrimitiveExpression(il.ResolveOperand());
			vm.Stack.Push(expr);
		}

		private void LoadLength(Instruction il) {
			CodeExpression targetObject = vm.Stack.Pop() as CodeExpression;
			CodeLengthReference expr = new CodeLengthReference(targetObject);
			vm.Stack.Push(expr);
		}

		private void LoadElement(Instruction il) {
			CodeExpression index = vm.Stack.Pop();
			CodeExpression targetObject = vm.Stack.Pop();
			CodeArrayIndexerExpression expr = new CodeArrayIndexerExpression(targetObject, index);
			vm.Stack.Push(expr);
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
					vm.Stack.Push(expr);
					return;
				}
			}

			throw new NotImplementedException();
		}

		private void StoreElement(Instruction il) {
			CodeExpression value = vm.Stack.Pop();
			CodeExpression index = vm.Stack.Pop();
			CodeExpression array = vm.Stack.Pop();

			CodeArrayIndexerExpression lhs = new CodeArrayIndexerExpression(array, index);
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, value);
			AddStatment(stmt, il);
		}

		private void StoreArgument(Instruction il) {
			int index = (int)il.ResolveOperand();

			if (!this.method.IsStatic) {
				index--;
			}

			var args = method.Parameters;
			var arg = args[index];
			CodeArgumentReference lhs = new CodeArgumentReference(arg);

			CodeExpression rhs = vm.Stack.Pop();
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
			AddStatment(stmt, il);
		}

		private void StoreLocal(Instruction il) {
			int index = (int)il.ResolveOperand();
			CodeVariableReference lhs = new CodeVariableReference {
				Index = index
			};
			CodeExpression rhs = vm.Stack.Pop();
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
			AddStatment(stmt, il);
		}

		private void StoreField(Instruction il) {
			var field = (FieldReference)il.Operand;
			CodeExpression rhs = vm.Stack.Pop();
			CodeExpression targetObject = vm.Stack.Pop();
			CodeFieldReference lhs = new CodeFieldReference(targetObject, field);
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
			AddStatment(stmt, il);
		}

		private void StoreStaticField(Instruction il) {
			var field = (FieldReference)il.Operand;
			CodeTypeReference typeRef = new CodeTypeReference(field.DeclaringType);
			CodeFieldReference lhs = new CodeFieldReference(typeRef, field);
			CodeExpression rhs = vm.Stack.Pop();
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
			AddStatment(stmt, il);
		}

		private void BinaryExpression(Instruction il, CodeBinaryOperator op) {
			CodeExpression rhs = vm.Stack.Pop();
			CodeExpression lhs = vm.Stack.Pop();
			CodeBinaryExpression expr = new CodeBinaryExpression(lhs, op, rhs);
			vm.Stack.Push(expr);
		}

		private void UnaryExpression(Instruction il, CodeUnaryOperator op) {
			CodeExpression operand = vm.Stack.Pop();
			CodeUnaryExpression expr = new CodeUnaryExpression(operand, op);
			vm.Stack.Push(expr);
		}

		private void Comparision(Instruction il, CodeBinaryOperator op) {
			CodeExpression rhs = vm.Stack.Pop();
			CodeExpression lhs = vm.Stack.Pop();
			CodeBinaryExpression expr = new CodeBinaryExpression(lhs, op, rhs);
			vm.Stack.Push(expr);
		}

		private void ConditionalBranch(Instruction il, CodeBinaryOperator op) {
			CodeExpression rhs = vm.Stack.Pop();
			CodeExpression lhs = vm.Stack.Pop();
			CodeBinaryExpression condition = new CodeBinaryExpression(lhs, op, rhs);
			CodeExpressionStatement stmt = new CodeExpressionStatement(condition);
			AddStatment(stmt, il);
		}

		private void ConditionalBranch(Instruction il, bool test) {
			CodePrimitiveExpression rhs = new CodePrimitiveExpression(test);
			CodeExpression lhs = vm.Stack.Pop();
			CodeBinaryExpression condition = new CodeBinaryExpression(
				lhs, CodeBinaryOperator.IdentityEquality, rhs);
			CodeExpressionStatement stmt = new CodeExpressionStatement(condition);
			AddStatment(stmt, il);
		}

		private void Branch(Instruction il) {
			CodeGotoStatement stmt = new CodeGotoStatement((Instruction)il.Operand);
			AddStatment(stmt, il);
		}

		private void NewArray(Instruction il) {
			CodeExpression count = vm.Stack.Pop();
			var type = (TypeReference)il.Operand;
			CodeArrayCreateExpression expr = new CodeArrayCreateExpression {
				SizeExpression = count,
				Type = type
			};
			vm.Stack.Push(expr);
		}

		private void CollectArgs(ParameterDefinitionCollection defs, List<CodeExpression> into) {
			List<CodeExpression> args = new List<CodeExpression>();
			for (int i = 0; i < defs.Count; i++) {
				args.Add(vm.Stack.Pop());
			}
			args.Reverse();
			into.AddRange(args.ToArray());
		}

		private void NewObject(Instruction il) {
			var ctor = (MethodReference)il.Operand;
			this.vm.ExternalMethods.Add(ctor);

			CodeObjectCreateExpression expr = new CodeObjectCreateExpression {
				Constructor = ctor
			};
			CollectArgs(ctor.Parameters, expr.Parameters);

			vm.Stack.Push(expr);
		}

		private void Dup(Instruction il) {
			CodeExpression exp = vm.Stack.Peek();
			vm.Stack.Push(exp);
		}

		private void Leave(Instruction il) {
			Debug.Assert(false);
			CodeGotoStatement stmt = new CodeGotoStatement((Instruction)il.Operand);
			AddStatment(stmt, il);
		}

		private void CastClass(Instruction il) {
			CodeExpression obj = vm.Stack.Pop();
			var type = (TypeReference)il.Operand;
			CodeExpression expr = new CodeCastExpression(type, obj);
			vm.Stack.Push(expr);
		}

		private void Throw(Instruction il) {
			CodeExpression obj = vm.Stack.Pop();
			CodeThrowStatement stmt = new CodeThrowStatement(obj);
			AddStatment(stmt, il);
		}

		private void Switch(Instruction il) {
			CodeExpression expr = vm.Stack.Pop();
			CodeSwitchStatement stmt = new CodeSwitchStatement {
				Expression = expr
			};
			AddStatment(stmt, il);
		}

		private void IsInstance(Instruction il) {
			CodeExpression obj = vm.Stack.Pop();
			var type = (TypeReference)il.Operand;
			CodeExpression expr = new CodeInstanceOfExpression(type, obj);
			vm.Stack.Push(expr);
		}
	}
}
