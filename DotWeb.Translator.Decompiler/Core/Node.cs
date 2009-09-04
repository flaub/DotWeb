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
using System.Reflection.Emit;

namespace DotWeb.Translator
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

	public class Node
	{
		public const int NoNode = -1;
		public const int NoDominator = -1;

		public const int ThenEdge = 0;
		public const int ElseEdge = 1;

		public int ID { get; private set; }
	
		public virtual string FullName {
			get {
				string[] values = this.Nodes.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				return string.Format("{0}: {1}", this.RefName, line);
			} 
		}

		public virtual string RefName {
			get {
				return string.Format("{0}{1}", this.GetType().Name[0], ID);
			}
		}

		public virtual FlowControl FlowControl { get { return FlowControl.Next; } }
		public List<Node> Nodes { get; private set; }

		#region Edges
		public List<Node> InEdges { get; private set; }
		public List<Node> OutEdges { get; private set; }
		#endregion

		#region Interval Construction
		public bool BeenOnHeaders { get; set; }
		public int InEdgeCount { get; set; }
		public Node ReachingInterval { get; set; }
		public Interval Interval { get; set; }
		#endregion

		#region DFS Traversal
		public int DfsFirstNumber { get; set; }
		public int DfsLastNumber { get; set; }
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

		public Node(int id) {
			this.ID = id;
			this.Nodes = new List<Node>();
			this.InEdges = new List<Node>();
			this.OutEdges = new List<Node>();
			this.BeenOnHeaders = false;
			this.InEdgeCount = 0;
			this.DfsFirstNumber = 0;
			this.DfsLastNumber = 0;
			this.DfsTraversed = DfsTraversal.None;
			this.ImmediateDominator = NoDominator;
			this.BackEdgeCount = 0;
			this.LoopHead = NoNode;
			this.IsLatchNode = false;
			this.LoopType = LoopType.None;
			this.LoopFollow = NoNode;
			this.IfFollow = NoNode;
			this.IsLoopNode = false;
			this.CaseHead = Node.NoNode;
			this.CaseTail = Node.NoNode;
		}

		public void AddInEdge(Node node) {
			this.InEdges.Add(node);
			this.InEdgeCount++;
		}

		/// <summary>
		/// Depth First Search is a traversal method that selects edges to
		/// traverse emanating from the most recently visited node which still
		/// has unvisited edges.
		/// </summary>
		public void DfsNumbering(Node[] dfsList, ref int first, ref int last) {
			this.DfsTraversed = DfsTraversal.Numbering;
			this.DfsFirstNumber = first++;

			foreach (Node node in this.OutEdges) {
				node.AddInEdge(this);
				if (node.DfsTraversed != DfsTraversal.Numbering)
					node.DfsNumbering(dfsList, ref first, ref last);
			}
			this.DfsLastNumber = last;
			dfsList[last] = this;
			last--;
		}

		public void CollectNodes(List<Node> nodes) {
			if (this.Nodes.Any()) {
				foreach (Node node in this.Nodes) {
					node.CollectNodes(nodes);
				}
			}
			else {
				nodes.Add(this);
			}
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}", FullName, DfsFirstNumber, DfsLastNumber);
			if (InEdges.Any()) {
				string[] values = InEdges.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				sb.AppendFormat("\n\tIn : {0}", line);
			}
			if (OutEdges.Any()) {
				string[] values = OutEdges.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				sb.AppendFormat("\n\tOut: {0}", line);
			}
			return sb.ToString();
		}
	}
}
