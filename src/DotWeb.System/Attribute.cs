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

using SysAttribute = System.Attribute;

#if HOSTED_MODE
using DotWeb.System.DotWeb;
using DotWeb.System.Runtime.InteropServices;
namespace DotWeb.System
#else
using System.DotWeb;
using System.Runtime.InteropServices;
namespace System
#endif
{
	[UseSystem]
	public class Attribute
	{
	}

	[UseSystem]
	[AttributeUsage(AttributeTargets.Enum, Inherited = false)]
	public class FlagsAttribute : SysAttribute
	{
	}

	[UseSystem]
	public class ParamArrayAttribute : SysAttribute
	{
	}

	[UseSystem]
	[Flags]
	public enum AttributeTargets
	{
		Assembly = 0x0001,
		Module = 0x0002,
		Class = 0x0004,
		Struct = 0x0008,
		Enum = 0x0010,
		Constructor = 0x0020,
		Method = 0x0040,
		Property = 0x0080,
		Field = 0x0100,
		Event = 0x0200,
		Interface = 0x0400,
		Parameter = 0x0800,
		Delegate = 0x1000,
		ReturnValue = 0x2000,
		GenericParameter = 0x4000,
		All = 0x8000
	}

	[UseSystem]
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	public class AttributeUsageAttribute : SysAttribute
	{
		public AttributeUsageAttribute(AttributeTargets validOn) {
			this.ValidOn = validOn;
		}

		public AttributeTargets ValidOn { get; set; }
		public bool AllowMultiple { get; set; }
		public bool Inherited { get; set; }
	}

	[AttributeUsage(
		AttributeTargets.Delegate |
		AttributeTargets.Enum |
		AttributeTargets.Struct |
		AttributeTargets.Class,
		Inherited = false)]
	[ComVisible(true)]
	public sealed class SerializableAttribute : SysAttribute
	{
		public SerializableAttribute() { }
	}
}
