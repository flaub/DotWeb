// Copyright 2009, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 
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
