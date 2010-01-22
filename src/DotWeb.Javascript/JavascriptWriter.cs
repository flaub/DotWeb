using System;
using Mono.Cecil;
using Cecil.Decompiler;
using Cecil.Decompiler.Languages;
using Cecil.Decompiler.Ast;
using System.Text;
using System.Collections.Generic;

namespace DotWeb.Javascript
{
	public class JavascriptWriter : BaseLanguageWriter
	{
		bool inside_binary;

		public JavascriptWriter(ILanguage language, IFormatter formatter)
			: base(language, formatter) {
		}

		public override void Write(MethodDefinition method) {

			if (method.IsStatic) {
				//WriteLine("{0}.{1} = function({2}) {{",
				//    Print(method.Definition.DeclaringType),
				//    this.printer.GetMemberName(method.Definition),
				//    string.Join(", ", args)
				//);
			}
			else {
				//WriteLine("{0}.prototype.{1} = function({2}) {{",
				//    Print(method.Definition.DeclaringType),
				//    this.printer.GetMemberName(method.Definition),
				//    string.Join(", ", args)
				//);
			}

			WriteReference(method.DeclaringType);
			WriteToken(".");
			WriteKeyword("prototype");
			WriteToken(".");
			Write(method.Name);
			WriteTokenBetweenSpace("=");
			WriteKeyword("function");

			WriteToken("(");
			WriteParameters(method);
			WriteToken(")");

			WriteSpace();

			Write(method.Body.Decompile(this.language));
		}

		public override void Write(Statement statement) {
			Visit(statement);
			WriteLine();
		}

		public override void Write(Expression expression) {
			Visit(expression);
		}

		#region Visitors

		public override void VisitBlockStatement(BlockStatement node) {
			WriteBlock(() => Visit(node.Statements));
		}

		public override void VisitExpressionStatement(ExpressionStatement node) {
			Visit(node.Expression);
			WriteToken(";");
			WriteLine();
		}

		public override void VisitAssignExpression(AssignExpression node) {
			Write(node.Target);
			WriteTokenBetweenSpace("=");
			Write(node.Expression);
		}

		public override void VisitIfStatement(IfStatement node) {
			WriteKeyword("if");
			WriteBetweenParenthesis(node.Condition);
			WriteSpace();

			Visit(node.Then);

			if (node.Else == null)
				return;

			WriteKeyword("else");
			WriteSpace();

			Visit(node.Else);
		}

		public override void VisitArgumentReferenceExpression(ArgumentReferenceExpression node) {
			Write(node.Parameter.Name);
		}

		public override void VisitVariableReferenceExpression(VariableReferenceExpression node) {
			Write(node.Variable.Name);
		}

		public override void VisitTypeReferenceExpression(TypeReferenceExpression node) {
			WriteReference(node.Type);
		}

		public override void VisitThisReferenceExpression(ThisReferenceExpression node) {
			WriteKeyword("this");
		}

		public override void VisitBaseReferenceExpression(BaseReferenceExpression node) {
			WriteKeyword("this");
			WriteToken(".");
			Write("$super");
		}

		public override void VisitMethodReferenceExpression(MethodReferenceExpression node) {
			if (node.Target != null) {
				Visit(node.Target);
				WriteToken(".");
			}

			if (!node.Method.HasThis) {
				WriteReference(node.Method.DeclaringType);
				WriteToken(".");
			}

			Write(node.Method.Name);
		}

		public override void VisitMethodInvocationExpression(MethodInvocationExpression node) {
			Visit(node.Method);
			WriteToken("(");
			VisitList(node.Arguments);
			WriteToken(")");
		}

		public override void VisitLiteralExpression(LiteralExpression node) {
			var value = node.Value;
			if (value == null) {
				WriteKeyword("null");
				return;
			}

			switch (Type.GetTypeCode(value.GetType())) {
				case TypeCode.Boolean:
					WriteKeyword((bool)value ? "true" : "false");
					return;
				case TypeCode.Char:
					WriteLiteral("'");
					WriteLiteral(value.ToString());
					WriteLiteral("'");
					return;
				case TypeCode.String:
					WriteLiteral("\"");
					WriteLiteral(value.ToString());
					WriteLiteral("\"");
					return;
				// complete
				default:
					WriteLiteral(value.ToString());
					return;
			}
		}

		public override void VisitBinaryExpression(BinaryExpression node) {
			var was_inside = inside_binary;
			inside_binary = true;

			if (was_inside)
				WriteToken("(");
			Visit(node.Left);
			WriteSpace();
			Write(ToString(node.Operator));
			WriteSpace();
			Visit(node.Right);
			if (was_inside)
				WriteToken(")");

			inside_binary = was_inside;
		}

		public override void VisitUnaryExpression(UnaryExpression node) {
			bool is_post_op = IsPostUnaryOperator(node.Operator);

			if (!is_post_op)
				Write(ToString(node.Operator));

			Visit(node.Operand);

			if (is_post_op)
				Write(ToString(node.Operator));
		}

		public override void VisitConditionExpression(ConditionExpression node) {
			WriteToken("(");
			Visit(node.Condition);
			WriteTokenBetweenSpace("?");
			Visit(node.Then);
			WriteTokenBetweenSpace(":");
			Visit(node.Else);
			WriteToken(")");
		}

		public override void VisitReturnStatement(ReturnStatement node) {
			WriteKeyword("return");

			if (node.Expression != null) {
				WriteSpace();
				Visit(node.Expression);
			}

			WriteToken(";");
			WriteLine();
		}

		#endregion

