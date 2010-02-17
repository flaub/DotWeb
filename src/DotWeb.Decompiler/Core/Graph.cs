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
using System.Collections;
using DotWeb.Decompiler.CodeModel;

namespace DotWeb.Decompiler.Core
{
	public class Graph
	{
		private int nextId = 0;

		public Graph Parent { get; private set; }
		public Node Root { get; private set; }
		public List<Node> Nodes { get; protected set; }
		public List<Node> Orphans { get; protected set; }

		public Graph(Graph parent) {
			this.Parent = parent;
			this.Nodes = new List<Node>();
			this.Orphans = new List<Node>();
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

		public void PartitionIntervals(List<Graph> graphs) {
			if (this.Nodes.Count == 1)
				return;

			var intervalGraph = new IntervalGraph(this);
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
					rhs = rhs.ImmediateDominator;
				}
				else {
					lhs = lhs.ImmediateDominator;
				}
			}
			return lhs;
		}
	}

	public class IntervalGraph : Graph
	{
		public IntervalGraph(Graph parent)
			: base(parent) {
		}

		public void CreateIntervalFromHeader(Node header, List<Interval> intervals) {
			var interval = new Interval();
			this.AddNode(interval);
			interval.BuildFromHeader(this.Parent.Nodes, header);
			intervals.Add(interval);
		}

		public void ConnectIntervals(List<Interval> intervals) {
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
