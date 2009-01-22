using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.InteropServices;
using H8.CodeModel;

namespace H8
{
	public class CodeModelVirtualMachine
	{
		public List<MethodBase> ExternalMethods { get; private set; }
		public Stack<CodeExpression> Stack { get; private set; }
		public CodeModelVirtualMachine() {
			Stack = new Stack<CodeExpression>();
			ExternalMethods = new List<MethodBase>();
		}
	}

	class CodeModelGenerator
	{
		public List<CodeStatement> Statements { get; private set; }
		private CodeModelVirtualMachine vm;

		public CodeModelGenerator(CodeModelVirtualMachine vm, List<ILInstruction> instructions) {
			this.vm = vm;
			Statements = new List<CodeStatement>();
			foreach (ILInstruction il in instructions) {
				HandleInstruction(il);
			}
		}

		private void HandleInstruction(ILInstruction il) {
			switch (il.PrimitiveName) {
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

		private void AddStatment(CodeStatement stmt, ILInstruction il) {
			stmt.Instruction = il;
			this.Statements.Add(stmt);
		}

		private void Pop(ILInstruction il) {
			CodeExpression exp = vm.Stack.Pop();
			if (exp is CodeObjectCreateExpression) {
				AddStatment(new CodeExpressionStatement(exp), il);
			}
		}

		private void Nop(ILInstruction il) {
			CodeCommentStatement stmt = new CodeCommentStatement("nop");
			this.AddStatment(stmt, il);
		}

		private void Return(ILInstruction il) {
			CodeReturnStatement ret = new CodeReturnStatement();
			if (vm.Stack.Any())
				ret.Expression = vm.Stack.Pop();
			AddStatment(ret, il);
		}

		private CodeExpression GetTargetObject(MethodBase method, ILInstruction il) {
			CodeExpression targetObject;
			if (method.IsStatic) {
				targetObject = new CodeTypeReference(method.ReflectedType);
				targetObject.Instruction = il;
			}
			else {
				targetObject = vm.Stack.Pop();
			}
			return targetObject;
		}

		private void CallMethod(ILInstruction il, MethodBase method) {
			CodeInvokeExpression expr = new CodeInvokeExpression();
			expr.Instruction = il;
			CollectArgs(method.GetParameters(), expr.Parameters);

			CodeExpression targetObject = GetTargetObject(method, il);
			expr.Method = new CodeMethodReference(targetObject, method);
			expr.Method.Instruction = il;
			this.vm.ExternalMethods.AddUnique(method);

			MethodInfo mi = method as MethodInfo;
			if (method.IsConstructor || (mi != null && mi.ReturnType == typeof(void))) {
				CodeExpressionStatement stmt = new CodeExpressionStatement(expr);
				AddStatment(stmt, il);
			}
			else {
				vm.Stack.Push(expr);
			}
		}

		private void CallGetter(ILInstruction il, MethodBase method) {
			ParameterInfo[] args = method.GetParameters();
			if (args.Length == 0) {
				string propName = method.Name.Substring("get_".Length);
				PropertyInfo pi = method.DeclaringType.GetProperty(propName);
				CodeExpression targetObject = GetTargetObject(method, il);
				CodePropertyReference expr = new CodePropertyReference(targetObject, pi);
				expr.Instruction = il;
				vm.Stack.Push(expr);
			}
			else {
				CodeIndexerExpression expr = new CodeIndexerExpression();
				expr.Instruction = il;
				CollectArgs(args, expr.Indices);
				expr.TargetObject = GetTargetObject(method, il);
				vm.Stack.Push(expr);
			}
		}

		private void CallSetter(ILInstruction il, MethodBase method) {
			ParameterInfo[] args = method.GetParameters();
			if (args.Length == 1) {
				string propName = method.Name.Substring("set_".Length);
				PropertyInfo pi = method.DeclaringType.GetProperty(propName);
				CodeExpression rhs = vm.Stack.Pop();
				CodeExpression targetObject = GetTargetObject(method, il);
				CodePropertyReference lhs = new CodePropertyReference(targetObject, pi);
				lhs.Instruction = il;
				CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
				AddStatment(stmt, il);
			}
			else {
				CodeIndexerExpression lhs = new CodeIndexerExpression();
				lhs.Instruction = il;
				CollectArgs(args, lhs.Indices);
				CodeExpression rhs = lhs.Indices[lhs.Indices.Count - 1];
				lhs.Indices.Remove(rhs);
				lhs.TargetObject = GetTargetObject(method, il);
				CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
				AddStatment(stmt, il);
			}
		}

		private void Call(ILInstruction il) {
			MethodBase method = il.Operand as MethodBase;
			if (method.IsSpecialName) {
				if (method.Name.StartsWith("get_")) {
					CallGetter(il, method);
					return;
				}
				else if (method.Name.StartsWith("set_")) {
					CallSetter(il, method);
					return;
				}
			}
			CallMethod(il, method);
		}

		private void Convert(ILInstruction il) {
			CodeExpression value = vm.Stack.Pop();
			Type targetType = (Type)il.Operand;
			CodeCastExpression expr = new CodeCastExpression(targetType, value);
			expr.Instruction = il;
			vm.Stack.Push(value);
		}

		private void LoadArgument(ILInstruction il) {
			MethodBase method = il.Method;
			int index = (int)il.Operand;
			if (!method.IsStatic) {
				if (index == 0) {
					CodeExpression thisExp = new CodeThisReference();
					thisExp.Instruction = il;
					vm.Stack.Push(thisExp);
					return;
				}
				index--;
			}

			ParameterInfo[] args = method.GetParameters();
			ParameterInfo arg = args[index];
			CodeExpression expr = new CodeArgumentReference(arg);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void LoadMethod(ILInstruction il) {
			MethodBase method = il.Operand as MethodBase;
			CodeTypeReference type = new CodeTypeReference(method.DeclaringType);
			type.Instruction = il;
			CodeMethodReference expr = new CodeMethodReference(type, method);
			this.vm.ExternalMethods.AddUnique(method);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void LoadField(ILInstruction il) {
			FieldInfo field = il.Operand as FieldInfo;
			CodeExpression targetObject = vm.Stack.Pop();
			CodeFieldReference expr = new CodeFieldReference(targetObject, field);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void LoadStaticField(ILInstruction il) {
			FieldInfo field = il.Operand as FieldInfo;
			CodeTypeReference typeRef = new CodeTypeReference(field.DeclaringType);
			typeRef.Instruction = il;
			CodeFieldReference expr = new CodeFieldReference(typeRef, field);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void LoadLocal(ILInstruction il) {
			int index = (int)il.Operand;
			CodeVariableReference expr = new CodeVariableReference {
				Index = index
			};
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void LoadLocalAddress(ILInstruction il) {
			int index = (int)il.Operand;
			CodeVariableReference expr = new CodeVariableReference {
				Index = index
			};
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void Load(ILInstruction il) {
			CodePrimitiveExpression expr = new CodePrimitiveExpression(il.Operand);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void LoadLength(ILInstruction il) {
			CodeExpression targetObject = vm.Stack.Pop() as CodeExpression;
			CodeLengthReference expr = new CodeLengthReference(targetObject);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void LoadElement(ILInstruction il) {
			CodeExpression index = vm.Stack.Pop();
			CodeExpression targetObject = vm.Stack.Pop();
			CodeArrayIndexerExpression expr = new CodeArrayIndexerExpression(targetObject, index);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private int[] StructAsInt32Array(object data) {
			int size = Marshal.SizeOf(data);
			int[] array = new int[size / sizeof(int)];
			for (int i = 0; i < array.Length; i++) {
				array[i] = Marshal.ReadInt32(data, i * sizeof(int));
			}
			return array;
		}

		private void LoadToken(ILInstruction il) {
			if (il.Operand is FieldInfo) {
				FieldInfo fi = (FieldInfo)il.Operand;
				if (fi.IsStatic) {
					// FIXME: filter this for only int[] initialization
					object value = fi.GetValue(null);
					int[] array = StructAsInt32Array(value);
					CodePrimitiveExpression expr = new CodePrimitiveExpression(array);
					expr.Instruction = il;
					vm.Stack.Push(expr);
					return;
				}
			}

			throw new NotImplementedException();
		}

		private void StoreElement(ILInstruction il) {
			CodeExpression value = vm.Stack.Pop();
			CodeExpression index = vm.Stack.Pop();
			CodeExpression array = vm.Stack.Pop();

			CodeArrayIndexerExpression lhs = new CodeArrayIndexerExpression(array, index);
			lhs.Instruction = il;
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, value);
			AddStatment(stmt, il);
		}

		private void StoreArgument(ILInstruction il) {
			MethodBase method = il.Method;
			int index = (int)il.Operand;

			if (!method.IsStatic) {
				index--;
			}

			ParameterInfo[] args = method.GetParameters();
			ParameterInfo arg = args[index];
			CodeArgumentReference lhs = new CodeArgumentReference(arg);
			lhs.Instruction = il;

			CodeExpression rhs = vm.Stack.Pop();
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
			AddStatment(stmt, il);
		}

		private void StoreLocal(ILInstruction il) {
			int index = (int)il.Operand;
			CodeVariableReference lhs = new CodeVariableReference {
				Index = index
			};
			lhs.Instruction = il;
			CodeExpression rhs = vm.Stack.Pop();
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
			AddStatment(stmt, il);
		}

		private void StoreField(ILInstruction il) {
			FieldInfo field = il.Operand as FieldInfo;
			CodeExpression rhs = vm.Stack.Pop();
			CodeExpression targetObject = vm.Stack.Pop();
			CodeFieldReference lhs = new CodeFieldReference(targetObject, field);
			lhs.Instruction = il;
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
			AddStatment(stmt, il);
		}

		private void StoreStaticField(ILInstruction il) {
			FieldInfo field = il.Operand as FieldInfo;
			CodeTypeReference typeRef = new CodeTypeReference(field.DeclaringType);
			typeRef.Instruction = il;
			CodeFieldReference lhs = new CodeFieldReference(typeRef, field);
			lhs.Instruction = il;
			CodeExpression rhs = vm.Stack.Pop();
			CodeAssignStatement stmt = new CodeAssignStatement(lhs, rhs);
			AddStatment(stmt, il);
		}

		private void BinaryExpression(ILInstruction il, CodeBinaryOperator op) {
			CodeExpression rhs = vm.Stack.Pop();
			CodeExpression lhs = vm.Stack.Pop();
			CodeBinaryExpression expr = new CodeBinaryExpression(lhs, op, rhs);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void UnaryExpression(ILInstruction il, CodeUnaryOperator op) {
			CodeExpression operand = vm.Stack.Pop();
			CodeUnaryExpression expr = new CodeUnaryExpression(operand, op);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void Comparision(ILInstruction il, CodeBinaryOperator op) {
			CodeExpression rhs = vm.Stack.Pop();
			CodeExpression lhs = vm.Stack.Pop();
			CodeBinaryExpression expr = new CodeBinaryExpression(lhs, op, rhs);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void ConditionalBranch(ILInstruction il, CodeBinaryOperator op) {
			CodeExpression rhs = vm.Stack.Pop();
			CodeExpression lhs = vm.Stack.Pop();
			CodeBinaryExpression condition = new CodeBinaryExpression(lhs, op, rhs);
			condition.Instruction = il;
			CodeExpressionStatement stmt = new CodeExpressionStatement(condition);
			AddStatment(stmt, il);
		}

		private void ConditionalBranch(ILInstruction il, bool test) {
			CodePrimitiveExpression rhs = new CodePrimitiveExpression(test);
			rhs.Instruction = il;
			CodeExpression lhs = vm.Stack.Pop();
			CodeBinaryExpression condition = new CodeBinaryExpression(
				lhs, CodeBinaryOperator.IdentityEquality, rhs);
			condition.Instruction = il;
			CodeExpressionStatement stmt = new CodeExpressionStatement(condition);
			AddStatment(stmt, il);
		}

		private void Branch(ILInstruction il) {
			CodeGotoStatement stmt = new CodeGotoStatement(il.Operand.ToString());
			AddStatment(stmt, il);
		}

		private void NewArray(ILInstruction il) {
			CodeExpression count = vm.Stack.Pop();
			Type type = (Type)il.Operand;
			CodeArrayCreateExpression expr = new CodeArrayCreateExpression {
				SizeExpression = count,
				Type = type
			};
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void CollectArgs(ParameterInfo[] infos, List<CodeExpression> into) {
			List<CodeExpression> args = new List<CodeExpression>();
			for (int i = 0; i < infos.Length; i++) {
				args.Add(vm.Stack.Pop());
			}
			args.Reverse();
			into.AddRange(args.ToArray());
		}

		private void NewObject(ILInstruction il) {
			ConstructorInfo ctor = (ConstructorInfo)il.Operand;

			CodeObjectCreateExpression expr = new CodeObjectCreateExpression {
				Instruction = il,
				Constructor = ctor
			};
//			expr.CreateType = new CodeTypeReference(ctor.ReflectedType);
			CollectArgs(ctor.GetParameters(), expr.Parameters);

			vm.Stack.Push(expr);
		}

		private void Dup(ILInstruction il) {
			CodeExpression exp = vm.Stack.Peek();
			vm.Stack.Push(exp);
		}

		private void Leave(ILInstruction il) {
			CodeGotoStatement stmt = new CodeGotoStatement(il.Operand.ToString());
			AddStatment(stmt, il);
		}

		private void CastClass(ILInstruction il) {
			CodeExpression obj = vm.Stack.Pop();
			Type type = (Type)il.Operand;
			CodeExpression expr = new CodeCastExpression(type, obj);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}

		private void Throw(ILInstruction il) {
			CodeExpression obj = vm.Stack.Pop();
			CodeThrowStatement stmt = new CodeThrowStatement(obj);
			AddStatment(stmt, il);
		}

		private void Switch(ILInstruction il) {
			CodeExpression expr = vm.Stack.Pop();
			CodeSwitchStatement stmt = new CodeSwitchStatement {
				Expression = expr
			};
			AddStatment(stmt, il);
		}

		private void IsInstance(ILInstruction il) {
			CodeExpression obj = vm.Stack.Pop();
			Type type = (Type)il.Operand;
			CodeExpression expr = new CodeInstanceOfExpression(type, obj);
			expr.Instruction = il;
			vm.Stack.Push(expr);
		}
	}
}
