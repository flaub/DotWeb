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
using System.Diagnostics;
using DotWeb.Translator.CodeModel;

namespace DotWeb.Translator
{
	class ControlFlowAnalyzer
	{
		public ControlFlowGraph Cfg { get; private set; }

		public ControlFlowAnalyzer(ControlFlowGraph cfg) {
			this.Cfg = cfg;
		}

		public void Structure() {
			FindImmediateDominator();
			if (Cfg.HasCases) {
				StructureCases();
			}
			StructureLoops();
			StructureIfs();
			CompoundConditions();

			//DisplayDfs(this.Cfg.Root);
		}

		private void CompoundConditions() {
			bool change = true;
			while (change) {
				change = false;
				/* Traverse nodes in postorder, this way, the header node of a
				 * compound condition is analysed first */
				for (int i = 0; i < this.Cfg.DfsList.Length; i++) {
					BasicBlock bb = this.Cfg.DfsList[i];

					if (bb.IsTwoWay) {
						BasicBlock bbThen = (BasicBlock)bb.OutEdges[Node.ThenEdge];
						BasicBlock bbElse = (BasicBlock)bb.OutEdges[Node.ElseEdge];

						if ((bbThen.IsTwoWay) &&
							(bbThen.Statements.Count == 1) &&
							(bbThen.InEdges.Count == 1)) {
							/* Check (X || Y) case */
							if (bbThen.OutEdges[Node.ElseEdge] == bbElse) {
								change = CompoundOr(bb, bbThen, bbElse);
							}
							/* Check (!X && Y) case */
							else if (bbThen.OutEdges[Node.ThenEdge] == bbElse) {
								change = CompoundNotAnd(bb, bbThen, bbElse);
							}
						}
						else if ((bbElse.IsTwoWay) &&
							(bbElse.Statements.Count == 1) &&
							(bbElse.InEdges.Count == 1)) {
							/* Check (X && Y) case */
							if (bbElse.OutEdges[Node.ThenEdge] == bbThen) {
								change = CompoundAnd(bb, bbThen, bbElse);
							}
							/* Check (!X || Y) case */
							else if (bbElse.OutEdges[Node.ElseEdge] == bbThen) {
								change = CompoundNotOr(bb, bbThen, bbElse);
							}
						}
					}
				}
			}
		}

		private bool CompoundOr(BasicBlock bb, BasicBlock bbThen, BasicBlock bbElse) {
			BasicBlock obb = (BasicBlock)bbThen.OutEdges[Node.ThenEdge];
			CodeExpressionStatement lhs = (CodeExpressionStatement)bb.LastStatement;
			CodeExpressionStatement rhs = (CodeExpressionStatement)bbThen.LastStatement;

			/* Construct compound DBL_OR expression */
			lhs.Expression = new CodeBinaryExpression(
				lhs.Expression,
				CodeBinaryOperator.BooleanOr,
				rhs.Expression
			);
			/* Replace in-edge to obb from t to pbb */
			for (int i = 0; i < obb.InEdges.Count; i++) {
				if (obb.InEdges[i] == bbThen) {
					obb.InEdges[i] = bb;
					break;
				}
			}
			/* New THEN out-edge of pbb */
			bb.OutEdges[Node.ThenEdge] = obb;

			/* Remove in-edge t to e */
			for (int i = 0; i < bbElse.InEdges.Count - 1; i++) {
				if (bbElse.InEdges[i] == bbThen) {
					bbElse.InEdges.RemoveAt(i);
					break;
				}
			}

			if (bb.IsLatchNode) {
				this.Cfg.DfsList[bbThen.DfsLastNumber] = bb;
			}
			else {
				// continue analysis
			}

			bb.InEdgeCount--;
			return true;
		}

		private bool CompoundNotAnd(BasicBlock bb, BasicBlock bbThen, BasicBlock bbElse) {
			BasicBlock obb = (BasicBlock)bbThen.OutEdges[Node.ElseEdge];
			CodeExpressionStatement lhs = (CodeExpressionStatement)bb.LastStatement;
			CodeExpressionStatement rhs = (CodeExpressionStatement)bbThen.LastStatement;

			/* Construct compound DBL_AND expression */
			lhs.Expression = new CodeBinaryExpression(
				lhs.Expression.Invert(),
				CodeBinaryOperator.BooleanAnd,
				rhs.Expression
			);

			/* Replace in-edge to obb from t to pbb */
			for (int i = 0; i < obb.InEdges.Count; i++) {
				if (obb.InEdges[i] == bbThen) {
					obb.InEdges[i] = bb;
					break;
				}
			}

			/* New THEN and ELSE out-edges of pbb */
			bb.OutEdges[Node.ThenEdge] = bbElse;
			bb.OutEdges[Node.ElseEdge] = obb;

			/* Remove in-edge t to e */
			for (int i = 0; i < (bbElse.InEdges.Count - 1); i++) {
				if (bbElse.InEdges[i] == bbThen) {
					bbElse.InEdges.RemoveAt(i);
					break;
				}
			}
			if (bb.IsLatchNode) {
				this.Cfg.DfsList[bbThen.DfsLastNumber] = bb;
			}

			return true;
		}

