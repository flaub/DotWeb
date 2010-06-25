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
namespace System.Reflection
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
