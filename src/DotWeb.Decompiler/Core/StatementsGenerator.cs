// Copyright 2010, Frank Laub
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
using DotWeb.Decompiler.CodeModel;
using Mono.Cecil;
using DotWeb.Utility;
using System.Diagnostics;
using Mono.Cecil.Cil;

namespace DotWeb.Decompiler.Core
{
	static class HashSetExtensions
	{
		public static HashSet<Node> NewAdd(this HashSet<Node> set, Node item) {
			if (item == null)
				return set;
			set = new HashSet<Node>(set);
			set.Add(item);
			return set;
		}
	}

	class StatementsGenerator
	{
		class Context
		{
			private TryStructure tryContext;
			private Loop loop;
			private HashSet<Node> until;

			public Context() {
				this.loop = null;
				this.tryContext = null;
				this.until = new HashSet<Node>();
			}

			private Context(Loop loop, HashSet<Node> until, TryStructure tryContext) {
				this.loop = loop;
				this.until = until;
				this.tryContext = tryContext;
			}

			public Context NewLoop(Loop loop) {
				return new Context(loop, this.until, this.tryContext);
			}

			public Context NewUntil(Node node) {
				return new Context(this.loop, this.until.NewAdd(node), this.tryContext);
			}

			public Context NewTry(TryStructure tryContext) {
				var until = this.until;
				if (tryContext.Follow != null) {
					until = this.until.NewAdd(tryContext.Follow);
				}
				return new Context(this.loop, until, tryContext);
			}

			public Node LoopHeader {
				get { return this.loop == null ? null : this.loop.Header; }
			}

			public Node LoopFollow {
				get { return this.loop == null ? null : this.loop.Follow; }
			}

			public bool IsUntil(Node node) {
				return this.until.Contains(node);
			}

			public TryStructure Try {
				get { return this.tryContext; }
			}
		}

		private Graph graph;
		private CodeMethodMember method;

		public StatementsGenerator(MethodDefinition methodDef, Graph graph) {
			this.graph = graph;
			this.method = new CodeMethodMember(methodDef);
		}

		public CodeMethodMember WriteMethodBody() {
			WriteCode(null, (BasicBlock)this.graph.Root, this.method.Statements, new Context());
			return this.method;
		}

		private bool WriteCode(BasicBlock previous, BasicBlock block, List<CodeStatement> stmts, Context context) {
			if (block == context.LoopFollow) {
				AddStatement(stmts, new CodeBreakStatement());
				return true;
			}

			if (block == context.LoopHeader && (previous == null || !previous.IsLoopLatch)) {
				AddStatement(stmts, new CodeContinueStatement());
				return true;
			}

			if (context.IsUntil(block) ||
				block.DfsTraversed == DfsTraversal.Alpha) {
				return false;
			}

			if (block.IsTryHeader && context.Try != block.Try) {
				return WriteTry(block, stmts, context);
			}

			block.DfsTraversed = DfsTraversal.Alpha;

			if (block.IsLoopHeader) {
				return WriteLoop(block, stmts, context);
			}
			else if (block.IsMultiWay) {
				return WriteSwitch(block, stmts, context);
			}
			else if (block.Conditional != null) {
				return WriteIf(block, block.Conditional, stmts, context);
			}
			else {
				var isReturn = WriteBasicBlock(block, stmts);
				if (isReturn)
					return true;
			
				var succ = (BasicBlock)block.Successors.FirstOrDefault();
				return WriteCode(block, succ, stmts, context);
			}
		}

		private bool WriteTry(BasicBlock block, List<CodeStatement> stmts, Context context) {
			// find catch/finally blocks that match this try
			// write this block into the try
			// continue until we find the try follow, which is the first block that has a last != leave
			// if the try follow lands on a loop or conditional header, then use their follow instead
			// TODO: deal with nested trys
			var tryStmt = new CodeTryStatement();
			AddStatement(stmts, tryStmt);

			var tryContext = context.NewTry(block.Try);

			WriteCode(null, block, tryStmt.Try, tryContext);

			foreach (BasicBlock catchBlock in block.Try.Catches) {
				var catchType = catchBlock.ExceptionHandler.CatchType;
				var variable = Interpreter.CreateExceptionVariableReference(this.method.Definition, catchType);
				var catchClause = new CodeCatchClause {
					Type = new CodeTypeReference(catchType),
					Variable = variable
				};

				tryStmt.Catches.Add(catchClause);

				WriteCode(null, catchBlock, catchClause.Statements, tryContext);
			}

			if (block.Try.Finally != null) {
				WriteCode(null, (BasicBlock)block.Try.Finally, tryStmt.Finally, tryContext);
			}

			if (block.Try.Follow != null) {
				return WriteCode(block, (BasicBlock)block.Try.Follow, stmts, context);
			}

			return true;
		}

