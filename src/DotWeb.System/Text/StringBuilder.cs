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
		private string value = "";

		public StringBuilder() {
		}

		public StringBuilder Append(string value) {
			if (value == null)
				return this;

			if (value.Length == 0) {
				this.value = value;
				return this;
			}

			this.value += value;
			return this;
		
			//if (_length == 0 && value.Length < _maxCapacity && value.Length > _str.Length) {
			//    _length = value.Length;
			//    _str = _cached_str = value;
			//    return this;
			//}

			//int needed_cap = _length + value.Length;
			//if (null != _cached_str || _str.Length < needed_cap)
			//    InternalEnsureCapacity(needed_cap);

			//String.CharCopy(_str, _length, value, 0, value.Length);
			//_length = needed_cap;
			//return this;
		}

		public StringBuilder Append(bool value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(byte value) {
			return Append(value.ToString());
		}

		//public StringBuilder Append(decimal value) {
		//    return this;
		//}

		public StringBuilder Append(double value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(float value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(int value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(long value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(object value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(sbyte value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(short value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(uint value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(ulong value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(ushort value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(char[] value) {
			if (value == null)
				return this;

			for (int i = 0; i < value.Length; i++) {
				this.Append(value[i]);
			}

			//int needed_cap = _length + value.Length;
			//if (null != _cached_str || _str.Length < needed_cap)
			//    InternalEnsureCapacity(needed_cap);

			//String.CharCopy(_str, _length, value, 0, value.Length);
			//_length = needed_cap;
			return Append(value.ToString());
		}

		public StringBuilder Append(char value) {
			//int needed_cap = _length + 1;
			//if (null != _cached_str || _str.Length < needed_cap)
			//    InternalEnsureCapacity(needed_cap);

			//_str.InternalSetChar(_length, value);
			//_length = needed_cap;

			//return this;
			return Append(value.ToString());
		}

		public StringBuilder Append(char value, int repeatCount) {
			//if (repeatCount < 0)
			//    throw new ArgumentOutOfRangeException();

			//InternalEnsureCapacity(_length + repeatCount);

			//for (int i = 0; i < repeatCount; i++)
			//    _str.InternalSetChar(_length++, value);

			//return this;
			for (int i = 0; i < repeatCount; i++) {
				this.Append(value);
			}
			return this;
		}

		public StringBuilder Append(char[] value, int startIndex, int charCount) {
			if (value == null) {
				if (!(startIndex == 0 && charCount == 0))
					throw new ArgumentNullException("value");

				return this;
			}

			if ((charCount < 0 || startIndex < 0) || 
				(startIndex > value.Length - charCount))
				throw new ArgumentOutOfRangeException();

			for (int i = startIndex; i < charCount; i++) {
				this.Append(value[i]);
			}

			//int needed_cap = _length + charCount;
			//InternalEnsureCapacity(needed_cap);

			//String.CharCopy(_str, _length, value, startIndex, charCount);
			//_length = needed_cap;
			return this;
		}

		public StringBuilder Append(string value, int startIndex, int count) {
			if (value == null) {
				if (startIndex != 0 && count != 0)
					throw new ArgumentNullException("value");

				return this;
			}

			if ((count < 0 || startIndex < 0) || 
				(startIndex > value.Length - count))
				throw new ArgumentOutOfRangeException();

			for (int i = startIndex; i < count; i++) {
				this.Append(value[i]);
			}

			//int needed_cap = _length + count;
			//if (null != _cached_str || _str.Length < needed_cap)
			//    InternalEnsureCapacity(needed_cap);

			//String.CharCopy(_str, _length, value, startIndex, count);

			//_length = needed_cap;
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
			//return Append(System.Environment.NewLine);
			return this;
		}

		public StringBuilder AppendLine(string value) {
			return Append(value).AppendLine();
		}

		public override string ToString() {
			return this.value;
		}
	}
}
