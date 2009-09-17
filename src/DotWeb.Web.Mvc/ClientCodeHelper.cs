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

using System.IO;
using System.Web.UI;
using DotWeb.Web;

namespace System.Web.Mvc
{
	/// <summary>
	/// HtmlHelper extensions to easily emit Javascript code translated from .NET MSIL.
	/// </summary>
	public static class ClientCodeHelper
	{
		/// <summary>
		/// HtmlHelper extension to easily emit Javascript code translated from .NET MSIL.
		/// </summary>
		/// <param name="html"></param>
		/// <param name="typeName"></param>
		/// <returns></returns>
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
