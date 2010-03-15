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
using DotWeb.Utility;
using DotWeb.Decompiler.CodeModel;
using Mono.Cecil.Cil;

namespace DotWeb.Decompiler.Core
{
	public class ControlFlowGraph : Graph
	{
		public ControlFlowGraph()
			: base(null) {
		}

		public void Structure() {
			CompoundConditionals();
			OptimizeReturn();
			StructureLoops();
			StructureConditionals();
			StructureExceptions();
		}

		public void SortByDepthFirstPostOrder() {
			var sorted = new List<Node>(this.Nodes.Count);
			DepthFirstTraversalPostAction((Node node) => {
				node.DfsIndex = this.Nodes.Count - sorted.Count;
				sorted.Insert(0, node);
			});
			this.Nodes = sorted;

			ComputeImmediateDominators();
		}

		public void DepthFirstTraversalPostAction(Action<Node> action) {
			var visited = new HashSet<Node>();
			foreach (var orphan in this.Orphans) {
				DepthFirstTraversal(orphan, null, action, visited);
			}
			DepthFirstTraversal(this.Root, null, action, visited);
		}

		private void DepthFirstTraversal(Node node, Action<Node> preAction, Action<Node> postAction, HashSet<Node> visited) {
			visited.Add(node);

			if (preAction != null) {
				preAction(node);
			}

			foreach (var succ in node.Successors) {
				if (!visited.Contains(succ)) {
					DepthFirstTraversal(succ, preAction, postAction, visited);
				}
			}

			if (postAction != null) {
				postAction(node);
			}
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			foreach (BasicBlock block in this.Nodes) {
				sb.AppendLine(block.ToStringDetails());
			}
			return sb.ToString();
		}

		public void PrintDot(string name) {
			SortByDepthFirstPostOrder();

			Console.WriteLine("digraph G {");
			Console.WriteLine("\tgraph [label=\"{0}\"];", name);

			var loops = new List<Loop>();

			foreach (BasicBlock block in this.Nodes) {
				var attrs = new List<string>();
				if (block.Try != null) {
					if (block.IsTryHeader) {
						attrs.Add("TH");
					}
					if (block == block.Try.Finally) {
						attrs.Add(string.Format("F: {0}", block.Try.Header.RefName));
					}
					if (block.Try.Catches.Contains(block)) {
						attrs.Add(string.Format("C: {0}", block.Try.Header.RefName));
					}
					if (block.Try.Nodes.Contains(block)) {
						attrs.Add(string.Format("T: {0}", block.Try.Header.RefName));
					}
					if (block == block.Try.Follow) {
						attrs.Add(string.Format("TF: {0}", block.Try.Header.RefName));
					}
				}

				if (block.Loop != null) {
					loops.Add(block.Loop);
				}
				if (block.IsLoopHeader) {
					attrs.Add("LH");
				}
				if (block.IsLoopLatch) {
					attrs.Add("LL");
				}
				if (loops.Any(x => x.Follow == block)) {
					attrs.Add("LF");
				}

				if (block.Conditional != null) {
					if (block.Conditional.Header != null) {
						attrs.Add("CH");
					}
					if (block.Conditional.Follow != null) {
						attrs.Add("CF");
					}
				}

				var attrsLine = "";
				if (attrs.Any()) {
					attrsLine = "\\n" + string.Join(", ", attrs.ToArray());
				}

				Console.WriteLine("\t{0} [label=\"{1}: {0} (^{2}){3}\\n{4}\"];",
					block.RefName,
					block.DfsIndex,
					block.ImmediateDominator == null ? "" : block.ImmediateDominator.RefName,
					attrsLine,
					block.LastInstruction.OpCode);
			}

			foreach (var block in this.Nodes) {
				foreach (var succ in block.Successors) {
					Console.WriteLine("\t{0} -> {1};", block.RefName, succ.RefName);
				}
			}

			Console.WriteLine("}");
		}

		public List<Graph> DeriveSequences() {
			var graphs = new List<Graph>();
			PartitionIntervals(graphs);
			return graphs;
		}

		public List<Loop> StructureLoops() {
			var loops = new List<Loop>();
			var graphs = DeriveSequences();

			foreach (var graph in graphs) {
				foreach (Interval interval in graph.Nodes) {
					var loop = interval.StructureLoop(this);
					if (loop != null) {
						loops.Add(loop);
					}
				}
			}

			return loops;
		}

		public List<Conditional> StructureConditionals() {
			var conditionals = new List<Conditional>();
			var unresolved = new List<Conditional>();

			for (int i = this.Nodes.Count - 1; i >= 0; --i) {
				var node = this.Nodes[i];

				if (node.Successors.Count > 1 && !node.IsLoopNode) {
					var conditional = new Conditional(this, node);
					conditional.FindFollow();
					node.Conditional = conditional;

					if (conditional.Follow != null) {
						while (unresolved.Any()) {
							var item = unresolved.Dequeue();
							item.Follow = conditional.Follow;
						}
					}
					else {
						unresolved.Add(conditional);
					}

					conditionals.Add(conditional);
				}
			}

			return conditionals;
		}

