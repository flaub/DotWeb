using DotWeb.System;

namespace System.System.Reflection
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
	public class DefaultMemberAttribute : Attribute
	{
		public DefaultMemberAttribute(string memberName) {
			MemberName = memberName;
		}

		public string MemberName { get; private set; }
	}
}