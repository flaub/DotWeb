using SysAttribute = System.Attribute;

#if HOSTED_MODE
namespace DotWeb.System.Runtime.InteropServices
#else
namespace System.Runtime.InteropServices
#endif
{
	// Summary:
	//     Controls accessibility of an individual managed type or member, or of all
	//     types within an assembly, to COM.
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	[ComVisible(true)]
	public sealed class ComVisibleAttribute : SysAttribute
	{
		// Summary:
		//     Initializes a new instance of the ComVisibleAttribute class.
		//
		// Parameters:
		//   visibility:
		//     true to indicate that the type is visible to COM; otherwise, false. The default
		//     is true.
		public ComVisibleAttribute(bool visibility) { }

		// Summary:
		//     Gets a value that indicates whether the COM type is visible.
		//
		// Returns:
		//     true if the type is visible; otherwise, false. The default value is true.
		public bool Value { get; private set; }
	}
}
