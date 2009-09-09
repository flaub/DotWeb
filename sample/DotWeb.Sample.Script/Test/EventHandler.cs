using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client;
using DotWeb.Client.Dom;

namespace DotWeb.Sample.Script.Test
{
	public class EventHandler : JsScript
	{
		private Element box;

		public EventHandler() {
			this.box = Window.document.getElementById("box");
			this.box.onmouseover = this.box_OnMouseOver;
			this.box.onmouseout = this.box_OnMouseOut;
		}

		private void box_OnMouseOver() {
			this.box.style.backgroundColor = "red";
		}

		private void box_OnMouseOut() {
			this.box.style.backgroundColor = "black";
		}
	}
}
