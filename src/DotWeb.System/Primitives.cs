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