		private bool WriteLoop(BasicBlock block, List<CodeStatement> stmts, Context context) {
			var loop = block.Loop;
			Debug.Assert(loop.Header == block);
			switch (loop.LoopType) {
				case LoopType.While:
					return WriteWhileLoop(block, loop, stmts, context);
				case LoopType.Repeat:
					return WriteRepeatLoop(block, loop, stmts, context);
				case LoopType.Endless:
					return WriteEndlessLoop(block, loop, stmts, context);
				default:
					throw new InvalidOperationException();
			}
		}

		private bool WriteSwitch(BasicBlock block, List<CodeStatement> stmts, Context context) {
			AddManyStatements(stmts, block.Statements);
			var switchStmt = (CodeSwitchStatement)block.Statements.Last();

			var targets = (Instruction[])block.LastInstruction.Operand;
			var casesByOffset = new Dictionary<int, CodeCase>();
			var follow = block.Conditional.Follow;

			foreach (BasicBlock succ in block.Successors) {
				CodeCase codeCase = new CodeCase();
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					var followContext = context;
					if (follow != null) {
						followContext = context.NewUntil(follow);
					}
					if (!WriteCode(block, succ, codeCase.Statements, followContext)) {
						codeCase.Statements.Add(new CodeBreakStatement());
					}
				}
				casesByOffset.Add(succ.BeginOffset, codeCase);
			}

			for (int i = 0; i < targets.Length; i++) {
				int offset = targets[i].Offset;
				var codeCase = casesByOffset[offset];
				codeCase.Expressions.Add(new CodePrimitiveExpression(i));
			}

			switchStmt.Cases.AddRange(casesByOffset.Values);

			if (follow != null) {
				return WriteCode(null, (BasicBlock)follow, stmts, context);
			}

			return false;
		}

		private bool WriteIf(BasicBlock block, Conditional conditional, List<CodeStatement> stmts, Context context) {
			var preStmts = block.Statements.Take(block.Statements.Count - 1);
			AddManyStatements(stmts, preStmts);

			var last = (CodeExpressionStatement)block.Statements.Last();
			var ifStmt = new CodeIfStatement {
				Condition = last.Expression
			};

			AddStatement(stmts, ifStmt);
		
			bool emptyThen = false;
			// is there a follow?
			if (conditional.Follow != null && conditional.Follow != context.LoopFollow) {
				// process the THEN part
				bool isBreak = false;
				var succ = block.ThenEdge;
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					if (succ != conditional.Follow) {
						// THEN part 
						ifStmt.Condition = ifStmt.Condition.Invert();
						isBreak = WriteCode(block, (BasicBlock)succ, ifStmt.TrueStatements, context.NewUntil(conditional.Follow));
					}
					else {
						// empty THEN part => negate ELSE part
						isBreak = WriteCode(block, (BasicBlock)block.ElseEdge, ifStmt.TrueStatements, context.NewUntil(conditional.Follow));
						emptyThen = true;
					}
				}

				// process the ELSE part
				succ = block.ElseEdge;
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					if (succ != conditional.Follow) {
						// ELSE part
						var output = ifStmt.FalseStatements;
						if (isBreak)
							output = stmts;
						WriteCode(block, (BasicBlock)succ, output, context.NewUntil(conditional.Follow));
					}
				}
				else if (!emptyThen) {
					// already visited => emit label
					throw new InvalidOperationException();
				}

