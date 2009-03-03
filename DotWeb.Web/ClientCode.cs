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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using System.IO;
using System.Web.Caching;
using DotWeb.Translator;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Remoting.Messaging;
using DotWeb.Hosting.Bridge;
using System.Diagnostics;
using System.Reflection;
using DotWeb.Web.Properties;

namespace DotWeb.Web
{
	[ToolboxData("<{0}:ClientCode runat=server></{0}:ClientCode>")]
	public class ClientCode : Control
	{
		public string Source { get; set; }

		[DefaultValue(true)]
		public bool Minify { get; set; }

		[DefaultValue("~/js/Cache")]
		public string CacheDir { get; set; }

		[DefaultValue("Web")]
		public string Mode { get; set; }

		[DefaultValue(true)]
		public bool EnableCache { get; set; }

		private bool isDebug;

		public ClientCode() {
			this.CacheDir = WebConfigurationManager.AppSettings["JavaScriptCache"];
			if (this.CacheDir == null)
				this.CacheDir = "~/js/Cache";

			this.Mode = WebConfigurationManager.AppSettings["DotWeb-Mode"];
			if (this.Mode == null)
				this.Mode = "Web";

			this.EnableCache = true;
			string value = WebConfigurationManager.AppSettings["DotWeb-EnableCache"];
			if (!string.IsNullOrEmpty(value) && value != "true")
				this.EnableCache = false;

			Configuration cfg = WebConfigurationManager.OpenWebConfiguration("~");
			ConfigurationSectionGroup grp = cfg.GetSectionGroup("system.web");
			CompilationSection section = grp.Sections.Get("compilation") as CompilationSection;

			this.isDebug = section.Debug;
			if(this.isDebug) {
				this.Minify = false;
			}
			else {
				this.Minify = true;
			}
		}

		private string Translate() {
			Type srcType = Type.GetType(this.Source);
			string typeName = srcType.FullName;
			string filename = typeName
				.Replace('.', '_')
				.Replace('+', '_') + ".js";
			Uri uri = new Uri(srcType.Assembly.CodeBase);
			string srcPath = uri.AbsolutePath;
			string virtualPath = string.Format("{0}/{1}", this.CacheDir, filename);
			string tgtPath = this.MapPathSecure(virtualPath);

			using (StreamWriter writer = new StreamWriter(tgtPath)) {
				TranslationEngine translator = new TranslationEngine(writer, true);
				translator.Translate(srcType);
			}

			string src = this.ResolveUrl(virtualPath);

			if (this.EnableCache) {
				Cache cache = this.Context.Cache;
				CacheDependency depends = new CacheDependency(srcPath);
				cache.Add(
					this.Source,
					src,
					null,
					Cache.NoAbsoluteExpiration,
					Cache.NoSlidingExpiration,
					CacheItemPriority.Normal,
					null);
			}
			return src;
		}

		private void OnAccept(IAsyncResult ar) {
			TcpListener listener = (TcpListener)ar.AsyncState;
			TcpClient tcp = listener.EndAcceptTcpClient(ar);
			NetworkStream stream = tcp.GetStream();
			try {
				listener.BeginAcceptTcpClient(this.OnAccept, listener);

				JsBridge bridge = new JsBridge(stream);
				bridge.DispatchForever();
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				stream.Close();
			}

			tcp.Close();
		}

		protected override void Render(HtmlTextWriter writer) {
			if (this.Mode == "Hosted") {
				HttpCookie cookie = new HttpCookie("X-DotWeb");
				this.Context.Response.Cookies.Add(cookie);
				TcpListener listener = Context.Application["DotWeb.TcpListener"] as TcpListener;
				if (listener == null) {
					listener = new TcpListener(IPAddress.Loopback, 0);
					listener.Start();
					Context.Application["DotWeb.TcpListener"] = listener;
					listener.BeginAcceptTcpClient(this.OnAccept, listener);
				}
				IPEndPoint ip = (IPEndPoint)listener.LocalEndpoint;

				//<embed id="__$plugin" type="application/x-dotweb"/>
				writer.AddAttribute(HtmlTextWriterAttribute.Id, "__$plugin");
				writer.AddAttribute(HtmlTextWriterAttribute.Type, "application/x-dotweb");
				writer.RenderBeginTag(HtmlTextWriterTag.Embed);
				writer.RenderEndTag();

				writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
				writer.RenderBeginTag(HtmlTextWriterTag.Script);
//				writer.WriteLine("$wnd.__$serverUrl = 'tcp://localhost:{0}';", ip.Port);
//				writer.WriteLine("$wnd.__$serverType = '{0}';", this.Source);
				writer.WriteLine(Resources.JsHelper);
				string js = string.Format(@"
window.onload = function() {{
	var plugin = $doc.getElementById('__$plugin');
	plugin.onLoad(__$helper, 'localhost', {0}, '{1}');
}};", ip.Port, this.Source);

				writer.WriteLine(js);
				writer.RenderEndTag();
			}
			else if (this.Mode == "Web") {
				string src = null;
				if (this.EnableCache) {
					Cache cache = this.Context.Cache;
					src = cache.Get(this.Source) as string;
				}
				if (src == null) {
					src = Translate();
				}

				writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
				writer.AddAttribute(HtmlTextWriterAttribute.Src, src);
				writer.RenderBeginTag(HtmlTextWriterTag.Script);
				writer.RenderEndTag();
			}
			else {
				throw new ConfigurationErrorsException(string.Format("Invalid DotWeb-Mode: {0}", this.Mode));
			}
		}
	}
}
