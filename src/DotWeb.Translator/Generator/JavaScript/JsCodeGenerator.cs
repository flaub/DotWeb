﻿// Copyright 2009-2010, Frank Laub
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
using System.IO;
using System.CodeDom.Compiler;
using DotWeb.Client;
using DotWeb.Translator.Properties;
using DotWeb.Decompiler.CodeModel;
using DotWeb.Decompiler;
using Mono.Cecil;
using System.Diagnostics;
using DotWeb.Utility.Cecil;

namespace DotWeb.Translator.Generator.JavaScript
{
	public class JsCodeGenerator: ICodeStatementVisitor, ICodeMemberVisitor
	{
		private TypeSystem typeSystem;

		public JsCodeGenerator(TypeSystem typeSystem, TextWriter output, bool writeHeader) {
			this.typeSystem = typeSystem;
			this.printer = new JsPrinter(typeSystem);
			this.writer = new IndentedTextWriter(output, "\t");
			if (writeHeader) {
				this.writer.WriteLine("// Generated by DotWeb at: {0}", DateTime.Now);
				this.writer.WriteLine();
				this.writer.WriteLine(Resources.Runtime);
			}
		}

		public void WriteEntryPoint(TypeDefinition type) {
			this.writer.WriteLine("$wnd.onload = function() {");
			this.writer.Indent++;
			this.writer.WriteLine("new {0}().$ctor();", Print(type));
			this.writer.Indent--;
			this.writer.WriteLine("}");
		}

		public void Write(CodeNamespace ns) {
			ns.Accept(this);
			this.writer.Flush();
		}

		public void Write(CodeTypeDeclaration type) {
			type.Accept(this);
			this.writer.Flush();
		}

		public void Write(CodeMethodMember method) {
			method.Accept(this);
			this.writer.Flush();
		}

		private void WriteLine() {
			this.writer.WriteLine();
		}

		private void WriteLine(object arg) {
			this.writer.WriteLine(arg);
		}

		private void WriteLine(string format, params object[] args) {
			this.writer.WriteLine(format, args);
		}

		private void Write(object arg) {
			this.writer.Write(arg);
		}

		private void Write(string format, params object[] args) {
			this.writer.Write(format, args);
		}

		private void Write(IEnumerable<CodeStatement> stmts) {
			foreach (var stmt in stmts) {
				stmt.Accept(this);
			}
		}

		private string Print(TypeReference type) {
			return this.printer.Print(type);
		}

		private string Print(CodeExpression expr) {
			return this.printer.Print(expr);
		}

		#region Statements
		public void Visit(CodeTryStatement stmt) {
			WriteLine("try {{");
			this.writer.Indent++;
			Write(stmt.Try);
			this.writer.Indent--;
			WriteLine("}}");
			if (stmt.Catches.Any()) {
				WriteLine("catch (__ex__) {{");
				//WriteLine("console.log(__ex__);");
				this.writer.Indent++;
				bool isFirst = true;
				bool hasGeneric = false;
				foreach (var catchClause in stmt.Catches) {
					if (isFirst) {
						isFirst = false;
					}
					else {
						Write("else ");
					}
					var catchTypeName = Print(catchClause.Type);
					if (catchTypeName == ConstantTypeNames.Exception) {
						WriteLine("if (__ex__) {{");
						hasGeneric = true;
					}
					else {
						WriteLine("if (__ex__ instanceof {0}) {{", Print(catchClause.Type));
					}
					this.writer.Indent++;
					Write(catchClause.Statements);
					this.writer.Indent--;
					WriteLine("}}");
				}
				if (!isFirst && !hasGeneric) {
					WriteLine("else {{");
					this.writer.Indent++;
					WriteLine("throw __ex__;");
					this.writer.Indent--;
					WriteLine("}}");
				}
				this.writer.Indent--;
				WriteLine("}}");
			}
			if (stmt.Finally.Any()) {
				WriteLine("finally {{");
				this.writer.Indent++;
				Write(stmt.Finally);
				this.writer.Indent--;
				WriteLine("}}");
			}
		}

		public void Visit(CodeSwitchStatement stmt) {
			WriteLine("switch ({0}) {{", Print(stmt.Expression));
			this.writer.Indent++;
			CodeCase defaultCase = null;

			foreach (CodeCase cc in stmt.Cases) {
				if (cc.Expressions.Count == 0) {
					defaultCase = cc;
					continue;
				}
				foreach (CodeExpression exp in cc.Expressions) {
					WriteLine("case {0}:", Print(exp));
				}
				this.writer.Indent++;
				Write(cc.Statements);
				//WriteLine("break;");
				this.writer.Indent--;
			}

			if (defaultCase != null) {
				WriteLine("default:");
				this.writer.Indent++;
				Write(defaultCase.Statements);
				//WriteLine("break;");
				this.writer.Indent--;
			}

			this.writer.Indent--;
			WriteLine("}}");
		}

		public void Visit(CodeVariableDeclarationStatement stmt) {
//			WriteLine("var {1}; // {0}", Print(stmt.Type), stmt.Name);
		}

