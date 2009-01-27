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
			JsBridge.Instance.OnNavigating(this.browser.Document);
		}

		void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
			JsBridge.Instance.OnNavigated(this.browser.Document);
		}

		private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
			this.browser.Document.Window.Load += new HtmlElementEventHandler(Window_Load);
			JsBridge.Instance.OnDocumentComplete(this.browser.Document);
		}

		void Window_Load(object sender, HtmlElementEventArgs e) {
			Thread.Sleep(1000);
			LoadModule();
		}

		private void OnEvent(Tuple tuple, int id) {
			Console.WriteLine("OnEvent: {0}, {1}", tuple, id);
		}

		private void LoadModule() {
			Config config = new Config {
				Id = 666,
				Value = "value"
			};
			Tuple tuple = new Tuple(config);
			int id = tuple.id;
			tuple.id = 9;
			tuple.handler = this.OnEvent;
			Console.WriteLine("before");
			tuple.fireEvent();
			Console.WriteLine(id);

			Tuple.StaticMethod(2, 5);

			Tuple t2 = Tuple.Factory();
			Console.WriteLine(t2.id);
		}
	}
}