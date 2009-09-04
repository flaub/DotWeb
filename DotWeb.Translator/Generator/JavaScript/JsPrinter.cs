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
using System.Reflection;
using DotWeb.Client;
using DotWeb.Utility;
using System.Diagnostics;
using DotWeb.Decompiler.CodeModel;

namespace DotWeb.Translator.Generator.JavaScript
{
	class TypeMap : Dictionary<Type, string> { }
	class MethodMap : Dictionary<string, string> { }

	class JsPrinter : ICodeExpressionVisitor<string>
	{
		public const string CtorMethodName = "$ctor";
		private const string LocalVarPrefix = "loc";
		private TypeMap typeMap = new TypeMap();
		private MethodMap methodMap = new MethodMap();
		public MethodBase CurrentMethod { get; set; }

		public JsPrinter() {
			methodMap.Add("System.Console.WriteLine", "console.log");
		}

		#region Operators
		public static string Print(CodeUnaryOperator op) {
			switch (op) {
				case CodeUnaryOperator.Positive:
					return "+";
				case CodeUnaryOperator.Not:
					return "!";
				case CodeUnaryOperator.Negate:
					return "-";
				case CodeUnaryOperator.Increment:
					return "++";
				case CodeUnaryOperator.Decrement:
					return "--";
				case CodeUnaryOperator.BitwiseComplement:
					return "~";
				default:
					throw new InvalidOperationException();
			}
		}

		public static string Print(CodeBinaryOperator op) {
			switch (op) {
				case CodeBinaryOperator.Add:
					return "+";
				case CodeBinaryOperator.Assign:
					return "=";
				case CodeBinaryOperator.BitwiseAnd:
					return "&";
				case CodeBinaryOperator.BitwiseOr:
					return "|";
				case CodeBinaryOperator.BooleanAnd:
					return "&&";
				case CodeBinaryOperator.BooleanOr:
					return "||";
				case CodeBinaryOperator.Divide:
					return "/";
				case CodeBinaryOperator.GreaterThan:
					return ">";
				case CodeBinaryOperator.GreaterThanOrEqual:
					return ">=";
				case CodeBinaryOperator.IdentityEquality:
					return "==";
				case CodeBinaryOperator.IdentityInequality:
					return "!=";
				case CodeBinaryOperator.LessThan:
					return "<";
				case CodeBinaryOperator.LessThanOrEqual:
					return "<=";
				case CodeBinaryOperator.Modulus:
					return "%";
				case CodeBinaryOperator.Multiply:
					return "*";
				case CodeBinaryOperator.Subtract:
					return "-";
				case CodeBinaryOperator.ValueEquality:
					return "==";
				case CodeBinaryOperator.ExclusiveOr:
					return "^";
				case CodeBinaryOperator.LeftShift:
					return "<<";
				case CodeBinaryOperator.RightShift:
					return ">>";
				case CodeBinaryOperator.UnsignedRightShift:
					return ">>>";
				default:
					throw new InvalidOperationException();
			}
		}
		#endregion

		#region Helpers

		public string Print(CodeExpression expr) {
			return expr.Accept<JsPrinter, string>(this);
		}

		public string Print(IEnumerable<CodeExpression> args) {
			var parts = args.Select(x => Print(x)).ToArray();
			return string.Join(", ", parts);
		}

		private string GetTypeName(Type type) {
			if (type.DeclaringType == null) {
				return type.Name;
			}

			return string.Format("{0}_{1}", GetTypeName(type.DeclaringType), type.Name);
		}

		public string Print(Type type) {
			JsNamespaceAttribute jsNamespace = type.GetCustomAttribute<JsNamespaceAttribute>();

			string ns;
			if (jsNamespace != null)
				ns = jsNamespace.Namespace;
			else
				ns = type.Namespace;

			string name;
			if (string.IsNullOrEmpty(ns))
				name = GetTypeName(type);
			else
				name = ns + "." + GetTypeName(type);

			if (type.IsGenericType) {
//				Type[] typeArgs = type.GetGenericArguments();
//				string[] parts = typeArgs.Select(x => Print(x).Replace(".", "_")).ToArray();
//				string lhs = name.Split('`').First();
//				name = string.Format("{0}${1}", lhs, string.Join("$", parts));
				name = string.Format("{0}${1}", name.Split('`').First(), type.GetGenericArguments().Length);
			}
			return EncodeName(name);
		}

		private string EncloseParens(CodeExpression exp) {
			string str = Print(exp);
			if (exp is CodeBinaryExpression) {
				return string.Format("({0})", str);
			}
			return str;
		}

		public string EncodeName(string name) {
			return name.Replace("<", "_").Replace(">", "_");
		}

		public string PrintArray(Array array) {
			StringBuilder sb = new StringBuilder();
			sb.Append("[ ");
			bool isFirst = true;
			foreach (var item in array) {
				if (isFirst)
					isFirst = false;
				else
					sb.Append(", ");
				sb.Append(item);
			}
			sb.Append(" ]");
			return sb.ToString();
		}

		public string PrintLiteral(object value) {
			if (value == null)
				return "null";

			Type type = value.GetType();
			if (type.IsArray) {
				return PrintArray((Array)value);
			}

			switch (type.Name) {
				case "String":
					return string.Format("\"{0}\"", value);
				case "Boolean":
					return ((bool)value) ? "true" : "false";
				default:
					return value.ToString();
			}
		}

		#endregion

		#region Expressions

		public string VisitReturn(CodeTypeReference exp) {
			return Print(exp.Type);
		}

		public string VisitReturn(CodeVariableReference exp) {
			return string.Format("{0}{1}", LocalVarPrefix, exp.Index);
		}

