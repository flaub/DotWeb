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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Decompiler.Core
{
	public class Conditional
	{
		public Node Header { get; set; }
		public Node Follow { get; set; }

		private Graph graph;

		public Conditional(Graph graph, Node header) {
			this.graph = graph;
			this.Header = header;
		}

		public override string ToString() {
			return string.Format("{0} -> {1}", Header.RefName, Follow == null ? "" : Follow.RefName);
		}

		public void FindFollow() {
			int followPredCount = 0;
			Node follow = null;

			for (int i = Header.DfsIndex + 1; i < this.graph.Nodes.Count; i++) {
				var descendant = this.graph.Nodes[i];
				if (descendant.ImmediateDominator == this.Header) {
					var forwardInEdges = descendant.Predecessors.Where(x => x.DfsIndex < descendant.DfsIndex).Count();
					if (forwardInEdges >= followPredCount) {
						followPredCount = forwardInEdges;
						follow = descendant;
					}
				}
			}

			if (follow != null && followPredCount > 1) {
				this.Follow = follow;
			}
		}
	}

}
