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
using DotWeb.Translator.Test.Properties;
using NUnit.Framework;
using Mono.Cecil;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class LoopsTest : TranslationTestHelper
	{
		private TypeDefinition sourceTestsCompiledType;

		public LoopsTest()
			: base("DotWeb.Translator.Test.Script", Loops.Source) {
			this.sourceTestsCompiledType = this.CompiledAssembly.MainModule.Types["H8.Loops"];
		}

		[Test]
		public void SimpleFor() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleFor", Loops.SimpleFor);
		}

		[Test]
		public void SimpleDoWhile() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleDoWhile", Loops.SimpleDoWhile);
		}

		[Test]
		public void SimpleWhile() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleWhile", Loops.SimpleWhile);
		}

		[Test]
		public void NestedDoWhile() {
			this.TestMethod(this.sourceTestsCompiledType, "NestedDoWhile", Loops.NestedDoWhile);
		}

		[Test]
		public void BreakInWhile() {
			this.TestMethod(this.sourceTestsCompiledType, "BreakInWhile", Loops.BreakInWhile);
		}

		[Test]
		public void WhileBreak() {
			this.TestMethod(this.sourceTestsCompiledType, "WhileBreak", Loops.WhileBreak);
		}

		[Test]
		public void WhileCondBreak() {
			this.TestMethod(this.sourceTestsCompiledType, "WhileCondBreak", Loops.WhileCondBreak);
		}
	}
}
