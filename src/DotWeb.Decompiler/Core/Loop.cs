using System;
using System.Linq;
using System.Collections.Generic;
using DotWeb.Utility;
using DotWeb.Decompiler.CodeModel;
using System.Diagnostics;

namespace DotWeb.Decompiler.Core
{
	public class Loop
	{
		public LoopType LoopType { get; set; }
		public Node Header { get; set; }
		public List<Node> Tails { get; private set; }
		public Node Follow { get; set; }
		public List<Node> Exits { get; private set; }
		public List<Node> Nodes { get; private set; }

		private Graph graph;

		public Loop(Graph graph) {
			this.graph = graph;
			this.LoopType = LoopType.None;
			this.Tails = new List<Node>();
			this.Nodes = new List<Node>();
			this.Exits = new List<Node>();
		}

		private string GetNodeName(Node node) {
			var str = node.RefName;
			if (Tails.Contains(node))
				str = "#" + str;
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
			node.Loops.Add(this);
		}

		public CodeLoopStatement CreateLoopStatement() {
//			var bbHeader = (BasicBlock)this.Header;
			if (this.LoopType == LoopType.While ||
				this.LoopType == LoopType.Endless) {
				return CreateWhileStatement();
			}
			else {
				return CreateRepeatStatement();
			}
		}

		private CodeWhileStatement CreateWhileStatement() {
			var stmt = new CodeWhileStatement {
				TestExpression = new CodePrimitiveExpression(true)
			};

			Node succ;
			if (Header.Successors.Count > 1) {
				// not an endless loop:
				// if(cond) { <then>; break; }
				// FIXME: get correct successor here
				succ = Header.Successors.First();
			}
			else {
				succ = Header.Successors.First();
			}

			return stmt;
		}

		private CodeRepeatStatement CreateRepeatStatement() {
			return null;
		}


		/*
		NaturalLoopForEdge(Block header, Block tail)
		{
			Stack workList;
			Loop  loop;
		 
			loop = new Loop();
		 
			loop->header = header
			loop->blocks += header
		 
			if header != tail {
				loop->blocks += tail
				workList += tail
			}
			while workList not empty {
				block = workList.pop
				for each pred in block->predecessors {
					if not loop->find(pred) {
						loop->blocks += pred
						workList += pred
					}
				}
			}
			return loop
		}*/
		public static Loop Construct(Graph graph, Node header, List<Node> tails) {
			var loop = new Loop(graph) {
				Header = header,
				Tails = tails
			};

			loop.AddNode(header);

			foreach (var tail in tails) {
				loop.AddFromTail(tail);
			}

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
					if (joint.ImmediateDominatorNode == commonDom) {
						// walk down exit2 until we get a node that has an ImmediateDominator == commonDom
						start = exit;
						other = joint;
					}
					else if (exit.ImmediateDominatorNode == commonDom) {
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

			//for (int i = node.DfsIndex; i < this.graph.Nodes.Count; i++) {
			//    var succ = this.graph.Nodes[i];
			//    if (succ.ImmediateDominatorNode == immediateDom)
			//        return succ;

			//    visited.AddUnique(succ);
			//}

			foreach (var succ in node.Successors) {
				// skip back-edges
				if (succ.DfsIndex < node.DfsIndex)
					continue;

				if (succ.ImmediateDominatorNode == immediateDom)
					return succ;

				return FindJoint(succ, immediateDom, visited);
			}

			return null;
		}

	}

}
