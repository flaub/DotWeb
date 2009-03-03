using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Hosting
{
	[Flags]
	public enum DispatchType : byte
	{
		Method = 0x1,
		PropertyGet = 0x2,
		PropertySet = 0x4
	}

	public static class DispatchTypeExtensions
	{
		public static bool IsMethod(this DispatchType type) {
			return (type & DispatchType.Method) != 0;
		}

		public static bool IsProperty(this DispatchType type) {
			return IsPropertyGet(type) || IsPropertyPut(type);
		}

		public static bool IsPropertyGet(this DispatchType type) {
			return (type & DispatchType.PropertyGet) != 0;
		}

		public static bool IsPropertyPut(this DispatchType type) {
			return (type & DispatchType.PropertySet) != 0;
		}
	}

}
