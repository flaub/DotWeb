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

namespace DotWeb.Decompiler.CodeModel
{
	public interface ICodeExpressionVisitor
		: ICodeVisitor<CodeArrayCreateExpression>
		, ICodeVisitor<CodeArrayIndexerExpression>
		, ICodeVisitor<CodeArrayInitializeExpression>
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
		, ICodeVisitor<CodeBaseReference>
		, ICodeVisitor<CodeVariableReference>
	{
	}

	public interface ICodeExpressionVisitor<Return>
		: ICodeVisitor<CodeArrayCreateExpression, Return>
		, ICodeVisitor<CodeArrayIndexerExpression, Return>
		, ICodeVisitor<CodeArrayInitializeExpression, Return>
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
		, ICodeVisitor<CodeBaseReference, Return>
		, ICodeVisitor<CodeVariableReference, Return>
	{
	}
}
