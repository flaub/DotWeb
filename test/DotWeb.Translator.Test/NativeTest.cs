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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DotWeb.Translator.Test.Properties;
using System.Reflection;
using DotWeb.Translator.Generator.JavaScript;
using DotWeb.Decompiler;

namespace DotWeb.Translator.Test
{
	[TestClass]
	public class NativeTest : TranslationTestHelper<NativeTest>
	{
		public NativeTest()
			: base(Resources.NativeTest_Source) {
			this.sourceTestsCompiledType = this.compiledAssembly.GetType("H8.NativeTest");
		}

		[TestMethod]
		public void TestTuple() {
			this.TestMethod(this.sourceTestsCompiledType, "TestTuple", Resources.NativeTest_TestTuple);
		}

		private Type sourceTestsCompiledType;
	}
}
