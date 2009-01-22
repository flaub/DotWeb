using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public interface ICodeExpressionVisitor
		: ICodeVisitor<CodeArrayCreateExpression>
		, ICodeVisitor<CodeArrayIndexerExpression>
		, ICodeVisitor<CodeBinaryExpression>
		, ICodeVisitor<CodeCastExpression>
		, ICodeVisitor<CodeInstanceOfExpression>
		, ICodeVisitor<CodeIndexerExpression>
		, ICodeVisitor<CodeInvokeExpression>
		, ICodeVisitor<CodeObjectCreateExpression>

		, ICodeVisitor<CodeParameterDeclarationExpression>
		, ICodeVisitor<CodePrimitiveExpression>
		, ICodeVisitor<CodeTypeReference>
		, ICodeVisitor<CodeUnaryExpression>
		, ICodeVisitor<CodeArgumentReference>
		, ICodeVisitor<CodeFieldReference>
		, ICodeVisitor<CodeLengthReference>
		, ICodeVisitor<CodeMethodReference>
		, ICodeVisitor<CodePropertyReference>
		, ICodeVisitor<CodeThisReference>
		, ICodeVisitor<CodeVariableReference>
	{
	}

	public interface ICodeExpressionVisitor<Return>
		: ICodeVisitor<CodeArrayCreateExpression, Return>
		, ICodeVisitor<CodeArrayIndexerExpression, Return>
		, ICodeVisitor<CodeBinaryExpression, Return>
		, ICodeVisitor<CodeCastExpression, Return>
		, ICodeVisitor<CodeInstanceOfExpression, Return>
		, ICodeVisitor<CodeIndexerExpression, Return>
		, ICodeVisitor<CodeInvokeExpression, Return>
		, ICodeVisitor<CodeObjectCreateExpression, Return>
		, ICodeVisitor<CodeParameterDeclarationExpression, Return>
		, ICodeVisitor<CodePrimitiveExpression, Return>
		, ICodeVisitor<CodeTypeReference, Return>
		, ICodeVisitor<CodeUnaryExpression, Return>

		, ICodeVisitor<CodeArgumentReference, Return>
		, ICodeVisitor<CodeFieldReference, Return>
		, ICodeVisitor<CodeLengthReference, Return>
		, ICodeVisitor<CodeMethodReference, Return>
		, ICodeVisitor<CodePropertyReference, Return>
		, ICodeVisitor<CodeThisReference, Return>
		, ICodeVisitor<CodeVariableReference, Return>
	{
	}
}
