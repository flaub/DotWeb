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
using DotWeb.Decompiler.CodeModel;
using Mono.Cecil.Cil;
using System.Diagnostics;

namespace DotWeb.Decompiler.Core
{
	class BackEnd
	{
		public ControlFlowGraph Cfg { get; private set; }
		public CodeMethodMember Method { get; private set; }

		class Context
		{
			private ControlFlowGraph cfg;
			public Node LatchNode { get; private set; }
			public Node IfFollow { get; private set; }
			public Node LoopFollow { get; private set; }
			public Node LoopHeader { get; private set; }

			public Context(ControlFlowGraph cfg) {
				this.cfg = cfg;
				this.LatchNode = null;
				this.IfFollow = null;
				this.LoopHeader = null;
				this.LoopFollow = null;
			}

			public Context Clone() {
				return new Context(this.cfg) {
					LatchNode = this.LatchNode,
					IfFollow = this.IfFollow,
					LoopFollow = this.LoopFollow,
					LoopHeader = this.LoopHeader
				};
			}

			public Context NewIfFollow(int ifFollow) {
				var node = this.cfg.DepthFirstPostOrder[ifFollow];
				var ctx = this.Clone();
				ctx.IfFollow = node;
				return ctx;
			}

			public Context NewLatch(Node latchNode) {
				var ctx = this.Clone();
				ctx.LatchNode = latchNode;
				return ctx;
			}

			public Context NewLoop(int loopHeader, int loopFollow) {
				var ctx = this.Clone();
				ctx.LoopHeader = this.cfg.DepthFirstPostOrder[loopHeader];
				ctx.LoopFollow = this.cfg.DepthFirstPostOrder[loopFollow];
				return ctx;
			}
		}

		public BackEnd(ControlFlowGraph cfg) {
			this.Cfg = cfg;

			this.Method = new CodeMethodMember(cfg.Method) {
				ExternalMethods = cfg.ExternalMethods
			};

			//foreach (LocalVariableInfo local in cfg.Method.GetMethodBody().LocalVariables) {
			//    this.Method.Statements.Add(new CodeVariableDeclarationStatement(
			//        local.LocalType, 
			//        CodeDomGenerator.LocalVariable(local.LocalIndex)
			//    ));
			//}
		}

		public void WriteCode() {
			this.WriteCode(this.Cfg.Root, new Context(this.Cfg), this.Method.Statements);
		}

		private void WriteIf(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			int i = 0;
			for (i = 0; i < bb.Statements.Count - 1; i++) {
				stmts.Add(bb.Statements[i]);
			}

			CodeStatement last = bb.Statements[i];
			CodeExpressionStatement ces = last as CodeExpressionStatement;
			CodeExpression test = ces.Expression;
			CodeIfStatement condition = new CodeIfStatement();
			stmts.Add(condition);

			bool emptyThen = false;
			// is there a follow?
			if (bb.IfFollow != Node.NoNode) {
				// process the THEN part
				Node succ = bb.ThenEdge;
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					// not visited
					context = context.NewIfFollow(bb.IfFollow);
					if (succ.DfsPostOrder != bb.IfFollow) {
						// THEN part 
						test = test.Invert();
						WriteCode((BasicBlock)succ, context, condition.TrueStatements);
					}
					else {
						// empty THEN part => negate ELSE part
						WriteCode((BasicBlock)bb.ElseEdge, context, condition.TrueStatements);
						emptyThen = true;
					}
				}

				// process the ELSE part
				succ = bb.ElseEdge;
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					if (succ.DfsPostOrder != bb.IfFollow) {
						// ELSE part
						WriteCode((BasicBlock)succ, context.NewIfFollow(bb.IfFollow), condition.FalseStatements);
					}
				}
				else if (!emptyThen) {
					// already visited => emit label
					throw new InvalidOperationException();
				}

