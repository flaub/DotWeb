using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.IO;
using System.Web.UI;
using System.Web;
using DotWeb.Web;

namespace System.Web.Mvc
{
	class HttpContextImpl : IHttpContext
	{
		private HttpContextBase context;

		public HttpContextImpl(HttpContextBase context) {
			this.context = context;
		}

		public string MapPath(string virtualPath) {
			return context.Server.MapPath(virtualPath);
		}

		public string ResolveUrl(string url) {
			return url.Replace("~", context.Request.ApplicationPath);
		}

		public System.Web.Caching.Cache Cache {
			get { return context.Cache; }
		}

		public void AddCookie(HttpCookie cookie) {
			context.Response.Cookies.Add(cookie);
		}

		public object GetApplicationState(string key) {
			return context.Application.Get(key);
		}

		public void SetApplicationState(string key, object value) {
			context.Application.Set(key, value);
		}
	}

	public static class ClientCodeHelper
	{
		public static string ClientCode(this HtmlHelper html, string typeName) {
			StringWriter sw = new StringWriter();
			using (HtmlTextWriter writer = new HtmlTextWriter(sw)) {
				HttpContextImpl impl = new HttpContextImpl(html.ViewContext.HttpContext);
				ClientCodeRenderer renderer = new ClientCodeRenderer(impl);
				renderer.Source = typeName;
				renderer.Render(writer);
			}
			return sw.ToString();
		}
	}
}
