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

using System.Collections.Generic;
using System.Linq;
using System.IO;
using DotWeb.Utility;

namespace DotWeb.Hosting
{
	public enum MessageType : byte
	{
		Load = 0,
		GetTypeRequest = 1,
		GetTypeResponse = 2,
		InvokeMember = 3,
		InvokeDelegate = 4,
		DefineFunction = 5,
		InvokeFunction = 6,
		Return = 7,
		Quit = 8
	}

	public enum ExceptionType : byte
	{
		Generic,
		MissingMember
	}

	public interface IMessage
	{
		void Write(NetworkWriter writer);
		void Read(NetworkReader reader);

		MessageType MessageType { get; }
	}

	public abstract class MessageBase : IMessage
	{
		private byte[] Serialize(IMessage msg) {
			MemoryStream ms = new MemoryStream();
			NetworkWriter writer = new NetworkWriter(ms);
			msg.Write(writer);
			return ms.ToArray(); 
		}

		public override bool Equals(object obj) {
			IMessage rhs = obj as IMessage;
			if (rhs == null)
				return false;

			byte[] lhsBytes = Serialize(this);
			byte[] rhsBytes = Serialize(rhs);

			return ByteArraysEqual(lhsBytes, rhsBytes);
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}

		private bool ByteArraysEqual(byte[] b1, byte[] b2) {
			if (b1 == b2) return true;
			if (b1 == null || b2 == null) return false;
			if (b1.Length != b2.Length) return false;
			for (int i = 0; i < b1.Length; i++) {
				if (b1[i] != b2[i]) return false;
			}
			return true;
		}

		#region IMessage Members

		public abstract void Write(NetworkWriter writer);
		public abstract void Read(NetworkReader reader);
		public abstract MessageType MessageType { get; }

		#endregion
	}

	public class LoadMessage : MessageBase
	{
		public string TypeName;

		#region Message
		public override MessageType MessageType { get { return MessageType.Load; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(TypeName);
		}

		public override void Read(NetworkReader reader) {
			TypeName = reader.ReadString();
		}
		#endregion

		public override string ToString() {
			return string.Format("LoadMessage [{0}]", this.TypeName);
		}
	}

	public class GetTypeRequestMessage : MessageBase
	{
		public int TargetId;

		#region Message
		public override MessageType MessageType { get { return MessageType.GetTypeRequest; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(TargetId);
		}

		public override void Read(NetworkReader reader) {
			TargetId = reader.ReadInt32();
		}
		#endregion

		public override string ToString() {
			return string.Format("GetTypeRequestMessage [{0}]", this.TargetId);
		}
	}

	public class TypeMemberInfo
	{
		public int MemberId;
		public string Name;
		public DispatchType DispatchType;

		public void Write(NetworkWriter writer) {
			writer.Write(MemberId);
			writer.Write(Name);
			writer.Write((byte)DispatchType);
		}

		public void Read(NetworkReader reader) {
			MemberId = reader.ReadInt32();
			Name = reader.ReadString();
			DispatchType = (DispatchType)reader.ReadByte();
		}
	}

	public class GetTypeResponseMessage : MessageBase
	{
		public int IndexerLength;
		public List<TypeMemberInfo> Members;

		#region Message
		public override MessageType MessageType { get { return MessageType.GetTypeResponse; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(IndexerLength);
			writer.Write(Members.Count);
			foreach (TypeMemberInfo info in Members) {
				info.Write(writer);
			}
		}

		public override void Read(NetworkReader reader) {
			IndexerLength = reader.ReadInt32();
			int count = reader.ReadInt32();
			Members = new List<TypeMemberInfo>();
			for (int i = 0; i < count; i++) {
				TypeMemberInfo info = new TypeMemberInfo();
				info.Read(reader);
				Members.Add(info);
			}
		}
		#endregion

		public override string ToString() {
			string[] parts = Members.Select(x => string.Format("[{0}, {1}]", x.MemberId, x.Name)).ToArray();
			string members = string.Join(", ", parts);
			return string.Format(
				"GetTypeResponseMessage [IndexerLength: {0}, Members: ({1})]", 
				this.IndexerLength,
				members);
		}
	}

	public class InvokeMemberMessage : MessageBase
	{
		public int TargetId;
		public int MemberId;
		public DispatchType DispatchType;
		public JsValue[] Parameters;

