using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using DotWeb.Hosting;
using DotWeb.Hosting.Bridge;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Reflection;
using System.IO;
using DotWeb.Utility;

namespace DotWeb.Runtime
{
	class CallContextStorage : IDotWebHost
	{
		private const string DataSlotName = "DotWebHost";

		public IDotWebHost Host {
			get {
				var host = CallContext.GetData(DataSlotName) as IDotWebHost;
				if (host == null) {
					Debugger.Log(0, "DotWeb", "Lost my mind");
					Debugger.Break();
				}
				return host;
			}

			set {
				CallContext.SetData(DataSlotName, value);
			}
		}

		#region IDotWebHost Members

		public object Invoke(object scope, object method, object[] args) {
			return this.Host.Invoke(scope, method, args);
		}

		public T Cast<T>(object obj) {
			return this.Host.Cast<T>(obj);
		}

		#endregion
	}

	public static class HostedTypeHelper
	{
		public static Type GetType(string name) {
			return null;
		}
	}

	public class HostedMode
	{
		string binPath;
		TcpListener listener;

		static HostedMode() {
			DotWeb.Hosting.HostedMode.Host = new CallContextStorage();
		}

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
				DotWeb.Hosting.HostedMode.Host = bridge;
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
