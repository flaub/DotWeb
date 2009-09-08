using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client;
using Ext;

namespace DotWeb.Sample.Script.Test
{
	public class EventHandler : JsScript
	{
		public EventHandler() {
			var box = Window.document.getElementById("box");
			box.onmouseover = this.box_OnMouseOver;
		}

		private void box_OnMouseOver() {
			Window.alert("OK");
		}
	}
}
