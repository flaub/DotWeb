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
	class HttpContextImpl : IHttpContext
	{
		private HttpContext context;

		public HttpContextImpl(HttpContext context) {
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

	[ToolboxData("<{0}:ClientCode runat=server></{0}:ClientCode>")]
	public class ClientCode : Control
	{
		public string Source {
			get { return this.renderer.Source; }
			set { this.renderer.Source = value; }
		}

		[DefaultValue(true)]
		public bool Minify {
			get { return this.renderer.Minify; }
			set { this.renderer.Minify = value; }
		}

		[DefaultValue("~/js/Cache")]
		public string CacheDir {
			get { return this.renderer.CacheDir; }
			set { this.renderer.CacheDir = value; }
		}

		[DefaultValue("Web")]
		public string Mode {
			get { return this.renderer.Mode; }
			set { this.renderer.Mode = value; }
		}

		[DefaultValue(true)]
		public bool EnableCache {
			get { return this.renderer.EnableCache; }
			set { this.renderer.EnableCache = value; }
		}

		private ClientCodeRenderer renderer;

		public ClientCode() {
			HttpContextImpl impl = new HttpContextImpl(this.Context);
			this.renderer = new ClientCodeRenderer(impl);
		}

		protected override void Render(HtmlTextWriter writer) {
			this.renderer.Render(writer);
		}
	}
}
