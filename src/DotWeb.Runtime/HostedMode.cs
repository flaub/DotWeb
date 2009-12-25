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
// 
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
using DotWeb.Tools.Weaver;

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

		public string PrepareType(AssemblyQualifiedTypeName aqtn) {
			var weaver = new HostingWeaver(this.binPath, this.binPath, new string[] { this.binPath });
			string path = Path.Combine(this.binPath, aqtn.AssemblyName.Name);
			if (!path.EndsWith(".dll")) {
				path += ".dll";
			}

			var asm = weaver.ProcessAssembly(path);
			var asmName = asm.GetName();
			aqtn.AssemblyName.Name = asmName.Name;
			return aqtn.ToString();
		}
		
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
