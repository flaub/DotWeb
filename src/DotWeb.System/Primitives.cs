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
	{
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
		public static bool IsDigit(char ch) {
			return false;
		}
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
