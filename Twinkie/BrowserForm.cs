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
using System.Threading;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;

namespace Twinkie
{
	public partial class BrowserForm : Form
	{
		public BrowserForm() {
			InitializeComponent();
			this.browser.ObjectForScripting = new External();
			this.browser.Navigating += new WebBrowserNavigatingEventHandler(browser_Navigating);
			this.browser.Navigated += new WebBrowserNavigatedEventHandler(this.browser_Navigated);
//			this.browser.Navigate("http://localhost:1037/");
			this.browser.DocumentText = Resources.Test;
		}

		void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
			JsAgent.Instance.OnNavigating(this.browser.Document);
		}

		void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
			JsAgent.Instance.OnNavigated(this.browser.Document);
		}

		private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
			this.browser.Document.Window.Load += new HtmlElementEventHandler(Window_Load);
			JsAgent.Instance.OnDocumentComplete(this.browser.Document);
		}

		public delegate void RemoteOnLoadCall(IJsAgent agent);

		void Window_Load(object sender, HtmlElementEventArgs e) {
			IJsBridge bridge = (IJsBridge)Activator.GetObject(typeof(JsBridge), "ipc://DotWeb.Server/JsBridge");

			RemoteOnLoadCall call = new RemoteOnLoadCall(bridge.OnLoad);
			AsyncCallback callback = new AsyncCallback(this.OnLoadComplete);
			call.BeginInvoke(JsAgent.Instance, callback, bridge);
		}

		[OneWay]
		private void OnLoadComplete(IAsyncResult ar) {
			RemoteOnLoadCall del = (RemoteOnLoadCall)((AsyncResult)ar).AsyncDelegate;
			del.EndInvoke(ar);
		}
	}
}