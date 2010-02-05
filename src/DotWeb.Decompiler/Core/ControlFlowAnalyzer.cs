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
using DotWeb.Utility;

namespace DotWeb.Decompiler.Core
{
	class ControlFlowAnalyzer
	{
		public ControlFlowGraph Cfg { get; private set; }

		public ControlFlowAnalyzer(ControlFlowGraph cfg) {
			this.Cfg = cfg;
		}

		public void Structure() {
			//CompoundConditions();

			FindImmediateDominator();
			if (Cfg.HasCases) {
				StructureCases();
			}
			StructureLoops();
			StructureIfs();

			//DisplayDfs(this.Cfg.Root);
		}

		public static void Structure2(Graph graph) {
			CompoundConditionals(graph);
		}

		public static void CompoundConditionals(Graph graph) {
			bool change = true;
			while (change) {
				change = false;

				// nodes should be sorted in postorder at this point
				foreach (BasicBlock block in graph.Nodes) {
					if (block.Successors.Count == 2) {
						if (CompoundConditionals(graph, block)) {
							change = true;
							break;
						}
					}
				}
			}
		}

		private static bool CompoundConditionals(Graph graph, BasicBlock block) {
			if (block.Successors.Count == 2) {
				var thenBlock = (BasicBlock)block.Successors[1];
				var elseBlock = (BasicBlock)block.Successors[0];

				if (elseBlock.Successors.Count == 2 &&
					elseBlock.Predecessors.Count == 1) {
					if (elseBlock.Successors[1] == thenBlock) {
						if (CompoundAnd(block, thenBlock, elseBlock)) {
							graph.Nodes.Remove(elseBlock);
							return true;
						}
					}
					else if (elseBlock.Successors[0] == thenBlock) {
						if (CompoundOr(block, thenBlock, elseBlock)) {
							graph.Nodes.Remove(elseBlock);
							return true;
						}
					}
				}
			}

			return false;
		}

		private static bool CompoundOr(BasicBlock bb, BasicBlock bbThen, BasicBlock bbElse) {
			BasicBlock finalThen = (BasicBlock)bbElse.Successors[1];
			CodeExpressionStatement lhs = (CodeExpressionStatement)bb.LastStatement;
			CodeExpressionStatement rhs = (CodeExpressionStatement)bbElse.LastStatement;

			// Build an AND because the BackEnd will invert it later
			lhs.Expression = new CodeBinaryExpression(
				lhs.Expression.Invert(),
				CodeBinaryOperator.BooleanAnd,
				rhs.Expression
			);

			// Replace in-edge to finalThen from bbElse to bb
			finalThen.ReplacePredecessorsWith(bbElse, bb);

			// New THEN out-edge of bb
			bb.Successors[1] = finalThen;
			// New ELSE out-edge of bb
			bb.Successors[0] = bbThen;

			// Remove in-edge bbElse to bbThen
			bbThen.Predecessors.Remove(bbElse);

			//bbElse.IsInvalid = true;

			//if (bb.IsLatchNode) {
			//    this.Cfg.DepthFirstPostOrder[bbThen.DfsPostOrder] = bb;
			//    return false;
			//}

			return true;
		}

		private static bool CompoundAnd(BasicBlock bb, BasicBlock bbThen, BasicBlock bbElse) {
			BasicBlock finalElse = (BasicBlock)bbElse.Successors[0];
			CodeExpressionStatement lhs = (CodeExpressionStatement)bb.LastStatement;
			CodeExpressionStatement rhs = (CodeExpressionStatement)bbElse.LastStatement;

			// Build an OR because the BackEnd will invert it later
			lhs.Expression = new CodeBinaryExpression(
				lhs.Expression,
				CodeBinaryOperator.BooleanOr,
				rhs.Expression
			);

			// Replace in-edge to finalElse from bbElse to bb
			finalElse.ReplacePredecessorsWith(bbElse, bb);

			// New ELSE out-edge of bb
			bb.Successors[0] = finalElse;

			// Remove in-edge bbElse to bbThen
			bbThen.Predecessors.Remove(bbElse);

			//bbElse.IsInvalid = true;

			//if (bb.IsLatchNode) {
			//    this.Cfg.DepthFirstPostOrder[bbElse.DfsPostOrder] = bb;
			//    return false;
			//}

			return true;
		}

