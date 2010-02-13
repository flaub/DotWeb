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
	public class Interval : Node
	{
		public Node Header { get; private set; }
		public List<Node> Nodes { get; private set; }

		public Interval() {
			this.Nodes = new List<Node>();
		}

		public override void CollectNodes(List<Node> nodes) {
			foreach (Node node in this.Nodes) {
				node.CollectNodes(nodes);
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

		public Loop StructureLoop(Graph graph) {
			var nodes = new List<Node>();
			CollectNodes(nodes);
			
			var header = nodes.First();
			var tails = new List<Node>();

			foreach (var pred in header.Predecessors) {
				if (nodes.Contains(pred)) {// && pred.Dominators.Get(header.Id - 1)) {
					tails.Add(pred);
				}
			}

			if (tails.Any()) {
				return Loop.Construct(graph, header, tails);
			}

			return null;
		}


		private void AddNode(Node node) {
			node.Interval = this;
			this.Nodes.Add(node);
		}

		private bool AllPredecessorsInThisInterval(Node node) {
			if (!node.Predecessors.Any())
				return false;

			foreach (var pred in node.Predecessors) {
				if (!Nodes.Contains(pred)) {
					return false;
				}
			}
			return true;
		}

		public override string FullName {
			get {
				string[] values = this.Nodes.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				return string.Format("{0}: {1}", this.RefName, line);
			}
		}
	}
}