		public void Visit(CodeCommentStatement stmt) {
			WriteLine("// {0}", stmt.Comment);
		}

		public void Visit(CodeAssignStatement stmt) {
			string rhs;
			CodePrimitiveExpression cpe = stmt.Right as CodePrimitiveExpression;
			if (cpe != null) {
				var evaluator = new CodeTypeEvaluator(this.typeSystem, this.currentMethod.Definition);
				var typeRef = evaluator.Evaluate(stmt.Left);
				var reflectionType = TypeSystem.GetReflectionType(typeRef);
				object target = Convert.ChangeType(cpe.Value, reflectionType);
				rhs = this.printer.PrintLiteral(target);
			}
			else {
				rhs = Print(stmt.Right);
			}

			CodePropertyReference cpr = stmt.Left as CodePropertyReference;
			if (cpr != null && !cpr.IsFieldLike(this.typeSystem)) {
				// setter invocation
				// foo.set_X(1);
				WriteLine(string.Format("{0}({1});", Print(cpr.Method), rhs));
				return;
			}

			CodeVariableReference cvr = stmt.Left as CodeVariableReference;
			if (cvr != null) {
				if (!locals.ContainsKey(cvr.Variable.GetName())) {
					locals.Add(cvr.Variable.GetName(), cvr);
					this.writer.Write("var ");
				}
			}
			WriteLine("{0} = {1};", Print(stmt.Left), rhs);
		}

		public void Visit(CodeExpressionStatement stmt) {
			string code = Print(stmt.Expression);
			if(!string.IsNullOrEmpty(code))
				WriteLine("{0};", code);
		}

		public void Visit(CodeReturnStatement stmt) {
			if (stmt.Expression != null) {
				WriteLine("return {0};", Print(stmt.Expression));
			}
			else {
				// Optimize for return statements from a void method that is
				// at the end of a function; no code follows this point
				if (currentMethod != null && currentMethod.Statements.Last() == stmt) {
					return;
				}
				WriteLine("return;");
			}
		}

		public void Visit(CodeWhileStatement stmt) {
			WriteLine("while ({0}) {{", Print(stmt.TestExpression));
			this.writer.Indent++;
			Write(stmt.Statements);
			this.writer.Indent--;
			WriteLine("}}");
		}

		public void Visit(CodeRepeatStatement stmt) {
			WriteLine("do {{");
			this.writer.Indent++;
			Write(stmt.Statements);
			this.writer.Indent--;
			WriteLine("}} while ({0});", Print(stmt.TestExpression));
		}

		public void Visit(CodeBreakStatement stmt) {
			WriteLine("break;");
		}

		public void Visit(CodeContinueStatement stmt) {
			WriteLine("continue;");
		}

		public void Visit(CodeIfStatement stmt) {
			WriteLine("if ({0}) {{", Print(stmt.Condition));
			this.writer.Indent++;
			Write(stmt.TrueStatements);
			this.writer.Indent--;
			WriteLine("}}");
			if (stmt.FalseStatements.Count > 0) {
				WriteLine("else {{");
				this.writer.Indent++;
				Write(stmt.FalseStatements);
				this.writer.Indent--;
				WriteLine("}}");
			}
		}

		public void Visit(CodeThrowStatement stmt) {
			WriteLine("throw {0};", Print(stmt.Expression));
		}

		public void Visit(CodeGotoStatement stmt) {
			throw new NotSupportedException();
		}

		#endregion

		public void WriteTypeConstructor(TypeDefinition type) {
			if (AttributeHelper.IsAnonymous(type, this.typeSystem) ||
				AttributeHelper.GetJsAugment(type) != null) {
				return;
			}
			
			// $Class(System.BaseClass, '', 'Class');
			string parent;
			if (type.HasBase(this.typeSystem)) {
				parent = Print(type.BaseType);
			}
			else {
				parent = "null";
			}
			string ns = JsPrinter.EncodeName(JsPrinter.GetNamespace(type));
			string name = JsPrinter.EncodeName(this.printer.GetTypeName(type));

			var items = new List<string>();
			foreach (FieldDefinition field in type.Fields) {
				if (!field.IsStatic) {
					string value = JsPrinter.GetDefaultValue(field.FieldType);
					items.Add(string.Format("{0}: {1}", this.printer.GetMemberName(field), value));
				}
			}

			string dict = "";
			if (items.Any()) {
				var dictInner = string.Join(", ", items.ToArray());
				dict = string.Format(", {{ {0} }}", dictInner);
			}

			WriteLine("$Class({0}, '{1}', '{2}'{3});", parent, ns, name, dict);

			WriteLine();
		}