				// Continue with the follow
				return WriteCode(null, (BasicBlock)conditional.Follow, stmts, context);
			}
			else {
				// no follow => if..then..else
				ifStmt.Condition = ifStmt.Condition.Invert();
				var isBreak = WriteCode(block, (BasicBlock)block.ThenEdge, ifStmt.TrueStatements, context);
				var output = ifStmt.FalseStatements;
				if (isBreak)
					output = stmts;
				return WriteCode(block, (BasicBlock)block.ElseEdge, output, context);
			}
		}

		private bool WriteWhileLoop(BasicBlock block, Loop loop, List<CodeStatement> stmts, Context context) {
			var loopContext = context.NewLoop(loop);

			CodeWhileStatement whileStmt;
			if (block.Statements.Count > 1) {
				// emit a while(true) { $bb.stmts; if($condition) { $then_stmts; break; } ... }
				whileStmt = new CodeWhileStatement {
					TestExpression = new CodePrimitiveExpression(true)
				};

				var conditional = new Conditional(this.graph, block);
				WriteIf(block, conditional, whileStmt.Statements, loopContext);
			}
			else {
				var last = (CodeExpressionStatement)block.Statements.Last();
				var test = last.Expression;

				if (block.ElseEdge == loop.Follow) {
					test = test.Invert();
				}

				// emit a pre-tested loop
				whileStmt = new CodeWhileStatement {
					TestExpression = test
				};
			}

			AddStatement(stmts, whileStmt);

			if (!loop.Tails.Contains(block)) {
				WriteLoopInner(block, loop, whileStmt.Statements, loopContext);
			}

			if (loop.Follow != null) {
				return WriteCode(null, (BasicBlock)loop.Follow, stmts, context);
			}
			return false;
		}

		private bool WriteRepeatLoop(BasicBlock block, Loop loop, List<CodeStatement> stmts, Context context) {
			var loopContext = context.NewLoop(loop);

			var last = (CodeExpressionStatement)block.Statements.Last();
			var test = last.Expression;
			CodeRepeatStatement repeatStmt = new CodeRepeatStatement {
				TestExpression = test
			};

			AddStatement(stmts, repeatStmt);

			if (!loop.Tails.Contains(block)) {
				WriteLoopInner(block, loop, repeatStmt.Statements, loopContext);
			}

			var preTestStmts = block.Statements.Take(block.Statements.Count - 1);
			repeatStmt.Statements.AddRange(preTestStmts);

			if (loop.Follow != null) {
				return WriteCode(null, (BasicBlock)loop.Follow, stmts, context);
			}
			return false;
		}

		private bool WriteEndlessLoop(BasicBlock block, Loop loop, List<CodeStatement> stmts, Context context) {
			var loopContext = context.NewLoop(loop);

			CodeWhileStatement whileStmt = new CodeWhileStatement {
				TestExpression = new CodePrimitiveExpression(true)
			};

			AddStatement(stmts, whileStmt);

			if (block.Successors.Count > 1) {
				var conditional = new Conditional(this.graph, block);
				WriteIf(block, conditional, whileStmt.Statements, loopContext);
			}
			else {
				WriteBasicBlock(block, whileStmt.Statements);
			}

			if (!loop.Tails.Contains(block)) {
				WriteLoopInner(block, loop, whileStmt.Statements, loopContext);
			}

			if (loop.Follow != null) {
				return WriteCode(null, (BasicBlock)loop.Follow, stmts, context);
			}
			return false;
		}

		private void WriteLoopInner(BasicBlock block, Loop loop, List<CodeStatement> stmts, Context context) {
			Node succ;
			if (block.Successors.Count > 1) {
				succ = block.ThenEdge;
				if (succ == loop.Follow) {
					succ = block.ElseEdge;
				}
			}
			else {
				succ = block.Successors.First();
			}

			WriteCode(block, (BasicBlock)succ, stmts, context);
		}

		private bool WriteBasicBlock(BasicBlock block, List<CodeStatement> stmts) {
			foreach (var stmt in block.Statements) {
				if (stmt is CodeGotoStatement)
					continue;

				AddStatement(stmts, stmt);
			}

			if (block.FlowControl == FlowControl.Return || 
				block.FlowControl == FlowControl.Throw) {

				var lastReturn = stmts.LastOrDefault() as CodeReturnStatement;
				if (lastReturn != null) {
					var lastAssignment = lastReturn.Previous as CodeAssignStatement;
					if (lastAssignment != null) {
						var lhsVariable = lastAssignment.Left as CodeVariableReference;
						var rhsVariable = lastReturn.Expression as CodeVariableReference;
						if (lhsVariable != null && rhsVariable != null && lhsVariable.Variable == rhsVariable.Variable) {

							lastReturn.Previous = lastAssignment.Previous;
							stmts.Remove(lastAssignment);

							lastReturn.Expression = lastAssignment.Right;
						}
					}
				}
				return true;
			}
			return false;
		}

		private void AddStatement(List<CodeStatement> stmts, CodeStatement stmt) {
			var last = stmts.LastOrDefault();
			if (last != null) {
				last.Next = stmt;
				stmt.Previous = last;
			}
			stmts.Add(stmt);
		}

		private void AddManyStatements(List<CodeStatement> stmts, IEnumerable<CodeStatement> range) {
			foreach (var stmt in range) {
				AddStatement(stmts, stmt);
			}
		}
	}
}
