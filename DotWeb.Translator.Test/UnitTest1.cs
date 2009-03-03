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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DotWeb.Translator.Test.Properties;
using System.Reflection;

namespace DotWeb.Translator.Test
{
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class DecompilerTest
	{
		public DecompilerTest() {
		}

		private StringWriter writer;
		private TranslationEngine decompiler;

		[TestInitialize()]
		public void Initialize() {
			this.writer = new StringWriter();
			this.decompiler = new TranslationEngine(this.writer, false);
			string src = Resources.SourceTests;
		}

		[TestCleanup()]
		public void Cleanup() {
			this.decompiler = null;
		}

		private void TestMethod(string methodName, string expected) {
			this.decompiler.TranslateSource(
				Resources.SourceTests, 
				Assembly.GetExecutingAssembly(), 
				"H8.SourceTests", 
				methodName
			);
			Assert.AreEqual(expected, this.writer.ToString());
		}

		[TestMethod]
		public void HelloWorld() {
			this.TestMethod("HelloWorld", Resources.SourceTests_HelloWorld);
		}

		[TestMethod]
		public void WhileLoop() {
			this.TestMethod("WhileLoop", Resources.SourceTests_WhileLoop);
		}

		[TestMethod]
		public void ForLoop() {
			this.TestMethod("ForLoop", Resources.SourceTests_ForLoop);
		}

		[TestMethod]
		public void DoWhileLoop() {
			this.TestMethod("DoWhileLoop", Resources.SourceTests_DoWhileLoop);
		}

		[TestMethod]
		public void WhileBreakLoop() {
			this.TestMethod("WhileBreakLoop", Resources.SourceTests_WhileBreakLoop);
		}

		[TestMethod]
		public void WhileCondBreakLoop() {
			this.TestMethod("WhileCondBreakLoop", Resources.SourceTests_WhileCondBreakLoop);
		}

		[TestMethod]
		public void If() {
			this.TestMethod("If", Resources.SourceTests_If);
		}

		[TestMethod]
		public void IfElse() {
			this.TestMethod("IfElse", Resources.SourceTests_IfElse);
		}

		[TestMethod]
		public void IfIf() {
			this.TestMethod("IfIf", Resources.SourceTests_IfIf);
		}
		
		[TestMethod]
		public void Cifuentes() {
			this.TestMethod("Cifuentes", Resources.SourceTests_Cifuentes);
		}
		
		[TestMethod]
		public void EnumArray() {
			this.TestMethod("EnumArray", Resources.SourceTests_EnumArray);
		}
	
		[TestMethod]
		public void CreateObject() {
			this.TestMethod("CreateObject", Resources.SourceTests_CreateObject);
		}

		[TestMethod]
		public void Linq() {
			this.TestMethod("Linq", Resources.SourceTests_Linq);
		}
		
		[TestMethod]
		public void TakeParameters() {
			this.TestMethod("TakeParameters", Resources.SourceTests_TakeParameters);
		}
	
		[TestMethod]
		public void Callback() {
			this.TestMethod("Callback", Resources.SourceTests_Callback);
		}

		[TestMethod]
		public void Switch() {
			this.TestMethod("Switch", Resources.SourceTests_Switch);
		}

		[TestMethod]
		public void AnonymousType() {
			this.TestMethod("AnonymousType", Resources.SourceTests_AnonymousType);
		}
	}
}
