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
using System.Reflection.Emit;
using System.Reflection;
using DotWeb.Decompiler.CodeModel;

namespace DotWeb.Decompiler.Core
{
	class BackEnd
	{
		public ControlFlowGraph Cfg { get; private set; }
		public CodeMethodMember Method { get; private set; }

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
			this.WriteCode(this.Cfg.Root, Node.NoNode, Node.NoNode, this.Method.Statements);
		}

		private void WriteIf(BasicBlock bb, int latchNode, int ifFollow, List<CodeStatement> stmts) {
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
			if (bb.IfFollow != Node.NoNode) /* there is a follow */ {
				/* process the THEN part */
				Node succ = bb.OutEdges[Node.ThenEdge];
				if (succ.DfsTraversed != DfsTraversal.Alpha) /* not visited */ {
					if (succ.DfsLastNumber != bb.IfFollow) /* THEN part */ {
						test = test.Invert();
						WriteCode((BasicBlock)succ, latchNode, bb.IfFollow, condition.TrueStatements);
					}
					else /* empty THEN part => negate ELSE part */ {
						WriteCode((BasicBlock)bb.OutEdges[Node.ElseEdge], latchNode, bb.IfFollow, condition.TrueStatements);
						emptyThen = true;
					}
				}

				/* process the ELSE part */
				succ = bb.OutEdges[Node.ElseEdge];
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					if (succ.DfsLastNumber != bb.IfFollow) /* ELSE part */ {
						WriteCode((BasicBlock)succ, latchNode, bb.IfFollow, condition.FalseStatements);
					}
				}
				else if (!emptyThen) /* already visited => emit label */ {
					throw new InvalidOperationException();
				}

				/* Continue with the follow */
				succ = this.Cfg.DfsList[bb.IfFollow];
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					WriteCode((BasicBlock)succ, latchNode, ifFollow, stmts);
				}
			}
			else /* no follow => if..then..else */ {
				test = test.Invert();
				WriteCode((BasicBlock)bb.OutEdges[Node.ThenEdge], latchNode, ifFollow, condition.TrueStatements);
				WriteCode((BasicBlock)bb.OutEdges[Node.ElseEdge], latchNode, ifFollow, condition.FalseStatements);
			}

			condition.Condition = test;
		}

		private void WriteLoopInner(BasicBlock bb, int latchNode, int ifFollow, List<CodeStatement> stmts) {
			Node succ;
			if (bb.LoopType == LoopType.While) {
				succ = bb.OutEdges[Node.ThenEdge];
				if (succ.DfsLastNumber == bb.LoopFollow) {
					succ = bb.OutEdges[Node.ElseEdge];
				}
			}
			else {
				succ = bb.OutEdges.First();
			}

			if (succ.DfsTraversed != DfsTraversal.Alpha) {
				WriteCode((BasicBlock)succ, bb.LatchNode.DfsLastNumber, ifFollow, stmts);
			}
		}

		private void WriteLoopFollow(BasicBlock bb, int latchNode, int ifFollow, List<CodeStatement> stmts) {
			Node succ = this.Cfg.DfsList[bb.LoopFollow];
			if (succ.DfsTraversed != DfsTraversal.Alpha) {
				WriteCode((BasicBlock)succ, latchNode, ifFollow, stmts);
			}
		}

		private void WriteWhileLoop(BasicBlock bb, int latchNode, int ifFollow, List<CodeStatement> stmts) {
			int i = 0;
			for (i = 0; i < bb.Statements.Count - 1; i++) {
				stmts.Add(bb.Statements[i]);
			}

			CodeStatement last = bb.Statements[i];
			CodeExpressionStatement ces = last as CodeExpressionStatement;
			CodeExpression test = ces.Expression;
			if (bb.OutEdges[Node.ElseEdge].DfsLastNumber == bb.LoopFollow) {
				test = test.Invert();
			}

			CodeWhileStatement loop = new CodeWhileStatement {
				TestExpression = test
			};

			stmts.Add(loop);

			if (bb != bb.LatchNode) {
				WriteLoopInner(bb, latchNode, ifFollow, loop.Statements);
			}

			if (bb.LoopFollow != Node.NoNode) {
				WriteLoopFollow(bb, latchNode, ifFollow, stmts);
			}
		}

		private void WriteRepeatLoop(BasicBlock bb, int latchNode, int ifFollow, List<CodeStatement> stmts) {
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
				WriteLoopInner(bb, latchNode, ifFollow, loop.Statements);
			}

			loop.Statements.AddRange(temp);

			if (bb.LoopFollow != Node.NoNode) {
				WriteLoopFollow(bb, latchNode, ifFollow, stmts);
			}
		}

		private void WriteLoop(BasicBlock bb, int latchNode, int ifFollow, List<CodeStatement> stmts) {
			switch (bb.LoopType) {
				case LoopType.While:
					WriteWhileLoop(bb, latchNode, ifFollow, stmts);
					break;
				case LoopType.Repeat:
					WriteRepeatLoop(bb, latchNode, ifFollow, stmts);
					break;
				//case LoopType.Endless:
				//    loop = new CodeWhileStatement {
				//        TestExpression = new CodePrimitiveExpression(true)
				//    };
				//    break;
				default:
					throw new InvalidOperationException();
			}
		}

		private void WriteCode(BasicBlock bb, int latchNode, int ifFollow, List<CodeStatement> stmts) {
			if ((ifFollow != Node.NoNode) && (bb == this.Cfg.DfsList[ifFollow])) {
				return;
			}
			if (bb.DfsTraversed == DfsTraversal.Alpha) {
				return;
			}
			bb.DfsTraversed = DfsTraversal.Alpha;

			if (bb.LoopType != LoopType.None) {
				WriteLoop(bb, latchNode, ifFollow, stmts);
			}
			else if (bb.IsTwoWay) {
				WriteIf(bb, latchNode, ifFollow, stmts);
			}
			else if (bb.FlowControl == FlowControl.Return || 
				bb.FlowControl == FlowControl.Throw || 
				bb.DfsLastNumber == latchNode) {
				WriteBasicBlock(bb, stmts);
				return;
			}
			else if (bb.IsMultiWay) {
				WriteCases(bb, latchNode, ifFollow, stmts);
			}
			else {
				WriteBasicBlock(bb, stmts);
				Node succ = bb.OutEdges.First();
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					WriteCode((BasicBlock)succ, latchNode, ifFollow, stmts);
				}
			}
		}

		private void WriteCases(BasicBlock bb, int latchNode, int ifFollow, List<CodeStatement> stmts) {
			int i = 0;
			for (i = 0; i < bb.Statements.Count - 1; i++) {
				stmts.Add(bb.Statements[i]);
			}

			CodeStatement last = bb.Statements[i];
			CodeSwitchStatement sw = last as CodeSwitchStatement;
			stmts.Add(sw);

			int[] cases = (int[])bb.LastInstruction.Operand;
			Dictionary<int, CodeCase> ccDict = new Dictionary<int, CodeCase>();
			foreach (BasicBlock succ in bb.OutEdges) {
				CodeCase cc = new CodeCase();
				if (succ.DfsTraversed != DfsTraversal.Alpha) {
					WriteCode(succ, latchNode, bb.CaseTail, cc.Statements);
				}
				ccDict.Add(succ.BeginOffset, cc);
			}

			for (int j = 0; j < cases.Length; j++) {
				int offset = cases[j];
				CodeCase cc = ccDict[offset];
				cc.Expressions.Add(new CodePrimitiveExpression(j));
			}

			sw.Cases.AddRange(ccDict.Values);

			if (bb.CaseTail != Node.NoNode) {
				/* Continue with the follow */
				Node next = this.Cfg.DfsList[bb.CaseTail];
				if (next.DfsTraversed != DfsTraversal.Alpha) {
					WriteCode((BasicBlock)next, latchNode, ifFollow, stmts);
				}
			}
		}

		private void WriteBasicBlock(BasicBlock bb, List<CodeStatement> stmts) {
			foreach (CodeStatement stmt in bb.Statements) {
				if (stmt is CodeGotoStatement)
					continue;
				stmts.Add(stmt);
			}
		}
	}
}
