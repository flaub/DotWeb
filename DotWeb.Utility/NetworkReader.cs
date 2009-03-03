using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace DotWeb.Utility
{
	public class NetworkReader
	{
		private Stream stream;

		public NetworkReader(Stream input) {
			this.stream = input;
		}

		public virtual Stream BaseStream { get { return this.stream; } }

		public virtual int Read(byte[] buffer, int index, int count) {
			return this.stream.Read(buffer, index, count);
		}

		public virtual bool ReadBoolean() {
			byte x = ReadByte();
			return x != 0;
		}

		public virtual byte ReadByte() {
			int ret = this.stream.ReadByte();
			if (ret < 0)
				throw new IOException();
			return (byte)ret;
		}

		public virtual byte[] ReadBytes(int count) {
			byte[] buf = new byte[count];
			int remain = count;
			int index = 0;
			while (remain > 0) {
				int ret = Read(buf, index, remain);
				if (ret <= 0) {
					throw new Exception("0 bytes read");
				}
				remain -= ret;
				index += ret;
			}
			return buf;
		}

		public virtual short ReadInt16() {
			byte[] buf = ReadBytes(sizeof(short));
			return NetworkBitConverter.ToInt16(buf, 0);
		}

		public virtual int ReadInt32() {
			byte[] buf = ReadBytes(sizeof(int));
			return NetworkBitConverter.ToInt32(buf, 0);
		}

		public virtual long ReadInt64() {
			byte[] buf = ReadBytes(sizeof(long));
			return NetworkBitConverter.ToInt64(buf, 0);
		}

		public virtual sbyte ReadSByte() {
			return (sbyte)ReadByte();
		}

		public virtual ushort ReadUInt16() {
			return (ushort)ReadInt16();
		}

		public virtual uint ReadUInt32() {
			return (uint)ReadInt32();
		}

		public virtual ulong ReadUInt64() {
			return (ulong)ReadInt64();
		}

		public virtual string ReadString() {
			int size = ReadInt32();
			byte[] buf = ReadBytes(size);
			return Encoding.UTF8.GetString(buf);
		}

		public virtual float ReadSingle() {
			return (float)ReadInt32();
		}

		public virtual double ReadDouble() {
			return (double)ReadInt64();
		}
	}
}
