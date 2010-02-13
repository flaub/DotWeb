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
using System.Linq;
using System.Collections.Generic;
using DotWeb.Utility;
using DotWeb.Decompiler.CodeModel;
using System.Diagnostics;

namespace DotWeb.Decompiler.Core
{
	public enum LoopType
	{
		None,
		While,
		Repeat,
		Endless
	}

	public class Loop
	{
		public LoopType LoopType { get; set; }
		public Node Header { get; set; }
		public Node Latch { get; set; }
		public Node Follow { get; set; }
		public List<Node> Tails { get; private set; }
		public List<Node> Exits { get; private set; }
		public List<Node> Nodes { get; private set; }

		private Graph graph;

		public Loop(Graph graph, Node header, List<Node> tails) {
			this.graph = graph;
			this.Header = header;
			this.Tails = tails.OrderBy(x => x.DfsIndex).ToList();
			this.Latch = tails.Last();
			this.Latch.IsLoopLatch = true;
			this.LoopType = LoopType.None;
			this.Nodes = new List<Node>();
			this.Exits = new List<Node>();

			header.IsLoopNode = true;
			header.IsLoopHeader = true;
			header.Loop = this;
			AddNode(header);

			foreach (var tail in this.Tails) {
				tail.IsLoopNode = true;
				AddFromTail(tail);
			}
		}

		private string GetNodeName(Node node) {
			var str = node.RefName;
			if (Tails.Contains(node))
				str = "#" + str;
			if (node == Latch)
				str = "&" + str;
			if (node == Header)
				str = "$" + str;
			return str;
		}

		public override string ToString() {
			var nodes = Nodes.Select(x => GetNodeName(x));
			var exits = Exits.Select(x => "*" + x.RefName);
			var parts = nodes.Concat(exits).ToArray();
			var str = string.Format("({0}) {1}", this.LoopType, string.Join(", ", parts));
			if (this.Follow != null) {
				str = str + ", !" + this.Follow.RefName;
			}
			return str;
		}

		public void AddNode(Node node) {
			this.Nodes.Add(node);
		}

		public static Loop Construct(Graph graph, Node header, List<Node> tails) {
			var loop = new Loop(graph, header, tails);
			loop.ProcessExits();
			return loop;
		}

		private void AddFromTail(Node tail) {
			var workList = new Stack<Node>();

			if (tail != Header) {
				AddNode(tail);
				workList.Push(tail);
			}

			while (workList.Count > 0) {
				var block = workList.Pop();
				foreach (var pred in block.Predecessors) {
					if (!Nodes.Contains(pred)) {
						AddNode(pred);
						workList.Push(pred);
					}
				}
			}
		}

		private void ProcessExits() {
			foreach (var node in Nodes) {
				foreach (var succ in node.Successors) {
					if (!Nodes.Contains(succ)) {
						if (Tails.Contains(node)) {
							LoopType = LoopType.Repeat;
							Follow = succ;
						}
						else if (node == Header) {
							if (LoopType == LoopType.None)
								LoopType = LoopType.While;
							// we can't be certain here if this header has some
							// extra statements that would make the loop endless with 
							// if(cond) { <then>; break; }
							// so just mark it as an exit and proceed
							Exits.AddUnique(succ);
						}
						else {
							Exits.AddUnique(succ);
						}
					}
				}
			}

			if (LoopType == LoopType.None) {
				LoopType = LoopType.Endless;
			}

			if (Follow == null && Exits.Count == 1) {
				Follow = Exits.Dequeue();
				return;
			}

			if (Follow == null && Exits.Any()) {
				var joint = Exits.Dequeue();
				while (Exits.Any()) {
					var exit = Exits.Dequeue();

					var commonDom = Graph.CommonDominator(joint, exit);
					Node start;
					Node other;
					if (joint.ImmediateDominator == commonDom) {
						// walk down exit2 until we get a node that has an ImmediateDominator == commonDom
						start = exit;
						other = joint;
					}
					else if (exit.ImmediateDominator == commonDom) {
						// walk down exit1
						start = joint;
						other = exit;
					}
					else {
						// walk down both
						throw new NotImplementedException();
					}

					var visited = new List<Node>();
					var nextJoint = FindJoint(start, commonDom, visited);
					if (nextJoint == null) {
						// this branch leads to a return,
						// include this path inside of the loop.
					}
					else {
						joint = nextJoint;
						GetNodesUntil(other, joint, visited);
					}

					foreach (var node in visited) {
						AddNode(node);
					}
				}

				Follow = joint;
			}
		}

		private void GetNodesUntil(Node node, Node until, List<Node> visited) {
			if (node == until)
				return;

			visited.AddUnique(node);
			foreach (var succ in node.Successors) {
				// skip back-edges
				if (succ.DfsIndex < node.DfsIndex)
					continue;

				GetNodesUntil(succ, until, visited);
			}
		}

		/// <summary>
		/// Find the next descendant that has the same immediate dominator
		/// as the one specified. Collect all visited nodes along the way.
		/// </summary>
		/// <param name="node"></param>
		/// <param name="immediateDom"></param>
		/// <param name="visited"></param>
		/// <returns></returns>
		private Node FindJoint(Node node, Node immediateDom, List<Node> visited) {
			visited.AddUnique(node);

			foreach (var succ in node.Successors) {
				// skip back-edges
				if (succ.DfsIndex < node.DfsIndex)
					continue;

				if (succ.ImmediateDominator == immediateDom)
					return succ;

				return FindJoint(succ, immediateDom, visited);
			}

			return null;
		}

	}

}
