using System;
using System.Linq;
using NUnit.Framework;
using DotWeb.Decompiler.Core;
using System.Collections.Generic;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class IntervalTests
	{
		class NodeTest : Node
		{
			public override string FullName {
				get { return this.RefName; }
			}
		}

		class IntervalSpec
		{
			public int[] NodeIds { get; set; }

			public void Test(Graph graph, Interval interval) {
				var expected = new List<Node>();
				foreach (var nodeId in NodeIds) {
					expected.Add(graph.Nodes[nodeId - 1]);
				}

				var actual = new List<Node>();
				interval.CollectNodes(actual);

				Assert.AreEqual(expected, actual);
			}
		}

		class IntervalGraphSpec
		{
			private Dictionary<int, IntervalSpec> intervals = new Dictionary<int, IntervalSpec>();

			public void Test(Graph graph, Graph intervalGraph) {
				Assert.AreEqual(this.intervals.Count, intervalGraph.Nodes.Count);

				for (int i = 0; i < intervalGraph.Nodes.Count; i++) {
					var expected = this.intervals[i + 1];
					var actual = (Interval)intervalGraph.Nodes[i];

					expected.Test(graph, actual);
				}
			}

			public IntervalSpec Get(int id) {
				IntervalSpec spec;
				if (!this.intervals.TryGetValue(id, out spec)) {
					spec = new IntervalSpec();
					this.intervals.Add(id, spec);
				}
				return spec;
			}
		}

		class TestSpec
		{
			private Dictionary<int, IntervalGraphSpec> levels = new Dictionary<int, IntervalGraphSpec>();

			public void Test(Graph graph, List<Graph> sequences) {
				Assert.AreEqual(this.levels.Count, sequences.Count);

				for (int i = 0; i < sequences.Count; i++) {
					var expected = this.levels[i + 1];
					var actual = sequences[i];

					expected.Test(graph, actual);
				}
			}

			public void ReadLine(string line) {
				// LevelId, IntervalId, Node[0], Node[1]
				var parts = line.Split(',');
				var levelId = GetId(parts[0]);
				var intervalId = GetId(parts[1]);

				var nodeIds = parts.Skip(2).Select(x => GetId(x));

				var graphSpec = Get(levelId);
				var intervalSpec = graphSpec.Get(intervalId);

				intervalSpec.NodeIds = nodeIds.ToArray();
			}

			private IntervalGraphSpec Get(int id) {
				IntervalGraphSpec level;
				if (!levels.TryGetValue(id, out level)) {
					level = new IntervalGraphSpec();
					levels.Add(id, level);
				}
				return level;
			}

			private int GetId(string part) {
				var number = part.Trim().Substring(1);
				return int.Parse(number);
			}
		}

		class GraphBuilder
		{
			private Graph graph;

			public GraphBuilder(int count) {
				this.graph = new Graph(null);

				for (int i = 0; i < count; i++) {
					var node = new NodeTest();
					this.graph.AddNode(node);
				}
			}

			public void Connect(int src, int tgt) {
				var pred = this.graph.Nodes[src - 1];
				var succ = this.graph.Nodes[tgt - 1];
				this.graph.Connect(pred, succ);
			}

			public void Print(List<Graph> graphs) {
				int i = 0;
				foreach (var graph in graphs) {
					Console.WriteLine("Level: {0}", i++);

					foreach (var interval in graph.Nodes) {
						Console.WriteLine(interval);
					}
				}
			}

			public void Test(params string[] lines) {
				var sequences = this.graph.DeriveSequences();
				Print(sequences);

				var spec = new TestSpec();
				foreach (var line in lines) {
					spec.ReadLine(line);
				}

				spec.Test(this.graph, sequences);
			}
		}

		[Test]
		public void Simple() {
			var builder = new GraphBuilder(2);
			builder.Connect(1, 2);
			builder.Test("L1, i1, n1, n2");
		}

		[Test]
		public void SimpleBranch() {
			var builder = new GraphBuilder(4);
			builder.Connect(1, 2);
			builder.Connect(1, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 4);
			builder.Test("L1, i1, n1, n2, n3, n4");
		}

		[Test]
		public void SimpleLoop() {
			var builder = new GraphBuilder(3);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(3, 1);
			builder.Test("L1, i1, n1, n2, n3");
		}

		[Test]
		public void DragonBook() {
			// Taken from the Dragon book, Page 661, Example 10.30, Fig. 10.45
			var builder = new GraphBuilder(10);
			builder.Connect(1, 3);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(3, 4);
			builder.Connect(4, 6);
			builder.Connect(4, 5);
			builder.Connect(4, 3);
			builder.Connect(5, 7);
			builder.Connect(6, 7);
			builder.Connect(7, 4);
			builder.Connect(7, 8);
			builder.Connect(8, 10);
			builder.Connect(8, 9);
			builder.Connect(8, 3);
			builder.Connect(9, 1);
			builder.Connect(10, 7);
			builder.Test(
				"L1, i1, n1, n2",
				"L1, i2, n3",
				"L1, i3, n4, n5, n6",
				"L1, i4, n7, n8, n9, n10",
				"L2, i1, n1, n2",
				"L2, i2, n3",
				"L2, i3, n4, n5, n6, n7, n8, n9, n10",
				"L3, i1, n1, n2",
				"L3, i2, n3, n4, n5, n6, n7, n8, n9, n10",
				"L4, i1, n1, n2, n3, n4, n5, n6, n7, n8, n9, n10"
			);
		}

		[Test]
		public void Cifuentes1() {
			// Taken from "Reverse Compilation Techniques", by C. Cifuentes, Section 6.3, Fig. 6-11
			var builder = new GraphBuilder(6);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(3, 4);
			builder.Connect(4, 2);
			builder.Connect(2, 5);
			builder.Connect(5, 1);
			builder.Connect(5, 6);
			builder.Test(
				"L1, i1, n1",
				"L1, i2, n2, n3, n4, n5, n6",
				"L2, i1, n1, n2, n3, n4, n5, n6"
			);
		}

		[Test]
		public void Cifuentes2() {
			// Taken from "Reverse Compilation Techniques", by C. Cifuentes, Section 6.3, Fig. 6-23
			var builder = new GraphBuilder(15);
			builder.Connect(1, 2);
			builder.Connect(1, 5);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 5);
			builder.Connect(4, 5);
			builder.Connect(5, 6);
			builder.Connect(6, 7);
			builder.Connect(6, 11);
			builder.Connect(7, 8);
			builder.Connect(8, 9);
			builder.Connect(9, 8);
			builder.Connect(9, 10);
			builder.Connect(10, 6);
			builder.Connect(11, 12);
			builder.Connect(11, 13);
			builder.Connect(12, 13);
			builder.Connect(12, 14);
			builder.Connect(13, 14);
			builder.Connect(14, 15);
			builder.Test(
				"L1, i1, n1, n2, n3, n4, n5",
				"L1, i2, n6, n7, n11, n12, n13, n14, n15",
				"L1, i3, n8, n9, n10",
				"L2, i1, n1, n2, n3, n4, n5",
				"L2, i2, n6, n7, n11, n12, n13, n14, n15, n8, n9, n10",
				"L3, i1, n1, n2, n3, n4, n5, n6, n7, n11, n12, n13, n14, n15, n8, n9, n10"
			);
		}
	}
}
