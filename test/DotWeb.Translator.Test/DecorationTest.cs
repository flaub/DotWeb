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
	/// <summary>
	/// Summary description for DecorationTest
	/// </summary>
	[TestFixture]
	public class DecorationTest : TestBase
	{
		public DecorationTest()
			: base("DotWeb.Translator.Test.Script", "H8.DecorationTests", Resources.Decoration.ResourceManager, "Source") {
		}

		[Test]
		public void TestJsCode() { RunTest(); }

		[Test]
		public void TestJsAnonymous() { RunTestWithDependencies(); }

		[Test]
		public void TestJsIntrinsic() { RunTestWithDependencies(); }

		[Test]
		public void TestJsNamespace() { RunTestWithDependencies(); }

		[Test]
		public void TestJsMacro() { RunTest(); }

		[Test]
		public void TestJsCamelCase() { RunTest(); }
	}
}
