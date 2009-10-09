using SysAttribute = System.Attribute;

#if HOSTED_MODE
namespace DotWeb.System
#else
namespace System
#endif
{
	public class Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Enum, Inherited = false)]
	public class FlagsAttribute : SysAttribute
	{
	}

	public class ParamArrayAttribute : SysAttribute
	{
	}

	[Flags]
	public enum AttributeTargets
	{
		Assembly = 0x0001,
		Module = 0x0002,
		Class = 0x0004,
		Struct = 0x0008,
		Enum = 0x0010,
		Constructor = 0x0020,
		Method = 0x0040,
		Property = 0x0080,
		Field = 0x0100,
		Event = 0x0200,
		Interface = 0x0400,
		Parameter = 0x0800,
		Delegate = 0x1000,
		ReturnValue = 0x2000,
		GenericParameter = 0x4000,
		All = 0x8000
	}

	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	public class AttributeUsageAttribute : SysAttribute
	{
		public AttributeUsageAttribute(AttributeTargets validOn) {
			this.ValidOn = validOn;
		}

		public AttributeTargets ValidOn { get; set; }
		public bool AllowMultiple { get; set; }
		public bool Inherited { get; set; }
	}

	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	internal class DotWebInternal : SysAttribute
	{
	}
}
