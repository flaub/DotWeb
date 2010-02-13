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
