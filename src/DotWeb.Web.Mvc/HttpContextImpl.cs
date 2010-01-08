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

using DotWeb.Web;

namespace System.Web.Mvc
{
	class HttpContextImpl : IHttpContext
	{
		private readonly HttpContextBase context;

		public HttpContextImpl(HttpContextBase context) {
			this.context = context;
		}

		public string MapPath(string virtualPath) {
			return context.Server.MapPath(virtualPath);
		}

		public string ResolveUrl(string url) {
			var root = context.Request.ApplicationPath;
			if (root.EndsWith("/")) {
				root = root.Substring(0, root.Length - 1);
			}
			return url.Replace("~", root);
		}

		public System.Web.Caching.Cache Cache {
			get { return context.Cache; }
		}

		public object GetApplicationState(string key) {
			return context.Application.Get(key);
		}

		public void SetApplicationState(string key, object value) {
			context.Application.Set(key, value);
		}

		public IHttpModule GetModule(string key) {
			return this.context.ApplicationInstance.Modules.Get(key);
		}
	}
}