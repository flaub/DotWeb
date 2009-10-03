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

using System.Web;

namespace DotWeb.Web
{
	class HttpContextImpl : IHttpContext
	{
		private readonly HttpContext context;

		public HttpContextImpl(HttpContext context) {
			this.context = context;
		}

		public string MapPath(string virtualPath) {
			return context.Server.MapPath(virtualPath);
		}

		public string ResolveUrl(string url) {
			return url.Replace("~/", context.Request.ApplicationPath);
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
	}
}