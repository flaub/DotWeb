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
	public class Session
	{
		private NetworkReader reader;
		private NetworkWriter writer;
		private Stream stream;

		public Session(Stream stream) {
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
