#if HOSTED_MODE
namespace DotWeb.System.Reflection
#else
namespace System.Reflection
#endif
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
