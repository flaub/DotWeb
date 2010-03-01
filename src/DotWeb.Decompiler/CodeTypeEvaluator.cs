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
using DotWeb.Decompiler.CodeModel;
using Mono.Cecil;
using System.Diagnostics;
using DotWeb.Utility.Cecil;

namespace DotWeb.Decompiler
{
	public class CodeTypeEvaluator : ICodeExpressionVisitor<TypeReference>
	{
		private readonly TypeSystem typeSystem;
		private readonly MethodDefinition context;

		public CodeTypeEvaluator(TypeSystem typeSystem, MethodDefinition method) {
			this.typeSystem = typeSystem;
			this.context = method;
		}

		public TypeReference Evaluate(CodeExpression exp) {
			return exp.Accept<CodeTypeEvaluator, TypeReference>(this);
		}

		public TypeReference VisitReturn(CodeArrayCreateExpression obj) {
			return new ArrayType(obj.Type);
		}

		public TypeReference VisitReturn(CodeArrayIndexerExpression obj) {
			ArrayType arrayType = (ArrayType)Evaluate(obj.TargetObject);
			return arrayType.ElementType;
		}

		public TypeReference VisitReturn(CodeBinaryExpression obj) {
			switch (obj.Operator) {
				case CodeBinaryOperator.BooleanAnd:
				case CodeBinaryOperator.BooleanOr:
				case CodeBinaryOperator.GreaterThan:
				case CodeBinaryOperator.GreaterThanOrEqual:
				case CodeBinaryOperator.IdentityEquality:
				case CodeBinaryOperator.IdentityInequality:
				case CodeBinaryOperator.LessThan:
				case CodeBinaryOperator.LessThanOrEqual:
				case CodeBinaryOperator.ValueEquality:
					return this.typeSystem.TypeDefinitionCache.Boolean;
				case CodeBinaryOperator.Add:
				case CodeBinaryOperator.BitwiseAnd:
				case CodeBinaryOperator.BitwiseOr:
				case CodeBinaryOperator.Divide:
				case CodeBinaryOperator.ExclusiveOr:
				case CodeBinaryOperator.LeftShift:
				case CodeBinaryOperator.Modulus:
				case CodeBinaryOperator.Multiply:
				case CodeBinaryOperator.RightShift:
				case CodeBinaryOperator.Subtract:
				case CodeBinaryOperator.UnsignedRightShift:
					// FIXME: find 'highest' type of each side
					return Evaluate(obj.Left);
				default:
					throw new NotSupportedException();
			}
		}

		public TypeReference VisitReturn(CodeCastExpression obj) {
			return obj.TargetType;
		}

		public TypeReference VisitReturn(CodeInstanceOfExpression obj) {
			return obj.TargetType;
		}

		public TypeReference VisitReturn(CodeIndexerExpression obj) {
			return obj.Property.PropertyType;
		}

		public TypeReference VisitReturn(CodeInvokeExpression obj) {
			return VisitMethod(obj.Method.Reference);
		}

		public TypeReference VisitReturn(CodeObjectCreateExpression obj) {
			return obj.Type;
		}

		public TypeReference VisitReturn(CodeParameterDeclarationExpression obj) {
			return obj.Definition.ParameterType;
		}

		public TypeReference VisitReturn(CodePrimitiveExpression obj) {
			var primitiveType = obj.Value.GetType();
			var ret = this.typeSystem.GetTypeDefinition(primitiveType);
			return ret;
		}

		public TypeReference VisitReturn(CodeTypeReference obj) {
			return obj.Type;
		}

		public TypeReference VisitReturn(CodeUnaryExpression obj) {
			return Evaluate(obj.Expression);
		}

		public TypeReference VisitReturn(CodeArgumentReference obj) {
			return obj.Argument.ParameterType;
		}

		public TypeReference VisitReturn(CodeFieldReference obj) {
			return obj.Field.FieldType;
		}

		public TypeReference VisitReturn(CodeLengthReference obj) {
			throw new NotSupportedException();
		}

		public TypeReference VisitReturn(CodeMethodReference obj) {
			return VisitMethod(obj.Reference);
		}

		public TypeReference VisitReturn(CodePropertyReference obj) {
			return obj.Property.PropertyType;
		}

		public TypeReference VisitReturn(CodeThisReference obj) {
			return this.context.DeclaringType;
		}

		public TypeReference VisitReturn(CodeBaseReference obj) {
			return this.context.DeclaringType.BaseType;
		}

		public TypeReference VisitReturn(CodeVariableReference obj) {
			return obj.Variable.VariableType;
		}

		private TypeReference VisitMethod(MethodReference method) {
			var def = method.Resolve();
			if (def.IsConstructor)
				return method.DeclaringType;
			return def.ReturnType.ReturnType;
		}

		public TypeReference VisitReturn(CodeArrayInitializeExpression obj) {
			return new ArrayType(obj.ElementType);
		}
	}
}
