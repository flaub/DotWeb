// Copyright 2010, Frank Laub
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

namespace System.DotWeb
{
	[JsCamelCase]
	public class JsString
	{
		[JsMacro("RegExp({1}, 'g')")]
		private static extern object RE(string pattern);

		[JsCode(@"return value.replace(/\&/g, '&amp;').replace(/\</g, '&lt;').replace(/\>/g, '&gt;');")]
		public static extern string HtmlEncode(string value);

		[JsMacro("String({0})")]
		public static extern JsString String(object value);

		[JsMacro("new String()")]
		public extern JsString();

		/// <summary>
		/// When String is called as part of a new expression, it is a constructor: it initialises the newly created object. 
		/// </summary>
		/// <remarks>
		/// The  [[Prototype]] internal property of the newly constructed object is set to the standard built-in String 
		/// prototype object that is the initial value of String.prototype (15.5.3.1).
		/// The [[Class]] internal property of the newly constructed object is set to "String". 
		/// The [[Extensible]] internal property of the newly constructed object is set to true. 
		/// The [[PrimitiveValue]] internal property of the newly constructed object is set to ToString(value), or to the empty 
		/// String if value is not supplied. 
		/// </remarks>
		/// <param name="value"></param>
		[JsMacro("new String({0})")]
		public extern JsString(object value);

		/// <summary>
		/// The number of characters in the String value represented by this String object.
		/// </summary>
		/// <remarks>
		/// Once a String object is created, this property is unchanging. It has the attributes { [[Writable]]:  false, 
		/// [[Enumerable]]: false, [[Configurable]]: false }. 
		/// </remarks>
		public extern int Length {
			get;
		}

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
