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
namespace System
{
	public static class ObjectExtensions
	{
#if HOSTED_MODE
		public static string GetTypeName(this object obj) {
			var type = obj.GetType();
			var name = type.FullName;
			if (name.StartsWith("DotWeb.System")) {
				name = name.Substring("DotWeb.".Length);
			}
			return name;
		}
#else
		[JsMacro("{1}.$typename")]
		public static extern string GetTypeName(this object obj);
#endif
	}
}
