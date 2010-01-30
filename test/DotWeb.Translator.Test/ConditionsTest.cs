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
	public class ConditionsTest : TranslationTestHelper
	{
		private TypeDefinition sourceTestsCompiledType;

		public ConditionsTest()
			: base("DotWeb.Translator.Test.Script", Conditions.Source) {
			this.sourceTestsCompiledType = this.CompiledAssembly.MainModule.Types["H8.Conditions"];
		}

		[Test]
		public void SimpleIf() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIf", Conditions.SimpleIf);
		}

		[Test]
		public void SimpleIfIf() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfIf", Conditions.SimpleIfIf);
		}

		[Test]
		public void SimpleIfElse() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfElse", Conditions.SimpleIfElse);
		}

		[Test]
		public void SimpleIfElseIf() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfElseIf", Conditions.SimpleIfElseIf);
		}

		[Test]
		public void SimpleIfAnd() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfAnd", Conditions.SimpleIfAnd);
		}

		[Test]
		public void SimpleIfAndNot() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfAndNot", Conditions.SimpleIfAndNot);
		}

		[Test]
		public void SimpleIfNotAnd() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfNotAnd", Conditions.SimpleIfNotAnd);
		}

		[Test]
		public void SimpleIfNotAndNot() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfNotAndNot", Conditions.SimpleIfNotAndNot);
		}

		[Test]
		public void SimpleIfOr() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfOr", Conditions.SimpleIfOr);
		}

		[Test]
		public void SimpleIfOrNot() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfOrNot", Conditions.SimpleIfOrNot);
		}

		[Test]
		public void SimpleIfNotOr() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfNotOr", Conditions.SimpleIfNotOr);
		}

		[Test]
		public void SimpleIfNotOrNot() {
			this.TestMethod(this.sourceTestsCompiledType, "SimpleIfNotOrNot", Conditions.SimpleIfNotOrNot);
		}
	}
}
