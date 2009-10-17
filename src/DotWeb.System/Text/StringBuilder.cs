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
