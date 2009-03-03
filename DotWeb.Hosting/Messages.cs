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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

	public class LoadMessage : IMessage
	{
		public string TypeName;

		#region Message
		public MessageType MessageType { get { return MessageType.Load; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(TypeName);
		}

		public void Read(NetworkReader reader) {
			TypeName = reader.ReadString();
		}
		#endregion
	}

	public class GetTypeRequestMessage : IMessage
	{
		public int TargetId;

		#region Message
		public MessageType MessageType { get { return MessageType.GetTypeRequest; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(TargetId);
		}

		public void Read(NetworkReader reader) {
			TargetId = reader.ReadInt32();
		}
		#endregion
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

	public class GetTypeResponseMessage : IMessage
	{
		public int IndexerLength;
		public List<TypeMemberInfo> Members;

		#region Message
		public MessageType MessageType { get { return MessageType.GetTypeResponse; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(IndexerLength);
			writer.Write(Members.Count);
			foreach (TypeMemberInfo info in Members) {
				info.Write(writer);
			}
		}

		public void Read(NetworkReader reader) {
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
	}

	public class InvokeMemberMessage : IMessage
	{
		public int TargetId;
		public int MemberId;
		public DispatchType DispatchType;
		public JsValue[] Parameters;

		#region Message
		public MessageType MessageType { get { return MessageType.InvokeMember; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(this.TargetId);
			writer.Write(this.MemberId);
			writer.Write((byte)this.DispatchType);
			writer.Write(this.Parameters.Length);
			foreach (JsValue arg in Parameters) {
				arg.Write(writer);
			}
		}

		public void Read(NetworkReader reader) {
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
	}

	public class InvokeDelegateMessage : IMessage
	{
		public int TargetId;
		public JsValue[] Parameters;

		#region Message
		public MessageType MessageType { get { return MessageType.InvokeDelegate; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(TargetId);
			writer.Write(this.Parameters.Length);
			foreach (JsValue arg in Parameters) {
				arg.Write(writer);
			}
		}

		public void Read(NetworkReader reader) {
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
	}

	public class ReturnMessage : IMessage
	{
		public bool IsException;
		public JsValue Value;

		#region Message
		public MessageType MessageType { get { return MessageType.Return; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(IsException);
			Value.Write(writer);
		}

		public void Read(NetworkReader reader) {
			Value = new JsValue();
			IsException = reader.ReadBoolean();
			Value.Read(reader);
		}
		#endregion
	}

	public class QuitMessage : IMessage
	{
		#region Message
		public MessageType MessageType { get { return MessageType.Quit; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
		}

		public void Read(NetworkReader reader) {
		}
		#endregion
	}

	public class DefineFunctionMessage : IMessage
	{
		public string Name;
		public string Parameters;
		public string Body;

		#region Message
		public MessageType MessageType { get { return MessageType.DefineFunction; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(Name);
			writer.Write(Parameters);
			writer.Write(Body);
		}

		public void Read(NetworkReader reader) {
			Name = reader.ReadString();
			Parameters = reader.ReadString();
			Body = reader.ReadString();
		}
		#endregion
	}

	public class InvokeFunctionMessage : IMessage
	{
		public string Name;
		public int ScopeId;
		public JsValue[] Parameters;

		#region Message
		public MessageType MessageType { get { return MessageType.InvokeFunction; } }

		public void Write(NetworkWriter writer) {
			writer.Write((byte)MessageType);
			writer.Write(Name);
			writer.Write(ScopeId);
			writer.Write(this.Parameters.Length);
			foreach (JsValue arg in Parameters) {
				arg.Write(writer);
			}
		}

		public void Read(NetworkReader reader) {
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
	}
}
