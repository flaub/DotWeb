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
using System.Diagnostics;

namespace DotWeb.Decompiler.Core
{
	class ControlFlowGraph
	{
		private readonly CodeModelGenerator generator;

		public MethodDefinition Method { get; private set; }
		public BasicBlock Root { get { return (BasicBlock)this.BasicGraph.Root; } }
		public List<Graph> Sequences { get; private set; }
		public BasicBlock[] DepthFirstPostOrder { get; private set; }
		public bool HasCases { get; private set; }
		public HashSet<MethodReference> ExternalMethods { get { return this.generator.ExternalMethods; } }
		public Graph BasicGraph { get; private set; }

		public ControlFlowGraph(TypeSystem typeSystem, MethodDefinition method) {
			this.Method = method;
			this.HasCases = false;

			this.generator = new CodeModelGenerator(typeSystem, method);

			var builder = new ControlFlowGraphBuilder(method);
			this.BasicGraph = builder.CreateGraph();

			DfsNumbering();
			this.Sequences = this.BasicGraph.DeriveSequences();
			GenerateCodeModel();
		}

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			foreach (BasicBlock block in this.BasicGraph.Nodes) {
				sb.AppendLine(block.ToStringDetails());
			}

			int i = 0;
			foreach (var graph in Sequences) {
				sb.AppendFormat("Level: {0}\n", i++);
				foreach (var interval in graph.Nodes) {
					sb.AppendLine(interval.ToString());
				}
			}
			return sb.ToString();
		}

		public void PrintDot() {
			Console.WriteLine("digraph G {");
			Console.WriteLine("\tgraph [label=\"{0}\"];", this.Method);
			var first = this.Sequences.First();

			foreach (Interval interval in first.Nodes) {
				Console.WriteLine("\tsubgraph cluster_{0} {{", interval.RefName);
				Console.WriteLine("\t\tgraph [label=\"{0}\"];", interval.RefName);
				var nodes = new List<Node>();
				interval.CollectNodes(nodes);
				foreach (BasicBlock block in nodes) {
					Console.WriteLine("\t\t{0} [label=\"{0} (#{1}) (^{2})\\n{3}\"];", 
						block.RefName, 
						block.DfsIndex,
						block.ImmediateDominatorNode == null ? "" : block.ImmediateDominatorNode.RefName,
						block.LastInstruction.OpCode);
				}
				Console.WriteLine("\t}");
			}

			foreach (var block in this.BasicGraph.Nodes) {
				foreach (var succ in block.Successors) {
					Console.WriteLine("\t{0} -> {1};", block.RefName, succ.RefName);
				}
			}

			Console.WriteLine("}");
		}

		public void Structure() {
		}

		private void GenerateCodeModel() {
			this.BasicGraph.DepthFirstTraversal((Node node) => {
				// Accumulate statements into node.Statements
				this.generator.ProcessBlock((BasicBlock)node);
			});
		}

		private void DfsNumbering() {
			int first = 0;
			int last = this.BasicGraph.Nodes.Count - 1;
			this.DepthFirstPostOrder = new BasicBlock[this.BasicGraph.Nodes.Count];
			this.Root.DfsNumbering(this.DepthFirstPostOrder, ref first, ref last);
		}

	}
}
