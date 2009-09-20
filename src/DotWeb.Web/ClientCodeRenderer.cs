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
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.UI;
using DotWeb.Client;
using DotWeb.Hosting;
using DotWeb.Hosting.Bridge;
using DotWeb.Translator;
using DotWeb.Web.Properties;
using System.Runtime.Remoting.Messaging;

namespace DotWeb.Web
{
	public class ClientCodeRenderer
	{
		private const string DotWebMimeType = "application/x-dotweb";
		private const string DotWebTcpListenerKey = "DotWeb.TcpListener";
		private readonly IHttpContext context;
		private readonly bool isDebug;

		#region Properties

		public string Source { get; set; }

		public bool Minify { get; set; }

		public string CacheDir { get; set; }

		public string Mode { get; set; }

		public bool EnableCache { get; set; }

		#endregion

		public ClientCodeRenderer(IHttpContext context) {
			this.context = context;

			CacheDir = WebConfigurationManager.AppSettings["JavaScriptCache"] ?? "~/js/Cache";
			Mode = WebConfigurationManager.AppSettings["DotWeb-Mode"] ?? "Web";

			EnableCache = true;
			string value = WebConfigurationManager.AppSettings["DotWeb-EnableCache"];
			if (!string.IsNullOrEmpty(value) && value != "true")
				EnableCache = false;

			Configuration cfg = WebConfigurationManager.OpenWebConfiguration("~");
			ConfigurationSectionGroup grp = cfg.GetSectionGroup("system.web");
			if (grp != null) {
				var section = grp.Sections.Get("compilation") as CompilationSection;
				if (section != null)
					isDebug = section.Debug;
			}
			Minify = !isDebug;
		}

		private string Translate() {
			Type srcType = Type.GetType(Source);
			string typeName = srcType.FullName;
			string filename = typeName
			                  	.Replace('.', '_')
			                  	.Replace('+', '_') + ".js";
			var uri = new Uri(srcType.Assembly.CodeBase);
			string srcPath = uri.AbsolutePath;
			string virtualPath = string.Format("{0}/{1}", CacheDir, filename);
			string tgtPath = context.MapPath(virtualPath);

			using (var writer = new StreamWriter(tgtPath)) {
				var translator = new TranslationEngine(writer, true);
				translator.TranslateType(srcType);
			}

			string src = context.ResolveUrl(virtualPath);

			if (EnableCache) {
				Cache cache = context.Cache;
				var depends = new CacheDependency(srcPath);
				cache.Add(
					Source,
					src,
					depends,
					Cache.NoAbsoluteExpiration,
					Cache.NoSlidingExpiration,
					CacheItemPriority.Normal,
					null);
			}
			return src;
		}

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

		private void OnAccept(IAsyncResult ar) {
			var listener = (TcpListener) ar.AsyncState;
			TcpClient tcp = listener.EndAcceptTcpClient(ar);
			NetworkStream stream = tcp.GetStream();
			try {
				listener.BeginAcceptTcpClient(OnAccept, listener);
				var session = new RemoteSession(stream);
				var factory = new DefaultFactory();
				var bridge = new JsBridge(session, factory);
				JsHost.Storage = new CallContextStorage(bridge);
				bridge.DispatchForever();
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				stream.Close();
			}

			tcp.Close();
		}

		public void Render(HtmlTextWriter writer) {
			if (Mode == "Hosted") {
				RenderHostedMode(writer);
			}
			else if (Mode == "Web") {
				RenderWebMode(writer);
			}
			else {
				throw new ConfigurationErrorsException(string.Format("Invalid DotWeb-Mode: {0}", Mode));
			}
		}

		private void RenderHostedMode(HtmlTextWriter writer) {
			var cookie = new HttpCookie("X-DotWeb");
			context.AddCookie(cookie);
			var listener = context.GetApplicationState(DotWebTcpListenerKey) as TcpListener;
			if (listener == null) {
				listener = new TcpListener(IPAddress.Loopback, 0);
				listener.Start();
				context.SetApplicationState(DotWebTcpListenerKey, listener);
				listener.BeginAcceptTcpClient(OnAccept, listener);
			}
			var ip = (IPEndPoint) listener.LocalEndpoint;

			//<embed id="__$plugin" type="application/x-dotweb"/>
			writer.AddAttribute(HtmlTextWriterAttribute.Id, "__$plugin");
			writer.AddAttribute(HtmlTextWriterAttribute.Type, DotWebMimeType);
			writer.RenderBeginTag(HtmlTextWriterTag.Embed);
			writer.RenderEndTag();

			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
			writer.RenderBeginTag(HtmlTextWriterTag.Script);

			writer.WriteLine(Resources.JsHelper);
			string js = string.Format(Resources.HostedEntry, ip.Port, Source);

			writer.WriteLine(js);
			writer.RenderEndTag();
		}

		private void RenderWebMode(HtmlTextWriter writer) {
			string src = null;
			if (EnableCache) {
				Cache cache = context.Cache;
				src = cache.Get(Source) as string;
			}
			if (src == null) {
				src = Translate();
			}

			//			string js = string.Format(Resources.WebEntry, typeName);

			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
			writer.AddAttribute(HtmlTextWriterAttribute.Src, src);
			writer.RenderBeginTag(HtmlTextWriterTag.Script);
			writer.RenderEndTag();
		}
	}
}