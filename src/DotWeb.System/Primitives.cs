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

#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
	public struct Boolean 
#if !HOSTED_MODE
//		: IComparable, IComparable<bool>, IEquatable<bool>
#endif
	{
#if !HOSTED_MODE
		//public int CompareTo(object obj) {
		//    if (obj != null) {
		//        if (!(obj is bool)) {
		//            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeBoolean"));
		//        }
		//        if (this == ((bool)obj)) {
		//            return 0;
		//        }
		//        if (!this) {
		//            return -1;
		//        }
		//    }
		//    return 1;
		//}

		//public int CompareTo(bool value) {
		//    if (this == value) {
		//        return 0;
		//    }
		//    if (!this) {
		//        return -1;
		//    }
		//    return 1;
		//}

		//public bool Equals(bool obj) {
		//    return (this == obj);
		//}

		//public override bool Equals(object obj) {
		//    return ((obj is bool) && (this == ((bool)obj)));
		//}

		//public override int GetHashCode() {
		//    if (!this) {
		//        return 0;
		//    }
		//    return 1;
		//}

		//public override string ToString() {
		//    if (!this) {
		//        return "False";
		//    }
		//    return "True";
		//}
#endif
	}

	[UseSystem]
	public struct Byte
	{
	}

	[UseSystem]
	public struct SByte
	{
	}

	[UseSystem]
	public struct Char
	{
	}

	[UseSystem]
	public struct Int16
	{
	}

	[UseSystem]
	public struct UInt16
	{
	}

	[UseSystem]
	public struct Int32
	{
		public const int MaxValue = 0x7fffffff;
		public const int MinValue = -2147483648;
	}

	[UseSystem]
	public struct UInt32
	{
	}

	[UseSystem]
	public struct Int64
	{
	}

	[UseSystem]
	public struct UInt64
	{
	}

	[UseSystem]
	public struct Single
	{
	}

	[UseSystem]
	public struct Double
	{
	}

	[UseSystem]
	public struct Void
	{
	}

	[UseSystem]
	public struct IntPtr
	{
	}

	[UseSystem]
	public struct UIntPtr
	{
	}
}
