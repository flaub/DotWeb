using SysAttribute = System.Attribute;

#if HOSTED_MODE
namespace DotWeb.System.Runtime.InteropServices
#else
namespace System.Runtime.InteropServices
#endif
{
	public class OutAttribute : SysAttribute
	{
	}
}
