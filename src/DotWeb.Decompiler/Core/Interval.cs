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
using DotWeb.Utility;
using Mono.Cecil.Cil;

namespace DotWeb.Decompiler.Core
{
	//class IntervalGraph : List<Interval> 
	//{
	//    public int Id { get; private set; }

	//    public IntervalGraph(int id) {
	//        this.Id = id;
	//    }

	//    public override string ToString() {
	//        string[] values = this.Select(x => x.RefName).ToArray();
	//        string line = string.Join(", ", values);
	//        return string.Format("G{0}: {1}", Id, line);
	//    }
	//}

	public class Interval : Node
	{
		public Node Header { get; private set; }
		public List<Node> Nodes { get; private set; }

		public Interval() {
			this.Nodes = new List<Node>();
		}

		public override void CollectNodes(List<Node> nodes) {
			if (this.Nodes.Any()) {
				foreach (Node node in this.Nodes) {
					node.CollectNodes(nodes);
				}
			}
			else {
				nodes.Add(this);
			}
		}

		public void BuildFromHeader(IEnumerable<Node> graph, Node header) {
			this.Header = header;
			AddNode(header);

			foreach (var node in graph) {
				if (!Nodes.Contains(node) &&
					AllPredecessorsInThisInterval(node)) {
					AddNode(node);
				}
			}
		}

		private void AddNode(Node node) {
			node.Interval = this;
			this.Nodes.Add(node);
		}

		private bool AllPredecessorsInThisInterval(Node node) {
			foreach (var pred in node.Predecessors) {
				if (!Nodes.Contains(pred)) {
					return false;
				}
			}
			return true;
		}

		//public override string PrintDetails() {
		//    var str = base.PrintDetails();
		//    var sb = new StringBuilder(str);

		//    string[] values = Nodes.Select(x => x.Name).ToArray();
		//    string line = string.Join(", ", values);
		//    sb.AppendLine();
		//    sb.AppendFormat("\tNodes: {0}", line);

		//    return sb.ToString();
		//}

		public override string FullName {
			get {
				string[] values = this.Nodes.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				return string.Format("{0}: {1}", this.RefName, line);
			}
		}
	}

	//public class Interval : Node
	//{
	//    private Queue<Node> pending = new Queue<Node>();

	//    public List<Node> Nodes { get; private set; }
	//    public int ExternalEdgeCount { get; private set; }

	//    public Interval(int id) : base(id) {
	//        ExternalEdgeCount = 0;
	//    }

	//    public override string FullName {
	//        get {
	//            string[] values = this.Nodes.Select(x => x.RefName).ToArray();
	//            string line = string.Join(", ", values);
	//            return string.Format("{0}: {1}", this.RefName, line);
	//        }
	//    }

	//    public override FlowControl FlowControl {
	//        get { throw new NotImplementedException(); }
	//    }

	//    public void CollectNodes(List<Node> nodes) {
	//        //if (this.Nodes.Any()) {
	//        //    foreach (Node node in this.Nodes) {
	//        //        node.CollectNodes(nodes);
	//        //    }
	//        //}
	//        //else {
	//        //    nodes.Add(this);
	//        //}
	//    }

	//    /// <summary>
	//    /// Process all nodes in the current interval list
	//    /// </summary>
	//    /// <param name="headers"></param>
	//    /// <param name="header"></param>
	//    public void Process(List<Node> headers, Node header) {
	//        // pI(header) = {header}
	//        AppendNode(headers, header);

	//        while (this.pending.Any()) {
	//            var node = this.pending.Dequeue();

	//            // Check all immediate successors of node
	//            foreach (Node successor in node.Successors) {
	//                //successor.InEdgeCount--;

	//                ProcessSuccessor(headers, header, successor);
	//            }
	//        }
	//    }

	//    private void ProcessSuccessor(List<Node> headers, Node header, Node successor) {
	//        //if (successor.ReachingInterval == null) {
	//        //    // first visit
	//        //    successor.ReachingInterval = header;
	//        //    if (successor.InEdgeCount == 0) {
	//        //        AppendNode(headers, successor);
	//        //    }
	//        //    else if (!successor.BeenOnHeaders) {
	//        //        // out edge
	//        //        headers.Add(successor);
	//        //        //headers.AddUnique(succ);
	//        //        successor.BeenOnHeaders = true;
	//        //        ExternalEdgeCount++;
	//        //    }
	//        //}
	//        //else if (successor.InEdgeCount == 0) {
	//        //    // node has been visited before
	//        //    if (successor.ReachingInterval == header ||
	//        //        successor.Interval == this) {
	//        //        // same interval
	//        //        if (successor != header) {
	//        //            AppendNode(headers, successor);
	//        //        }
	//        //    }
	//        //    else {
	//        //        // out edge
	//        //        ExternalEdgeCount++;
	//        //    }
	//        //}
	//        //else if (successor != header && successor.BeenOnHeaders) {
	//        //    ExternalEdgeCount++;
	//        //}
	//    }

	//    /// <summary>
	//    /// Appends 'node' to the end of the interval list I, updates currNode
	//    /// if necessary, and removes the node from the header list H if it is 
	//    /// there.  The interval header information is placed in the field 
	//    /// node->inInterval.
	//    /// <remarks>
	//    /// Note: nodes are added to the interval list in interval order (which
	//    /// topsorts the dominance relation).
	//    /// </remarks>
	//    /// </summary>
	//    /// <param name="headers"></param>
	//    /// <param name="node"></param>
	//    private void AppendNode(List<Node> headers, Node node) {
	//        /* Append node if it is not already in the interval list */
	//        //Nodes.AddUnique(node);
	//        if (Nodes.AddUnique(node)) {
	//            this.pending.Enqueue(node);
	//        }

	//        /* Check header list for occurrence of node, if found, remove it 
	//         * and decrement number of out-edges from this interval.    */
	//        if (node.BeenOnHeaders && headers.Contains(node)) {
	//            headers.Remove(node);
	//            ExternalEdgeCount -= node.Predecessors.Count - 1;
	//        }

	//        /* Update interval header information for this basic block */
	//        node.Interval = this;
	//    }
	//}
}
