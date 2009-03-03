using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public interface ICodeStatementVisitor
		: ICodeVisitor<CodeAssignStatement>
		, ICodeVisitor<CodeCommentStatement>
		, ICodeVisitor<CodeExpressionStatement>
		, ICodeVisitor<CodeIfStatement>
		, ICodeVisitor<CodeRepeatStatement>
		, ICodeVisitor<CodeReturnStatement>
		, ICodeVisitor<CodeSwitchStatement>
		, ICodeVisitor<CodeThrowStatement>
		, ICodeVisitor<CodeVariableDeclarationStatement>
		, ICodeVisitor<CodeWhileStatement>
	{
	}

	public interface ICodeStatementVisitor<Return>
		: ICodeVisitor<CodeAssignStatement, Return>
		, ICodeVisitor<CodeCommentStatement, Return>
		, ICodeVisitor<CodeExpressionStatement, Return>
		, ICodeVisitor<CodeIfStatement, Return>
		, ICodeVisitor<CodeRepeatStatement, Return>
		, ICodeVisitor<CodeReturnStatement, Return>
		, ICodeVisitor<CodeSwitchStatement, Return>
		, ICodeVisitor<CodeThrowStatement, Return>
		, ICodeVisitor<CodeVariableDeclarationStatement, Return>
		, ICodeVisitor<CodeWhileStatement, Return>
	{
	}
}
