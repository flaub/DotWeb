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
