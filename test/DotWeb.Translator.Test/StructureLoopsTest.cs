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
	public class StructureLoopsTest
	{
		private List<Loop> TestLoops(ControlFlowGraph graph, params string[] args) {
			graph.SortByDepthFirstPostOrder();

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
			TestLoops(GraphLibrary.Simple());
		}

		[Test]
		public void SimpleBranch() {
			TestLoops(GraphLibrary.SimpleBranch());
		}

		[Test]
		public void SimpleLoop() {
			TestLoops(GraphLibrary.SimpleLoop(),
				"0: (Endless) $N1, &#N3, N2"
			);
		}

		[Test]
		public void SimpleDoWhile() {
			TestLoops(GraphLibrary.SimpleDoWhile(),
				"0: (Repeat) $&#N2, !N3"
			);
		}

		[Test]
		public void SimpleWhile() {
			TestLoops(GraphLibrary.SimpleWhile(),
				"0: (While) $N3, &#N2, !N4"
			);
		}

		[Test]
		public void WhileBreak() {
			TestLoops(GraphLibrary.WhileBreak(),
				"0: (While) $N2, &#N3, !N4"
			);
		}

		[Test]
		public void WhileContinue() {
			TestLoops(GraphLibrary.WhileContinue(),
				"0: (Endless) $N2, &#N4, #N3"
			);
		}

		[Test]
		public void WhileCondBreak() {
			TestLoops(GraphLibrary.WhileCondBreak(),
				"0: (While) $N5, &#N4, N2, N3, !N6"
			);
		}

		[Test]
		public void WhileCondContinue() {
			TestLoops(GraphLibrary.WhileCondContinue(),
				"0: (While) $N5, &#N4, N2, #N3, !N6"
			);
		}

		[Test]
		public void WhileBreakContinue() {
			TestLoops(GraphLibrary.WhileBreakContinue(),
				"0: (Endless) $N2, &#N6, N4, #N3, !N5"
			);
		}

		[Test]
		public void WhileBreakBreak() {
			TestLoops(GraphLibrary.WhileBreakBreak(),
				"0: (While) $N2, &#N6, N4, N5, N3, !N7"
			);
		}

		[Test]
		public void ComplexNestedLoop() {
			TestLoops(GraphLibrary.ComplexNestedLoop(),
				"0: (Endless) $N2, &#N8, N5, N3, N6, N7, N4, !N9",
				"1: (Repeat) $&#N6, !N7"
			);
		}

		[Test]
		public void MultiReturns() {
			TestLoops(GraphLibrary.MultiReturns(),
				"0: (While) $N7, &#N6, N4, N2, N5, N3, !N8"
			);
		}

		[Test]
		public void MultiReturns2() {
			TestLoops(GraphLibrary.MultiReturns2(),
				"0: (While) $N7, &#N6, N4, N2, N5, N3, !N8"
			);
		}

		[Test]
		public void NestedDoWhile() {
			var graph = GraphLibrary.NestedDoWhile();
			var loops = TestLoops(graph,
				"0: (Repeat) $&#N2, !N3",
				"1: (While) $N4, &#N3, N2, !N5"
			);

			var node = graph.Nodes.Single(x => x.Id == 2);
			Assert.AreEqual(loops[0], node.Loop);
		}

		[Test]
		public void SwitchInsideWhile() {
			TestLoops(GraphLibrary.SwitchInsideWhile(),
				"0: (While) $N9, #N6, N2, &#N8, N5, N7, N3, N4, !N10"
			);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DragonBook() {
			TestLoops(GraphLibrary.DragonBook(),
				"0: (While) $N7, &#N10, N8",
				"1: (While) $N4, &#N7, N5, N6, N10, N8",
				"2: (Endless) $N3, &#N4, N7, N5, N6, N10, N8",
				"3: (Endless) $N1, &#N9, N8, N7, N5, N6, N10, N4, N3, N2"
			);
		}

		[Test]
		public void Cifuentes1() {
			TestLoops(GraphLibrary.Cifuentes1(),
				"0: (While) $N2, &#N4, N3, !N5",
				"1: (Repeat) $N1, &#N5, N2, N4, N3, !N6"
			);
		}

		[Test]
		public void Cifuentes2() {
			TestLoops(GraphLibrary.Cifuentes2(),
				"0: (Repeat) $N8, &#N9, !N10",
				"1: (While) $N6, &#N10, N9, N8, N7, !N11"
			);
		}
	}
}
