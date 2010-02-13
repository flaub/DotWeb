using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Utility;
using DotWeb.Decompiler.CodeModel;

namespace DotWeb.Decompiler.Core
{
	public class ControlFlowGraph : Graph
	{
		public ControlFlowGraph()
			: base(null) {
		}

		public void Structure() {
			CompoundConditionals();
			StructureCases();
			StructureLoops();
			StructureConditionals();
		}

		public void SortByDepthFirstPostOrder() {
			var sorted = new List<Node>(this.Nodes.Count);
			DepthFirstTraversal((Node node) => {
				node.DfsIndex = this.Nodes.Count - sorted.Count;
				sorted.Insert(0, node);
			});
			this.Nodes = sorted;

			ComputeImmediateDominators();
		}

		public void DepthFirstTraversal(Action<Node> action) {
			var visited = new HashSet<Node>();
			DepthFirstTraversal(this.Root, action, visited);
		}

		private void DepthFirstTraversal(Node node, Action<Node> action, HashSet<Node> visited) {
			visited.Add(node);

			foreach (var succ in node.Successors) {
				if (!visited.Contains(succ)) {
					DepthFirstTraversal(succ, action, visited);
				}
			}

			action(node);
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

			foreach (BasicBlock block in this.Nodes) {
				Console.WriteLine("\t{0} [label=\"{0} (#{1}) (^{2})\\n{3}\"];",
					block.RefName,
					block.DfsIndex,
					block.ImmediateDominator == null ? "" : block.ImmediateDominator.RefName,
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

		public void StructureCases() {
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
						if (CompoundAnd(block, thenBlock, elseBlock)) {
							this.Nodes.Remove(elseBlock);
							return true;
						}
					}
					else if (elseBlock.ThenEdge == thenBlock) {
						if (CompoundOr(block, thenBlock, elseBlock)) {
							this.Nodes.Remove(elseBlock);
							return true;
						}
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

			//if (bb.IsLatchNode) {
			//    this.Cfg.DepthFirstPostOrder[bbThen.DfsPostOrder] = bb;
			//    return false;
			//}

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

			//if (bb.IsLatchNode) {
			//    this.Cfg.DepthFirstPostOrder[bbElse.DfsPostOrder] = bb;
			//    return false;
			//}

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
	}
}
