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
