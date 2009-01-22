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

namespace H8.Web
{
	[ToolboxData("<{0}:ClientCode runat=server></{0}:ClientCode>")]
	public class ClientCode : Control
	{
		public string Source { get; set; }

		[DefaultValue(true)]
		public bool Minify { get; set; }

		[DefaultValue("~/js/Cache")]
		public string CacheDir { get; set; }

		public ClientCode() {
			this.CacheDir = WebConfigurationManager.AppSettings["JavaScriptCache"];
			if (this.CacheDir == null)
				this.CacheDir = "~/js/Cache";

			Configuration cfg = WebConfigurationManager.OpenWebConfiguration("~");
			ConfigurationSectionGroup grp = cfg.GetSectionGroup("system.web");
			CompilationSection section = grp.Sections.Get("compilation") as CompilationSection;

			if (section.Debug) {
				this.Minify = false;
			}
			else {
				this.Minify = true;
			}
		}

		private string Translate() {
			string srcPath = this.MapPathSecure(this.Source);
			string filename = this.Source
				.Replace('\\', '_')
				.Replace('/', '_')
				.Replace('~', '_');
			filename = Path.GetFileNameWithoutExtension(filename) + ".js";
			string virtualPath = string.Format("{0}/{1}", this.CacheDir, filename);
			string tgtPath = this.MapPathSecure(virtualPath);

			using (StreamWriter writer = new StreamWriter(tgtPath)) {
				Translator translator = new Translator(writer, true);
				translator.TranslateFile(srcPath, Page.GetType().Assembly);
			}

			string src = this.ResolveUrl(virtualPath);

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
			return src;
		}

		protected override void Render(HtmlTextWriter writer) {
			Cache cache = this.Context.Cache;
			string src = cache.Get(this.Source) as string;
			if (src == null)
				src = Translate();

			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
			writer.AddAttribute(HtmlTextWriterAttribute.Src, src);
			writer.RenderBeginTag(HtmlTextWriterTag.Script);
			writer.RenderEndTag();
		}
	}
}
