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

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil.Cil;
using DotWeb.Utility;
using System.Collections;
using System;

namespace DotWeb.Decompiler.Core
{
	public enum LoopType
	{
		None,
		While,
		Repeat,
		Endless
	}

	public enum DfsTraversal
	{
		None,
		Display,
		Merge,
		Numbering,
		CodeDom,
		Case,
		Alpha,
		Jump
	}

	public class Conditional
	{
		public Node Header { get; set; }
		public Node Follow { get; set; }

		private Graph graph;

		public Conditional(Graph graph, Node header) {
			this.graph = graph;
			this.Header = header;
		}

		public override string ToString() {
			return string.Format("{0} -> {1}", Header.RefName, Follow == null ? "" : Follow.RefName);
		}

		public void FindFollow() {
			int followPredCount = 0;
			Node follow = null;

			for (int i = Header.DfsIndex + 1; i < this.graph.Nodes.Count; i++) {
				var descendant = this.graph.Nodes[i];
				if (descendant.ImmediateDominator == this.Header) {
					var forwardInEdges = descendant.Predecessors.Where(x => x.DfsIndex < descendant.DfsIndex).Count();
					if (forwardInEdges >= followPredCount) {
						followPredCount = forwardInEdges;
						follow = descendant;
					}
				}
			}

			if (follow != null && followPredCount > 1) {
				this.Follow = follow;
			}
		}
	}

	public abstract class Node
	{
		public int Id { get; set; }

		public abstract string FullName { get; }

		public virtual string RefName {
			get { return string.Format("{0}{1}", this.GetType().Name[0], Id); }
		}

		public virtual FlowControl FlowControl { get { return FlowControl.Next; } }

		#region Edges
		public List<Node> Predecessors { get; private set; }
		public List<Node> Successors { get; private set; }

		public Node ThenEdge {
			get { return this.Successors[0]; }
			set { this.Successors[0] = value; }
		}

		public Node ElseEdge {
			get { return this.Successors[1]; }
			set { this.Successors[1] = value; }
		}

		public void ReplacePredecessorsWith(Node search, Node replace) {
			for (int i = 0; i < this.Predecessors.Count; i++) {
				if (this.Predecessors[i] == search) {
					this.Predecessors[i] = replace;
					break;
				}
			}
		}

		#endregion

		#region Interval Construction
		public Interval Interval { get; set; }
		#endregion

		#region DFS Traversal
		public int DfsIndex { get; set; }
		public DfsTraversal DfsTraversed { get; set; }
		#endregion

		#region Structure
		public Loop Loop { get; set; }
		public Conditional Conditional { get; set; }
		public Node ImmediateDominator { get; set; }
		public bool IsLoopNode { get; set; }
		public bool IsLoopHeader { get; set; }
		public bool IsLoopLatch { get; set; }
		//public int CaseHead { get; set; }
		//public int CaseTail { get; set; }
		#endregion

		public Node() {
			this.Id = -1;
			this.Predecessors = new List<Node>();
			this.Successors = new List<Node>();
			this.DfsIndex = -1;
			this.DfsTraversed = DfsTraversal.None;
			this.IsLoopNode = false;
			this.IsLoopHeader = false;
			//this.CaseHead = NoNode;
			//this.CaseTail = NoNode;
		}

		public virtual void CollectNodes(List<Node> nodes) {
			nodes.Add(this);
		}

		public override string ToString() {
			return FullName;
		}
	}
}
