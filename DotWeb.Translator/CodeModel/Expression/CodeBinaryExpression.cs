using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public enum CodeBinaryOperator
	{
		// Summary:
		//     Addition operator.
		Add = 0,
		//
		// Summary:
		//     Subtraction operator.
		Subtract = 1,
		//
		// Summary:
		//     Multiplication operator.
		Multiply = 2,
		//
		// Summary:
		//     Division operator.
		Divide = 3,
		//
		// Summary:
		//     Modulus operator.
		Modulus = 4,
		//
		// Summary:
		//     Assignment operator.
		Assign = 5,
		//
		// Summary:
		//     Identity not equal operator.
		IdentityInequality = 6,
		//
		// Summary:
		//     Identity equal operator.
		IdentityEquality = 7,
		//
		// Summary:
		//     Value equal operator.
		ValueEquality = 8,
		//
		// Summary:
		//     Bitwise or operator.
		BitwiseOr = 9,
		//
		// Summary:
		//     Bitwise and operator.
		BitwiseAnd = 10,
		//
		// Summary:
		//     Boolean or operator. This represents a short circuiting operator. A short
		//     circuiting operator will evaluate only as many expressions as necessary before
		//     returning a correct value.
		BooleanOr = 11,
		//
		// Summary:
		//     Boolean and operator. This represents a short circuiting operator. A short
		//     circuiting operator will evaluate only as many expressions as necessary before
		//     returning a correct value.
		BooleanAnd = 12,
		//
		// Summary:
		//     Less than operator.
		LessThan = 13,
		//
		// Summary:
		//     Less than or equal operator.
		LessThanOrEqual = 14,
		//
		// Summary:
		//     Greater than operator.
		GreaterThan = 15,
		//
		// Summary:
		//     Greater than or equal operator.
		GreaterThanOrEqual = 16,
		LeftShift,
		RightShift,
		UnsignedRightShift,
		ExclusiveOr
	}

	public class CodeBinaryExpression : CodeExpression
	{
		public CodeBinaryExpression(CodeExpression lhs, CodeBinaryOperator op, CodeExpression rhs) {
			Left = lhs;
			Operator = op;
			Right = rhs;
		}

		#region Visitor Pattern
		public override void Accept<V>(V visitor) {
			((ICodeVisitor<CodeBinaryExpression>)visitor).Visit(this);
		}

		public override R Accept<V, R>(V visitor) {
			return ((ICodeVisitor<CodeBinaryExpression, R>)visitor).VisitReturn(this);
		}
		#endregion

		public CodeExpression Left { get; set; }
		public CodeBinaryOperator Operator { get; set; }
		public CodeExpression Right { get; set; }

		public override CodeExpression Invert() {
			switch (Operator) {
				case CodeBinaryOperator.BitwiseAnd:
				case CodeBinaryOperator.BitwiseOr:
				case CodeBinaryOperator.Add:
				case CodeBinaryOperator.Subtract:
				case CodeBinaryOperator.Multiply:
				case CodeBinaryOperator.Divide:
				case CodeBinaryOperator.Modulus:
				case CodeBinaryOperator.ExclusiveOr:
				case CodeBinaryOperator.LeftShift:
				case CodeBinaryOperator.RightShift:
				case CodeBinaryOperator.UnsignedRightShift:
					return new CodeUnaryExpression(this, CodeUnaryOperator.Not);
				case CodeBinaryOperator.BooleanAnd:
					return new CodeBinaryExpression(Left.Invert(), CodeBinaryOperator.BooleanOr, Right.Invert());
				case CodeBinaryOperator.BooleanOr:
					return new CodeBinaryExpression(Left.Invert(), CodeBinaryOperator.BooleanAnd, Right.Invert());
				case CodeBinaryOperator.GreaterThan:
					return new CodeBinaryExpression(Left, CodeBinaryOperator.LessThanOrEqual, Right);
				case CodeBinaryOperator.GreaterThanOrEqual:
					return new CodeBinaryExpression(Left, CodeBinaryOperator.LessThan, Right);
				case CodeBinaryOperator.LessThan:
					return new CodeBinaryExpression(Left, CodeBinaryOperator.GreaterThanOrEqual, Right);
				case CodeBinaryOperator.LessThanOrEqual:
					return new CodeBinaryExpression(Left, CodeBinaryOperator.GreaterThan, Right);
				case CodeBinaryOperator.IdentityEquality:
					return new CodeBinaryExpression(Left, CodeBinaryOperator.IdentityInequality, Right);
				case CodeBinaryOperator.IdentityInequality:
					return new CodeBinaryExpression(Left, CodeBinaryOperator.IdentityEquality, Right);
				case CodeBinaryOperator.ValueEquality:
				case CodeBinaryOperator.Assign:
					throw new NotImplementedException();
				default:
					return this;
			}
		}
	}
}
