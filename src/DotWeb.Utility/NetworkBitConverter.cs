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

namespace DotWeb.Utility
{
	public class NetworkBitConverter
	{
		public static byte[] ToBuffer(short value) {
			byte[] buf = new byte[sizeof(short)];
			buf[0] = (byte)((value >> 8) & 0xff);
			buf[1] = (byte)(value & 0xff);
			return buf;
		}

		public static byte[] ToBuffer(int value) {
			byte[] buf = new byte[sizeof(int)];
			buf[0] = (byte)((value >> 24) & 0xff);
			buf[1] = (byte)((value >> 16) & 0xff);
			buf[2] = (byte)((value >> 8) & 0xff);
			buf[3] = (byte)(value & 0xff);
			return buf;
		}

		public static byte[] ToBuffer(long value) {
			byte[] buf = new byte[sizeof(long)];
			buf[0] = ((byte)((value >> 56) & 0xff));
			buf[1] = ((byte)((value >> 48) & 0xff));
			buf[2] = ((byte)((value >> 40) & 0xff));
			buf[3] = ((byte)((value >> 32) & 0xff));
			buf[4] = ((byte)((value >> 24) & 0xff));
			buf[5] = ((byte)((value >> 16) & 0xff));
			buf[6] = ((byte)((value >> 8) & 0xff));
			buf[7] = ((byte)(value & 0xff));
			return buf;
		}

		public static bool ToBoolean(byte[] buf, int index) {
			return buf[index] != 0;
		}

		public static short ToInt16(byte[] buf, int index) {
			short ret = (short)(
				((ushort)buf[index + 0] << 8) |
				(ushort)buf[index + 1]
			);
			return ret;
		}

		public static int ToInt32(byte[] buf, int index) {
			int ret = (int)(
				((uint)buf[index + 0] << 24) |
				((uint)buf[index + 1] << 16) |
				((uint)buf[index + 2] << 8) |
				(uint)buf[index + 3]
			);
			return ret;
		}

		public static long ToInt64(byte[] buf, int index) {
			long ret = (long)(
				((ulong)buf[index + 0] << 56) |
				((ulong)buf[index + 1] << 48) |
				((ulong)buf[index + 2] << 40) |
				((ulong)buf[index + 3] << 32) |
				((ulong)buf[index + 4] << 24) |
				((ulong)buf[index + 5] << 16) |
				((ulong)buf[index + 6] << 8) |
				(ulong)buf[index + 7]
			);
			return ret;
		}

		public static ushort ToUInt16(byte[] buf, int index) {
			return (ushort)ToInt16(buf, index);
		}

		public static uint ToUInt32(byte[] buf, int index) {
			return (uint)ToInt32(buf, index);
		}

		public static ulong ToUInt64(byte[] buf, int index) {
			return (ulong)ToInt64(buf, index);
		}
	}
}
