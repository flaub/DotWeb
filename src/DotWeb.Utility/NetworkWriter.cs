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

using System.Text;
using System.IO;
using System;

namespace DotWeb.Utility
{
	public class NetworkWriter
	{
		private readonly Stream stream;

		public NetworkWriter(Stream output) {
			this.stream = output;
		}

		public virtual Stream BaseStream { get { return this.stream; } }

		public virtual void Write(byte[] buffer, int index, int count) {
			this.stream.Write(buffer, index, count);
		}

		public virtual void Write(bool value) {
			this.stream.WriteByte(value ? (byte)1 : (byte)0);
		}

		public virtual void Write(byte value) {
			this.stream.WriteByte(value);
		}

		public virtual void Write(byte[] buffer) {
			this.stream.Write(buffer, 0, buffer.Length);
		}

		public virtual void Write(short value) {
			byte[] buf = NetworkBitConverter.ToBuffer(value);
			this.stream.Write(buf, 0, buf.Length);
		}

		public virtual void Write(int value) {
			byte[] buf = NetworkBitConverter.ToBuffer(value);
			this.stream.Write(buf, 0, buf.Length);
		}

		public virtual void Write(long value) {
			byte[] buf = NetworkBitConverter.ToBuffer(value);
			this.stream.Write(buf, 0, buf.Length);
		}

		public virtual void Write(sbyte value) {
			this.stream.WriteByte((byte)value);
		}

		public virtual void Write(ushort value) {
			this.Write((short)value);
		}

		public virtual void Write(uint value) {
			this.Write((int)value);
		}

		public virtual void Write(ulong value) {
			this.Write((long)value);
		}

		public virtual void Write(string value) {
			this.Write(value.Length);
			byte[] buf = Encoding.UTF8.GetBytes(value);
			this.Write(buf);
		}

		// FIXME!
		//public virtual void Write(float value) {
		//    this.Write((int)value);
		//}

		public virtual void Write(double value) {
			byte[] buf = NetworkBitConverter.ToBuffer(value);
			this.stream.Write(buf, 0, buf.Length);
		}
	}
}
