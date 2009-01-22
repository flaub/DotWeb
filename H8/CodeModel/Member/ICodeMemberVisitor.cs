using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public interface ICodeMemberVisitor
		: ICodeVisitor<CodeEventMember>
		, ICodeVisitor<CodeMethodMember>
		, ICodeVisitor<CodeFieldMember>
		, ICodeVisitor<CodePropertyMember>
		, ICodeVisitor<CodeTypeDeclaration>
		, ICodeVisitor<CodeNamespace>
	{
	}

	public interface ICodeMemberVisitor<Return>
		: ICodeVisitor<CodeEventMember, Return>
		, ICodeVisitor<CodeMethodMember, Return>
		, ICodeVisitor<CodeFieldMember, Return>
		, ICodeVisitor<CodePropertyMember, Return>
		, ICodeVisitor<CodeTypeDeclaration, Return>
		, ICodeVisitor<CodeNamespace, Return>
	{
	}
}