		private bool CompoundAnd(BasicBlock bb, BasicBlock bbThen, BasicBlock bbElse) {
			return false;
		}

		private bool CompoundNotOr(BasicBlock bb, BasicBlock bbThen, BasicBlock bbElse) {
			return false;
		}

		private void DisplayDfs(BasicBlock bb) {
			bb.DfsTraversed = DfsTraversal.Display;

			Console.WriteLine("{0}: NodeType: {1}, in: {2}, out: {3}",
				bb.RefName, bb.FlowControl, bb.InEdges.Count, bb.OutEdges.Count);
			Console.WriteLine("dfsFirst: {0}, dfsLast: {1}, immedDom: {2}",
				bb.DfsFirstNumber, bb.DfsFirstNumber, bb.ImmediateDominator);

			string latch = "(null)";
			if (bb.LatchNode != null)
				latch = bb.LatchNode.RefName;
			Console.WriteLine("LoopType: {0}, LoopHead: {1}, LatchNode: {2}, Follow: {3}",
				bb.LoopType, bb.LoopHead, latch, bb.LoopFollow);
			Console.WriteLine("IfFollow: {0}",
				bb.IfFollow);
			Console.WriteLine("----");

			foreach (Node node in bb.OutEdges) {
				if (node.DfsTraversed != DfsTraversal.Display)
					DisplayDfs((BasicBlock)node);
			}
		}

		/// <summary>
		/// Finds the immediate dominator of each node in the graph pProc->cfg. 
		/// Adapted version of the dominators algorithm by Hecht and Ullman; finds
		/// immediate dominators only.  
		/// Note: graph should be reducible
		/// </summary>
		private void FindImmediateDominator() {
			Node[] dfsList = this.Cfg.DfsList;
			for (int curIndex = 0; curIndex < dfsList.Length; curIndex++) {
				Node node = dfsList[curIndex];
				foreach (Node pred in node.InEdges) {
					int predIndex = pred.DfsLastNumber;
					if (predIndex < curIndex) {
						node.ImmediateDominator = CommonDominator(node.ImmediateDominator, predIndex);
					}
				}
			}
		}

		/// <summary>
		/// Finds the common dominator of the current immediate dominator
		/// currImmDom and its predecessor's immediate dominator predImmDom
		/// </summary>
		private int CommonDominator(int curImmDom, int predImmDom) {
			if (curImmDom == Node.NoDominator)
				return predImmDom;
			if (predImmDom == Node.NoDominator)
				return curImmDom;
			while ((curImmDom != Node.NoDominator) && (predImmDom != Node.NoDominator) &&
				(curImmDom != predImmDom)) {
				if (curImmDom < predImmDom)
					predImmDom = this.Cfg.DfsList[predImmDom].ImmediateDominator;
				else
					curImmDom = this.Cfg.DfsList[curImmDom].ImmediateDominator;
			}
			return curImmDom;
		}

		private bool IsSuccessor(int successor, int header)
		{
			return Cfg.DfsList[header].OutEdges.Any(x => x.DfsLastNumber == successor);
		}

		private void StructureCases() {
			int exitNode = Node.NoNode;
			List<int> caseNodes = new List<int>();

			/* Linear scan of the nodes in reverse dfsLast order, searching for
			 * case nodes                           */
			for (int i = Cfg.DfsList.Length - 1; i >= 0; i--) {
				BasicBlock caseHeader = (BasicBlock)Cfg.DfsList[i];
				if (caseHeader.LastInstruction.Code != OpCodes.Switch)
					continue;

				/* Find descendant node which has as immediate predecessor 
				 * the current header node, and is not a successor.    */
				for (int j = i + 2; j < Cfg.DfsList.Length; j++) {
					if (!IsSuccessor(j, i) && Cfg.DfsList[j].ImmediateDominator == i) {
						if (exitNode == Node.NoNode) {
							exitNode = j;
						}
						else if (Cfg.DfsList[exitNode].InEdges.Count < Cfg.DfsList[j].InEdges.Count) {
							exitNode = j;
						}
					}
				}
				caseHeader.CaseTail = exitNode;

				/* Tag nodes that belong to the case by recording the
				 * header field with caseHeader.           */

				caseNodes.Add(i);
				caseHeader.CaseHead = i;
				foreach (BasicBlock node in caseHeader.OutEdges) {
					TagNodesInCase(node, caseNodes, i, exitNode);
				}
				if (exitNode != Node.NoNode) {
					Cfg.DfsList[exitNode].CaseHead = i;
				}
			}
		}

