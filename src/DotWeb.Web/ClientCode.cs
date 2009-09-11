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

using System.ComponentModel;
using System.Web.UI;

namespace DotWeb.Web
{
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
