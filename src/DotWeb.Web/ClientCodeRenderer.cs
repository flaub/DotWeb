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
using DotWeb.Runtime;
using System.Reflection;
using Mono.Cecil;
using DotWeb.Utility;

namespace DotWeb.Web
{
	public class ClientCodeRenderer
	{
		private const string DotWebMimeType = "application/x-dotweb";
		private const string DotWebHostedMode = "DotWeb.HostedMode";
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
			var aqtn = new AssemblyQualifiedTypeName(Source);
			string filename = aqtn.TypeName
			                  	.Replace('.', '_')
			                  	.Replace('+', '_') + ".js";

			string virtualPath = string.Format("{0}/{1}", CacheDir, filename);
			string tgtPath = context.MapPath(virtualPath);

			using (var writer = new StreamWriter(tgtPath)) {
				var path = context.MapPath("/bin");
				var translator = new TranslationEngine(writer, true, path);

				translator.TranslateType(aqtn);
			}

			string src = context.ResolveUrl(virtualPath);

			//if (EnableCache) {
			//    Cache cache = context.Cache;
			//    var uri = new Uri(srcType.Assembly.CodeBase);
			//    string srcPath = uri.AbsolutePath;
			//    var depends = new CacheDependency(srcPath);
			//    cache.Add(
			//        Source,
			//        src,
			//        depends,
			//        Cache.NoAbsoluteExpiration,
			//        Cache.NoSlidingExpiration,
			//        CacheItemPriority.Normal,
			//        null);
			//}
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
			var hostedMode = context.GetApplicationState(DotWebHostedMode) as HostedMode;
			if (hostedMode == null) {
				var binPath = context.MapPath("/bin");
				hostedMode = new HostedMode(binPath);
				context.SetApplicationState(DotWebHostedMode, hostedMode);
				hostedMode.Start();
			}

			var ip = hostedMode.EndPoint;
			var aqtn = new AssemblyQualifiedTypeName(Source);
			var src = hostedMode.PrepareType(aqtn);

			//<embed id="__$plugin" type="application/x-dotweb"/>
			writer.AddAttribute(HtmlTextWriterAttribute.Id, "__$plugin");
			writer.AddAttribute(HtmlTextWriterAttribute.Type, DotWebMimeType);
			writer.RenderBeginTag(HtmlTextWriterTag.Embed);
			writer.RenderEndTag();

			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
			writer.RenderBeginTag(HtmlTextWriterTag.Script);

			writer.WriteLine(Resources.JsHelper);
			string js = string.Format(Resources.HostedEntry, ip.Port, src);

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

			//string js = string.Format(Resources.WebEntry, typeName);

			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
			writer.AddAttribute(HtmlTextWriterAttribute.Src, src);
			writer.RenderBeginTag(HtmlTextWriterTag.Script);
			writer.RenderEndTag();
		}
	}
}