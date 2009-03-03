using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Translator.CodeModel;

namespace DotWeb.Translator
{
	public class CodeSequence : ICodeExpressionVisitor, ICodeStatementVisitor, ICodeMemberVisitor
	{
		public List<CodeObject> Sequence { get; private set; }

		public CodeSequence() {
			this.Sequence = new List<CodeObject>();
		}

		public void Visit(CodeArrayCreateExpression obj) {
			Sequence.Add(obj);
			obj.SizeExpression.Accept(this);
		}

		public void Visit(CodeArrayIndexerExpression obj) {
			Sequence.Add(obj);
			obj.TargetObject.Accept(this);
			obj.Indices.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeBinaryExpression obj) {
			Sequence.Add(obj);
			obj.Left.Accept(this);
			obj.Right.Accept(this);
		}

		public void Visit(CodeCastExpression obj) {
			Sequence.Add(obj);
			obj.Expression.Accept(this);
		}

		public void Visit(CodeInstanceOfExpression obj) {
			Sequence.Add(obj);
			obj.Expression.Accept(this);
		}

		public void Visit(CodeIndexerExpression obj) {
			Sequence.Add(obj);
			obj.TargetObject.Accept(this);
			obj.Indices.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeInvokeExpression obj) {
			Sequence.Add(obj);
			obj.Method.Accept(this);
			obj.Parameters.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeObjectCreateExpression obj) {
			Sequence.Add(obj);
			obj.Parameters.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeParameterDeclarationExpression obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodePrimitiveExpression obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeTypeReference obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeUnaryExpression obj) {
			Sequence.Add(obj);
			obj.Expression.Accept(this);
		}

		public void Visit(CodeArgumentReference obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeFieldReference obj) {
			Sequence.Add(obj);
			obj.TargetObject.Accept(this);
		}

		public void Visit(CodeLengthReference obj) {
			Sequence.Add(obj);
			obj.TargetObject.Accept(this);
		}

		public void Visit(CodeMethodReference obj) {
			Sequence.Add(obj);
			obj.TargetObject.Accept(this);
		}

		public void Visit(CodePropertyReference obj) {
			Sequence.Add(obj);
			obj.TargetObject.Accept(this);
		}

		public void Visit(CodeThisReference obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeVariableReference obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeAssignStatement obj) {
			Sequence.Add(obj);
			obj.Left.Accept(this);
			obj.Right.Accept(this);
		}

		public void Visit(CodeCommentStatement obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeExpressionStatement obj) {
			Sequence.Add(obj);
			obj.Expression.Accept(this);
		}

		public void Visit(CodeIfStatement obj) {
			Sequence.Add(obj);
			obj.Condition.Accept(this);
			obj.TrueStatements.ForEach(x => x.Accept(this));
			obj.FalseStatements.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeRepeatStatement obj) {
			Sequence.Add(obj);
			obj.TestExpression.Accept(this);
			obj.Statements.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeReturnStatement obj) {
			Sequence.Add(obj);
			if(obj.Expression != null)
				obj.Expression.Accept(this);
		}

		public void Visit(CodeSwitchStatement obj) {
			Sequence.Add(obj);
			obj.Expression.Accept(this);
			foreach (CodeCase item in obj.Cases) {
				item.Expressions.ForEach(x => x.Accept(this));
				item.Statements.ForEach(x => x.Accept(this));
			}
		}

		public void Visit(CodeThrowStatement obj) {
			Sequence.Add(obj);
			obj.Expression.Accept(this);
		}

		public void Visit(CodeVariableDeclarationStatement obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeWhileStatement obj) {
			Sequence.Add(obj);
			obj.TestExpression.Accept(this);
			obj.Statements.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeEventMember obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeMethodMember obj) {
			Sequence.Add(obj);
			obj.Statements.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeFieldMember obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodePropertyMember obj) {
			Sequence.Add(obj);
		}

		public void Visit(CodeTypeDeclaration obj) {
			Sequence.Add(obj);
			obj.Fields.ForEach(x => x.Accept(this));
			obj.Methods.ForEach(x => x.Accept(this));
			obj.Properties.ForEach(x => x.Accept(this));
			obj.Events.ForEach(x => x.Accept(this));
		}

		public void Visit(CodeNamespace obj) {
			Sequence.Add(obj);
			obj.Types.ForEach(x => x.Accept(this));
		}
	}
}
