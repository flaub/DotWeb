using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Utility;

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

		public void Merge(Node predecessor, Node successor) {
			predecessor.Successors.Clear();
			predecessor.Successors.AddRange(successor.Successors);
			foreach (var succ in successor.Successors) {
				succ.Predecessors.Remove(successor);
				succ.Predecessors.AddUnique(predecessor);
			}
			this.Nodes.Remove(successor);
		}

		public List<Graph> DeriveSequences() {
			var graphs = new List<Graph>();
			PartitionIntervals(graphs);
			return graphs;
		}

		public void PartitionIntervals(List<Graph> graphs) {
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
	}
}
