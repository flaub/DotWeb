using SysAttribute = System.Attribute;

#if HOSTED_MODE
namespace DotWeb.System.DotWeb
#else
namespace System.DotWeb
#endif
{
	[AttributeUsage(
		AttributeTargets.Class | 
		AttributeTargets.Struct | 
		AttributeTargets.Enum, 
		AllowMultiple = false, 
		Inherited = false)]
	internal class UseSystemAttribute : SysAttribute
	{
	}
}
