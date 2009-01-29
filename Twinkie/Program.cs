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

namespace Twinkie
{
	class Program
	{
		[STAThread]
		static void Main(string[] args) {
			BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
			provider.TypeFilterLevel = TypeFilterLevel.Full;
			Hashtable props = new Hashtable();
			props["portName"] = "DotWeb.Client";
			props["exclusiveAddressUse"] = false;
			IpcChannel channel = new IpcChannel(props, null, provider);

			ChannelServices.RegisterChannel(channel, false);

			Application.Run(new BrowserForm());
		}
	}
}
