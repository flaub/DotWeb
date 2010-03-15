// Copyright 2010, Frank Laub
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
using DotWeb.Utility.Cecil;
using System.Linq;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class TypeSystemTest
	{
		private GlobalAssemblyResolver resolver = new GlobalAssemblyResolver();

		[Test]
		public void TestLoadAssembly() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.Types["System.Object"];
			var set = typeSystem.GetSubclasses(root);
			Assert.IsNotNull(set);
			Assert.Greater(set.Count, 0);
		}

		[Test]
		public void TestIsSubclassOf() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.Types["System.Object"];
			var subclass = sysDef.MainModule.Types["System.Type"];
			Assert.IsTrue(typeSystem.IsSubclassOf(subclass, root));
		}

		[Test]
		public void TestChildAssembly() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");
			var asmDef = typeSystem.LoadAssembly("DotWeb.Translator.Test.Script");

			var root = sysDef.MainModule.Types["System.Object"];
			var subclass = asmDef.MainModule.Types["H8.GeneralTests"];
			Assert.IsTrue(typeSystem.IsSubclassOf(subclass, root));
		}

		[Test]
		public void TestMethodOverrides() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.Types["System.Object"];
			var str = sysDef.MainModule.Types["System.String"];

			MethodDefinition equals = FindMethodByName(root.Methods, "Equals");
			var overrides = typeSystem.GetOverridesForVirtualMethod(equals);
			Assert.Greater(overrides.Count, 0);

			MethodDefinition overridenEquals = FindMethodByName(str.Methods, "Equals");
			Assert.IsTrue(overrides.Contains(overridenEquals));
		}

		[Test]
		public void TestImplsOfInterface() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var iface = sysDef.MainModule.Types["System.IDisposable"];
			var impl = sysDef.MainModule.Types["System.Collections.Generic.List`1/Enumerator"];

			MethodDefinition ifaceMethod = FindMethodByName(iface.Methods, "Dispose");
			var overrides = typeSystem.GetOverridesForVirtualMethod(ifaceMethod);
			Assert.Greater(overrides.Count, 0);

			MethodDefinition overridenMethod = FindMethodByName(impl.Methods, "Dispose");
			Assert.IsTrue(overrides.Contains(overridenMethod));
		}

		[Test]
		public void TestIEnumeratorCurrent() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var iface = sysDef.MainModule.Types["System.Collections.IEnumerator"];
			var impl = sysDef.MainModule.Types["System.Collections.Generic.List`1/Enumerator"];

			MethodDefinition ifaceMethod = FindMethodByName(iface.Methods, "get_Current");
			var overrides = typeSystem.GetOverridesForVirtualMethod(ifaceMethod);
			Assert.Greater(overrides.Count, 0);

			MethodDefinition overridenMethod = FindMethodByName(impl.Methods, "System.Collections.IEnumerator.get_Current");
			Assert.IsTrue(overrides.Contains(overridenMethod));
		}

		[Test]
		public void TestEqualityComparer() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var iface = sysDef.MainModule.Types["System.Collections.Generic.IEqualityComparer`1"];
			var impl = sysDef.MainModule.Types["System.Collections.Generic.EqualityComparer`1"];
			var impl2 = sysDef.MainModule.Types["System.Collections.Generic.EqualityComparer`1/DefaultComparer"];

			var ifaceMethod = FindMethodByName(iface.Methods, "GetHashCode");
			var overrides = typeSystem.GetOverridesForVirtualMethod(ifaceMethod);
			Assert.Greater(overrides.Count, 0);

			var overridenMethod = FindMethodByName(impl.Methods, "GetHashCode");
			// this one is abstract
			Assert.IsFalse(overrides.Contains(overridenMethod));

			var overridenMethod2 = FindMethodByName(impl2.Methods, "GetHashCode");
			Assert.IsTrue(overrides.Contains(overridenMethod2));
		}

		private MethodDefinition FindMethodByName(MethodDefinitionCollection methods, string name) {
			return methods.Cast<MethodDefinition>().Where(x => x.Name == name).SingleOrDefault();
		}
	}
}
