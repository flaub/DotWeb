using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Twinkie
{
	class Program
	{
		[STAThread]
		static void Main(string[] args) {
			Application.Run(new BrowserForm());
		}
	}
}
