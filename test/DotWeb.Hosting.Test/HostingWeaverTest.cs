using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DotWeb.Tools.Weaver;

namespace DotWeb.Hosting.Test
{
	[TestFixture]
	public class HostingWeaverTest
	{
		[Test]
		public void SanityTest() {
			var weaver = new HostingWeaver(inputDir, outputDir, new string[] { searchDir });
			weaver.ProcessAssembly(asmPath);
		}

		[Test]
		public void ExternTest() {
		}

		[Test]
		public void EnumTest() {
		}

		[Test]
		public void TypeTest() {
		}

		[Test]
		public void GenericTest() {
		}

		[Test]
		public void CastTest() {
		}

		[Test]
		public void IsInstanceTest() {
		}

		[Test]
		public void ArrayTest() {
		}

		[Test]
		public void ExceptionTest() {
		}

		[Test]
		public void DependencyTest() {
		}
	}
}
