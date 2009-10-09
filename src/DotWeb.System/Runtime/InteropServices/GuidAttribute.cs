using SysAttribute = System.Attribute;

#if HOSTED_MODE
namespace DotWeb.System.Runtime.InteropServices
#else
namespace System.Runtime.InteropServices
#endif
{
	// Summary:
	//     Supplies an explicit System.Guid when an automatic GUID is undesirable.
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	[ComVisible(true)]
	public sealed class GuidAttribute : SysAttribute
	{
		// Summary:
		//     Initializes a new instance of the System.Runtime.InteropServices.GuidAttribute
		//     class with the specified GUID.
		//
		// Parameters:
		//   guid:
		//     The System.Guid to be assigned.
		public GuidAttribute(string guid) { }

		// Summary:
		//     Gets the System.Guid of the class.
		//
		// Returns:
		//     The System.Guid of the class.
		public string Value { get; private set; }
	}
}
