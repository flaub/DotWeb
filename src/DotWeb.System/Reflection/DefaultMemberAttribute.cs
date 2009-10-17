#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System.Reflection
#else
using System.DotWeb;
namespace System.Reflection
#endif
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
	[UseSystem]
	public class DefaultMemberAttribute : Attribute
	{
		public DefaultMemberAttribute(string memberName) {
			MemberName = memberName;
		}

		public string MemberName { get; private set; }
	}
}
