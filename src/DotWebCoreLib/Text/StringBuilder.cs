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
namespace System.Text
{
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
		}

		public StringBuilder Append(object value) {
			return Append(value.ToString());
		}

		public StringBuilder Append(char[] value) {
			if (value == null)
				return this;

			for (int i = 0; i < value.Length; i++) {
				this.Append(value[i]);
			}

			return Append(value.ToString());
		}

		public StringBuilder Append(char value, int repeatCount) {
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

			for (int i = startIndex; i < startIndex + count; i++) {
				this.Append(value[i]);
			}

			return this;
		}

		public StringBuilder AppendFormat(string format, params object[] args) {
			return string.FormatHelper(this, format, args);
		}

		//public StringBuilder AppendFormat(IFormatProvider provider, string format, params object[] args) {
		//    return this;
		//}

		public StringBuilder AppendFormat(string format, object arg0) {
			return string.FormatHelper(this, format, arg0);
		}

		public StringBuilder AppendFormat(string format, object arg0, object arg1) {
			return string.FormatHelper(this, format, arg0, arg1);
		}

		public StringBuilder AppendFormat(string format, object arg0, object arg1, object arg2) {
			return string.FormatHelper(this, format, arg0, arg1, arg2);
		}

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
