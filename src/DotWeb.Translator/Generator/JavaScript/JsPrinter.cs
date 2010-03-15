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
using DotWeb.Client;
using DotWeb.Utility;
using System.Diagnostics;
using DotWeb.Decompiler.CodeModel;
using Mono.Cecil;
using DotWeb.Utility.Cecil;
using DotWeb.Decompiler;

namespace DotWeb.Translator.Generator.JavaScript
{
	class JsPrinter : ICodeExpressionVisitor<string>
	{
		public const string CtorMethodName = "$ctor";
		public const string StaticCtorMethodName = "$cctor";
		private TypeSystem typeSystem;

		public MethodDefinition CurrentMethod { get; set; }

		public JsPrinter(TypeSystem typeSystem) {
			this.typeSystem = typeSystem;
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

		public static string GetNamespace(TypeReference type) {
			if (type == null)
				throw new ArgumentNullException("type");

			string jsNamespace = AttributeHelper.GetJsNamespace(type);
			if (jsNamespace != null)
				return jsNamespace;

			// This is to fix a problem with Mono.Cecil, nested types don't return
			// the namespace correctly.
			string ret = null;
			var nextType = type.Resolve();
			while (nextType != null) {
				ret = nextType.Namespace;
				nextType = nextType.DeclaringType;
			}
			return ret;
		}

		public string Print(CodeExpression expr) {
			return expr.Accept<JsPrinter, string>(this);
		}

		public string Print(IEnumerable<CodeExpression> args) {
			var parts = args.Select(x => Print(x)).ToArray();
			return string.Join(", ", parts);
		}

		public string GetTypeName(TypeReference type) {
			var typeDef = type.Resolve();
			if (typeDef.DeclaringType == null) {
				return typeDef.Name;
			}

			return string.Format("{0}_{1}", GetTypeName(typeDef.DeclaringType), typeDef.Name);
		}

		public string Print(TypeReference type) {
			if (type == null)
				throw new ArgumentNullException("type");

			string ns = GetNamespace(type);

			string name;
			if (string.IsNullOrEmpty(ns))
				name = GetTypeName(type);
			else
				name = ns + "." + GetTypeName(type);

			return EncodeName(name);
		}

		private string EncloseParens(CodeExpression exp) {
			string str = Print(exp);
			if (exp is CodeBinaryExpression) {
				return string.Format("({0})", str);
			}
			return str;
		}

		public static string EncodeName(string name) {
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
			return new String(chars).Replace(".ctor", CtorMethodName);
		}

		private static string EncodeChar(char value) {
			switch (value) {
				case '\\':
					return ("\\\\");
				case '\n':
					return ("\\n");
				case '\t':
					return ("\\t");
				case '\r':
					return ("\\r");
				case '\"':
					return ("\\\"");
				default:
					if (char.IsControl(value)) {
						return Convert.ToString((int)value);
					}
					return Convert.ToString(value);
			}
		}

		public static string EncodeStringLiteral(string value) {
			var sb = new StringBuilder();
			sb.Append('\"');
			foreach (var ch in value) {
				sb.Append(EncodeChar(ch));
			}
			sb.Append('\"');
			return sb.ToString();
		}

		public static string EncodeCharLiteral(char value) {
			var sb = new StringBuilder();
			sb.Append('\'');
			sb.Append(EncodeChar(value));
			sb.Append('\'');
			return sb.ToString();
		}

		public string PrintArray(Array array) {
			StringBuilder sb = new StringBuilder();
			sb.Append("[");
			bool isFirst = true;
			foreach (var item in array) {
				if (isFirst)
					isFirst = false;
				else
					sb.Append(", ");
				sb.Append(item);
			}
			sb.Append("]");
			return sb.ToString();
		}

		public string PrintLiteral(object value) {
			if (value == null)
				return "null";

			if (value is string) {
				return EncodeStringLiteral((string)value);
			}
			else if (value is bool) {
				return ((bool)value) ? "true" : "false";
			}
			else if (value is char) {
				return EncodeCharLiteral((char)value);
			}
			else {
				return value.ToString();
			}
		}

		public static string GetDefaultValue(TypeReference type) {
			if (type.IsValueType) {
				return "0";
			}
			else {
				return "null";
			}
		}

		private string PrintMacro(string macro, MethodDefinition method, string target, List<CodeExpression> parameters) {
			var args = new List<string>();
			args.Add(target);
			if (parameters != null) {
				parameters.ForEach(x => args.Add(Print(x)));
			}
			return string.Format(macro, args.ToArray());
		}

		public string GetMethodName(MethodReference method) {
			var type = method.DeclaringType.Resolve();

			var methodDef = method.Resolve();
			if (!methodDef.HasBody || methodDef.Body.CodeSize == 0) {
				var jsCode = AttributeHelper.GetJsCode(methodDef);
				if (jsCode == null) {
					return GetMemberName(methodDef);
				}
			}

			if (methodDef.IsConstructor) {
				if (type.Constructors.Count == 1) {
					return CtorMethodName;
				}
				else {
					return string.Format("{0}${1}", CtorMethodName, type.Constructors.IndexOf(methodDef));
				}
			}
			else {
				var match = type.Methods.GetMethod(method.Name);
				if (match.Length == 1) {
					return GetMemberName(method);
				}
				else {
					// this is to handle overloaded methods (different argument types)
					for (int i = 0; i < match.Length; i++) {
						var item = match[i];
						if (item.MetadataToken == method.MetadataToken) {
							var name = string.Format("{0}${1}", GetMemberName(method), i);
							return EncodeName(name);
						}
					}
					throw new NotSupportedException();
				}
			}
		}

		public string GetMemberName(MemberReference member) {
			var jsName = AttributeHelper.GetJsName(member);
			if (jsName != null) {
				return jsName;
			}

			var name = member.Name;
			if (name == "ToString" || AttributeHelper.IsCamelCase(member, this.typeSystem)) {
				char[] chars = name.ToCharArray();
				chars[0] = Char.ToLower(chars[0]);
				name = new string(chars);
			}
			return EncodeName(name);
		}

		#endregion

		#region Expressions

		public string VisitReturn(CodeTypeReference exp) {
			return Print(exp.Type);
		}

		public string VisitReturn(CodeVariableReference exp) {
			return EncodeName(exp.Variable.Name);
		}

		public string VisitReturn(CodeLengthReference expr) {
			return string.Format("{0}.length", Print(expr.TargetObject));
		}

		public string VisitReturn(CodePropertyReference exp) {
			// deal with [JsMacro]
			var method = exp.Method.Reference.Resolve();
			string jsMacro = AttributeHelper.GetJsMacro(method);
			if (jsMacro != null) {
				Debug.Assert(exp.ReferenceType == CodePropertyReference.RefType.Get);
				return PrintMacro(jsMacro, method, Print(exp.TargetObject), null);
			}

			if (exp.IsFieldLike(this.typeSystem)) {
				return string.Format("{0}.{1}", Print(exp.TargetObject), GetMemberName(exp.Property));
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
			// deal with [JsMacro]
			var method = exp.Method.Reference.Resolve();
			string jsMacro = AttributeHelper.GetJsMacro(method);
			if (jsMacro != null) {
				Debug.Assert(exp.ReferenceType == CodePropertyReference.RefType.Get);
				return PrintMacro(jsMacro, method, Print(exp.TargetObject), exp.Indices);
			}

			if (exp.IsFieldLike(this.typeSystem)) {
				return string.Format("{0}[{1}]", Print(exp.TargetObject), Print(exp.Indices));
			}

			Debug.Assert(exp.ReferenceType == CodePropertyReference.RefType.Get);
			return string.Format("{0}({1})", VisitReturn(exp.Method), Print(exp.Indices));
		}

		public string VisitReturn(CodeFieldReference exp) {
			return string.Format("{0}.{1}", Print(exp.TargetObject), GetMemberName(exp.Field));
		}

		public string VisitReturn(CodeMethodReference exp) {
			var methodName = GetMethodName(exp.Reference);
			var target = Print(exp.TargetObject);
			if (this.typeSystem.IsDelegate(exp.Reference.DeclaringType)) {
				if (methodName == "Invoke") {
					return target;
				}
				throw new NotSupportedException();
			}
			return string.Format("{0}.{1}", target, methodName);
		}

		public string VisitReturn(CodeArgumentReference exp) {
			return EncodeName(exp.Argument.Name);
		}

		public string VisitReturn(CodeThisReference exp) {
			return "this";
		}

		public string VisitReturn(CodeBaseReference exp) {
			return "this.$super";
		}

		public string VisitReturn(CodeCastExpression exp) {
			//return string.Format("/*({0})*/{1}", Print(exp.TargetType), Print(exp.Expression));
			var evaluator = new CodeTypeEvaluator(this.typeSystem, this.CurrentMethod);
			var type = evaluator.Evaluate(exp.Expression);
			if (exp.TargetType.FullName == Constants.Int32 && type.FullName != Constants.Int32) {
				return string.Format("Math.floor({0})", Print(exp.Expression));
			}
			return Print(exp.Expression);
		}

		public string VisitReturn(CodeInstanceOfExpression exp) {
			return string.Format("{0} instanceof {1}", Print(exp.Expression), Print(exp.TargetType));
		}

		public string VisitReturn(CodeParameterDeclarationExpression exp) {
			//return string.Format("/*{0}*/ {1}", EncodeName(exp.Definition.ParameterType.FullName), EncodeName(exp.Name));
			return EncodeName(exp.Name);
		}

		public string VisitReturn(CodeInvokeExpression exp) {
			var method = exp.Method.Reference.Resolve();
			string jsMacro = AttributeHelper.GetJsMacro(method);
			if (jsMacro != null) {
				return PrintMacro(jsMacro, method, Print(exp.Method.TargetObject), exp.Parameters);
			}

			if (method.IsConstructor) {
				if (method.DeclaringType != this.CurrentMethod.DeclaringType &&
					!CurrentMethod.DeclaringType.HasBase(this.typeSystem)) {
					return "";
				}
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
				if ((test && exp.Operator == CodeBinaryOperator.IdentityEquality) ||
					(!test && exp.Operator == CodeBinaryOperator.IdentityInequality)) {
					// (x == true) -> (x)
					// (x != false) -> (x)
					return EncloseParens(exp.Left);
				}
				else if ((test && exp.Operator == CodeBinaryOperator.IdentityInequality) ||
					(!test && exp.Operator == CodeBinaryOperator.IdentityEquality)) {
					// (x != true) -> !(x)
					// (x == false) -> !(x)
					return string.Format("!{0}", EncloseParens(exp.Left));
				}
				else {
					throw new NotSupportedException();
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
			string size = Print(exp.SizeExpression);
			//return string.Format("new /*{0}*/Array({1})", Print(exp.Type), size);
			return string.Format("$Array({0}, {1})", size, GetDefaultValue(exp.Type));
		}

		public string VisitReturn(CodeArrayInitializeExpression obj) {
			return PrintArray(obj.InitialValues);
		}

		public string VisitReturn(CodeObjectCreateExpression exp) {
			var method = exp.Constructor.Resolve();
			string jsMacro = AttributeHelper.GetJsMacro(method);
			if (jsMacro != null) {
				return PrintMacro(jsMacro, method, Print(exp.Type), exp.Parameters);
			}

			if (this.typeSystem.IsDelegate(exp.Type)) {
				CodeMethodReference methodRef = (CodeMethodReference)exp.Parameters[1];
				string targetObject = Print(exp.Parameters[0]);
				if (targetObject == "null")
					targetObject = Print(methodRef.TargetObject);
				return string.Format("$Delegate({0}, {0}.{1})", targetObject, GetMethodName(methodRef.Reference));
			}
			if (AttributeHelper.IsAnonymous(exp.Type, this.typeSystem)) {
				return "{}";
			}
			if (this.typeSystem.IsSubclassOf(exp.Type, this.typeSystem.TypeDefinitionCache.JsObject)) {
				return string.Format("new {0}({1})", Print(exp.Type), Print(exp.Parameters));
			}

			return string.Format("new {0}().{1}({2})", Print(exp.Type), GetMethodName(exp.Constructor), Print(exp.Parameters));
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
