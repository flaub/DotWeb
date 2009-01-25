using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlDom;
using System.Windows.Forms;

namespace Twinkie
{
	class Program
	{
		[STAThread]
		static void Main(string[] args) {
//			Window window = new WindowImpl();
//			window.alert("Hello");
			Application.Run(new BrowserForm());
		}
	}
}