				// Continue with the follow
				succ = this.Cfg.DepthFirstPostOrder[bb.IfFollow];
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					WriteCode((BasicBlock)succ, context, stmts);
				}
			}
			else {
				// no follow => if..then..else
				test = test.Invert();
				WriteCode((BasicBlock)bb.ThenEdge, context, condition.TrueStatements);
				WriteCode((BasicBlock)bb.ElseEdge, context, condition.FalseStatements);
			}

			condition.Condition = test;
		}

		private void WriteLoopInner(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			Node succ;
			if (bb.LoopType == LoopType.While) {
				succ = bb.ThenEdge;
				if (succ.DfsPostOrder == bb.LoopFollow) {
					succ = bb.ElseEdge;
				}
			}
			else {
				succ = bb.Successors.First();
			}

			if (succ.DfsTraversed != DfsTraversal.Alpha) {
				WriteCode((BasicBlock)succ, context.NewLatch(bb.LatchNode), stmts);
			}
		}

		private void WriteLoopFollow(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			Node succ = this.Cfg.DepthFirstPostOrder[bb.LoopFollow];
			if (succ.DfsTraversed != DfsTraversal.Alpha) {
				WriteCode((BasicBlock)succ, context, stmts);
			}
		}

		private void WriteWhileLoop(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			context = context.NewLoop(bb.LoopHead, bb.LoopFollow);

			CodeWhileStatement loop;
			if (bb.Statements.Count > 1) {
				// emit a while(true) { $bb.stmts; if($condition) { $then_stmts; break; } ... }
				loop = new CodeWhileStatement {
					TestExpression = new CodePrimitiveExpression(true)
				};

				WriteIf(bb, context, loop.Statements);
			}
			else {
				CodeStatement last = bb.Statements.Last();
				CodeExpressionStatement ces = last as CodeExpressionStatement;
				CodeExpression test = ces.Expression;

				if (bb.ElseEdge.DfsPostOrder == bb.LoopFollow) {
					test = test.Invert();
				}

				// emit a pre-tested loop
				loop = new CodeWhileStatement {
					TestExpression = test
				};
			}

			stmts.Add(loop);

			if (bb != bb.LatchNode) {
				WriteLoopInner(bb, context, loop.Statements);
			}

			if (bb.LoopFollow != Node.NoNode) {
				WriteLoopFollow(bb, context, stmts);
			}
		}

		private void WriteRepeatLoop(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			List<CodeStatement> temp = new List<CodeStatement>();
			int i = 0;
			for (i = 0; i < bb.Statements.Count - 1; i++) {
				temp.Add(bb.Statements[i]);
			}
			CodeStatement last = bb.Statements[i];
			CodeExpressionStatement ces = last as CodeExpressionStatement;
			CodeExpression test = ces.Expression;
			CodeRepeatStatement loop = new CodeRepeatStatement {
				TestExpression = test
			};

			stmts.Add(loop);

			if (bb != bb.LatchNode) {
				WriteLoopInner(bb, context, loop.Statements);
			}

			loop.Statements.AddRange(temp);

			if (bb.LoopFollow != Node.NoNode) {
				WriteLoopFollow(bb, context, stmts);
			}
		}

		private void WriteLoop(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			switch (bb.LoopType) {
				case LoopType.While:
					WriteWhileLoop(bb, context, stmts);
					break;
				case LoopType.Repeat:
					WriteRepeatLoop(bb, context, stmts);
					break;
				case LoopType.Endless:
					Debug.Assert(false);
					//loop = new CodeWhileStatement {
					//    TestExpression = new CodePrimitiveExpression(true)
					//};
					break;
				default:
					throw new InvalidOperationException();
			}
		}

		private void WriteCode(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			if ((context.IfFollow != null) && (bb == context.IfFollow)) {
				return;
			}
			if (bb.DfsTraversed == DfsTraversal.Alpha) {
				return;
			}
			bb.DfsTraversed = DfsTraversal.Alpha;

			if (bb.LoopType != LoopType.None) {
				WriteLoop(bb, context, stmts);
			}
			else if (bb.IsTwoWay) {
				WriteIf(bb, context, stmts);
			}
			else if (bb.FlowControl == FlowControl.Return ||
				bb.FlowControl == FlowControl.Throw ||
				bb == context.LatchNode) {
				WriteBasicBlock(bb, context, stmts);
				return;
			}
			else if (bb.IsMultiWay) {
				WriteCases(bb, context, stmts);
			}
			else {
				WriteBasicBlock(bb, context, stmts);
				Node succ = bb.Successors.First();
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					WriteCode((BasicBlock)succ, context, stmts);
				}
			}
		}

		private void WriteCases(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			int i = 0;
			for (i = 0; i < bb.Statements.Count - 1; i++) {
				stmts.Add(bb.Statements[i]);
			}

			CodeStatement last = bb.Statements[i];
			CodeSwitchStatement sw = last as CodeSwitchStatement;
			stmts.Add(sw);

			var cases = (Instruction[])bb.LastInstruction.Operand;
			Dictionary<int, CodeCase> ccDict = new Dictionary<int, CodeCase>();
			foreach (BasicBlock succ in bb.Successors) {
				CodeCase cc = new CodeCase();
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					WriteCode(succ, context.NewIfFollow(bb.CaseTail), cc.Statements);
				}
				ccDict.Add(succ.BeginOffset, cc);
			}

			for (int j = 0; j < cases.Length; j++) {
				int offset = cases[j].Offset;
				CodeCase cc = ccDict[offset];
				cc.Expressions.Add(new CodePrimitiveExpression(j));
			}

			sw.Cases.AddRange(ccDict.Values);

			if (bb.CaseTail != Node.NoNode) {
				/* Continue with the follow */
				Node next = this.Cfg.DepthFirstPostOrder[bb.CaseTail];
				if (next.DfsTraversed != DfsTraversal.Alpha) {
					WriteCode((BasicBlock)next, context, stmts);
				}
			}
		}

		private void WriteBasicBlock(BasicBlock bb, Context context, List<CodeStatement> stmts) {
			foreach (CodeStatement stmt in bb.Statements) {
				var gotoStmt = stmt as CodeGotoStatement;
				if (gotoStmt != null) {
					if (context.LoopFollow != null) {
						var bbFollow = (BasicBlock)context.LoopFollow;
						if (bbFollow.FirstInstruction == gotoStmt.Target) {
							stmts.Add(new CodeBreakStatement());
							continue;
						}
					}
					if (context.LoopHeader != null) {
						var bbHeader = (BasicBlock)context.LoopHeader;
						if (bbHeader.FirstInstruction == gotoStmt.Target) {
							stmts.Add(new CodeContinueStatement());
							continue;
						}
					}
				}
				else {
					stmts.Add(stmt);
				}
			}
		}
	}
}
