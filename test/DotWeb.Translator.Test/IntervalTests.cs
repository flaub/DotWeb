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
using System.Linq;
using NUnit.Framework;
using DotWeb.Decompiler.Core;
using System.Collections.Generic;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class IntervalTests
	{
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

		private void Print(List<Graph> graphs) {
			int i = 0;
			foreach (var graph in graphs) {
				Console.WriteLine("Level: {0}", i++);

				foreach (var interval in graph.Nodes) {
					Console.WriteLine(interval);
				}
			}
		}

		private void Test(ControlFlowGraph graph, params string[] lines) {
			var sequences = graph.DeriveSequences();
			Print(sequences);

			var spec = new TestSpec();
			foreach (var line in lines) {
				spec.ReadLine(line);
			}

			spec.Test(graph, sequences);
		}

		[Test]
		public void Simple() {
			var builder = new SimpleGraphBuilder(2);
			builder.Connect(1, 2);
			Test(builder.Graph, "L1, i1, n1, n2");
		}

		[Test]
		public void SimpleBranch() {
			Test(GraphLibrary.SimpleBranch(), "L1, i1, n1, n2, n3, n4");
		}

		[Test]
		public void SimpleLoop() {
			Test(GraphLibrary.SimpleLoop(), "L1, i1, n1, n2, n3");
		}

		[Test]
		public void WhileBreak() {
			Test(GraphLibrary.WhileBreak(), 
				"L1, i1, n1", 
				"L1, i2, n2, n3, n4", 
				"L2, i1, n1, n2, n3, n4"
			);
		}

		[Test]
		public void DragonBook() {
			Test(GraphLibrary.DragonBook(), 
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
			Test(GraphLibrary.Cifuentes1(), 
				"L1, i1, n1",
				"L1, i2, n2, n3, n4, n5, n6",
				"L2, i1, n1, n2, n3, n4, n5, n6"
			);
		}

		[Test]
		public void Cifuentes2() {
			Test(GraphLibrary.Cifuentes2(), 
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
