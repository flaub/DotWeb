using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace DotWeb.Hosting.Bridge
{
	public class HostingServer
	{
		private TcpListener listener;

		public IPEndPoint EndPoint { get { return (IPEndPoint)this.listener.LocalEndpoint; } }

		public HostingServer()
			: this(0) {
		}

		public HostingServer(int port) {
			this.listener = new TcpListener(IPAddress.Loopback, port);
		}

		public void Start() {
			this.listener.Start();
			while (true) {
				var client = this.listener.AcceptTcpClient();
				ThreadPool.QueueUserWorkItem((state) => RunInAppDomain(client));
			}
		}

		public void AsyncStart() {
			this.listener.Start();
			this.listener.BeginAcceptTcpClient(this.OnAccept, null);
		}

		private void OnAccept(IAsyncResult ar) {
			var client = this.listener.EndAcceptTcpClient(ar);
			this.listener.BeginAcceptTcpClient(this.OnAccept, null);
			RunInAppDomain(client);
		}

		private void RunInAppDomain(TcpClient client) {
			var curDomain = AppDomain.CurrentDomain;
			var setup = curDomain.SetupInformation;

			var appDomain = AppDomain.CreateDomain("DotWeb Hosting Environment", null, setup);
			var type = typeof(IsolatedContext);
			var context = (IsolatedContext)appDomain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);

			try {
				context.Run(client.GetStream());
			}
			finally {
				client.Close();
				AppDomain.Unload(appDomain);
			}
		}

		/// <summary>
		/// This allows static variables to be reset on each new request.
		/// It also serves as a good way to isolate each request from each other.
		/// </summary>
		class IsolatedContext : MarshalByRefObject
		{
			public void Run(NetworkStream stream) {
				HostedMode.Host = new CallContextStorage();
				try {
					var session = new RemoteSession(stream, stream);
					var factory = new DefaultFactory();
					var bridge = new JsBridge(session, factory);
					HostedMode.Host = bridge;
					bridge.DispatchForever();
				}
				catch (Exception ex) {
					Debug.WriteLine(ex);
				}
				finally {
					stream.Close();
				}
			}
		}
	}
}
