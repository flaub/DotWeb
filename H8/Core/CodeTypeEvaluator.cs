using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H8.CodeModel;
using System.Reflection;

namespace H8
{
	class CodeTypeEvaluator : ICodeExpressionVisitor<Type>
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
			return Evaluate(obj.TargetObject);
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
