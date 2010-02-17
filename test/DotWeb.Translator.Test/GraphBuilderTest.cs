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
using DotWeb.Translator.Test.Properties;
using Mono.Cecil;
using System.Diagnostics;
using System.Text;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class GraphBuilderTest : TranslationTestHelper
	{
		private TypeDefinition compiledType;

		public GraphBuilderTest()
			: base("DotWeb.Translator.Test.Script", GraphBuilderTestData.Source) {
			this.compiledType = this.CompiledAssembly.MainModule.Types["H8.GraphBuilderTest"];
		}

		private string ToStringDetails(Graph graph) {
			var sb = new StringBuilder();
			foreach (BasicBlock block in graph.Nodes) {
				sb.AppendLine(block.ToStringDetails());
			}
			return sb.ToString();
		}

		private void TestGraph() {
			var frame = new StackFrame(1);
			var methodName = frame.GetMethod().Name;
			var method = this.compiledType.Methods.GetMethod(methodName).First();
			var builder = new ControlFlowGraphBuilder(method);
			var graph = builder.CreateGraph();
			graph.SortByDepthFirstPostOrder();

			var actual = ToStringDetails(graph).Trim();
			Console.WriteLine("Actual:");
			Console.WriteLine(actual);

			var expected = GraphBuilderTestData.ResourceManager.GetString(methodName).Trim();
			Console.WriteLine("Expected:");
			Console.WriteLine(expected);

			graph.PrintDot(methodName);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NullBlock() { TestGraph(); }
		[Test]
		public void OneBlock() { TestGraph(); }
		[Test]
		public void SimpleIf() { TestGraph(); }
		[Test]
		public void WhileBreak() { TestGraph(); }
		[Test]
		public void Switch() { TestGraph(); }
		[Test]
		public void TryCatchFinally() { TestGraph(); }
	}
}