		public void WriteStaticConstructor(CodeTypeInitializer method) {
			this.printer.CurrentMethod = method.Definition;
			this.currentMethod = method;
			this.locals.Clear();

			WriteLine("(function() {{");
			this.writer.Indent++;

			foreach (var field in method.DefaultStaticFields) {
				var typeRef = new CodeTypeReference(field.DeclaringType);
				var lhs = new CodeFieldReference(typeRef, field);

				object initialValue = 0;
				if (field.Constant != null) {
					initialValue = field.Constant;
				}

				var targetType = TypeSystem.GetReflectionType(field.FieldType);
				if (targetType.IsPrimitive) {
					initialValue = Convert.ChangeType(initialValue, targetType);
				}
				else {
					initialValue = null;
				}
				var rhs = new CodePrimitiveExpression(initialValue);

				WriteLine("{0} = {1};", Print(lhs), Print(rhs));
			}

			if (string.IsNullOrEmpty(method.NativeCode)) {
				Write(method.Statements);
			}
			else {
				this.writer.WriteLine(method.NativeCode);
			}

			this.writer.Indent--;
			WriteLine("}})();");

			WriteLine();
		}

		#region Members
		public void Visit(CodeTypeDeclaration type) {
			try {
				WriteTypeConstructor(type.Type);

				type.Methods.ForEach(x => x.Accept(this));
				WriteLine();

//				type.Properties.ForEach(x => x.Accept(this));
//				WriteLine();
			}
			finally {
				this.writer.Flush();
			}
		}

		public void Visit(CodeMethodMember method) {
			this.printer.CurrentMethod = method.Definition;
			this.currentMethod = method;
			this.locals.Clear();

			string[] args = method.Parameters.Select(x => Print(x)).ToArray();
			Write(Print(method.Definition.DeclaringType));
			Write(".");
			if (!method.Definition.IsStatic) {
				Write("prototype.");
			}
			Write(this.printer.GetMethodName(method.Definition));
			WriteLine(" = function({0}) {{", string.Join(", ", args));

			this.writer.Indent++;
			if (string.IsNullOrEmpty(method.NativeCode)) {
				Write(method.Statements);
				if (method.Definition.IsConstructor) {
					WriteLine("return this;");
				}
			}
			else {
				this.writer.WriteLine(method.NativeCode);
			}
			this.writer.Indent--;
			WriteLine("}};");
			WriteLine();
		}

		public void Visit(CodePropertyGetterMember method) {
			if (AttributeHelper.IsIntrinsic(method.Property, this.typeSystem)) {
				// FIXME: how to throw exceptions?
				//if (!method.IsAutoImplemented())
				//	throw new InvalidIntrinsicUsageException(method.PropertyInfo.DeclaringType.ToString(), method.PropertyInfo.ToString());
				return;
			}
			// This is to look and optimize for properties that have automatic implementations
			//if (method.IsAutoImplemented())
			//	return;

			Visit((CodeMethodMember)method);
		}

		public void Visit(CodePropertySetterMember method) {
			if (AttributeHelper.IsIntrinsic(method.Property, this.typeSystem)) {
				// FIXME: how to throw exceptions?
				//if (!method.IsAutoImplemented())
				//	throw new InvalidIntrinsicUsageException(method.PropertyInfo);
				return;
			}
			// This is to look and optimize for properties that have automatic implementations
			//if (method.IsAutoImplemented())
			//	return;
			Visit((CodeMethodMember)method);
		}

		public void Visit(CodeFieldMember field) {
			WriteLine("{0}: {1} // field: {2}",
				this.printer.GetMemberName(field.Definition),
				"{}", 
				Print(field.Definition.FieldType)
			);
		}

		public void Visit(CodeEventMember evt) {
			WriteLine("{0}: {1} // event: {2}",
				JsPrinter.EncodeName(evt.Name), 
				"[]", 
				Print(evt.Definition.EventType));
		}

		public void Visit(CodePropertyMember property) {
			//string name = JsPrinter.EncodeName(property.Name);
			//if (property.Info.GetAccessors().Any(x => x.IsStatic)) {
			//    WriteLine("{0}.prototype.{1} = function() {{",
			//        Print(property.Info.DeclaringType),
			//        name
			//    );
			//}
			//else {
			//    WriteLine("{0}.{1} = function() {{",
			//        Print(property.Info.DeclaringType),
			//        name
			//    );
			//}

			//this.writer.Indent++;
			//this.writer.WriteLine("return this.get_{0}();", name);
			//this.writer.Indent--;
			//WriteLine("}};");
			//WriteLine();

			//WriteLine("{0}: '' // property: {1}",
			//    JsPrinter.EncodeName(property.Name),
			//    Print(property.Info.PropertyType));
		}

		public void WriteNamespaceDecl(CodeNamespace ns) {
			if (!string.IsNullOrEmpty(ns.Name)) {
//				WriteLine("if(typeof({0}) == 'undefined') {0} = {{}};", ns.Name);
				WriteLine("$Namespace('{0}');", ns.Name);
				WriteLine();
			}
		}

		public void Visit(CodeNamespace ns) {
			WriteNamespaceDecl(ns);

			foreach (CodeTypeDeclaration type in ns.Types) {
				Write(type);
			}
		}
		#endregion

		private readonly Dictionary<string, CodeVariableReference> locals = new Dictionary<string, CodeVariableReference>();
		private readonly JsPrinter printer;
		private readonly IndentedTextWriter writer;
		private CodeMethodMember currentMethod;
	}
}
