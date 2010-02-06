using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Diagnostics;

namespace DotWeb.Decompiler.Core
{
	public class ControlFlowGraphBuilder
	{
		private MethodBody body;
		private SortedDictionary<int, BasicBlock> blocks = new SortedDictionary<int, BasicBlock>();
		private Graph graph;

		public ControlFlowGraphBuilder(MethodDefinition method) {
			this.body = method.Body;
			this.graph = new Graph(null);
		}

		public Graph CreateGraph() {
			DelimitBlocks();
			ConnectBlocks();
			return this.graph;
		}

		private void DelimitBlocks() {
			MarkBlockStarts();
			MarkBlockEnds();
		}

		private void ConnectBlocks() {
			foreach (var block in blocks.Values) {
				ConnectBlock(block);
			}
		}

		private void ConnectBlock(BasicBlock block) {
			var cil = block.LastInstruction;
			switch (block.FlowControl) {
				case FlowControl.Branch:
				case FlowControl.Cond_Branch: {
						var target = GetBranchTargetBlock(cil);
						if (block.FlowControl == FlowControl.Cond_Branch && cil.Next != null) {
							this.graph.Connect(block, GetBlock(cil.Next));
						}
						this.graph.Connect(block, target);
					}
					break;
				case FlowControl.Call:
				case FlowControl.Next:
					if (cil.Next != null) {
						this.graph.Connect(block, GetBlock(cil.Next));
					}
					break;
				case FlowControl.Return:
				case FlowControl.Throw:
					break;
				default:
					throw new NotSupportedException();
			}
		}

		private void MarkBlockStarts() {
			for (int i = 0; i < this.body.Instructions.Count; i++) {
				var cil = this.body.Instructions[i];
				if (i == 0) {
					MarkBlockStart(cil);
				}

				if (!IsBlockDelimiter(cil)) {
					continue;
				}

				var target = GetBranchTarget(cil);
				if (target != null) {
					MarkBlockStart(target);
				}

				// the next instruction after a branch starts a block
				if (cil.Next != null) {
					MarkBlockStart(cil.Next);
				}
			}
		}

		private void MarkBlockEnds() {
			var iterator = this.blocks.GetEnumerator();
			iterator.MoveNext();

			var current = iterator.Current;
			this.graph.AddNode(current.Value);

			var cil = current.Value.FirstInstruction;
			// move past first instruction
			cil = cil.Next;

			while (iterator.MoveNext()) {

				var next = iterator.Current;
				this.graph.AddNode(next.Value);

				cil = CopyInstructions(cil, next.Key, current.Value.Instructions);
				current = next;

				cil = cil.Next;
			}

			while (cil != null) {
				current.Value.Instructions.Add(cil);
				cil = cil.Next;
			}
		}

		private Instruction CopyInstructions(Instruction cil, int offset, List<Instruction> into) {
			while (cil.Offset < offset) {
				into.Add(cil);
				cil = cil.Next;
			}

			Debug.Assert(cil.Offset == offset);
			return cil;
		}

		private void MarkBlockStart(Instruction cil) {
			var block = GetBlock(cil);
			if (block == null) {
				block = new BasicBlock(this.body.Method);
				block.Instructions.Add(cil);
				RegisterBlock(block);
			}
		}

		private void RegisterBlock(BasicBlock block) {
			blocks.Add(block.FirstInstruction.Offset, block);
		}

		private BasicBlock GetBlock(Instruction cil) {
			BasicBlock block;
			this.blocks.TryGetValue(cil.Offset, out block);
			return block;
		}

		private bool IsBlockDelimiter(Instruction cil) {
			switch (cil.OpCode.FlowControl) {
				case FlowControl.Break:
				case FlowControl.Branch:
				case FlowControl.Return:
				case FlowControl.Cond_Branch:
					return true;
			}
			return false;
		}

		private Instruction GetBranchTarget(Instruction cil) {
			return (Instruction)cil.Operand;
		}

		private BasicBlock GetBranchTargetBlock(Instruction cil) {
			return GetBlock(GetBranchTarget(cil));
		}
	}
}
