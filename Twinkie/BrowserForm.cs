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
			this.browser.Navigated += new WebBrowserNavigatedEventHandler(this.browser_Navigated);
//			this.browser.Navigate("http://localhost:1037/");
			this.browser.DocumentText = Resources.Test;
		}

		void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
			JsBridge.Instance.OnNavigated(this.browser.Document);
		}

		private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
			JsBridge.Instance.OnDocumentComplete(this.browser.Document);
			LoadModule();
		}

		private void OnEvent(int id) {
			Console.WriteLine("OnEvent: {0}", id);
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
			tuple.fireEvent();
			Console.WriteLine(id);

			Tuple.StaticMethod(2, 5);
		}
	}
}