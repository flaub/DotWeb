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
using DotWeb.Client;
using System.DotWeb;

namespace DotWeb.Weaver.Test.Script
{
	enum EnumTest
	{
		First = 1,
		Second = 2,
		Third = 3
	}

	[Flags]
	enum FlagsTest
	{
		First = 0x01,
		Second = 0x02,
		Third = 0x04
	}

	class TypeTest
	{
		public int field;
		public int Property { get; set; }
		public event Action Event;

		public TypeTest() {
			this.field = 1;
		}

		public void Method() {
			if (Event != null)
				Event();
		}

		public const EnumTest EnumValue = EnumTest.First;
		public const FlagsTest FlagsValue = FlagsTest.First;
	}

	class NativeType : JsObject
	{
		public extern NativeType();
	}

	class DerivedNativeType : NativeType
	{
		public extern DerivedNativeType();
	}
}
