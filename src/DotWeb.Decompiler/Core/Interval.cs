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

namespace DotWeb.Decompiler.Core
{
	class IntervalGraph : List<Interval> 
	{
		public int ID { get; private set; }

		public IntervalGraph(int id) {
			this.ID = id;
		}

		public override string ToString() {
			string[] values = this.Select(x => x.RefName).ToArray();
			string line = string.Join(", ", values);
			return string.Format("G{0}: {1}", ID, line);
		}
	}

	class Interval : Node
	{
		public int ExternalEdgeCount { get; private set; }

		public Interval(int id) : base(id) {
			ExternalEdgeCount = 0;
		}

		public override System.Reflection.Emit.FlowControl FlowControl {
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Process all nodes in the current interval list
		/// </summary>
		/// <param name="headers"></param>
		/// <param name="header"></param>
		public void Process(List<Node> headers, Node header) {
			/* pI(header) = {header} */
			AppendNode(headers, header);

			int index = 0;
			while (index < Nodes.Count) {
				Node node = Nodes[index++];

				/* Check all immediate successors of node */
				foreach (Node succ in node.OutEdges) {
					succ.InEdgeCount--;

					if (succ.ReachingInterval == null) /* first visit */ {
						succ.ReachingInterval = header;
						if (succ.InEdgeCount == 0) {
							AppendNode(headers, succ);
						}
						else if (!succ.BeenOnHeaders) /* out edge */ {
							headers.AddUnique(succ);
							succ.BeenOnHeaders = true;
							ExternalEdgeCount++;
						}
					}
					else if (succ.InEdgeCount == 0) /* node has been visited before */ {
						if (succ.ReachingInterval == header || succ.Interval == this) /* same interval */ {
							if (succ != header) {
								AppendNode(headers, succ);
							}
						}
						else { /* out edge */
							ExternalEdgeCount++;
						}
					}
					else if (succ != header && succ.BeenOnHeaders) {
						ExternalEdgeCount++;
					}
				}
			}
		}

		/// <summary>
		/// Appends node node to the end of the interval list I, updates currNode
		/// if necessary, and removes the node from the header list H if it is 
		/// there.  The interval header information is placed in the field 
		/// node->inInterval.
		/// <remarks>
		/// Note: nodes are added to the interval list in interval order (which
		/// topsorts the dominance relation).
		/// </remarks>
		/// </summary>
		/// <param name="headers"></param>
		/// <param name="node"></param>
		/// <param name="interval"></param>
		public void AppendNode(List<Node> headers, Node node) {
			/* Append node if it is not already in the interval list */
			Nodes.AddUnique(node);

			/* Check header list for occurrence of node, if found, remove it 
			 * and decrement number of out-edges from this interval.    */
			if (node.BeenOnHeaders && headers.Contains(node)) {
				headers.Remove(node);
				ExternalEdgeCount -= node.InEdges.Count - 1;
			}

			/* Update interval header information for this basic block */
			node.Interval = this;
		}
	}
}
