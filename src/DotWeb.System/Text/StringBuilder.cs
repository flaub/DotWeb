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
using DotWeb.System.DotWeb;
namespace DotWeb.System.Text
#else
using System.DotWeb;
namespace System.Text
#endif
{
	[UseSystem]
	public class StringBuilder
	{
		public StringBuilder() {
		}

		public StringBuilder Append(bool value) {
			return this;
		}

		public StringBuilder Append(byte value) {
			return this;
		}

		public StringBuilder Append(char value) {
			return this;
		}

		public StringBuilder Append(char[] value) {
			return this;
		}

		//public StringBuilder Append(decimal value) {
		//    return this;
		//}

		public StringBuilder Append(double value) {
			return this;
		}

		public StringBuilder Append(float value) {
			return this;
		}

		public StringBuilder Append(int value) {
			return this;
		}

		public StringBuilder Append(long value) {
			return this;
		}

		public StringBuilder Append(object value) {
			return this;
		}

		public StringBuilder Append(sbyte value) {
			return this;
		}

		public StringBuilder Append(short value) {
			return this;
		}

		public StringBuilder Append(string value) {
			return this;
		}

		public StringBuilder Append(uint value) {
			return this;
		}

		public StringBuilder Append(ulong value) {
			return this;
		}

		public StringBuilder Append(ushort value) {
			return this;
		}

		public StringBuilder Append(char value, int repeatCount) {
			return this;
		}

		public StringBuilder Append(char[] value, int startIndex, int charCount) {
			return this;
		}

		public StringBuilder Append(string value, int startIndex, int count) {
			return this;
		}

		public StringBuilder AppendFormat(string format, params object[] args) {
			return this;
		}

		//public StringBuilder AppendFormat(IFormatProvider provider, string format, params object[] args) {
		//    return this;
		//}
		//public StringBuilder AppendFormat(string format, object arg0, object arg1);
		//public StringBuilder AppendFormat(string format, object arg0, object arg1, object arg2);
		public StringBuilder AppendLine() {
			return this;
		}

		public StringBuilder AppendLine(string value) {
			return this;
		}
	}
}
