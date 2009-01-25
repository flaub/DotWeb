using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;
using Twinkie.Properties;

namespace Twinkie
{
	public partial class BrowserForm : Form
	{
		public BrowserForm() {
			InitializeComponent();
			this.browser.ObjectForScripting = new External();
			this.browser.Navigated += new WebBrowserNavigatedEventHandler(browser_Navigated);
			this.browser.Navigate("http://localhost:1037/");
		}

		void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
			Console.WriteLine(e.Url);
			IHTMLWindow2 win2 = (IHTMLWindow2)this.browser.Document.Window.DomWindow;
			win2.execScript("_$ = window.external;", null);
			win2.execScript("function __cbWrapper(cb) { return function() { _$.DoCallback(cb); } };", null);
			win2.execScript("console = {}; console.log = function(args) { _$.Log(args); };", null);
		}

		private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
			IHTMLWindow2 win2 = (IHTMLWindow2)this.browser.Document.Window.DomWindow;

			//			this.browser.Document.AttachEventHandler("onclick", new EventHandler(new Example().OnClick));
			//			win2.document.onclick = new EventHandler(new Example().OnClick);
			//			win2.execScript("function __defineStatic(__arg0) { window.__static = __arg0; };", null);
			win2.execScript("function test() { return 1; };", null);
			win2.execScript("function test2() { _$.get('Example').Execute(); };", null);
			//			win2.execScript("document.onclick = function() { return window.external.OnClick(arguments); };", null);
			win2.execScript("function test3(cb) { console.log(cb); cb(); };", null);
			win2.execScript("function test4() { var cb = _$.get('Callback'); console.log(cb); _$.DoCallback(cb); };", null);

			//			object staticDispatcher = null;
			//			this.browser.Document.InvokeScript("__defineStatic", new object[] { staticDispatcher })
		}
	}
}