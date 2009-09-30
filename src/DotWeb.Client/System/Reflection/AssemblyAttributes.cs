using DotWeb.System;

namespace System.System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCompanyAttribute : Attribute
	{
		public AssemblyCompanyAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyConfigurationAttribute : Attribute
	{
		public AssemblyConfigurationAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCopyrightAttribute : Attribute
	{
		public AssemblyCopyrightAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCultureAttribute : Attribute
	{
		public AssemblyCultureAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyDescriptionAttribute : Attribute
	{
		public AssemblyDescriptionAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyFileVersionAttribute : Attribute
	{
		public AssemblyFileVersionAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyProductAttribute : Attribute
	{
		public AssemblyProductAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyTitleAttribute : Attribute
	{
		public AssemblyTitleAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyTrademarkAttribute : Attribute
	{
		public AssemblyTrademarkAttribute(string value) { }
	}

	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyVersionAttribute : Attribute
	{
		public AssemblyVersionAttribute(string value) { }
	}
}
