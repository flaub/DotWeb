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
using Mono.Cecil;
using Mono.Cecil.Cil;
using DotWeb.Utility.Cecil;

namespace DotWeb.Decompiler.Core
{
	class ControlFlowGraph
	{
		//private int intervalIdGenerator = 1;
		private readonly CodeModelVirtualMachine context = new CodeModelVirtualMachine();

		public MethodDefinition Method { get; private set; }
		public BasicBlock Root { get { return (BasicBlock)this.BasicGraph.Root; } }
		public List<Graph> Graphs { get; private set; }
		public BasicBlock[] DepthFirstPostOrder { get; private set; }
		public bool HasCases { get; private set; }
		public HashSet<MethodReference> ExternalMethods { get; private set; }
		public Graph BasicGraph { get; private set; }

		public ControlFlowGraph(TypeSystem typeSystem, MethodDefinition method) {
			this.Method = method;
			this.BasicGraph = new Graph(null);
			this.HasCases = false;

			var blocksByOffset = new Dictionary<int, BasicBlock>();

			CreateBlocks(blocksByOffset);
			ResolveBranches(blocksByOffset);
			Merge(this.Root);

			this.BasicGraph.Nodes.RemoveAll((Node node) => {
				return node.DfsTraversed != DfsTraversal.Merge;
			});

			DfsNumbering();
			this.Graphs = this.BasicGraph.DeriveSequences();
			this.Root.GenerateCodeModel(typeSystem, this.context);
			this.ExternalMethods = this.context.ExternalMethods;
		}

		private void CreateBlocks(Dictionary<int, BasicBlock> blocksByOffset) {
			BasicBlock lastBlock = null;
			foreach (Instruction cil in Method.Body.Instructions) {
				if (cil.OpCode.OperandType == OperandType.InlineSwitch)
					this.HasCases = true;

				var block = new BasicBlock(Method);
				block.Instructions.Add(cil);
				blocksByOffset.Add(block.BeginOffset, block);
				this.BasicGraph.AddNode(block);

				if (lastBlock != null) {
					var flow = lastBlock.FlowControl;
					if (flow != FlowControl.Return && 
						flow != FlowControl.Branch &&
						flow != FlowControl.Throw) {
						this.BasicGraph.Connect(lastBlock, block);
					}
				}

				lastBlock = block;
			}
		}

		private void Merge(BasicBlock bb) {
			while (bb.FlowControl != FlowControl.Cond_Branch &&
				bb.FlowControl != FlowControl.Return &&
				bb.FlowControl != FlowControl.Throw) {
				BasicBlock next = (BasicBlock)bb.Successors.First();
				if (next.Predecessors.Count != 1)
					break;

				this.BasicGraph.Merge(bb, next);

				bb.Instructions.AddRange(next.Instructions);
			}
			bb.DfsTraversed = DfsTraversal.Merge;

			foreach (BasicBlock next in bb.Successors) {
				if (next.DfsTraversed != DfsTraversal.Merge) {
					Merge(next);
				}
			}
		}

		/// <summary>
		/// resolve branches into in/out edges
		/// </summary>
		private void ResolveBranches(Dictionary<int, BasicBlock> blocksByOffset) {
			var branchBlocks = blocksByOffset.Values.Where(x => x.LastInstruction.IsBranch());
			foreach (BasicBlock bb in branchBlocks) {
				if (bb.LastInstruction.OpCode.OperandType == OperandType.InlineSwitch) {
					var targets = (Instruction[])bb.LastInstruction.Operand;
					foreach (var target in targets) {
						this.BasicGraph.Connect(bb, blocksByOffset[target.Offset]);
					}
				}
				else {
					var target = (Instruction)bb.LastInstruction.Operand;
					this.BasicGraph.Connect(bb, blocksByOffset[target.Offset]);
				}
			}
		}

		private void DfsNumbering() {
			int first = 0;
			int last = this.BasicGraph.Nodes.Count - 1;
			this.DepthFirstPostOrder = new BasicBlock[this.BasicGraph.Nodes.Count];
			this.Root.DfsNumbering(this.DepthFirstPostOrder, ref first, ref last);
		}

		//private void DeriveSequences() {
		//    this.Graphs = new List<IntervalGraph>();
		//    Node root = this.Root;

		//    IntervalGraph intervals;
		//    int graphId = 1;
		//    do {
		//        intervals = FindIntervals(graphId++, root);
		//        this.Graphs.Add(intervals);
		//        root = intervals.First();
		//    }
		//    while (intervals.Count > 1);
		//}

		/// <summary>
		/// Finds the intervals of graph derivedGi->Gi and places them in the list 
		/// of intervals derivedGi->Ii.
		/// Algorithm by M.S.Hecht.
		/// </summary>
		/// <returns></returns>
		//private IntervalGraph FindIntervals(int graphId, Node root) {
		//    IntervalGraph intervals = new IntervalGraph(graphId);
		//    var headers = new List<Node>();

		//    //headers.Enqueue(root);
		//    headers.Add(root);
		//    root.BeenOnHeaders = true;
		//    //root.ReachingInterval = new Node(-1);

		//    /* Process header nodes list H */
		//    while (headers.Any()) {
		//        Node header = headers.Dequeue();

		//        Interval interval = new Interval(intervalIdGenerator++);
		//        interval.Process(headers, header);

		//        intervals.Add(interval);
		//    }

		//    ResolveLinks(intervals);
		//    return intervals;
		//}

		//private void ResolveLinks(IntervalGraph intervals) {
		//    foreach (Interval interval in intervals.Where(x => x.ExternalEdgeCount > 0)) {
		//        foreach (Node node in interval.Nodes) {
		//            foreach (Node succ in node.Successors) {
		//                if (succ.Interval != node.Interval) {
		//                    interval.Successors.Add(succ.Interval);
		//                    //succ.Interval.AddPredecessor(interval);
		//                    succ.Interval.Predecessors.Add(interval);
		//                }
		//            }
		//        }
		//    }
		//}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			if (Graphs != null) {
				foreach (BasicBlock block in this.BasicGraph.Nodes) {
					sb.AppendLine(block.ToString());
				}
			}
			else {
				int i = 0;
				foreach (var graph in Graphs) {
					sb.AppendFormat("Level: {0}\n", i++);
					foreach (var interval in graph.Nodes) {
						sb.AppendLine(interval.ToString());
					}
				}
			}
			return sb.ToString();
		}
	}
}
