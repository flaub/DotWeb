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
