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
using System.IO;
using DotWeb.Utility;
using System.Diagnostics;

namespace DotWeb.Hosting
{
	public class RemoteSession : ISession
	{
		public RemoteSession(Stream stream) {
			this.stream = stream;
			this.reader = new NetworkReader(stream);
			this.writer = new NetworkWriter(stream);
		}

		public void SendMessage(IMessage msg) {
			Debug.WriteLine(string.Format("Send: {0}", msg));
			msg.Write(this.writer);
		}

		public IMessage ReceiveMessage() {
			Debug.WriteLine("");
			var type = (MessageType)this.reader.ReadByte();
			IMessage ret;
			switch (type) {
				case MessageType.Load:
					ret = new LoadMessage();
					break;
				case MessageType.Return:
					ret = new ReturnMessage();
					break;
				case MessageType.DefineFunction:
					ret = new DefineFunctionMessage();
					break;
				case MessageType.GetTypeRequest:
					ret = new GetTypeRequestMessage();
					break;
				case MessageType.GetTypeResponse:
					ret = new GetTypeResponseMessage();
					break;
				case MessageType.InvokeDelegate:
					ret = new InvokeDelegateMessage();
					break;
				case MessageType.InvokeFunction:
					ret = new InvokeFunctionMessage();
					break;
				case MessageType.InvokeMember:
					ret = new InvokeMemberMessage();
					break;
				case MessageType.Quit:
					this.stream.Close();
					return new QuitMessage();
				default:
					Debug.WriteLine(string.Format("Unknown message type: {0}", type));
					throw new ArgumentException("Unknown MessageType", "type");
			}

			ret.Read(this.reader);
			Debug.WriteLine(string.Format("Receive: {0}", ret));
			return ret;
		}

		private readonly NetworkReader reader;
		private readonly NetworkWriter writer;
		private readonly Stream stream;
	}
}
