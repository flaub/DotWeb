﻿// Copyright 2009, Frank Laub
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
	/// <summary>
	/// Summary description for DecorationTest
	/// </summary>
	[TestFixture]
	public class SystemTest : TranslationTestHelper<SystemTest>
	{
		public SystemTest()
			: base("DotWeb.Translator.Test.Script", Resources.SystemTest) {
			this.compiledType = this.CompiledAssembly.MainModule.Types["H8.SystemTests"];
		}

		[Test]
		public void TestToStringDirect() {
			TestMethod(this.compiledType, "TestToStringDirect", Resources.SystemTest_TestToStringDirect, true);
		}

		[Test]
		public void TestToStringIndirect() {
			TestMethod(this.compiledType, "TestToStringIndirect", Resources.SystemTest_TestToStringIndirect, true);
		}

		private TypeDefinition compiledType;
	}
}
