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

using System.Net.Sockets;
using System.Net;
using System.IO;
using DotWeb.Utility;
using DotWeb.Tools.Weaver;
using System;
using System.Diagnostics;

namespace DotWeb.Hosting.Bridge
{
	public interface IHostingServer
	{
		string PrepareType(string binPath, AssemblyQualifiedTypeName aqtn);

		IPEndPoint EndPoint { get; }

		void Start();
		void StartAsync();
		void Stop();
	}

	public static class HostingServerFactory
	{
		public static IHostingServer CreateHostingServer() {
			//var curDomain = AppDomain.CurrentDomain;
			//var setup = curDomain.SetupInformation;

			//setup.AppDomainInitializer = OnAppDomainInit;
			//setup.AppDomainInitializerArguments = null;

			//var appDomain = AppDomain.CreateDomain("DotWeb Hosting Environment", null, setup);

			//var type = typeof(HostingServer);
			//var server = (HostingServer)appDomain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
			//return server;
			HostedMode.Host = new CallContextStorage();

			return new HostingServer();
		}

		private static void OnAppDomainInit(string[] args) {
			HostedMode.Host = new CallContextStorage();
		}
	}

	class HostingServer : MarshalByRefObject, IHostingServer
	{
		TcpListener listener;

		public HostingServer() {
			this.listener = new TcpListener(IPAddress.Loopback, 0);
		}

		public IPEndPoint EndPoint { get { return (IPEndPoint)this.listener.LocalEndpoint; } }

		public string PrepareType(string binPath, AssemblyQualifiedTypeName aqtn) {
			var weaver = new HostingWeaver(binPath, binPath, new string[] { binPath });
			string path = Path.Combine(binPath, aqtn.AssemblyName.Name);
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
			this.RunLoop();
		}

		public void Stop() {
			this.listener.Stop();
		}

		public void StartAsync() {
			this.listener.Start();
			this.listener.BeginAcceptTcpClient(OnAccept, listener);
		}

		private void OnAccept(IAsyncResult ar) {
			var listener = (TcpListener)ar.AsyncState;
			var client = listener.EndAcceptTcpClient(ar);
			listener.BeginAcceptTcpClient(OnAccept, listener);
			RunOnce(client);
		}

		private void RunOnce(TcpClient client) {
			var stream = client.GetStream();
			try {
				var session = new RemoteSession(stream);
				var factory = new DefaultFactory();
				var bridge = new JsBridge(session, factory);
				HostedMode.Host = bridge;
				bridge.DispatchForever();
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				stream.Close();
			}

			client.Close();
		}

		private void RunLoop() {
			try {
				while (true) {
					var client = this.listener.AcceptTcpClient();
					RunOnce(client);
				}
			}
			catch (Exception ex) {
				Console.WriteLine("RunLoop exception:", ex.Message);
			}
		}
	}
}