		public List<TryStructure> StructureExceptions() {
			var tries = new List<TryStructure>();
			for (int i = this.Nodes.Count - 1; i >= 0; --i) {
				//foreach (BasicBlock block in this.Nodes) {
				var block = (BasicBlock)this.Nodes[i];
				if (block.ExceptionHandler != null) {
					var first = block.Instructions.First();
					if (block.ExceptionHandler.TryStart == first) {
						var tryStructure = new TryStructure(this, block);
						tries.Add(tryStructure);
					}
				}
			}
			return tries;
		}

		public void CompoundConditionals() {
			SortByDepthFirstPostOrder();

			bool change = true;
			while (change) {
				change = false;

				// nodes should be sorted in postorder at this point
				foreach (BasicBlock block in this.Nodes) {
					if (block.Successors.Count == 2) {
						if (CompoundConditionals(block)) {
							change = true;
							break;
						}
					}
				}
			}

			SortByDepthFirstPostOrder();
		}

		private bool CompoundConditionals(BasicBlock block) {
			if (block.Successors.Count == 2) {
				var thenBlock = (BasicBlock)block.ElseEdge;
				var elseBlock = (BasicBlock)block.ThenEdge;

				if (elseBlock.Successors.Count == 2 &&
					elseBlock.Predecessors.Count == 1) {
					if (elseBlock.ElseEdge == thenBlock) {
						CompoundAnd(block, thenBlock, elseBlock);
						return true;
					}
					else if (elseBlock.ThenEdge == thenBlock) {
						CompoundOr(block, thenBlock, elseBlock);
						return true;
					}
				}
			}

			return false;
		}

		private bool CompoundOr(BasicBlock bb, BasicBlock bbThen, BasicBlock bbElse) {
			var finalThen = (BasicBlock)bbElse.ElseEdge;
			var lhs = (CodeExpressionStatement)bb.LastStatement;
			var rhs = (CodeExpressionStatement)bbElse.LastStatement;

			// Build an AND because the BackEnd will invert it later
			lhs.Expression = new CodeBinaryExpression(
				lhs.Expression.Invert(),
				CodeBinaryOperator.BooleanAnd,
				rhs.Expression
			);

			// Replace in-edge to finalThen from bbElse to bb
			finalThen.ReplacePredecessorsWith(bbElse, bb);

			// New THEN out-edge of bb
			bb.ElseEdge = finalThen;
			// New ELSE out-edge of bb
			bb.ThenEdge = bbThen;

			// Remove in-edge bbElse to bbThen
			bbThen.Predecessors.Remove(bbElse);

			this.Nodes.Remove(bbElse);

			return true;
		}

		private bool CompoundAnd(BasicBlock bb, BasicBlock bbThen, BasicBlock bbElse) {
			var finalElse = (BasicBlock)bbElse.ThenEdge;
			var lhs = (CodeExpressionStatement)bb.LastStatement;
			var rhs = (CodeExpressionStatement)bbElse.LastStatement;

			// Build an OR because the BackEnd will invert it later
			lhs.Expression = new CodeBinaryExpression(
				lhs.Expression,
				CodeBinaryOperator.BooleanOr,
				rhs.Expression
			);

			// Replace in-edge to finalElse from bbElse to bb
			finalElse.ReplacePredecessorsWith(bbElse, bb);

			// New ELSE out-edge of bb
			bb.ThenEdge = finalElse;

			// Remove in-edge bbElse to bbThen
			bbThen.Predecessors.Remove(bbElse);

			this.Nodes.Remove(bbElse);

			return true;
		}


		private void ComputeImmediateDominators() {
			// assume that nodes are sorted by DfsPostOrder
			foreach (var node in this.Nodes) {
				foreach (var pred in node.Predecessors) {
					if (pred.DfsIndex < node.DfsIndex) {
						node.ImmediateDominator = CommonDominator(node.ImmediateDominator, pred);
					}
				}
			}
		}

		public void OptimizeReturn() {
			var returns = this.Nodes.Cast<BasicBlock>().Where(x => x.FlowControl == FlowControl.Return);
			if (returns.Count() == 1) {
				var exit = returns.Single();
				if (exit.Statements.Count == 1) {
					var returnStmt = exit.Statements.Single() as CodeReturnStatement;
					if (returnStmt != null) {
						var variableRef = returnStmt.Expression as CodeVariableReference;
						if (variableRef != null) {
							foreach (BasicBlock pred in exit.Predecessors) {
								pred.Successors.Remove(exit);
								var copy = new CodeReturnStatement {
									Expression = returnStmt.Expression
								};
								pred.Statements.Add(copy);
								if (pred.LastInstruction.OpCode.FlowControl == FlowControl.Branch) {
									pred.Instructions.Remove(pred.LastInstruction);
								}
								pred.Instructions.AddRange(exit.Instructions);
							}
							this.Nodes.Remove(exit);
						}
					}
				}
			}
		}
	}
}
