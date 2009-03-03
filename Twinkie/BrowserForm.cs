using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Twinkie
{
	public partial class BrowserForm : Form
	{
		public BrowserForm() {
			InitializeComponent();
			if (Program.StartingUrl != null)
				this.browser.Navigate(Program.StartingUrl);
			else
				this.browser.Navigate("http://www.google.com");
		}
	}
}