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
	public class GeneralTests : TestBase
	{
		public GeneralTests()
			: base("DotWeb.Translator.Test.Script", "H8.GeneralTests", General.ResourceManager, "Source") {
		}

		[Test]
		public void HelloWorld() { RunTest(); }
		[Test]
		public void Cifuentes() { RunTest(); }
		[Test]
		public void CreateInnerObject() { RunTestWithDependencies(); }
		[Test]
		public void CreateOuterObject() { RunTestWithDependencies(); }
		[Test]
		public void TakeParameters() { RunTest(); }
		[Test]
		public void AnonymousType() { RunTestWithDependencies(); }
		//[Test]
		//public void Linq() { RunTest(); }
		[Test]
		public void Callback() { RunTestWithDependencies(); }
		[Test]
		public void CallTakeParameters() { RunTestWithDependencies(); }
		[Test]
		public void CallDerived() { RunTestWithDependencies(); }
		[Test]
		public void Indexer() { RunTestWithDependencies(); }
		[Test]
		public void TestGenericNested() { RunTestWithDependencies(); }
		[Test]
		public void SwitchInsideWhile() { RunTest(); }
		[Test]
		public void GitHub_Issue3() { RunTest(); }
		[Test]
		public void GitHub_Issue4() { RunTestWithDependencies(); }
		[Test]
		public void GitHub_Issue5() { RunTestWithDependencies(); }
		[Test]
		public void GitHub_Issue6() { RunTest(); }
		[Test]
		public void NestedTry() { RunTest(); }
		[Test]
		public void ComplexNestedTry() { RunTest(); }
		[Test]
		public void TryInsideCatch() { RunTest(); }
		[Test]
		public void EscapeStringLiterals() { RunTest(); }
		[Test]
		public void ClientScript() { RunTestWithDependencies(); }
		[Test]
		public void ArgumentException() { RunTestWithDependencies(); }
		[Test]
		public void ExpectExceptionTest() { RunTestWithDependencies(); }
		[Test]
		public void Primitives() { RunTest(); }
	}
}