		private void DisplayDfs(BasicBlock bb) {
			bb.DfsTraversed = DfsTraversal.Display;

			Console.WriteLine("{0}: NodeType: {1}, in: {2}, out: {3}",
				bb.RefName, bb.FlowControl, bb.Predecessors.Count, bb.Successors.Count);
			Console.WriteLine("dfsFirst: {0}, dfsLast: {1}, immedDom: {2}",
				bb.DfsPreOrder, bb.DfsPreOrder, bb.ImmediateDominator);

			string latch = "(null)";
			if (bb.LatchNode != null)
				latch = bb.LatchNode.RefName;
			Console.WriteLine("LoopType: {0}, LoopHead: {1}, LatchNode: {2}, Follow: {3}",
				bb.LoopType, bb.LoopHead, latch, bb.LoopFollow);
			Console.WriteLine("IfFollow: {0}",
				bb.IfFollow);
			Console.WriteLine("----");

			foreach (Node node in bb.Successors) {
				if (node.IsInvalid)
					continue;

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
			Node[] dfsList = this.Cfg.DepthFirstPostOrder;
			for (int curIndex = 0; curIndex < dfsList.Length; curIndex++) {
				Node node = dfsList[curIndex];
				if (node.IsInvalid)
					continue;

				foreach (Node pred in node.Predecessors) {
					int predIndex = pred.DfsPostOrder;
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
					predImmDom = this.Cfg.DepthFirstPostOrder[predImmDom].ImmediateDominator;
				else
					curImmDom = this.Cfg.DepthFirstPostOrder[curImmDom].ImmediateDominator;
			}
			return curImmDom;
		}

		private bool IsSuccessor(int successor, int header)
		{
			return Cfg.DepthFirstPostOrder[header].Successors.Any(x => x.DfsPostOrder == successor);
		}

		private void StructureCases() {
			int exitNode = Node.NoNode;
			List<int> caseNodes = new List<int>();

			/* Linear scan of the nodes in reverse dfsLast order, searching for
			 * case nodes                           */
			for (int i = Cfg.DepthFirstPostOrder.Length - 1; i >= 0; i--) {
				BasicBlock caseHeader = (BasicBlock)Cfg.DepthFirstPostOrder[i];
				if (caseHeader.IsInvalid)
					continue;

				if (caseHeader.LastInstruction.OpCode != OpCodes.Switch)
					continue;

				/* Find descendant node which has as immediate predecessor 
				 * the current header node, and is not a successor.    */
				for (int j = i + 2; j < Cfg.DepthFirstPostOrder.Length; j++) {
					var node = Cfg.DepthFirstPostOrder[j];
					if (node.IsInvalid)
						continue;

					if (!IsSuccessor(j, i) && node.ImmediateDominator == i) {
						if (exitNode == Node.NoNode) {
							exitNode = j;
						}
						else if (Cfg.DepthFirstPostOrder[exitNode].Predecessors.Count < node.Predecessors.Count) {
							exitNode = j;
						}
					}
				}
				caseHeader.CaseTail = exitNode;

				/* Tag nodes that belong to the case by recording the
				 * header field with caseHeader.           */

				caseNodes.Add(i);
				caseHeader.CaseHead = i;
				foreach (BasicBlock node in caseHeader.Successors) {
					TagNodesInCase(node, caseNodes, i, exitNode);
				}
				if (exitNode != Node.NoNode) {
					Cfg.DepthFirstPostOrder[exitNode].CaseHead = i;
				}
			}
		}

		/// <summary>
		/// Recursive procedure to tag nodes that belong to the case described by
		/// the list l, head and tail (dfsLast index to first and exit node of the case).
		/// </summary>
		/// <param name="node"></param>
		/// <param name="list"></param>
		/// <param name="head"></param>
		/// <param name="tail"></param>
		private void TagNodesInCase(BasicBlock node, ICollection<int> list, int head, int tail) {
			node.DfsTraversed = DfsTraversal.Case;
			int current = node.DfsPostOrder;
			if ((current != tail) &&
				(node.LastInstruction.OpCode != OpCodes.Switch) &&
				list.Contains(node.ImmediateDominator)) {
				list.Add(current);
				node.CaseHead = head;
				foreach (BasicBlock bb in node.Successors) {
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
		/// <param name="pred"></param>
		/// <param name="succ"></param>
		/// <returns></returns>
		private bool IsBackEdge(Node pred, Node succ) {
			if (pred.DfsPreOrder >= succ.DfsPreOrder) {
				succ.BackEdgeCount++;
				return true;
			}
			return false;
		}

		private void StructureLoops() {
			foreach (var graph in this.Cfg.Sequences) {
				foreach (Interval interval in graph.Nodes) {
					StructureLoopForInterval(interval);
				}
			}
		}

		private void StructureLoopForInterval(Interval interval) {
			// Find nodes that belong to the interval (nodes from G1)
			List<Node> nodes = new List<Node>();
			interval.CollectNodes(nodes);
			BasicBlock head = (BasicBlock)nodes.First();

			BasicBlock latchNode = null;
			// Find greatest enclosing back edge (if any)
			foreach (BasicBlock pred in head.Predecessors) {
				if (nodes.Contains(pred) && IsBackEdge(pred, head)) {
					if (latchNode == null) {
						latchNode = pred;
					}
					else {
						if (pred.DfsPostOrder > latchNode.DfsPostOrder)
							latchNode = pred;
					}
				}
			}

			/* Find nodes in the loop and the type of loop */
			if (latchNode != null) {
				// Check latching node is at the same nesting level of case
				// statements (if any) and that the node doesn't belong to
				// another loop.
				if ((latchNode.CaseHead == head.CaseHead) &&
					(latchNode.LoopHead == Node.NoNode)) {
					head.LatchNode = latchNode;
					FindNodesInLoop(latchNode, head, nodes);
					latchNode.IsLatchNode = true;
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
			headerNode.LoopHead = headerNode.DfsPostOrder;

			List<int> loopNodes = new List<int>();
			loopNodes.Add(headerNode.LoopHead);

			for (int i = headerNode.LoopHead + 1; i < latchNode.DfsPostOrder; i++) {
				Node node = this.Cfg.DepthFirstPostOrder[i];
				if (node.IsInvalid)
					continue;

				int immedDom = node.ImmediateDominator;
				if (loopNodes.Contains(immedDom) && nodes.Contains(node)) {
					loopNodes.Add(i);
					if (node.LoopHead == Node.NoNode) {
						node.LoopHead = headerNode.LoopHead;
					}
				}
			}

			latchNode.LoopHead = headerNode.LoopHead;
			if (latchNode != headerNode) {
				loopNodes.Add(latchNode.DfsPostOrder);
			}

			ClassifyLoop(headerNode, latchNode, loopNodes);
		}

		private void ClassifyLoop(BasicBlock headerNode, BasicBlock latchNode, List<int> loopNodes) {
			int thenDfs = headerNode.ThenEdge.DfsPostOrder;
			int elseDfs = Node.NoNode;
			if (headerNode.Successors.Count > 1)
				elseDfs = headerNode.ElseEdge.DfsPostOrder;

			if (latchNode.IsTwoWay) {
				if ((headerNode.IsTwoWay) || (latchNode == headerNode)) {
					if ((latchNode == headerNode) ||
						loopNodes.Contains(thenDfs) &&
						loopNodes.Contains(elseDfs)) {
						headerNode.LoopType = LoopType.Repeat;
						if (latchNode.ThenEdge == headerNode)
							headerNode.LoopFollow = latchNode.ElseEdge.DfsPostOrder;
						else
							headerNode.LoopFollow = latchNode.ThenEdge.DfsPostOrder;
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
				else {
					// head = anything besides 2-way, latch = 2-way 
					headerNode.LoopType = LoopType.Repeat;
					if (latchNode.ThenEdge == headerNode)
						headerNode.LoopFollow = latchNode.ElseEdge.DfsPostOrder;
					else
						headerNode.LoopFollow = latchNode.ThenEdge.DfsPostOrder;
					latchNode.IsLoopNode = true;
				}
			}
			else {
				// latch = 1-way
				if (headerNode.IsTwoWay) {
					headerNode.LoopType = LoopType.While;
					Node node = latchNode;
					while (true) {
						if (node.DfsPostOrder == thenDfs) {
							headerNode.LoopFollow = elseDfs;
							break;
						}
						else if (node.DfsPostOrder == elseDfs) {
							headerNode.LoopFollow = thenDfs;
							break;
						}
						// Check if couldn't find it, then it is a strangely formed
						// loop, so it is safer to consider it an endless loop
						if (node.DfsPostOrder <= headerNode.DfsPostOrder) {
							headerNode.LoopType = LoopType.Endless;
							FindEndlessFollow(loopNodes, headerNode);
							break;
						}

						node = this.Cfg.DepthFirstPostOrder[node.ImmediateDominator];
					}

					if (node.DfsPostOrder > headerNode.DfsPostOrder) {
						this.Cfg.DepthFirstPostOrder[headerNode.LoopFollow].LoopHead = Node.NoNode;
					}
					headerNode.IsLoopNode = true;
				}
				else {
					headerNode.LoopType = LoopType.Endless;
					FindEndlessFollow(loopNodes, headerNode);
				}
			}
		}

		private void FindEndlessFollow(List<int> loopNodes, BasicBlock head) {
			head.LoopFollow = int.MaxValue;

			foreach (var i in loopNodes) {
				var node = this.Cfg.DepthFirstPostOrder[i];
				if (node.IsInvalid)
					continue;

				foreach (var succ in node.Successors) {
					if (!loopNodes.Contains(succ.DfsPostOrder) &&
						(succ.DfsPostOrder < head.LoopFollow)) {
						head.LoopFollow = succ.DfsPostOrder;
					}
				}
			}
		}

		private void StructureIfs() {
			var bbCount = this.Cfg.DepthFirstPostOrder.Length;
			var unresolved = new List<Node>();

			// Linear scan of nodes in reverse dfsLast order
			for (int cur = bbCount - 1; cur >= 0; cur--) {
				BasicBlock curNode = (BasicBlock)this.Cfg.DepthFirstPostOrder[cur];
				if (curNode.IsInvalid)
					continue;

				if (curNode.IsTwoWay && !curNode.IsLoopNode) {
					int followInEdges = 0;
					int follow = 0;

					// Find all nodes that have this node as immediate dominator
					for (int desc = cur + 1; desc < bbCount; desc++) {
						Node node = this.Cfg.DepthFirstPostOrder[desc];
						if (node.IsInvalid)
							continue;

						if (node.ImmediateDominator == cur) {
							int delta = node.Predecessors.Count - node.BackEdgeCount;
							if (delta >= followInEdges) {
								follow = desc;
								followInEdges = delta;
							}
						}
					}
				
					// Determine follow according to number of descendants 
					// immediately dominated by this node 
					if ((follow != 0) && (followInEdges > 1)) {
						curNode.IfFollow = follow;
						if (unresolved.Any()) {
							FlagNodes(unresolved, follow);
						}
					}
					else {
						unresolved.Add(curNode);
					}
				}
			}
		}

		private void FlagNodes(List<Node> list, int follow) {
			while (list.Any()) {
				var node = list.Dequeue();
				node.IfFollow = follow;
			}
		}
	}
}
