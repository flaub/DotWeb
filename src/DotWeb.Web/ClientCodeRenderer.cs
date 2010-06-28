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
using DotWeb.Translator;
using DotWeb.Web.Properties;
using System.Runtime.Remoting.Messaging;
using System.Reflection;
using Mono.Cecil;
using DotWeb.Utility;
using System.Collections.Generic;
using DotWeb.Hosting.Bridge;

namespace DotWeb.Web
{
	public class ClientCodeRenderer
	{
		private const string DotWebMimeType = "application/x-dotweb";
		private readonly IHttpContext context;
		private readonly bool isDebug;

		private string mode;

		#region Properties

		public string Source { get; set; }

		public bool Minify { get; set; }

		public string CacheDir { get; set; }

		public string Mode { 
			get { return this.mode; }
			set { this.mode = string.IsNullOrEmpty(value) ? "Web" : value; }
		}

		public bool EnableCache { get; set; }

		#endregion

		public ClientCodeRenderer(IHttpContext context) {
			this.context = context;

			CacheDir = WebConfigurationManager.AppSettings["JavaScriptCache"] ?? "~/js/Cache";
			Mode = WebConfigurationManager.AppSettings["DotWeb-Mode"];

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
			var aqtn = new AssemblyQualifiedTypeName(Source);
			string filename = aqtn.TypeName
				.Replace('.', '_')
				.Replace('+', '_') + ".js";

			string cachePath = context.MapPath(CacheDir);
			if (!Directory.Exists(cachePath)) {
				Directory.CreateDirectory(cachePath);
			}

			string virtualPath = string.Format("{0}/{1}", CacheDir, filename);
			string tgtPath = context.MapPath(virtualPath);

			string[] dependencies;
			using (var writer = new StreamWriter(tgtPath)) {
				var path = context.MapPath("/bin");
				var translator = new TranslationEngine(writer, true, path);

				dependencies = translator.TranslateType(aqtn);
			}

			string src = context.ResolveUrl(virtualPath);

			if (EnableCache) {
				context.Cache.Add(
					Source,
					src,
					new CacheDependency(dependencies),
					Cache.NoAbsoluteExpiration,
					Cache.NoSlidingExpiration,
					CacheItemPriority.Normal,
					null);
			}
			return src;
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
			//<embed id="__$plugin" type="application/x-dotweb"/>
			writer.AddAttribute(HtmlTextWriterAttribute.Id, "__$plugin");
			writer.AddAttribute(HtmlTextWriterAttribute.Type, DotWebMimeType);
			writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "0");
			writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "0");
			writer.RenderBeginTag(HtmlTextWriterTag.Embed);
			writer.RenderEndTag();

			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
			writer.RenderBeginTag(HtmlTextWriterTag.Script);

			var server = new HostingServer();
			server.AsyncStart();

			writer.WriteLine(Resources.JsHelper);
			var url = context.RequestUrl;
			var binPath = context.MapPath("/bin").Replace("\\", "\\\\");
			var typeSpec = HttpUtility.HtmlEncode(string.Format("{0}, {1}", Source, binPath));
			string js = string.Format(Resources.HostedEntry, url.Host, server.EndPoint.Port, typeSpec);

			writer.WriteLine(js);
			writer.RenderEndTag();
		}

		private void RenderWebMode(HtmlTextWriter writer) {
			string src = null;
			if (EnableCache) {
				src = context.Cache.Get(Source) as string;
			}
			if (src == null) {
				src = Translate();
			}

			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
			writer.AddAttribute(HtmlTextWriterAttribute.Src, src);
			writer.RenderBeginTag(HtmlTextWriterTag.Script);
			writer.RenderEndTag();
		}
	}
}