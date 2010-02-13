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
	public class StructureConditionalsTest
	{
		private List<Conditional> TestConditionals(ControlFlowGraph graph, params string[] args) {
			graph.SortByDepthFirstPostOrder();

			graph.StructureLoops();
			var conditionals = graph.StructureConditionals();

			const string fmt = "{0}: {1}";
			var lines = conditionals.Select((x, i) => {
				var str = string.Format(fmt, i, x);
				Console.WriteLine(str);
				return str;
			}).ToArray();

			Assert.AreEqual(conditionals.Count, args.Length);

			for (int i = 0; i < args.Length; i++) {
				var expected = args[i];
				var actual = lines[i];
				Assert.AreEqual(expected, actual);
			}

			return conditionals;
		}

		[Test]
		public void Simple() {
			TestConditionals(GraphLibrary.Simple());
		}

		[Test]
		public void SimpleBranch() {
			TestConditionals(GraphLibrary.SimpleBranch(),
				"0: N1 -> N4"
			);
		}

		[Test]
		public void SimpleLoop() {
			TestConditionals(GraphLibrary.SimpleLoop());
		}

		[Test]
		public void WhileBreak() {
			TestConditionals(GraphLibrary.WhileBreak());
		}

		[Test]
		public void SimpleWhile() {
			TestConditionals(GraphLibrary.SimpleWhile());
		}

		[Test]
		public void WhileCondBreak() {
			TestConditionals(GraphLibrary.WhileCondBreak(),
				"0: N2 -> "
			);
		}

		[Test]
		public void WhileCondContinue() {
			TestConditionals(GraphLibrary.WhileCondContinue(),
				"0: N2 -> "
			);
		}

		[Test]
		public void WhileBreakContinue() {
			TestConditionals(GraphLibrary.WhileBreakContinue(),
				"0: N4 -> "
			);
		}

		[Test]
		public void WhileBreakBreak() {
			TestConditionals(GraphLibrary.WhileBreakBreak(),
				"0: N4 -> "
			);
		}

		[Test]
		public void ComplexNestedLoop() {
			TestConditionals(GraphLibrary.ComplexNestedLoop(),
				"0: N5 -> N9",
				"1: N3 -> N9"
			);
		}

		[Test]
		public void MultiReturns() {
			TestConditionals(GraphLibrary.MultiReturns(),
				"0: N4 -> ",
				"1: N2 -> "
			);
		}

		[Test]
		public void MultiReturns2() {
			TestConditionals(GraphLibrary.MultiReturns2(),
				"0: N4 -> ",
				"1: N2 -> "
			);
		}

		[Test]
		public void NestedDoWhile() {
			TestConditionals(GraphLibrary.NestedDoWhile());
		}

		[Test]
		public void Switch() {
			TestConditionals(GraphLibrary.Switch(),
				"0: N1 -> N6"
			);
		}

		[Test]
		public void SwitchInsideWhile() {
			TestConditionals(GraphLibrary.SwitchInsideWhile(),
				"0: N2 -> N8"
			);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DragonBook() {
			TestConditionals(GraphLibrary.DragonBook());
		}

		[Test]
		public void Cifuentes1() {
			TestConditionals(GraphLibrary.Cifuentes1());
		}

		[Test]
		public void Cifuentes2() {
			TestConditionals(GraphLibrary.Cifuentes2(),
				"0: N12 -> N14",
				"1: N11 -> N14",
				"2: N2 -> N5",
				"3: N1 -> N5"
			);
		}
	}
}