		public string VisitReturn(CodeLengthReference expr) {
			return string.Format("{0}.length", Print(expr.TargetObject));
		}

		public string VisitReturn(CodePropertyReference exp) {
			if (exp.Property.DeclaringType.IsDefined(typeof(JsAnonymousAttribute), false)) {
				return string.Format("{0}.{1}", Print(exp.TargetObject), EncodeName(exp.Property.Name));
			}
			// Optimize for anonymous types.
			//CodeTypeEvaluator evaluator = new CodeTypeEvaluator(this.CurrentMethod);
			//Type type = evaluator.Evaluate(exp.TargetObject);
			//if (type.Name.StartsWith("<>f__AnonymousType")) {
			//    return string.Format("{0}.{1}", Print(exp.TargetObject), EncodeName(exp.Property.Name));
			//}
			Debug.Assert(exp.ReferenceType == CodePropertyReference.RefType.Get);
			return VisitReturn(exp.Method) + "()";
		}

		public string VisitReturn(CodeIndexerExpression exp) {
			return string.Format("{0}[{1}]", Print(exp.TargetObject), Print(exp.Indices));
		}

		public string VisitReturn(CodeFieldReference exp) {
			return string.Format("{0}.{1}", Print(exp.TargetObject), EncodeName(exp.Field.Name));
		}

		public string VisitReturn(CodeMethodReference exp) {
			string ret = string.Format("{0}.{1}", Print(exp.TargetObject), EncodeName(exp.Info.Name));
			string alt;
			if (methodMap.TryGetValue(ret, out alt))
				return alt;
			return ret;
		}

		public string VisitReturn(CodeArgumentReference exp) {
			return EncodeName(exp.Argument.Name);
		}

		public string VisitReturn(CodeThisReference exp) {
			return "this";
		}

		public string VisitReturn(CodeCastExpression exp) {
			return string.Format("/*({0})*/{1}", Print(exp.TargetType), Print(exp.Expression));
		}

		public string VisitReturn(CodeInstanceOfExpression exp) {
			return string.Format("{0} instanceof {1}", Print(exp.Expression), Print(exp.TargetType));
		}

		public string VisitReturn(CodeParameterDeclarationExpression exp) {
			return string.Format("{0} /*{1}*/", EncodeName(exp.Name), Print(exp.Info.ParameterType));
		}

		public string VisitReturn(CodeInvokeExpression exp) {
			if (exp.Method.Info.IsConstructor) {
				if (!CurrentMethod.DeclaringType.HasBase()) {
					return "";
				}
				string type = Print(CurrentMethod.DeclaringType);
				List<CodeExpression> args = new List<CodeExpression>();
				args.Add(new CodeThisReference());
				args.AddRange(exp.Parameters);
				return string.Format("this.$super.{0}.call({1})", CtorMethodName, Print(args));
			}
			return string.Format("{0}({1})", Print(exp.Method), Print(exp.Parameters));
		}

		public string VisitReturn(CodePrimitiveExpression exp) {
			return PrintLiteral(exp.Value);
		}

		public string VisitReturn(CodeUnaryExpression exp) {
			return string.Format("{0}{1}", Print(exp.Operator), Print(exp.Expression));
		}

		public string VisitReturn(CodeBinaryExpression exp) {
			CodePrimitiveExpression cpe = exp.Right as CodePrimitiveExpression;
			if (cpe != null && cpe.Value is bool) {
				bool test = (bool)cpe.Value;
				if (test &&
					(exp.Operator != CodeBinaryOperator.IdentityEquality ||
					exp.Operator == CodeBinaryOperator.IdentityInequality)) {
					return string.Format("!{0}", EncloseParens(exp.Left));
				}
				else {
					return EncloseParens(exp.Left);
				}
			}
			else {
				return string.Format("{0} {1} {2}", 
					EncloseParens(exp.Left), 
					Print(exp.Operator), 
					EncloseParens(exp.Right)
				);
			}
		}

		public string VisitReturn(CodeArrayCreateExpression exp) {
			if (exp.Type.IsDefined(typeof(JsAnonymousAttribute), false)) {
				return "[]";
			}
			string size = Print(exp.SizeExpression);
			return string.Format("new {0}[{1}]", Print(exp.Type), size);
		}

		public string VisitReturn(CodeObjectCreateExpression exp) {
			if (exp.Type.IsSubclassOf(typeof(Delegate))) {
				CodeMethodReference methodRef = (CodeMethodReference)exp.Parameters[1];
				string methodName = methodRef.Info.Name;
				string targetObject = Print(exp.Parameters[0]);
				if (targetObject == "null")
					targetObject = Print(methodRef.TargetObject);
				return string.Format("$Delegate({0}, {0}.{1})", targetObject, EncodeName(methodName));
			}
			if (exp.Type.IsDefined(typeof(JsAnonymousAttribute), false)) {
				return "{}";
			}
			if (exp.Type.IsSubclassOf(typeof(JsNativeBase))) {
				return string.Format("new {0}({1})", Print(exp.Type), Print(exp.Parameters));
			}

			return string.Format("new {0}().{1}({2})", Print(exp.Type), CtorMethodName, Print(exp.Parameters));
		}

		public string VisitReturn(CodeArrayIndexerExpression exp) {
			string obj = Print(exp.TargetObject);
			List<string> indexExpressions = new List<string>();
			foreach (CodeExpression indexExpression in exp.Indices) {
				indexExpressions.Add(Print(indexExpression));
			}
			string[] values = indexExpressions.ToArray();
			return string.Format("{0}[{1}]", obj, string.Join(", ", values));
		}

		#endregion
	}
}
