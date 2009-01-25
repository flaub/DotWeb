using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlDom;

namespace Twinkie
{
	public class WindowImpl : IWindow
	{
		#region Window Members

		public Document document {
			get { throw new NotImplementedException(); }
		}

		public void alert(string message) {
			throw new NotImplementedException();
		}

		public void blur() {
			throw new NotImplementedException();
		}

		public void clearInterval(int id) {
			throw new NotImplementedException();
		}

		public void clearTimeout(int id) {
			throw new NotImplementedException();
		}

		public void close() {
			throw new NotImplementedException();
		}

		public bool confirm(string message) {
			throw new NotImplementedException();
		}

		public void createPopup() {
			throw new NotImplementedException();
		}

		public void focus() {
			throw new NotImplementedException();
		}

		public void moveBy(int x, int y) {
			throw new NotImplementedException();
		}

		public void moveTo(int x, int y) {
			throw new NotImplementedException();
		}

		public IWindow open(string url, string name, string features, bool replace) {
			throw new NotImplementedException();
		}

		public void print() {
			throw new NotImplementedException();
		}

		public string prompt(string message) {
			throw new NotImplementedException();
		}

		public string prompt(string message, object value) {
			throw new NotImplementedException();
		}

		public void resizeBy(int x, int y) {
			throw new NotImplementedException();
		}

		public void resizeTo(int x, int y) {
			throw new NotImplementedException();
		}

		public void scrollBy(int x, int y) {
			throw new NotImplementedException();
		}

		public void scrollTo(int x, int y) {
			throw new NotImplementedException();
		}

		public int setInterval(string expression, int msec) {
			throw new NotImplementedException();
		}

		public int setTimeout(string expression, int msec) {
			throw new NotImplementedException();
		}

		#endregion
	}
}
