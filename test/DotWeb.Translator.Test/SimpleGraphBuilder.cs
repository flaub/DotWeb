using System;
using DotWeb.Decompiler.Core;
using System.Collections.Generic;

namespace DotWeb.Translator.Test
{
	class NodeTest : Node
	{
		public override string FullName {
			get { return this.RefName; }
		}
	}

	class SimpleGraphBuilder
	{
		public ControlFlowGraph Graph { get; private set; }

		public SimpleGraphBuilder(int count) {
			this.Graph = new ControlFlowGraph();

			for (int i = 0; i < count; i++) {
				var node = new NodeTest();
				this.Graph.AddNode(node);
			}
		}

		public void Connect(int src, int tgt) {
			var pred = this.Graph.Nodes[src - 1];
			var succ = this.Graph.Nodes[tgt - 1];
			this.Graph.Connect(pred, succ);
		}
	}

}
