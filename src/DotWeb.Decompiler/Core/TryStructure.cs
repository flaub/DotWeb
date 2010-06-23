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
using System.Diagnostics;

namespace DotWeb.Decompiler.Core
{
	public class TryStructure
	{
		public Node Header { get; set; }
		public Node Follow { get; set; }
		public Node Finally { get; set; }
		public List<Node> Catches { get; private set; }
		public List<Node> Nodes { get; private set; }

		private Graph graph;

		public TryStructure(Graph graph, Node header) {
			this.graph = graph;
			this.Header = header;
			this.Nodes = new List<Node>();
			this.Catches = new List<Node>();

			this.Header.IsTryHeader = true;

			CollectNodes((BasicBlock)this.Header, true);
			MatchOrphans();
		}

		private void AddNode(Node node) {
			this.Nodes.AddUnique(node);
			if (node.Try == null) {
				node.Try = this;
			}
		}

		private void MatchOrphans() {
			var headerBlock = (BasicBlock)this.Header;
			foreach (BasicBlock orphan in this.graph.Orphans) {
				var first = orphan.Instructions.First();
				if (orphan.ExceptionHandler.TryStart == headerBlock.ExceptionHandler.TryStart) {
					switch (orphan.ExceptionHandler.HandlerType) {
						case ExceptionHandlerType.Catch:
							this.Catches.Add(orphan);
							CollectNodes(orphan, false);
							break;
						case ExceptionHandlerType.Finally:
							// there should only ever be one finally per try
							Debug.Assert(this.Finally == null);
							this.Finally = orphan;
							CollectNodes(orphan, false);
							break;
						default:
							throw new NotSupportedException();
					}
				}
			}
		}

		private void CollectNodes(BasicBlock block, bool findFollow) {
			if (this.Nodes.Contains(block))
				return;

			AddNode(block);
			if (block.LastInstruction.IsLeave() && 
				(block.Try == null || block.Try == this || block.Try.Follow == block)) {
				var follow = (BasicBlock)block.Successors.Single();
				if (findFollow && !follow.IsLoopHeader) {
					this.Follow = follow;
					AddNode(this.Follow);
				}
				return;
			}

			foreach (BasicBlock succ in block.Successors) {
				CollectNodes(succ, findFollow);
			}
		}
	}
}
