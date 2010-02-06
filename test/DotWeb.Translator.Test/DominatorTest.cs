using System;
using System.Linq;
using NUnit.Framework;
using DotWeb.Decompiler.Core;

namespace DotWeb.Translator.Test
{
	//[TestFixture]
	public class DominatorTest
	{
		private void TestDominators(SimpleGraphBuilder builder, params string[] args) {
			TestDominators(builder.Graph, args);
		}

		private void TestDominators(Graph graph, params string[] args) {
			//graph.ComputeDominators();

			const string fmt = "{0}: {1}";
			var lines = graph.Nodes.Select((x, i) => {
				var line = string.Format(fmt, x.Id, x.Dominators.ToString());
				Console.WriteLine(line);
				return line;
			}).ToArray();

			Assert.AreEqual(lines.Length, args.Length);

			for (int i = 0; i < args.Length; i++) {
				var expected = args[i];
				var actual = lines[i];
				Assert.AreEqual(expected, actual);
			}
		}

		[Test]
		public void Simple() {
			TestDominators(GraphLibrary.Simple(), 
				"1: {10}", 
				"2: {11}"
			);
		}

		[Test]
		public void SimpleBranch() {
			TestDominators(GraphLibrary.SimpleBranch(),
				"1: {1000}",
				"2: {1100}",
				"3: {1010}",
				"4: {1001}"
			);
		}

		[Test]
		public void SimpleLoop() {
			TestDominators(GraphLibrary.SimpleLoop(),
				"1: {100}",
				"2: {110}",
				"3: {111}"
			);
		}

		[Test]
		public void SimpleWhile() {
			TestDominators(GraphLibrary.SimpleWhile(),
				"1: {1000}",
				"2: {1110}",
				"3: {1010}",
				"4: {1011}"
			);
		}

		[Test]
		public void WhileBreak() {
			TestDominators(GraphLibrary.WhileBreak(),
				"1: {1000}",
				"2: {1100}",
				"3: {1110}",
				"4: {1101}"
			);
		}

		[Test]
		public void NestedDoWhile() {
			TestDominators(GraphLibrary.NestedDoWhile(),
				"1: {10000}",
				"2: {11010}",
				"3: {11110}",
				"4: {10010}",
				"5: {10011}"
			);
		}

		[Test]
		public void WhileBreakBreak() {
			TestDominators(GraphLibrary.WhileBreakBreak(),
				"1: {1000000}",
				"2: {1100000}",
				"3: {1110000}",
				"4: {1101000}",
				"5: {1101100}",
				"6: {1101010}",
				"7: {1100001}"
			);
		}
	}
}
