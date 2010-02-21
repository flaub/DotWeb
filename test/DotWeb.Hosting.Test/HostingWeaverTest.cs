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
using System.Reflection;
using System.IO;
using DotWeb.Hosting.Weaver;

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
			var weaver = new HostingWeaver(dir, dir, new string[] { dir }, true);

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

			var genericInstance = type.GetProperty("GenericInstance");
			Assert.IsNotNull(genericInstance);

			var genericInstanceGetMethod = genericInstance.GetGetMethod();
			Assert.IsNotNull(genericInstanceGetMethod);
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
		public void EnumTest() {
			// weave an enum then get to the enum via reflection
			var test1 = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.EnumTest");
			var type1 = test1.GetType();
			Assert.IsNotNull(type1);

			var test2 = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.FlagsTest");
			var type2 = test2.GetType();
			Assert.IsNotNull(type2);

			var enumValue1 = Enum.ToObject(type1, 3);
			Assert.IsNotNull(enumValue1);
			Assert.AreEqual("Third", enumValue1.ToString());

			var enumValue2 = Enum.ToObject(type2, 3);
			Assert.IsNotNull(enumValue2);
			Assert.AreEqual("First, Second", enumValue2.ToString());
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
		public void ArrayTest() {
			// weave an array then grab via reflection
			var test = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.ArrayTest");
			var type = test.GetType();
			Assert.IsNotNull(type);

			var field = type.GetField("fieldArray");
			Assert.IsNotNull(field);
			Assert.AreEqual("System.Int32[*]", field.FieldType.ToString());

			var property = type.GetProperty("PropertyArray");
			Assert.IsNotNull(property);
			Assert.AreEqual("System.String[*]", property.PropertyType.ToString());

			var typeArray = type.GetField("typeArray");
			Assert.IsNotNull(typeArray);
			var elementType = typeArray.FieldType.GetElementType();
			Assert.AreEqual(type, elementType);

			var list = type.GetField("list");
			Assert.IsNotNull(list);
			var genericTypes = list.FieldType.GetGenericArguments();
			Assert.AreEqual(type, genericTypes[0]);

			var arrayOfLists = type.GetField("arrayOfLists");
			Assert.IsNotNull(arrayOfLists);
			Assert.AreEqual(list.FieldType, arrayOfLists.FieldType.GetElementType());

			var listOfArrays = type.GetField("listOfArrays");
			Assert.IsNotNull(listOfArrays);
			genericTypes = listOfArrays.FieldType.GetGenericArguments();
			Assert.AreEqual(typeArray.FieldType, genericTypes[0]);
		}

		[Test]
		public void ExceptionTest() {
			HostedMode.Host = new HostHarness {
				Invoker = delegate(object scope, object method, object[] args) {
					return null;
				}
			};

			var test = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.ExceptionTest");
			var type = test.GetType();
			Assert.IsNotNull(type);

			type.GetMethod("SimpleTryCatch").Invoke(test, null);
			type.GetMethod("SimpleTryFinally").Invoke(test, null);
			type.GetMethod("SimpleTryCatchFinally").Invoke(test, null);
			type.GetMethod("NestedTry").Invoke(test, null);
			type.GetMethod("TryInCatch").Invoke(test, null);
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

		[Test]
		public void NativeCallbackTest() {
			bool invokeCalled = false;
			HostedMode.Host = new HostHarness {
				Invoker = delegate(object scope, object method, object[] args) {
					invokeCalled = true;
					return null;
				}
			};

			var test = this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.NativeCallback");
			Assert.IsNotNull(test);
			var type = test.GetType();
			Assert.IsNotNull(type);
			Assert.IsTrue(invokeCalled);
		}

		[Test]
		public void Misc_ListTest() {
			try {
				this.hosted.CreateInstance("DotWeb.Weaver.Test.Script.Misc_ListTest");
			}
			catch (TargetInvocationException ex) {
				if (!(ex.InnerException is NullReferenceException))
					throw;
			}
		}
	}
}
