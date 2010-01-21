using System;
using NUnit.Framework;
using Mono.Cecil;
using DotWeb.Utility.Cecil;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class TypeHierarchyTest
	{
		private GlobalAssemblyResolver resolver = new GlobalAssemblyResolver();

		[Test]
		public void TestLoadAssembly() {
			var hierarchy = new TypeHierarchy(this.resolver);
			var sysDef = hierarchy.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.Types["System.Object"];
			var set = hierarchy.GetSubclasses(root);
			Assert.IsNotNull(set);
			Assert.Greater(set.Count, 0);
		}

		[Test]
		public void TestIsSubclassOf() {
			var hierarchy = new TypeHierarchy(this.resolver);
			var sysDef = hierarchy.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.Types["System.Object"];
			var subclass = sysDef.MainModule.Types["System.Type"];
			Assert.IsTrue(hierarchy.IsSubclassOf(subclass, root));
		}

		[Test]
		public void TestChildAssembly() {
			var hierarchy = new TypeHierarchy(this.resolver);
			var sysDef = hierarchy.LoadAssembly("DotWeb.System");
			var asmDef = hierarchy.LoadAssembly("DotWeb.Translator.Test.Script");

			var root = sysDef.MainModule.Types["System.Object"];
			var subclass = asmDef.MainModule.Types["H8.SourceTests"];
			Assert.IsTrue(hierarchy.IsSubclassOf(subclass, root));
		}

		[Test]
		public void TestMethodOverrides() {
			var hierarchy = new TypeHierarchy(this.resolver);
			var sysDef = hierarchy.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.Types["System.Object"];
			var str = sysDef.MainModule.Types["System.String"];

			MethodDefinition equals = null;
			foreach (MethodDefinition method in root.Methods) {
				if (method.Name == "Equals")
					equals = method;
			}

			var overrides = hierarchy.GetOverridesForVirtualMethod(equals);
			Assert.Greater(overrides.Count, 0);

			MethodDefinition overridenEquals = null;
			foreach (MethodDefinition method in str.Methods) {
				if (method.Name == "Equals")
					overridenEquals = method;
			}

			Assert.IsTrue(overrides.Contains(overridenEquals));
		}
	}
}
