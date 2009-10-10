using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using DotWeb.Hosting;
using DotWeb.Hosting.Bridge;
using DotWeb.Client;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Reflection;
using System.IO;
using DotWeb.Utility;

namespace DotWeb.Runtime
{
	class CallContextStorage : IJsHostStorage
	{
		private const string JsHostName = "JsHost";

		public CallContextStorage(IJsHost host) {
			CallContext.SetData(JsHostName, host);
		}

		public IJsHost Host {
			get {
				var host = CallContext.GetData(JsHostName) as IJsHost;
				if (host == null) {
					Debugger.Log(0, "DotWeb", "Lost my mind");
					Debugger.Break();
				}
				return host;
			}
		}
	}

	public class HostedMode
	{
		string binPath;
		TcpListener listener;

		public HostedMode(string binPath) {
			this.binPath = binPath;
			this.listener = new TcpListener(IPAddress.Loopback, 0);
		}

		public IPEndPoint EndPoint { get { return (IPEndPoint)this.listener.LocalEndpoint; } }

		//public string PrepareType(string fullTypeName) {
		//    string[] parts = fullTypeName.Split(',');
		//    string typeName = parts[0].Trim();
		//    string asmName = parts[1].Trim();

		//    var fixup = new AssemblyReferenceFixup(this.binPath);
		//    var altName = fixup.FixupReferences(asmName, false);

		//    var ret = string.Format("{0}, {1}", typeName, altName.Name);
		//    return ret;
		//}
		
		public void Start() {
			this.listener.Start();
			this.listener.BeginAcceptTcpClient(OnAccept, listener);
		}

		private void OnAccept(IAsyncResult ar) {
			var listener = (TcpListener)ar.AsyncState;
			TcpClient tcp = listener.EndAcceptTcpClient(ar);
			NetworkStream stream = tcp.GetStream();
			try {
				listener.BeginAcceptTcpClient(OnAccept, listener);
				var session = new RemoteSession(stream);
				var factory = new DefaultFactory();
				var bridge = new JsBridge(session, factory);
//				JsHost.Storage = new CallContextStorage(bridge);
				bridge.DispatchForever();
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				stream.Close();
			}

			tcp.Close();
		}
	}
}
