using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using DotWeb.Hosting;
using DotWeb.Hosting.Bridge;
using System.Diagnostics;
using System.Threading;

namespace DotWeb.Debugger
{
	class Program
	{
		static void Main(string[] args) {
			new Program().Start();
		}

		public void Start() {
			var listener = new TcpListener(IPAddress.Loopback, 0x1337);
			listener.Start();
			while (true) {
				var client = listener.AcceptTcpClient();
				ThreadPool.QueueUserWorkItem((state) => RunInAppDomain(client));
			}
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
