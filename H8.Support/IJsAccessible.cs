using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Core
{
	[Flags]
	public enum DispatchType
	{
		Method = 0x1,
		PropertyGet = 0x2,
		PropertyPut = 0x4,
		PropertyPutRef = 0x8
	}

	[Flags]
	public enum GetDispIdFlags
	{
		CaseSensitive = 0x00000001,
		Ensure = 0x00000002,
		Implicit = 0x00000004,
		CaseInsensitive = 0x00000008,
		Internal = 0x00000010,
		NoDynamicProperties = 0x00000020,
	}

	[Flags]
	public enum MemberProperties : uint
	{
		CanGet = 0x00000001,
		CannotGet = 0x00000002,
		CanPut = 0x00000004,
		CannotPut = 0x00000008,
		CanPutRef = 0x00000010,
		CannotPutRef = 0x00000020,
		NoSideEffects = 0x00000040,
		DynamicType = 0x00000080,
		CanCall = 0x00000100,
		CannotCall = 0x00000200,
		CanConstruct = 0x00000400,
		CannotConstruct = 0x00000800,
		CanSourceEvents = 0x00001000,
		CannotSourceEvents = 0x00002000,

		CanAll =
			   (CanGet | CanPut | CanPutRef |
				CanCall | CanConstruct | CanSourceEvents),
		CannotAll =
			   (CannotGet | CannotPut | CannotPutRef |
				CannotCall | CannotConstruct | CannotSourceEvents),
		ExtraAll =
			   (NoSideEffects | DynamicType),
		All =
			   (CanAll | CannotAll | ExtraAll)
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
			return (type & (DispatchType.PropertyPut | DispatchType.PropertyPutRef)) != 0;
		}
	}

	public interface IJsAccessible
	{
		int GetMemberId(string name);
		MemberProperties GetMemberProperties(int id, MemberProperties fetch);
		object Invoke(int methodId, DispatchType dispType, object[] args);
	}
}
