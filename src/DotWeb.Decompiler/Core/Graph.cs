using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Utility;
using System.Collections;

namespace DotWeb.Decompiler.Core
{
	public class Graph
	{
		private int nextId = 0;

		public Graph Parent { get; private set; }
		public Node Root { get; private set; }
		public List<Node> Nodes { get; private set; }

		public Graph(Graph parent) {
			this.Parent = parent;
			this.Nodes = new List<Node>();
		}

		public void AddNode(Node node) {
			node.Id = ++nextId;
			if (this.Root == null)
				this.Root = node;
			this.Nodes.Add(node);
		}

		public void Connect(Node predecessor, Node successor) {
			predecessor.Successors.AddUnique(successor);
			successor.Predecessors.AddUnique(predecessor);
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

		public void ComputeDominators() {
			foreach (var node in this.Nodes) {
				node.Dominators = new BitVector(this.Nodes.Count);
				node.Dominators.SetAll();
			}

			this.Root.Dominators.ClearAll();
			this.Root.Dominators.Set(this.Root.Id - 1);

			var temp = new BitVector(this.Nodes.Count);
			bool changed;
			do {
				changed = false;

				foreach (var block in this.Nodes) {
					if (block == this.Root)
						continue;

					foreach (var pred in block.Predecessors) {
						temp.ClearAll();
						temp.Or(block.Dominators);

						block.Dominators.And(pred.Dominators);
						block.Dominators.Set(block.Id - 1);
						if (block.Dominators != temp) {
							changed = true;
						}
					}
				}
			} while (changed);
		}

		public List<Graph> DeriveSequences() {
			var graphs = new List<Graph>();
			PartitionIntervals(graphs);
			return graphs;
		}

		/*		 
		ComputeNaturalLoops()
		{
			LoopSet   loopSet;
		 
			for each block in block_list {
				if (block == entry_block)
					continue

				for each succ in block->successors {
		 
					// Every successor that dominates its predecessor
					// must be the header of a loop.
					// That is, block -> succ is a back edge.
		 
					if block->dominators->find(succ)
						loopSet += NaturalLoopForEdge(succ, block);
		 
				}
			}
		}*/
		public List<Loop> StructureLoops() {
			var loops = new List<Loop>();
			var graphs = DeriveSequences();

			foreach (var graph in graphs) {
				foreach (Interval interval in graph.Nodes) {
					var loop = StructureLoopForInterval(interval);
					if (loop != null) {
						loops.Add(loop);
					}
				}
			}

			return loops;
		}

		private Loop StructureLoopForInterval(Interval interval) {
			var nodes = new List<Node>();
			interval.CollectNodes(nodes);
			var header = nodes.First();

			var tails = new List<Node>();

			foreach (var pred in header.Predecessors) {
				if (nodes.Contains(pred) && pred.Dominators.Get(header.Id - 1)) {
					tails.Add(pred);
				}
			}

			if (tails.Any()) {
				return Loop.Construct(this, header, tails);
			}

			return null;
		}

		private void PartitionIntervals(List<Graph> graphs) {
			if (this.Nodes.Count == 1)
				return;

			var intervalGraph = new Graph(this);
			var intervals = new List<Interval>();
			var header = this.Root;

			do {
				intervalGraph.CreateIntervalFromHeader(header, intervals);

				header = this.Nodes.FirstOrDefault(x =>
					x.Interval == null &&
					x.Predecessors.Any(y => y.Interval != null)
				);
			} while (header != null);

			intervalGraph.ConnectIntervals(intervals);
			graphs.Add(intervalGraph);

			intervalGraph.PartitionIntervals(graphs);
		}

		private void CreateIntervalFromHeader(Node header, List<Interval> intervals) {
			var interval = new Interval();
			this.AddNode(interval);
			interval.BuildFromHeader(this.Parent.Nodes, header);
			intervals.Add(interval);
		}

		private void ConnectIntervals(List<Interval> intervals) {
			if (intervals.Count > 1) {
				foreach (var interval in intervals) {
					foreach (var node in interval.Nodes) {
						foreach (var succ in node.Successors) {
							if (succ.Interval != interval && succ == succ.Interval.Header) {
								Connect(interval, succ.Interval);
							}
						}
					}
				}
			}
		}

		private void ComputeImmediateDominators() {
			// assume that nodes are sorted by DfsPostOrder
			foreach (var node in this.Nodes) {
				foreach (var pred in node.Predecessors) {
					if (pred.DfsIndex < node.DfsIndex) {
						node.ImmediateDominatorNode = CommonDominator(node.ImmediateDominatorNode, pred);
					}
				}
			}
		}

		/// <summary>
		/// Finds the common dominator of two nodes
		/// </summary>
		public static Node CommonDominator(Node lhs, Node rhs) {
			if (lhs == null)
				return rhs;
			if (rhs == null)
				return lhs;
			while ((lhs != null) && (rhs != null) && (lhs != rhs)) {
				if (lhs.DfsIndex < rhs.DfsIndex) {
					rhs = rhs.ImmediateDominatorNode;
				}
				else {
					lhs = lhs.ImmediateDominatorNode;
				}
			}
			return lhs;
		}
	}
}
