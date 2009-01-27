using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlDom;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

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
