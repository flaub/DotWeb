using System;
using System.Linq;
using NUnit.Framework;
using DotWeb.Decompiler.Core;
using System.Collections.Generic;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class StructureLoopsTest
	{
		private List<Loop> TestLoops(SimpleGraphBuilder builder, params string[] args) {
			return TestLoops(builder.Graph, args);
		}

		private List<Loop> TestLoops(Graph graph, params string[] args) {
			graph.SortByDepthFirstPostOrder();
			graph.ComputeDominators();

			var loops = graph.StructureLoops();

			const string fmt = "{0}: {1}";
			var lines = loops.Select((x, i) => {
				var str = string.Format(fmt, i, x);
				Console.WriteLine(str);
				return str;
			}).ToArray();

			Assert.AreEqual(loops.Count, args.Length);

			for (int i = 0; i < args.Length; i++) {
				var expected = args[i];
				var actual = lines[i];
				Assert.AreEqual(expected, actual);
			}

			return loops;
		}

		[Test]
		public void Simple() {
			var builder = new SimpleGraphBuilder(2);
			builder.Connect(1, 2);
			TestLoops(builder);
		}

		[Test]
		public void SimpleBranch() {
			var graph = GraphLibrary.SimpleBranch();
			TestLoops(graph);
		}

		[Test]
		public void SimpleLoop() {
			TestLoops(GraphLibrary.SimpleLoop(),
				"0: (Endless) $N1, #N3, N2"
			);
		}

		[Test]
		public void SimpleDoWhile() {
			TestLoops(GraphLibrary.SimpleDoWhile(),
				"0: (Repeat) $#N2, !N3"
			);
		}

		[Test]
		public void SimpleWhile() {
			TestLoops(GraphLibrary.SimpleWhile(),
				"0: (While) $N3, #N2, !N4"
			);
		}

		[Test]
		public void WhileBreak() {
			TestLoops(GraphLibrary.WhileBreak(),
				"0: (While) $N2, #N3, !N4"
			);
		}

		[Test]
		public void WhileContinue() {
			TestLoops(GraphLibrary.WhileContinue(),
				"0: (Endless) $N2, #N3, #N4"
			);
		}

		[Test]
		public void WhileCondBreak() {
			TestLoops(GraphLibrary.WhileCondBreak(),
				"0: (While) $N5, #N4, N2, N3, !N6"
			);
		}

		[Test]
		public void WhileCondContinue() {
			TestLoops(GraphLibrary.WhileCondContinue(),
				"0: (While) $N5, #N3, N2, #N4, !N6"
			);
		}

		[Test]
		public void WhileBreakContinue() {
			TestLoops(GraphLibrary.WhileBreakContinue(),
				"0: (Endless) $N2, #N3, #N6, N4, !N5"
			);
		}

		[Test]
		public void WhileBreakBreak() {
			TestLoops(GraphLibrary.WhileBreakBreak(),
				"0: (While) $N2, #N6, N4, N5, N3, !N7"
			);
		}

		[Test]
		public void ComplexNestedLoop() {
			TestLoops(GraphLibrary.ComplexNestedLoop(),
				"0: (Endless) $N2, #N8, N5, N3, N6, N7, N4, !N9",
				"1: (Repeat) $#N6, !N7"
			);
		}

		[Test]
		public void MultiReturns() {
			TestLoops(GraphLibrary.MultiReturns(),
				"0: (While) $N7, #N6, N4, N2, N5, N3, !N8"
			);
		}

		[Test]
		public void MultiReturns2() {
			TestLoops(GraphLibrary.MultiReturns2(),
				"0: (While) $N7, #N6, N4, N2, N5, N3, !N8"
			);
		}

		[Test]
		public void NestedDoWhile() {
			var graph = GraphLibrary.NestedDoWhile();
			var loops = TestLoops(graph,
				"0: (Repeat) $#N2, !N3",
				"1: (While) $N4, #N3, N2, !N5"
			);

			var node = graph.Nodes.Single(x => x.Id == 2);
			Assert.AreEqual(2, node.Loops.Count);

			var innerLoop = node.Loops[0];
			var outerLoop = node.Loops[1];

			Assert.AreEqual(loops[0], innerLoop);
			Assert.AreEqual(loops[1], outerLoop);
		}

		[Test]
		public void DragonBook() {
			TestLoops(GraphLibrary.DragonBook(),
				"0: (While) $N7, #N10, N8",
				"1: (While) $N4, #N7, N5, N6, N10, N8",
				"2: (Endless) $N3, #N4, N7, N5, N6, N10, N8",
				"3: (Endless) $N1, #N9, N8, N7, N5, N6, N10, N4, N3, N2"
			);
		}

		[Test]
		public void Cifuentes1() {
			TestLoops(GraphLibrary.Cifuentes1(),
				"0: (While) $N2, #N4, N3, !N5",
				"1: (Repeat) $N1, #N5, N2, N4, N3, !N6"
			);
		}

		[Test]
		public void Cifuentes2() {
			TestLoops(GraphLibrary.Cifuentes2(),
				"0: (Repeat) $N8, #N9, !N10",
				"1: (While) $N6, #N10, N9, N8, N7, !N11"
			);
		}
	}
}
