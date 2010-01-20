using System;
using DotWeb.Client;
using DotWeb.Client.Dom.Html;
using DotWeb.Client.Dom.Helper;

namespace DotWeb.Functional.Test.Client
{
	class Log : JsScript
	{
		private static Log log;
		private HtmlDivElement div;
		private HtmlElement container;
		private HtmlElement list;

		public Log(HtmlElement container) {
			this.container = container;
			var html = "<div class='log-main'><ol></ol></div>";
			this.div = ElementFactory.CreateDiv();
			this.div.id = "log-top";
			this.div.innerHTML = html;

			this.container.appendChild(this.div);
			this.list = (HtmlOListElement)this.div.getElementsByTagName("ol")[0];
		}

		public void Clear() {
			this.list.innerHTML = "";
		}

		public void AddMessage(string content) {
			var item = ElementFactory.CreateListItem();
			item.innerHTML = content;
			this.list.appendChild(item);
			this.ScrollToBottom();
		}

		public void ScrollToBottom() {
			this.list.scrollTop = this.list.scrollHeight;
		}

		public void Show() {
			this.div.style.display = "block";
		}

		public void Hide() {
			this.div.style.display = "none";
		}

		private static Log Instance {
			get {
				if (log == null) {
					var sandbox = Document.getElementById("sandbox");
					log = new Log(sandbox);
				}
				return log;
			}
		}

		public static void Write(string msg) {
			Instance.AddMessage(msg);
		}

		public static void Write(object obj) {
			Instance.AddMessage((string)obj);
		}
	}
}