		/// <summary>
		/// Recursive procedure to tag nodes that belong to the case described by
		/// the list l, head and tail (dfsLast index to first and exit node of the case).
		/// </summary>
		/// <param name="node"></param>
		/// <param name="caseNodes"></param>
		/// <param name="i"></param>
		/// <param name="exitNode"></param>
		private void TagNodesInCase(BasicBlock node, List<int> list, int head, int tail) {
			node.DfsTraversed = DfsTraversal.Case;
			int current = node.DfsLastNumber;
			if ((current != tail) &&
				(node.LastInstruction.Code != OpCodes.Switch) &&
				list.Contains(node.ImmediateDominator)) {
				list.Add(current);
				node.CaseHead = head;
				foreach (BasicBlock bb in node.OutEdges) {
					if (bb.DfsTraversed != DfsTraversal.Case) {
						TagNodesInCase(bb, list, head, tail);
					}
				}
			}
		}

		/// <summary>
		/// Checks if the edge (p,s) is a back edge.  If node s was visited first  
		/// during the dfs traversal (ie. s has a smaller dfsFirst number) or s == p,
		/// then it is a backedge. 
		/// Also incrementes the number of backedges entries to the header node. 
		/// </summary>
		/// <param name="lhs"></param>
		/// <param name="rhs"></param>
		/// <returns></returns>
		private bool IsBackEdge(Node pred, Node succ) {
			if (pred.DfsFirstNumber >= succ.DfsFirstNumber) {
				succ.BackEdgeCount++;
				return true;
			}
			return false;
		}

		private void StructureLoops() {
			int level = 0;
			foreach (IntervalGraph graph in this.Cfg.Graphs) {
				level++;
				foreach (Interval interval in graph) {
					/* Find nodes that belong to the interval (nodes from G1) */
					List<Node> nodes = new List<Node>();
					interval.CollectNodes(nodes);
					BasicBlock head = (BasicBlock)nodes.First();

					BasicBlock latchNode = null;
					/* Find greatest enclosing back edge (if any) */
					foreach (BasicBlock pred in head.InEdges) {
						if (nodes.Contains(pred) && IsBackEdge(pred, head)) {
							if (latchNode == null) {
								latchNode = pred;
							}
							else {
								if (pred.DfsLastNumber > latchNode.DfsLastNumber)
									latchNode = pred;
							}
						}
					}

					/* Find nodes in the loop and the type of loop */
					if (latchNode != null) {
						/* Check latching node is at the same nesting level of case
						 * statements (if any) and that the node doesn't belong to
						 * another loop.                   */
						if ((latchNode.CaseHead == head.CaseHead) &&
							(latchNode.LoopHead == Node.NoNode)) {
							head.LatchNode = latchNode;
							FindNodesInLoop(latchNode, head, nodes);
							latchNode.IsLatchNode = true;
						}
					}
				}
			}
		}

		/// <summary>
		/// Flags nodes that belong to the loop determined by (latchNode, head) and  
		/// determines the type of loop.
		/// </summary>
		/// <param name="latchNode"></param>
		/// <param name="headerNode"></param>
		/// <param name="nodes"></param>
		private void FindNodesInLoop(BasicBlock latchNode, BasicBlock headerNode, List<Node> nodes) {
			headerNode.LoopHead = headerNode.DfsLastNumber;

			List<int> loopNodes = new List<int>();
			loopNodes.Add(headerNode.LoopHead);

			for (int i = headerNode.LoopHead + 1; i < latchNode.DfsLastNumber; i++) {
				Node node = this.Cfg.DfsList[i];
				int immedDom = node.ImmediateDominator;
				if (loopNodes.Contains(immedDom) && nodes.Contains(node)) {
					loopNodes.Add(i);
					if (node.LoopHead == Node.NoNode) {
						node.LoopHead = headerNode.LoopHead;
					}
				}
			}

			ClassifyLoop(headerNode, latchNode, loopNodes);
		}

