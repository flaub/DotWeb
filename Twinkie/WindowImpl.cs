using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlDom;

namespace Twinkie
{
	public class Window : JsNativeBase, IWindow
	{
		public Document document {
			get { return (Document)_(); }
		}

		public void alert(string message) { _(message); }
		public void blur() { _(); }
		public void clearInterval(int id) { _(id); }
		public void clearTimeout(int id) { _(id); }
		public void close() { _(); }
		public bool confirm(string message) { return (bool)_(message); }
		public void createPopup() { _(); }
		public void focus() { _(); }
		public void moveBy(int x, int y) { _(x, y); }
		public void moveTo(int x, int y) { _(x, y); }
		public IWindow open(string url, string name, string features, bool replace) { return (IWindow)_(url, name, features, replace); }
		public void print() { _(); }
		public string prompt(string message) { return (string)_(message); }
		public string prompt(string message, object value) { return (string)_(message, value); }
		public void resizeBy(int x, int y) { _(x, y); }
		public void resizeTo(int x, int y) { _(x, y); }
		public void scrollBy(int x, int y) { _(x, y); }
		public void scrollTo(int x, int y) { _(x, y); }
		public int setInterval(string expression, int msec) { return (int)_(expression, msec); }
		public int setTimeout(string expression, int msec) { return (int)_(expression, msec); }
	}
}
