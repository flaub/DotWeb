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
using NUnit.Framework;
using Mono.Cecil;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class LoopsTest : TestBase
	{
		public LoopsTest()
			: base("DotWeb.Translator.Test.Script", "H8.Loops", Loops.ResourceManager, "Source") {
		}

		[Test]
		public void SimpleFor() { this.RunTest(); }
		[Test]
		public void SimpleDoWhile() { this.RunTest(); }
		[Test]
		public void SimpleWhile() { this.RunTest(); }
		[Test]
		public void NestedDoWhile() { this.RunTest(); }
		[Test]
		public void BreakInWhile() { this.RunTest(); }
		[Test]
		public void WhileBreak() { this.RunTest(); }
		[Test]
		public void WhileCondBreak() { this.RunTest(); }
		[Test]
		public void WhileBreakBreak() { this.RunTest(); }
		[Test]
		public void WhileContinue() { this.RunTest(); }
		[Test]
		public void WhileCondContinue() { this.RunTest(); }
		[Test]
		public void WhileBreakContinue() { this.RunTest(); }
		[Test]
		public void EndlessLoop() { this.RunTest(); }
		[Test]
		public void ComplexLoop() { this.RunTest(); }
		[Test]
		public void ComplexNestedLoop() { this.RunTest(); }
		[Test]
		public void MultiReturns() { this.RunTest(); }
		[Test]
		public void MultiReturns2() { this.RunTest(); }
		[Test]
		public void WhileTryCatchFinally() { this.RunTest(); }
	}
}