		private void ClassifyLoop(BasicBlock headerNode, BasicBlock latchNode, List<int> loopNodes) {
			int thenDfs = headerNode.OutEdges[Node.ThenEdge].DfsLastNumber;
			int elseDfs = Node.NoNode;
			if (headerNode.OutEdges.Count > 1)
				elseDfs = headerNode.OutEdges[Node.ElseEdge].DfsLastNumber;

			latchNode.LoopHead = headerNode.LoopHead;
			if (latchNode.IsTwoWay) {
				if ((headerNode.IsTwoWay) || (latchNode == headerNode)) {
					if ((latchNode == headerNode) ||
						loopNodes.Contains(thenDfs) &&
						loopNodes.Contains(elseDfs)) {
						headerNode.LoopType = LoopType.Repeat;
						if (latchNode.OutEdges[Node.ThenEdge] == headerNode)
							headerNode.LoopFollow = latchNode.OutEdges[Node.ElseEdge].DfsLastNumber;
						else
							headerNode.LoopFollow = latchNode.OutEdges[Node.ThenEdge].DfsLastNumber;
						latchNode.IsLoopNode = true;
					}
					else {
						headerNode.LoopType = LoopType.While;
						if (loopNodes.Contains(thenDfs))
							headerNode.LoopFollow = elseDfs;
						else
							headerNode.LoopFollow = thenDfs;
						headerNode.IsLoopNode = true;
					}
				}
				else /* head = anything besides 2-way, latch = 2-way */ {
					headerNode.LoopType = LoopType.Repeat;
					if (latchNode.OutEdges[Node.ThenEdge] == headerNode)
						headerNode.LoopFollow = latchNode.OutEdges[Node.ElseEdge].DfsLastNumber;
					else
						headerNode.LoopFollow = latchNode.OutEdges[Node.ThenEdge].DfsLastNumber;
					latchNode.IsLoopNode = true;
				}
			}
			else /* latch = 1-way */ {
				if (headerNode.IsTwoWay) {
					headerNode.LoopType = LoopType.While;
					Node node = latchNode;
					while (true) {
						if (node.DfsLastNumber == thenDfs) {
							headerNode.LoopFollow = elseDfs;
							break;
						}
						else if (node.DfsLastNumber == elseDfs) {
							headerNode.LoopFollow = thenDfs;
							break;
						}
						/* Check if couldn't find it, then it is a strangely formed
						 * loop, so it is safer to consider it an endless loop */
						if (node.DfsLastNumber <= headerNode.DfsLastNumber) {
							headerNode.LoopType = LoopType.Endless;
							// findEndlessFollow();
							break;
						}

						node = this.Cfg.DfsList[node.ImmediateDominator];
					}

					if (node.DfsLastNumber > headerNode.DfsLastNumber) {
						this.Cfg.DfsList[headerNode.LoopFollow].LoopHead = Node.NoNode;
					}
					headerNode.IsLoopNode = true;
				}
				else {
					headerNode.LoopType = LoopType.Endless;
					// findEndlessFollow();
				}
			}
		}

		private void StructureIfs() {
			int bbCount = this.Cfg.DfsList.Length;
			List<int> domDesc = new List<int>();
			List<int> unresolved = new List<int>();

			/* Linear scan of nodes in reverse dfsLast order */
			for (int cur = bbCount - 1; cur >= 0; cur--) {
				BasicBlock curNode = (BasicBlock)this.Cfg.DfsList[cur];
				if (curNode.IsTwoWay && !curNode.IsLoopNode) {
					int followInEdges = 0;
					int follow = 0;

					/* Find all nodes that have this node as immediate dominator */
					for (int desc = cur + 1; desc < bbCount; desc++) {
						Node node = this.Cfg.DfsList[desc];
						if (node.ImmediateDominator == cur) {
							domDesc.Add(desc);
							int delta = node.InEdges.Count - node.BackEdgeCount;
							if (delta >= followInEdges) {
								follow = desc;
								followInEdges = delta;
							}
						}
					}
				
					/* Determine follow according to number of descendants
					 * immediately dominated by this node  */
					if ((follow != 0) && (followInEdges > 1)) {
						curNode.IfFollow = follow;
						if (unresolved.Any()) {
							FlagNodes(unresolved, follow);
						}
					}
					else {
						unresolved.Add(cur);
					}
				}
			}
		}

		private void FlagNodes(List<int> list, int follow) {
			while(list.Any())
			{
				int index = list.First();
				this.Cfg.DfsList[index].IfFollow = follow;
				list.RemoveAt(0);
			}
		}
	}
}
