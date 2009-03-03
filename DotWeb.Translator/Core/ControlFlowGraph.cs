using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using DotWeb.Utility;

namespace DotWeb.Translator
{
	public class ControlFlowGraph
	{
		private int intervalIdGenerator = 1;
		private Dictionary<int, BasicBlock> blocks = new Dictionary<int, BasicBlock>();
		private CodeModelVirtualMachine context = new CodeModelVirtualMachine();

		public MethodBase Method { get; private set; } 
		public BasicBlock Root { get; private set; }
		public List<IntervalGraph> Graphs { get; private set; }
		public BasicBlock[] DfsList { get; private set; }
		public bool HasCases { get; private set; }
		public List<MethodBase> ExternalMethods { get; private set; }

		public ControlFlowGraph(MethodBase method) {
			this.Method = method;

			MethodBodyReader reader = new MethodBodyReader(method);
			this.HasCases = reader.HasCases;

			foreach (ILInstruction item in reader.Instructions) {
				Console.WriteLine(item);
			}
			
			CreateBlocks(reader.Instructions);
			ResolveBranches();
			Merge(this.Root);

			BasicBlock[] blocks = new BasicBlock[this.blocks.Values.Count];
			this.blocks.Values.CopyTo(blocks, 0);
			foreach (BasicBlock bb in blocks) {
				bb.InEdgeCount = 0;
				if (bb.DfsTraversed != DfsTraversal.Merge) {
					this.blocks.Remove(bb.BeginOffset);
				}
			}

			DfsNumbering();
			DeriveSequences();
			this.Root.GenerateCodeModel(this.context);
			this.ExternalMethods = this.context.ExternalMethods;
		}

		private void CreateBlocks(List<ILInstruction> instructions) {
			int id = 1;
			this.Root = new BasicBlock(id++);
			BasicBlock block = this.Root;
			foreach (ILInstruction ip in instructions) {
				block.Instructions.Add(ip);
				block = AddBlock(id++, block);
			}
		}

		private void Merge(BasicBlock bb) {
			while (bb.FlowControl != FlowControl.Cond_Branch &&
				bb.FlowControl != FlowControl.Return &&
				bb.FlowControl != FlowControl.Throw) {
				BasicBlock next = (BasicBlock)bb.OutEdges.First();
				if (next.InEdgeCount != 1)
					break;

				bb.OutEdges.Clear();
				bb.OutEdges.AddRange(next.OutEdges);
				bb.Instructions.AddRange(next.Instructions);

				blocks.Remove(next.BeginOffset);
			}
			bb.DfsTraversed = DfsTraversal.Merge;

			foreach (BasicBlock next in bb.OutEdges) {
				if (next.DfsTraversed != DfsTraversal.Merge) {
					Merge(next);
				}
			}
		}

		/// <summary>
		/// resolve branches into in/out edges
		/// </summary>
		private void ResolveBranches() {
			var branchBlocks = blocks.Values.Where(x => x.LastInstruction.IsBranch);
			foreach (BasicBlock bb in branchBlocks) {
				if (bb.LastInstruction.Code.OperandType == OperandType.InlineSwitch) {
					int[] cases = (int[])bb.LastInstruction.Operand;
					foreach (int targetOffset in cases) {
						ResolveBranchTarget(bb, targetOffset);
					}
				}
				else {
					int targetOffset = (int)bb.LastInstruction.Operand;
					ResolveBranchTarget(bb, targetOffset);
				}
			}
		}

		private void ResolveBranchTarget(BasicBlock bb, int targetOffset) {
			BasicBlock target = blocks[targetOffset];
			if (bb.OutEdges.AddUnique(target)) {
				target.InEdgeCount++;
			}
		}

		private BasicBlock AddBlock(int id, BasicBlock block) {
			blocks.Add(block.BeginOffset, block);
			BasicBlock ret = new BasicBlock(id);
			if (block.FlowControl != FlowControl.Return &&
				block.FlowControl != FlowControl.Branch && 
				block.FlowControl != FlowControl.Throw) {
				block.OutEdges.Add(ret);
				ret.InEdgeCount++;
			}
			return ret;
		}

		private void DfsNumbering() {
			int first = 0;
			int last = blocks.Count - 1;
			this.DfsList = new BasicBlock[blocks.Count];
			this.Root.DfsNumbering(this.DfsList, ref first, ref last);
		}

		private void DeriveSequences() {
			this.Graphs = new List<IntervalGraph>();
			Node root = this.Root;

			IntervalGraph intervals;
			int graphId = 1;
			do {
				intervals = FindIntervals(graphId++, root);
				this.Graphs.Add(intervals);
				root = intervals.First();
			}
			while (intervals.Count > 1);
		}

		/// <summary>
		/// Finds the intervals of graph derivedGi->Gi and places them in the list 
		/// of intervals derivedGi->Ii.
		/// Algorithm by M.S.Hecht.
		/// </summary>
		/// <returns></returns>
		private IntervalGraph FindIntervals(int graphId, Node root) {
			IntervalGraph intervals = new IntervalGraph(graphId);
			List<Node> headers = new List<Node>();

			headers.Enqueue(root);
			root.BeenOnHeaders = true;
			root.ReachingInterval = new Node(-1);

			/* Process header nodes list H */
			while (headers.Any()) {
				Node header = headers.Dequeue();

				Interval interval = new Interval(intervalIdGenerator++);
				interval.Process(headers, header);

				intervals.Add(interval);
			}

			ResolveLinks(intervals);
			return intervals;
		}

		private void ResolveLinks(IntervalGraph intervals) {
			foreach (Interval interval in intervals.Where(x => x.ExternalEdgeCount > 0)) {
				foreach (Node node in interval.Nodes) {
					foreach (Node succ in node.OutEdges) {
						if (succ.Interval != node.Interval) {
							interval.OutEdges.Add(succ.Interval);
							succ.Interval.AddInEdge(interval);
						}
					}
				}
			}
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			if (Graphs != null) {
				foreach (BasicBlock block in blocks.Values) {
					sb.AppendLine(block.ToString());
				}
			}
			else {
				int i = 0;
				foreach (IntervalGraph list in Graphs) {
					sb.AppendFormat("Level: {0}\n", i++);
					foreach (Interval interval in list) {
						sb.AppendLine(interval.ToString());
					}
				}
			}
			return sb.ToString();
		}
	}
}
