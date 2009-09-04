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
using DotWeb.Translator.CodeModel;
using System.Reflection;

namespace DotWeb.Translator
{
	public class CodeTypeEvaluator : ICodeExpressionVisitor<Type>
	{
		private MethodBase method;

		public CodeTypeEvaluator(MethodBase method) {
			this.method = method;
		}

		public Type Evaluate(CodeExpression exp) {
			return exp.Accept<CodeTypeEvaluator, Type>(this);
		}

		public Type VisitReturn(CodeArrayCreateExpression obj) {
			return obj.Type;
		}

		public Type VisitReturn(CodeArrayIndexerExpression obj) {
			Type arrayType = Evaluate(obj.TargetObject);
			return arrayType.GetElementType();
		}

		public Type VisitReturn(CodeBinaryExpression obj) {
			// FIXME: find 'highest' type of each side
			return Evaluate(obj.Left);
		}

		public Type VisitReturn(CodeCastExpression obj) {
			return obj.TargetType;
		}

		public Type VisitReturn(CodeInstanceOfExpression obj) {
			return obj.TargetType;
		}

		public Type VisitReturn(CodeIndexerExpression obj) {
			// FIXME: resolve this to an actual method
			throw new NotImplementedException();
		}

		public Type VisitReturn(CodeInvokeExpression obj) {
			return VisitMethod(obj.Method.Info);
		}

		public Type VisitReturn(CodeObjectCreateExpression obj) {
			return obj.Type;
		}

		public Type VisitReturn(CodeParameterDeclarationExpression obj) {
			return obj.Info.ParameterType;
		}

		public Type VisitReturn(CodePrimitiveExpression obj) {
			return obj.Value.GetType();
		}

		public Type VisitReturn(CodeTypeReference obj) {
			return obj.Type;
		}

		public Type VisitReturn(CodeUnaryExpression obj) {
			return Evaluate(obj.Expression);
		}

		public Type VisitReturn(CodeArgumentReference obj) {
			return obj.Argument.ParameterType;
		}

		public Type VisitReturn(CodeFieldReference obj) {
			return obj.Field.FieldType;
		}

		public Type VisitReturn(CodeLengthReference obj) {
			return typeof(int);
		}

		public Type VisitReturn(CodeMethodReference obj) {
			return VisitMethod(obj.Info);
		}

		public Type VisitReturn(CodePropertyReference obj) {
			return obj.Property.PropertyType;
		}

		public Type VisitReturn(CodeThisReference obj) {
			return this.method.DeclaringType;
		}

		public Type VisitReturn(CodeVariableReference obj) {
			LocalVariableInfo local = this.method.GetMethodBody().LocalVariables.Single(x => x.LocalIndex == obj.Index);
			return local.LocalType;
		}

		private Type VisitMethod(MethodBase method) {
			if (method.IsConstructor)
				return method.DeclaringType;
			MethodInfo mi = method as MethodInfo;
			return mi.ReturnType;
		}

	}
}
