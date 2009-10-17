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
using DotWeb.Client.Dom;
using DotWeb.Client;
using DotWeb.Client.Dom.Events;
using DotWeb.Client.Dom.Html;


namespace DotWeb.Sample.Script
{
	public class ConsoleScript : JsScript
	{
		/*
		#fauxconsole{
			position:absolute;
			top:0;
			right:0;
			width:300px;
			border:1px solid #999;
			font-family:courier,monospace;
			background:#eee;
			font-size:10px;
			padding:10px;
		}
		html>body #fauxconsole{
			position:fixed;
		}
		#fauxconsole a{
			float:right;
			padding-left:1em;
			padding-bottom:.5em;
			text-align:right;
		}
		*/

		private const string ConsoleDivId = "JavaScriptConsole";
		private HtmlDivElement div;
		private Element inner;

		public ConsoleScript() {
			var element = Document.createElement("div");
			this.div = (HtmlDivElement)element;
			this.div.id = ConsoleDivId;

			this.div.style.top = "0";
			this.div.style.right = "0";
			this.div.style.width = "300px";
			this.div.style.minHeight = "10px";
			this.div.style.border = "1px solid #999";
			this.div.style.fontFamily = "courier, monospace";
			this.div.style.background = "#eee";
			this.div.style.fontSize = "10px";
			this.div.style.padding = "10px";

			AddLink(this.OnHide, "close");
			AddLink(this.OnClear, "clear");
			AddLink(this.OnLog, "test");

			this.inner = Document.createElement("div");
			this.div.appendChild(inner);

			var content = Document.getElementById("content");
			content.appendChild(this.div);

			Log("Test1");
			Log("Test2");
		}

		private void AddLink(MouseEventHandler handler, string text) {
			var element = Document.createElement("a");
			var anchor = (HtmlAnchorElement)element;
			anchor.href = "#";
			anchor.onclick = handler;
			var textNode = Document.createTextNode(text);
			anchor.appendChild(textNode);

			anchor.style.cssFloat = "right";
			anchor.style.paddingLeft = "1em";
			anchor.style.paddingBottom = ".5em";
			anchor.style.textAlign = "right";

			this.div.appendChild(anchor);
		}

		private void OnLog(MouseEvent evt) {
			Log(evt.type);
		}

		private void OnHide(MouseEvent evt) {
			Log("OnHide");
			this.div.style.display = "none";
		}

		private void OnClear(MouseEvent evt) {
			Log("OnClear");
			var newInner = this.inner;
			this.inner = Document.createElement("div");
			this.div.replaceChild(this.inner, newInner);
		}

		private Text Text(string text) {
			return Document.createTextNode(text);
		}

		public void Log(string value) {
			var br = Document.createElement("br");
			this.inner.appendChild(br);
			this.inner.appendChild(Text(value));
		}
	}
}
