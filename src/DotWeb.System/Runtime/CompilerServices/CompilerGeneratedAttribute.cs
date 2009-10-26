using SysAttribute = System.Attribute;

#if HOSTED_MODE
namespace DotWeb.System.Runtime.CompilerServices
#else
namespace System.Runtime.CompilerServices
#endif
{
	[Serializable]
	[AttributeUsage(
		AttributeTargets.Assembly |
		AttributeTargets.Class |
		AttributeTargets.Constructor |
		AttributeTargets.Delegate |
		AttributeTargets.Enum |
		AttributeTargets.Event |
		AttributeTargets.Field |
		AttributeTargets.GenericParameter |
		AttributeTargets.Interface |
		AttributeTargets.Method |
		AttributeTargets.Module |
		AttributeTargets.Parameter |
		AttributeTargets.Property |
		AttributeTargets.ReturnValue |
		AttributeTargets.Struct,
		Inherited = true)]
	public sealed class CompilerGeneratedAttribute : SysAttribute
	{
		public CompilerGeneratedAttribute() { }
	}
}