		void WriteBlock(Action action) {
			WriteToken("{");
			WriteLine();
			Indent();

			action();

			Outdent();
			WriteToken("}");
			WriteLine();
		}

		void WriteReference(TypeReference reference) {
			formatter.WriteReference(ToString(reference), reference);
		}

		void WriteTokenBetweenSpace(string token) {
			WriteSpace();
			WriteToken(token);
			WriteSpace();
		}

		void WriteBetweenParenthesis(Expression expression) {
			WriteToken("(");
			Visit(expression);
			WriteToken(")");
		}

		void WriteParameters(MethodDefinition method) {
			for (int i = 0; i < method.Parameters.Count; i++) {
				var parameter = method.Parameters[i];

				if (i > 0) {
					WriteToken(",");
					WriteSpace();
				}

				WriteToken("/*");
				WriteReference(parameter.ParameterType);
				WriteToken("*/");
				WriteSpace();
				Write(parameter.Name);
			}

			//string[] args = method.Parameters.Select(x => ToString(x)).ToArray();
			//var str = string.Join(", ", args);
		}

		string ToString(BinaryOperator op) {
			switch (op) {
				case BinaryOperator.Add: return "+";
				case BinaryOperator.BitwiseAnd: return "&";
				case BinaryOperator.BitwiseOr: return "|";
				case BinaryOperator.BitwiseXor: return "^";
				case BinaryOperator.Divide: return "/";
				case BinaryOperator.GreaterThan: return ">";
				case BinaryOperator.GreaterThanOrEqual: return ">=";
				case BinaryOperator.LeftShift: return "<<";
				case BinaryOperator.LessThan: return "<";
				case BinaryOperator.LessThanOrEqual: return "<=";
				case BinaryOperator.LogicalAnd: return "&&";
				case BinaryOperator.LogicalOr: return "||";
				case BinaryOperator.Modulo: return "%";
				case BinaryOperator.Multiply: return "*";
				case BinaryOperator.RightShift: return ">>";
				case BinaryOperator.Subtract: return "-";
				case BinaryOperator.ValueEquality: return "==";
				case BinaryOperator.ValueInequality: return "!=";
				default: throw new ArgumentException();
			}
		}

		string ToString(UnaryOperator op) {
			switch (op) {
				case UnaryOperator.BitwiseNot:
					return "~";
				case UnaryOperator.LogicalNot:
					return "!";
				case UnaryOperator.Negate:
					return "-";
				case UnaryOperator.PostDecrement:
				case UnaryOperator.PreDecrement:
					return "--";
				case UnaryOperator.PostIncrement:
				case UnaryOperator.PreIncrement:
					return "++";
				default: throw new ArgumentException();
			}
		}

		string ToString(TypeReference type) {
			var spec = type as TypeSpecification;
			if (spec != null)
				return ToString(spec);

			string ns = GetNamespace(type);

			string name;
			if (string.IsNullOrEmpty(ns))
				name = GetTypeName(type);
			else
				name = ns + "." + GetTypeName(type);

			return EncodeName(name);
		}

		string ToString(TypeSpecification specification) {
			var pointer = specification as PointerType;
			if (pointer != null)
				return ToString(specification.ElementType) + "*";

			var reference = specification as ReferenceType;
			if (reference != null)
				return ToString(specification.ElementType) + "&";

			var array = specification as ArrayType;
			if (array != null)
				return ToString(specification.ElementType) + "[]";

			var generic = specification as GenericInstanceType;
			if (generic != null)
				return ToString(generic);

			throw new NotSupportedException();
		}

		string ToString(GenericInstanceType generic) {
			var name = ToString(generic.ElementType);

			var signature = new StringBuilder();
			signature.Append(name.Substring(0, name.Length - 2));
			signature.Append("<");

			for (int i = 0; i < generic.GenericArguments.Count; i++) {
				if (i > 0)
					signature.Append(", ");

				signature.Append(ToString(generic.GenericArguments[i]));
			}

			signature.Append(">");
			return signature.ToString();
		}

		string GetNamespace(TypeReference type) {
			if (type == null)
				throw new ArgumentNullException("type");

			//string jsNamespace = AttributeHelper.GetJsNamespace(type);
			//if (jsNamespace != null)
			//    return jsNamespace;

			// This is to fix a problem with Mono.Cecil, nested types don't return
			// the namespace correctly.
			string ret = null;
			var nextType = type;
			while (nextType != null) {
				ret = nextType.Namespace;
				nextType = nextType.DeclaringType;
			}
			return ret;
		}

		string GetTypeName(TypeReference type) {
			var typeDef = type.Resolve();
			if (typeDef.DeclaringType == null) {
				return typeDef.Name;
			}

			return string.Format("{0}_{1}", GetTypeName(typeDef.DeclaringType), typeDef.Name);
		}

		string EncodeName(string name) {
			var chars = name.ToCharArray();
			for (int i = 0; i < chars.Length; i++) {
				var ch = chars[i];
				switch (ch) {
					case '<':
					case '>':
					case '/':
						chars[i] = '_';
						break;
					case '`':
						chars[i] = '$';
						break;
					default:
						break;
				}
			}
			return new String(chars);
		}

		bool IsPostUnaryOperator(UnaryOperator op) {
			switch (op) {
				case UnaryOperator.PostIncrement:
				case UnaryOperator.PostDecrement:
					return true;
				default:
					return false;
			}
		}

		void VisitList(IList<Expression> list) {
			for (int i = 0; i < list.Count; i++) {
				if (i > 0) {
					WriteToken(",");
					WriteSpace();
				}

				Visit(list[i]);
			}
		}
	}
}
