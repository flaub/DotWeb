using SysAttribute = System.Attribute;

#if HOSTED_MODE
using DotWeb.System.Runtime.InteropServices;
namespace DotWeb.System.Diagnostics
#else
using System.Runtime.InteropServices;
namespace System.Diagnostics
#endif
{
	[ComVisible(true)]
	[AttributeUsage(
		AttributeTargets.Delegate | 
		AttributeTargets.Field | 
		AttributeTargets.Property | 
		AttributeTargets.Enum | 
		AttributeTargets.Struct | 
		AttributeTargets.Class | 
		AttributeTargets.Assembly, 
		AllowMultiple = true)]
	public sealed class DebuggerDisplayAttribute : SysAttribute
	{
		public DebuggerDisplayAttribute(string value) { Value = value; }

		public string Name { get; set; }
		public Type Target { get; set; }
		public string TargetTypeName { get; set; }
		public string Type { get; set; }
		public string Value { get; private set; }
	}

	[ComVisible(true)]
	public enum DebuggerBrowsableState
	{
		Collapsed = 2,
		Never = 0,
		RootHidden = 3
	}

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	[ComVisible(true)]
	public sealed class DebuggerBrowsableAttribute : SysAttribute
	{
		public DebuggerBrowsableAttribute(DebuggerBrowsableState state) { State = state; }
		public DebuggerBrowsableState State { get; private set; }
	}

	[Serializable]
	[ComVisible(true)]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
	public sealed class DebuggerHiddenAttribute : Attribute
	{
		public DebuggerHiddenAttribute() { }
	}

 

}
