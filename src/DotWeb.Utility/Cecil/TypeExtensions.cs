using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace DotWeb.Utility.Cecil
{
	public static class TypeExtensions
	{
		public static Type GetReflectionType(this TypeReference type) {
			switch (type.FullName) {
				case Constants.Boolean:
					return typeof(Boolean);
				case Constants.Byte:
					return typeof(Byte);
				case Constants.Char:
					return typeof(Char);
				case Constants.Double:
					return typeof(Double);
				case Constants.Enum:
					return typeof(Enum);
				case Constants.Int16:
					return typeof(Int16);
				case Constants.Int32:
					return typeof(Int32);
				case Constants.Int64:
					return typeof(Int64);
				case Constants.IntPtr:
					return typeof(IntPtr);
				case Constants.Object:
					return typeof(Object);
				case Constants.SByte:
					return typeof(SByte);
				case Constants.Single:
					return typeof(Single);
				case Constants.String:
					return typeof(String);
				case Constants.Type:
					return typeof(Type);
				case Constants.UInt16:
					return typeof(UInt16);
				case Constants.UInt32:
					return typeof(UInt32);
				case Constants.UInt64:
					return typeof(UInt64);
				case Constants.UIntPtr:
					return typeof(UIntPtr);
				case Constants.Void:
					return typeof(void);
				default:
					return typeof(object);
			}
		}
	}
}
