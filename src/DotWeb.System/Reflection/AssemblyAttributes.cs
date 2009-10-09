using SysAttribute = System.Attribute;

#if HOSTED_MODE
namespace DotWeb.System.Reflection
#else
namespace System.Reflection
#endif
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCompanyAttribute : SysAttribute
	{
		public AssemblyCompanyAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyConfigurationAttribute : SysAttribute
	{
		public AssemblyConfigurationAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCopyrightAttribute : SysAttribute
	{
		public AssemblyCopyrightAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCultureAttribute : SysAttribute
	{
		public AssemblyCultureAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyDescriptionAttribute : SysAttribute
	{
		public AssemblyDescriptionAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyFileVersionAttribute : SysAttribute
	{
		public AssemblyFileVersionAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyProductAttribute : SysAttribute
	{
		public AssemblyProductAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyTitleAttribute : SysAttribute
	{
		public AssemblyTitleAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyTrademarkAttribute : SysAttribute
	{
		public AssemblyTrademarkAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyVersionAttribute : SysAttribute
	{
		public AssemblyVersionAttribute(string value) { }
	}
}
