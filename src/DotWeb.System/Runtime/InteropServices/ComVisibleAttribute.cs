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
