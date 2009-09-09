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
using System.Net.Sockets;
using System.IO;
using DotWeb.Utility;
using System.Diagnostics;

namespace DotWeb.Hosting
{
	public class RemoteSession : ISession
	{
		private NetworkReader reader;
		private NetworkWriter writer;
		private Stream stream;

		public RemoteSession(Stream stream) {
			this.stream = stream;
			this.reader = new NetworkReader(stream);
			this.writer = new NetworkWriter(stream);
		}

		public void SendMessage(IMessage msg) {
			msg.Write(this.writer);
		}

		public IMessage ReadMessage() {
			Debug.WriteLine("Reading MessageHeader...");
			MessageType type = (MessageType)this.reader.ReadByte();
			IMessage ret;
			switch (type) {
				case MessageType.Load:
					Debug.WriteLine("MT_Load");
					ret = new LoadMessage();
					break;
				case MessageType.Return:
					Debug.WriteLine("MT_Return");
					ret = new ReturnMessage();
					break;
				case MessageType.DefineFunction:
					Debug.WriteLine("MT_DefineFunction");
					ret = new DefineFunctionMessage();
					break;
				case MessageType.GetTypeRequest:
					Debug.WriteLine("MT_GetTypeRequest");
					ret = new GetTypeRequestMessage();
					break;
				case MessageType.GetTypeResponse:
					Debug.WriteLine("MT_GetTypeResponse");
					ret = new GetTypeResponseMessage();
					break;
				case MessageType.InvokeDelegate:
					Debug.WriteLine("MT_InvokeDelegate");
					ret = new InvokeDelegateMessage();
					break;
				case MessageType.InvokeFunction:
					Debug.WriteLine("MT_InvokeFunction");
					ret = new InvokeFunctionMessage();
					break;
				case MessageType.InvokeMember:
					Debug.WriteLine("MT_InvokeMember");
					ret = new InvokeMemberMessage();
					break;
				case MessageType.Quit:
					Debug.WriteLine("MT_Quit");
					this.stream.Close();
					return new QuitMessage();
				default:
					Debug.WriteLine(string.Format("Unknown message type: {0}", type));
					throw new ArgumentException("Unknown MessageType", "type");
			}

			ret.Read(this.reader);
			return ret;
		}
	}
}
