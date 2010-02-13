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
	public class ConditionalsTest : TestBase
	{
		public ConditionalsTest()
			: base("DotWeb.Translator.Test.Script", "H8.Conditionals", Conditionals.ResourceManager) {
		}

		[Test]
		public void SimpleIf() { this.RunTest(); }
		[Test]
		public void SimpleIfIf() { this.RunTest(); }
		[Test]
		public void SimpleIfElse() { this.RunTest(); }
		[Test]
		public void SimpleIfElseIf() { this.RunTest(); }
		[Test]
		public void SimpleIfAnd() { this.RunTest(); }
		[Test]
		public void SimpleIfAndNot() { this.RunTest(); }
		[Test]
		public void SimpleIfNotAnd() { this.RunTest(); }
		[Test]
		public void SimpleIfNotAndNot() { this.RunTest(); }
		[Test]
		public void SimpleIfOr() { this.RunTest(); }
		[Test]
		public void SimpleIfOrNot() { this.RunTest(); }
		[Test]
		public void SimpleIfNotOr() { this.RunTest(); }
		[Test]
		public void SimpleIfNotOrNot() { this.RunTest(); }
		[Test]
		public void IfGreaterAnd() { this.RunTest(); }
		[Test]
		public void IfLessAnd() { this.RunTest(); }
		[Test]
		public void IfGreaterOr() { this.RunTest(); }
		[Test]
		public void IfLessOr() { this.RunTest(); }
		[Test]
		public void IfGreaterAndLess() { this.RunTest(); }
		[Test]
		public void IfLessAndGreater() { this.RunTest(); }
		[Test]
		public void IfOrOr() { this.RunTest(); }
		[Test]
		public void IfAndOr() { this.RunTest(); }
		[Test]
		public void IfOrAnd() { this.RunTest(); }
		[Test]
		public void IfAndAnd() { this.RunTest(); }
		[Test]
		public void Switch() { this.RunTest(); }
	}
}
