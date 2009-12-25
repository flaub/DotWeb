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
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DotWeb.Tools.Weaver;
using System.Reflection;
using System.IO;

namespace DotWeb.Hosting.Test
{
	[TestFixture]
	public class HostingWeaverTest
	{
		class HostHarness : IDotWebHost
		{
			public delegate object InvokeHandler(object scope, object method, object[] args);
			public delegate object CastHandler(object obj);

			public InvokeHandler Invoker { get; set; }
			public CastHandler Caster { get; set; }

			public object Invoke(object scope, object method, object[] args) {
				if (Invoker != null)
					return Invoker(scope, method, args);
				throw new NotImplementedException();
			}

			public T Cast<T>(object obj) {
				if (Caster != null) {
					var ret = Caster(obj);
					return (T)ret;
				}
				throw new NotImplementedException();
			}
		}

		private Assembly hosted;

		public HostingWeaverTest() {
			var thisAsm = Assembly.GetExecutingAssembly();
			string dir = Path.GetDirectoryName(thisAsm.Location);
			var weaver = new HostingWeaver(dir, dir, new string[] { dir });

			string asmPath = "DotWeb.Weaver.Test.Script.dll";
			weaver.ProcessAssembly(asmPath);

			var hostedPath = Path.Combine(dir, "Hosted-DotWeb.Weaver.Test.Script.dll");
			this.hosted = Assembly.LoadFile(hostedPath);
		}

		[Test]
		public void SanityTest() {
			var test = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.SanityTest");
			var type = test.GetType();
			Assert.IsNotNull(type);
		}

		[Test]
		public void ExternTest() {
			// hook IDotWeb.Invoke
			bool invokeCalled = false;
			HostedMode.Host = new HostHarness {
				Invoker = delegate(object scope, object method, object[] args) {
					invokeCalled = true;
					return null;
				}
			};

			var test = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.SanityTest");
			var type = test.GetType();
			var testMethod = type.GetMethod("Test");
			testMethod.Invoke(test, null);

			Assert.IsTrue(invokeCalled);
		}

		[Test]
		public void TypeTest() {
			// weave a type then get to the it via reflection
			var test = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.TypeTest");
			var type = test.GetType();
			Assert.IsNotNull(type);

			var field = type.GetField("field");
			Assert.IsNotNull(field);

			var property = type.GetProperty("Property");
			Assert.IsNotNull(property);

			var method = type.GetMethod("Method");
			Assert.IsNotNull(method);

			var evt = type.GetEvent("Event");
			Assert.IsNotNull(evt);
		}

		[Test]
		public void CastTest() {
			// hook IDotWeb.Cast
			bool castCalled = false;
			HostedMode.Host = new HostHarness {
				Invoker = delegate(object scope, object method, object[] args) {
					return null;
				},

				Caster = delegate(object obj) {
					castCalled = true;
					return obj;
				}
			};

			var test = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.CastTest");
			var type = test.GetType();
			var testMethod = type.GetMethod("Test");
			testMethod.Invoke(test, null);

			Assert.IsTrue(castCalled);
		}

		[Test]
		[Ignore]
		public void IsInstanceTest() {
			// fail for now
			Assert.Fail();
		}

		[Test]
		[Ignore]
		public void EnumTest() {
			// weave an enum then get to the enum via reflection
			Assert.Fail();
		}

		[Test]
		[Ignore]
		public void GenericTypeTest() {
			// weave a generic type then grab it via reflection
			Assert.Fail();
		}

		[Test]
		[Ignore]
		public void GenericMethodTest() {
			// weave a generic method then grab it via reflection
			Assert.Fail();
		}

		[Test]
		[Ignore]
		public void ArrayTest() {
			// weave an array then grab via reflection
			Assert.Fail();
		}

		[Test]
		[Ignore]
		public void ExceptionTest() {
			// fail for now
			Assert.Fail();
		}

		[Test]
		[Ignore]
		public void DependencyTest() {
			// have one assembly depend on another and ensure that weaver
			// properly walks thru each one
			Assert.Fail();
		}

		[Test]
		public void NestedTest() {
			var test = this.hosted.GetType("DotWeb.Weaver.Test.Script.NestedTest");
			var baseNested = test.GetNestedType("Base");
			var derivedNested = test.GetNestedType("Derived");
			Assert.IsNotNull(test, "NestedType is null");
			Assert.IsNotNull(baseNested, "NestedType+Base is null");
			Assert.IsNotNull(derivedNested, "NestedType+Derived is null");
		}
	}
}
