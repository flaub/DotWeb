using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Configuration;
using System.Web.Caching;
using System.IO;
using DotWeb.Translator;
using System.Net.Sockets;
using DotWeb.Hosting.Bridge;
using System.Diagnostics;
using System.Web;
using System.Net;
using System.Web.UI;
using DotWeb.Web.Properties;
using DotWeb.Hosting;

namespace DotWeb.Web
{
	public interface IHttpContext
	{
		string MapPath(string virtualPath);
		string ResolveUrl(string url);
		Cache Cache { get; }
		void AddCookie(HttpCookie cookie);

		object GetApplicationState(string key);
		void SetApplicationState(string key, object value);
	}

	public class ClientCodeRenderer
	{
		public ClientCodeRenderer(IHttpContext context) {
			this.context = context;

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
			if (this.isDebug) {
				this.Minify = false;
			}
			else {
				this.Minify = true;
			}
		}

		#region Properties
		public string Source { get; set; }

		public bool Minify { get; set; }

		public string CacheDir { get; set; }

		public string Mode { get; set; }

		public bool EnableCache { get; set; }

		private bool isDebug;
		#endregion

		private string Translate() {
			Type srcType = Type.GetType(this.Source);
			string typeName = srcType.FullName;
			string filename = typeName
				.Replace('.', '_')
				.Replace('+', '_') + ".js";
			Uri uri = new Uri(srcType.Assembly.CodeBase);
			string srcPath = uri.AbsolutePath;
			string virtualPath = string.Format("{0}/{1}", this.CacheDir, filename);
			string tgtPath = this.context.MapPath(virtualPath);

			using (StreamWriter writer = new StreamWriter(tgtPath)) {
				TranslationEngine translator = new TranslationEngine(writer, true);
				translator.TranslateType(srcType);
			}

			string src = this.context.ResolveUrl(virtualPath);

			if (this.EnableCache) {
				Cache cache = this.context.Cache;
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
				RemoteSession session = new RemoteSession(stream);
				JsBridge bridge = new JsBridge(session);
				bridge.DispatchForever();
			}
			catch (Exception ex) {
				Debug.WriteLine(ex);
				stream.Close();
			}

			tcp.Close();
		}

		public void Render(HtmlTextWriter writer) {
			if (this.Mode == "Hosted") {
				RenderHostedMode(writer);
			}
			else if (this.Mode == "Web") {
				RenderWebMode(writer);
			}
			else {
				throw new ConfigurationErrorsException(string.Format("Invalid DotWeb-Mode: {0}", this.Mode));
			}
		}

		private void RenderHostedMode(HtmlTextWriter writer) {
			HttpCookie cookie = new HttpCookie("X-DotWeb");
			this.context.AddCookie(cookie);
			TcpListener listener = this.context.GetApplicationState(DotWebTcpListenerKey) as TcpListener;
			if (listener == null) {
				listener = new TcpListener(IPAddress.Loopback, 0);
				listener.Start();
				this.context.SetApplicationState(DotWebTcpListenerKey, listener);
				listener.BeginAcceptTcpClient(this.OnAccept, listener);
			}
			IPEndPoint ip = (IPEndPoint)listener.LocalEndpoint;

			//<embed id="__$plugin" type="application/x-dotweb"/>
			writer.AddAttribute(HtmlTextWriterAttribute.Id, "__$plugin");
			writer.AddAttribute(HtmlTextWriterAttribute.Type, DotWebMimeType);
			writer.RenderBeginTag(HtmlTextWriterTag.Embed);
			writer.RenderEndTag();

			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
			writer.RenderBeginTag(HtmlTextWriterTag.Script);
			//				writer.WriteLine("$wnd.__$serverUrl = 'tcp://localhost:{0}';", ip.Port);
			//				writer.WriteLine("$wnd.__$serverType = '{0}';", this.Source);
			writer.WriteLine(Resources.JsHelper);
			string js = string.Format(Resources.HostedEntry, ip.Port, this.Source);

			writer.WriteLine(js);
			writer.RenderEndTag();
		}

		private void RenderWebMode(HtmlTextWriter writer) {
			string src = null;
			if (this.EnableCache) {
				Cache cache = this.context.Cache;
				src = cache.Get(this.Source) as string;
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

		private IHttpContext context;

		const string DotWebTcpListenerKey = "DotWeb.TcpListener";
		const string DotWebMimeType = "application/x-dotweb";
	}
}