		#region Message
		public override MessageType MessageType { get { return MessageType.InvokeMember; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(this.TargetId);
			writer.Write(this.MemberId);
			writer.Write((byte)this.DispatchType);
			writer.Write(this.Parameters.Length);
			foreach (JsValue arg in Parameters) {
				arg.Write(writer);
			}
		}

		public override void Read(NetworkReader reader) {
			TargetId = reader.ReadInt32();
			MemberId = reader.ReadInt32();
			DispatchType = (DispatchType)reader.ReadByte();
			int len = reader.ReadInt32();
			Parameters = new JsValue[len];
			for (int i = 0; i < len; i++) {
				JsValue value = new JsValue();
				value.Read(reader);
				Parameters[i] = value;
			}
		}
		#endregion

		public override string ToString() {
			string[] parts = Parameters.Select(x => x.ToString()).ToArray();
			string args = string.Join(", ", parts);
			return string.Format(
				"InvokeMemberMessage [Target: {0}, Member: {1}, DispatchType: {2}, Args: ({3})]", 
				this.TargetId, 
				this.MemberId, 
				this.DispatchType,
				args);
		}
	}

	public class InvokeDelegateMessage : MessageBase
	{
		public int TargetId;
		public JsValue[] Parameters;

		#region Message
		public override MessageType MessageType { get { return MessageType.InvokeDelegate; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(TargetId);
			writer.Write(this.Parameters.Length);
			foreach (JsValue arg in Parameters) {
				arg.Write(writer);
			}
		}

		public override void Read(NetworkReader reader) {
			TargetId = reader.ReadInt32();
			int len = reader.ReadInt32();
			Parameters = new JsValue[len];
			for (int i = 0; i < len; i++) {
				JsValue value = new JsValue();
				value.Read(reader);
				Parameters[i] = value;
			}
		}
		#endregion

		public override string ToString() {
			string[] parts = Parameters.Select(x => x.ToString()).ToArray();
			string args = string.Join(", ", parts);
			return string.Format("InvokeDelegateMessage [{0}({1})]", this.TargetId, args);
		}
	}

	public class ReturnMessage : MessageBase
	{
		public bool IsException;
		public JsValue Value;

		#region Message
		public override MessageType MessageType { get { return MessageType.Return; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(IsException);
			Value.Write(writer);
		}

		public override void Read(NetworkReader reader) {
			Value = new JsValue();
			IsException = reader.ReadBoolean();
			Value.Read(reader);
		}
		#endregion

		public override string ToString() {
			if (IsException)
				return string.Format("ReturnMessage [Exception: {0}]", Value);
			return string.Format("ReturnMessage [{0}]", Value);
		}
	}

	public class QuitMessage : MessageBase
	{
		#region Message
		public override MessageType MessageType { get { return MessageType.Quit; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
		}

		public override void Read(NetworkReader reader) {
		}
		#endregion

		public override string ToString() {
			return "QuitMessage";
		}
	}

	public class DefineFunctionMessage : MessageBase
	{
		public string Name;
		public string Parameters;
		public string Body;

		#region Message
		public override MessageType MessageType { get { return MessageType.DefineFunction; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(Name);
			writer.Write(Parameters);
			writer.Write(Body);
		}

		public override void Read(NetworkReader reader) {
			Name = reader.ReadString();
			Parameters = reader.ReadString();
			Body = reader.ReadString();
		}
		#endregion

		public override string ToString() {
			return string.Format("DefineFunctionMessage [{0}]", this.Name);
		}
	}

	public class InvokeFunctionMessage : MessageBase
	{
		public string Name;
		public int ScopeId;
		public JsValue[] Parameters;

		#region Message
		public override MessageType MessageType { get { return MessageType.InvokeFunction; } }

		public override void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(Name);
			writer.Write(ScopeId);
			writer.Write(this.Parameters.Length);
			foreach (JsValue arg in Parameters) {
				arg.Write(writer);
			}
		}

		public override void Read(NetworkReader reader) {
			Name = reader.ReadString();
			ScopeId = reader.ReadInt32();
			int len = reader.ReadInt32();
			Parameters = new JsValue[len];
			for (int i = 0; i < len; i++) {
				JsValue value = new JsValue();
				value.Read(reader);
				Parameters[i] = value;
			}
		}
		#endregion

		public override string ToString() {
			string[] parts = Parameters.Select(x => x.ToString()).ToArray();
			string args = string.Join(", ", parts);
			return string.Format("InvokeFunctionMessage [{0}({1})]", this.Name, args);
		}
	}
}
