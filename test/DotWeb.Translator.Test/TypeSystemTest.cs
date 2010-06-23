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
using System.Collections.Generic;
using Mono.Collections.Generic;

namespace DotWeb.Translator.Test
{
	[TestFixture]
	public class TypeSystemTest
	{
		private DotWeb.Utility.Cecil.GlobalAssemblyResolver resolver = new DotWeb.Utility.Cecil.GlobalAssemblyResolver();

		[Test]
		public void TestLoadAssembly() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.GetType("System.Object");
			var set = typeSystem.GetSubclasses(root);
			Assert.IsNotNull(set);
			Assert.Greater(set.Count, 0);
		}

		[Test]
		public void TestIsSubclassOf() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.GetType("System.Object");
			var subclass = sysDef.MainModule.GetType("System.Type");
			Assert.IsTrue(typeSystem.IsSubclassOf(subclass, root));
		}

		[Test]
		public void TestChildAssembly() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");
			var asmDef = typeSystem.LoadAssembly("DotWeb.Translator.Test.Script");

			var root = sysDef.MainModule.GetType("System.Object");
			var subclass = asmDef.MainModule.GetType("H8.GeneralTests");
			Assert.IsTrue(typeSystem.IsSubclassOf(subclass, root));
		}

		[Test]
		public void TestMethodOverrides() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			var root = sysDef.MainModule.GetType("System.Object");
			var str = sysDef.MainModule.GetType("System.String");

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

			var iface = sysDef.MainModule.GetType("System.IDisposable");
			var impl = sysDef.MainModule.GetType("System.Collections.Generic.List`1/Enumerator");

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

			var iface = sysDef.MainModule.GetType("System.Collections.IEnumerator");
			var impl = sysDef.MainModule.GetType("System.Collections.Generic.List`1/Enumerator");

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

			var iface = sysDef.MainModule.GetType("System.Collections.Generic.IEqualityComparer`1");
			var impl = sysDef.MainModule.GetType("System.Collections.Generic.EqualityComparer`1");
			var impl2 = sysDef.MainModule.GetType("System.Collections.Generic.EqualityComparer`1/DefaultComparer");

			var ifaceMethod = FindMethodByName(iface.Methods, "GetHashCode");
			var overrides = typeSystem.GetOverridesForVirtualMethod(ifaceMethod);
			Assert.Greater(overrides.Count, 0);

			var overridenMethod = FindMethodByName(impl.Methods, "GetHashCode");
			// this one is abstract
			Assert.IsFalse(overrides.Contains(overridenMethod));

			var overridenMethod2 = FindMethodByName(impl2.Methods, "GetHashCode");
			Assert.IsTrue(overrides.Contains(overridenMethod2));
		}

		[Test]
		public void TestGetCurrent() {
			var typeSystem = new TypeSystem(this.resolver);
			var sysDef = typeSystem.LoadAssembly("DotWeb.System");

			// System.Collections.Generic.IEnumerator<KeyValuePair<TKey, TValue>>
			var iface = sysDef.MainModule.GetType("System.Collections.Generic.IEnumerator`1");
			// System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator
			var impl = sysDef.MainModule.GetType("System.Collections.Generic.Dictionary`2/Enumerator");

			var ifaceMethod = FindMethodByName(iface.Methods, "get_Current");
			var overrides = typeSystem.GetOverridesForVirtualMethod(ifaceMethod);
			Assert.Greater(overrides.Count, 0);

			var overridenMethod = FindMethodByName(impl.Methods, "get_Current");
			Assert.IsTrue(overrides.Contains(overridenMethod));
		}

		private MethodDefinition FindMethodByName(Collection<MethodDefinition> methods, string name) {
			return methods.Cast<MethodDefinition>().Where(x => x.Name == name).SingleOrDefault();
		}

		[Test]
		public void TestVirtualsMapper() {
			var asm = this.resolver.Resolve("DotWeb.Translator.Test");

			var genericInterface = asm.MainModule.GetType("DotWeb.Translator.Test.TypeSystemTest/GenericInterface`2");
			var genericImpl = asm.MainModule.GetType("DotWeb.Translator.Test.TypeSystemTest/GenericImpl`2");
			var partialImpl1 = asm.MainModule.GetType("DotWeb.Translator.Test.TypeSystemTest/PartialImpl1`1");
			var partialImpl2 = asm.MainModule.GetType("DotWeb.Translator.Test.TypeSystemTest/PartialImpl2`1");
			var concreteImpl = asm.MainModule.GetType("DotWeb.Translator.Test.TypeSystemTest/ConcreteImpl");

			var baseMethod = genericInterface.GetMethods("Method").First();
			var genericMethod = genericImpl.GetMethods("Method").First();
			var partial1Method = partialImpl1.GetMethods("Method").First();
			var partial2Method = partialImpl2.GetMethods("Method").First();
			var concreteMethod = concreteImpl.GetMethods("Method").First();

			var genericIface = genericImpl.Interfaces[0] as GenericInstanceType;
			var partial1Iface = partialImpl1.Interfaces[0] as GenericInstanceType;
			var partial2Iface = partialImpl2.Interfaces[0] as GenericInstanceType;
			var concreteIface = concreteImpl.Interfaces[0] as GenericInstanceType;

			var a1 = genericIface.GenericArguments[0];
			var a2 = genericIface.GenericArguments[1];

			var b1 = partial1Iface.GenericArguments[0];
			var b2 = partial1Iface.GenericArguments[1];

			var c1 = partial2Iface.GenericArguments[0];
			var c2 = partial2Iface.GenericArguments[1];

			var d1 = concreteIface.GenericArguments[0];
			var d2 = concreteIface.GenericArguments[1];

			var x1 = genericInterface.GenericParameters[0];
			var x2 = genericInterface.GenericParameters[1];

			Assert.AreEqual(concreteMethod.GetMethodSignature(), VirtualsDictionary.NormalizeMethod(concreteIface, baseMethod).GetMethodSignature());
			Assert.AreEqual(partial1Method.GetMethodSignature(), VirtualsDictionary.NormalizeMethod(partial1Iface, baseMethod).GetMethodSignature());
			Assert.AreEqual(partial2Method.GetMethodSignature(), VirtualsDictionary.NormalizeMethod(partial2Iface, baseMethod).GetMethodSignature());
			Assert.AreEqual(genericMethod.GetMethodSignature(), VirtualsDictionary.NormalizeMethod(genericIface, baseMethod).GetMethodSignature());
		}

		interface GenericInterface<T, U>
		{
			void Method<X>(X x, T t, U u);
		}

		public class GenericImpl<T, U> : GenericInterface<T, U>
		{
			#region GenericInterface<T,U> Members

			public void Method<X>(X x, T t, U u) {
				throw new NotImplementedException();
			}

			#endregion
		}

		public class PartialImpl1<T> : GenericInterface<T, string>
		{
			#region GenericInterface<T,string> Members

			public void Method<X>(X x, T t, string u) {
				throw new NotImplementedException();
			}

			#endregion
		}

		public class PartialImpl2<T> : GenericInterface<string, T>
		{
			#region GenericInterface<string,T> Members

			public void Method<X>(X x, string t, T u) {
				throw new NotImplementedException();
			}

			#endregion
		}

		public class ConcreteImpl : GenericInterface<string, string>
		{
			#region GenericInterface<string,string> Members

			public void Method<X>(X x, string t, string u) {
				throw new NotImplementedException();
			}

			#endregion
		}
	}
}
