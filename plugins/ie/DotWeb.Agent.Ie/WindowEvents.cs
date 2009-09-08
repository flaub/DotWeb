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
using System.Linq;
using System.Text;
using mshtml;

namespace DotWeb.Agent.Ie
{
	class WindowEvents : HTMLWindowEvents2
	{
		private JsAgent agent;
		public WindowEvents(JsAgent agent) {
			this.agent = agent;
		}

		#region HTMLWindowEvents2 Members

		public void onafterprint(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onafterprint", pEvtObj);
		}

		public void onbeforeprint(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onbeforeprint", pEvtObj);
		}

		public void onbeforeunload(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onbeforeunload", pEvtObj);
		}

		public void onblur(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onblur", pEvtObj);
		}

		public void onerror(string description, string url, int line) {
		}

		public void onfocus(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onfocus", pEvtObj);
		}

		public bool onhelp(IHTMLEventObj pEvtObj) {
			return false;
		}

		public void onload(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onload", pEvtObj);
		}

		public void onresize(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onresize", pEvtObj);
		}

		public void onscroll(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onscroll", pEvtObj);
		}

		public void onunload(IHTMLEventObj pEvtObj) {
			this.agent.OnEvent("onunload", pEvtObj);
		}

		#endregion
	}
}
