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
using DotWeb.System.Text;
namespace DotWeb.System
#else
using ThisType = System.String;
using System.DotWeb;
using System.Text;
namespace System
#endif
{
	[UseSystem]
	[JsAnonymous]
	[JsNamespace]
	[JsCamelCase]
	public class String
	{
		public static readonly string Empty = "";
	
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

		[JsMacro("StringHelper.GetHashCode({0})")]
		public override int GetHashCode() {
			return StringHelper.GetHashCode(this);
		}

		public extern bool Contains(string value);

		public extern string Replace(string oldValue, string newValue);

		public extern string Replace(char oldValue, char newValue);

		public extern string Trim();

		public extern char this[int index] {
			[JsMacro("{0}.charAt({1})")]
			get;
		}

		//public string Substring(int startIndex) {
		//    //if (startIndex == 0)
		//    //    return this;
		//    if (startIndex < 0 || startIndex > this.Length)
		//        throw new ArgumentOutOfRangeException("startIndex");
		//    return InternalSubstring(startIndex, this.Length - startIndex);
		//}

		//public string Substring(int startIndex, int length) {
		//    if (length < 0)
		//        throw new ArgumentOutOfRangeException("length", "Cannot be negative.");
		//    if (startIndex < 0)
		//        throw new ArgumentOutOfRangeException("startIndex", "Cannot be negative.");
		//    if (startIndex > this.Length)
		//        throw new ArgumentOutOfRangeException("startIndex", "Cannot exceed length of string.");
		//    if (startIndex > this.Length - length)
		//        throw new ArgumentOutOfRangeException("length", "startIndex + length > this.length");
		//    //if (startIndex == 0 && length == this.Length)
		//    //    return this;
		//    return InternalSubstring(startIndex, length);
		//}

		//internal string InternalSubstring(int startIndex, int length) {
		//    if (length == 0)
		//        return string.Empty;
		//    return null;

		//    //string tmp = InternalAllocateStr(length);
		//    //fixed (char* dest = tmp, src = this) {
		//    //    CharCopy(dest, src + startIndex, length);
		//    //}
		//    //return tmp;
		//}

		//internal static void CharCopy(char[] dest, char[] src, int count) {
		//}

		public static string Format(string format, params object[] args) {
			var sb = FormatHelper(null, format, args);
			return sb.ToString();
		}

		internal static StringBuilder FormatHelper(StringBuilder result, string format, params object[] args) {
			if (format == null)
				throw new ArgumentNullException("format");
			if (args == null)
				throw new ArgumentNullException("args");

			if (result == null) {
				result = new StringBuilder();
			}

			int ptr = 0;
			int start = ptr;
			while (ptr < format.Length) {
				char ch = format[ptr++];
				if (ch == '{') {
					result.Append(format, start, ptr - start - 1);

					// check for escaped open bracket
					if (format[ptr] == '{') {
						start = ptr++;
						continue;
					}
				
					// parse specifier
				}
			}

			return result;
		}

		//private static void ParseFormatSpecifier(
		//    string str, 
		//    ref int ptr, 
		//    out int n, 
		//    out int width, 
		//    out bool left_align, 
		//    out string format) {
		//    // parses format specifier of form:
		//    //   N,[\ +[-]M][:F]}
		//    //
		//    // where:

		//    try {
		//        // N = argument number (non-negative integer)

		//        n = ParseDecimal(str, ref ptr);
		//        if (n < 0)
		//            throw new FormatException("Input string was not in a correct format.");

		//        // M = width (non-negative integer)

		//        if (str[ptr] == ',') {
		//            // White space between ',' and number or sign.
		//            ++ptr;
		//            while (Char.IsWhiteSpace(str[ptr]))
		//                ++ptr;
		//            int start = ptr;

		//            //format = str.Substring(start, ptr - start);

		//            left_align = (str[ptr] == '-');
		//            if (left_align)
		//                ++ptr;

		//            width = ParseDecimal(str, ref ptr);
		//            if (width < 0)
		//                throw new FormatException("Input string was not in a correct format.");
		//        }
		//        else {
		//            width = 0;
		//            left_align = false;
		//            format = String.Empty;
		//        }

		//        // F = argument format (string)

		//        if (str[ptr] == ':') {
		//            int start = ++ptr;
		//            while (str[ptr] != '}')
		//                ++ptr;

		//            format += str.Substring(start, ptr - start);
		//        }
		//        else
		//            format = null;

		//        if (str[ptr++] != '}')
		//            throw new FormatException("Input string was not in a correct format.");
		//    }
		//    catch (IndexOutOfRangeException) {
		//        throw new FormatException("Input string was not in a correct format.");
		//    }
		//}

		//private static int ParseDecimal(string str, ref int ptr) {
		//    int p = ptr;
		//    int n = 0;
		//    while (true) {
		//        char ch = str[p];
		//        if (ch < '0' || '9' < ch)
		//            break;

		//        n = n * 10 + ch - '0';
		//        ++p;
		//    }

		//    if (p == ptr)
		//        return -1;

		//    ptr = p;
		//    return n;
		//}

		#region Javascript Methods
		//public extern string ValueOf();

		/// <summary>
		/// Returns a String containing the character at position pos in the String resulting from converting this object to a 
		/// String. If there is no character at that position, the result is the empty String. The result is a String value, not a 
		/// String object. 
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		//public extern string CharAt(int pos);

		/// <summary>
		/// Returns a Number (a nonnegative integer less than 216) representing the code unit value of the character at 
		/// position  pos in the String resulting from converting this object to a String. If there is no character at that 
		/// position, the result is NaN. 
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		public extern int CharCodeAt(int pos);
		#endregion
	}

	[JsNamespace]
	internal static class StringHelper
	{
		internal static int GetHashCode(String str) {
			int hash = 0;
			for (int i = 0; i < str.Length; i++) {
				int ch = str.CharCodeAt(i);
				hash = (hash << 5) - hash + ch;
			}
			return hash;
		}
	}

}
