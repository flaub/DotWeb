using System;
using NUnit.Framework;
using DotWeb.Javascript.Test.Properties;
using Mono.Cecil;

namespace DotWeb.Javascript.Test
{
	[TestFixture]
	public class Conditions : BaseTestFixture
	{
		private TypeDefinition compiledType;

		public Conditions()
			: base("DotWeb.Javascript.Test.Source", Resources.Conditions) {
			this.compiledType = this.CompiledAssembly.MainModule.Types["Source.Conditions"];
		}

		[Test]
		public void SingleAnd() {
			TestMethod(this.compiledType, "SingleAnd", Resources.Conditions_SingleAnd);
		}

		[Test]
		public void SingleOr() {
			TestMethod(this.compiledType, "SingleOr", Resources.Conditions_SingleOr);
		}

		[Test]
		public void SimpleIf() {
			TestMethod(this.compiledType, "SimpleIf", Resources.Conditions_SimpleIf);
		}

		[Test]
		public void SimpleIfElse() {
			TestMethod(this.compiledType, "SimpleIfElse", Resources.Conditions_SimpleIfElse);
		}

		[Test]
		public void SimpleIfOr() {
			TestMethod(this.compiledType, "SimpleIfOr", Resources.Conditions_SimpleIfOr);
		}

		[Test]
		public void SimpleIfAnd() {
			TestMethod(this.compiledType, "SimpleIfAnd", Resources.Conditions_SimpleIfAnd);
		}

		[Test]
		public void NullCoalesce() {
			TestMethod(this.compiledType, "NullCoalesce", Resources.Conditions_NullCoalesce);
		}
	
		[Test]
		public void ReturnTernary() {
			TestMethod(this.compiledType, "ReturnTernary", Resources.Conditions_ReturnTernary);
		}
		
		[Test]
		public void ReturnNestedTernary() {
			TestMethod(this.compiledType, "ReturnNestedTernary", Resources.Conditions_ReturnNestedTernary);
		}
	}
}
