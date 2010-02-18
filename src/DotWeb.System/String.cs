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

#if HOSTED_MODE
using ThisType = DotWeb.System.String;
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using ThisType = System.String;
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
	[JsAnonymous]
	[JsNamespace]
	[JsCamelCase]
	public class String
	{
		/// <summary>
		/// The number of characters in the String value represented by this String object.
		/// </summary>
		/// <remarks>
		/// Once a String object is created, this property is unchanging. It has the attributes { [[Writable]]:  false, 
		/// [[Enumerable]]: false, [[Configurable]]: false }. 
		/// </remarks>
		public extern int Length { get; }

		[JsMacro("{1}")]
		public static extern string Concat(string str1);

		[JsMacro("{1} + {2}")]
		public static extern string Concat(string str1, string str2);

		[JsMacro("{1} + {2}")]
		public static extern string Concat(object obj1, object obj2);

		[JsMacro("{1} + {2} + {3}")]
		public static extern string Concat(string str1, string str2, string str3);

		[JsMacro("{1} + {2} + {3} + {4}")]
		public static extern string Concat(string str1, string str2, string str3, string str4);

		[JsMacro("{1}.join('')")]
		public static extern string Concat(string[] values);

		[JsMacro("{1}.join('')")]
		public static extern string Concat(object[] values);

		[JsMacro("({1} != {2})")]
		public static extern bool operator !=(String lhs, String rhs);

		[JsMacro("({1} == {2})")]
		public static extern bool operator ==(String lhs, String rhs);

		[JsMacro("({0} == {1})")]
		public extern override bool Equals(object obj);

		[JsCode("return 0;")]
		public extern override int GetHashCode();

		public extern string Replace(string oldValue, string newValue);

		public extern string Replace(char oldValue, char newValue);

		public extern string Trim();

		public extern string ValueOf();

		/// <summary>
		/// Returns a String containing the character at position pos in the String resulting from converting this object to a 
		/// String. If there is no character at that position, the result is the empty String. The result is a String value, not a 
		/// String object. 
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public extern string CharAt(int pos);

		/// <summary>
		/// Returns a Number (a nonnegative integer less than 216) representing the code unit value of the character at 
		/// position  pos in the String resulting from converting this object to a String. If there is no character at that 
		/// position, the result is NaN. 
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public extern int CharCodeAt(int pos);
	}
}
