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

	public abstract class Node
	{
		public const int NoNode = -1;
		public const int NoDominator = -1;

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

		public void RemovePredecessor(Node search) {
			for (int i = 0; i < this.Predecessors.Count; i++) {
			}
		}
		#endregion

		#region Interval Construction
		public Interval Interval { get; set; }
		#endregion

		#region DFS Traversal
		public int DfsPreOrder { get; set; }
		public int DfsPostOrder { get; set; }
		public DfsTraversal DfsTraversed { get; set; }
		#endregion

		#region Structure
		public int ImmediateDominator { get; set; }
		public int BackEdgeCount { get; set; }
		public int LoopHead { get; set; }
		public bool IsLatchNode { get; set; }
		public Node LatchNode { get; set; }
		public LoopType LoopType { get; set; }
		public int LoopFollow { get; set; }
		public int IfFollow { get; set; }
		public bool IsLoopNode { get; set; }
		public int CaseHead { get; set; }
		public int CaseTail { get; set; }
		#endregion

		public Node() {
			this.Id = -1;
			this.Predecessors = new List<Node>();
			this.Successors = new List<Node>();
			this.DfsPreOrder = 0;
			this.DfsPostOrder = 0;
			this.DfsTraversed = DfsTraversal.None;
			this.ImmediateDominator = NoDominator;
			this.BackEdgeCount = 0;
			this.LoopHead = NoNode;
			this.IsLatchNode = false;
			this.LoopType = LoopType.None;
			this.LoopFollow = NoNode;
			this.IfFollow = NoNode;
			this.IsLoopNode = false;
			this.CaseHead = NoNode;
			this.CaseTail = NoNode;
		}

		public virtual void CollectNodes(List<Node> nodes) {
			nodes.Add(this);
		}

		/// <summary>
		/// Depth First Search is a traversal method that selects edges to
		/// traverse emanating from the most recently visited node which still
		/// has unvisited edges.
		/// </summary>
		public void DfsNumbering(Node[] dfsList, ref int first, ref int last) {
			this.DfsTraversed = DfsTraversal.Numbering;
			this.DfsPreOrder = first++;

			foreach (Node node in this.Successors) {
				if (node.DfsTraversed != DfsTraversal.Numbering)
					node.DfsNumbering(dfsList, ref first, ref last);
			}

			this.DfsPostOrder = last--;
			dfsList[this.DfsPostOrder] = this;
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}", FullName);
			if (Predecessors.Any()) {
				string[] values = Predecessors.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				sb.AppendFormat("\n\tIn : {0}", line);
			}
			if (Successors.Any()) {
				string[] values = Successors.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				sb.AppendFormat("\n\tOut: {0}", line);
			}
			return sb.ToString();
		}
	}
}
