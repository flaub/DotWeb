using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Diagnostics;

namespace Twinkie
{
	class Program
	{
		public static string StartingUrl;

		[STAThread]
		static void Main(string[] args) {
			if (args.Length >= 1)
				StartingUrl = args[0];

			Application.Run(new BrowserForm());
		}
	}
}
