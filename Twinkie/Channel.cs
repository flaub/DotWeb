using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels;

namespace Twinkie
{
	public class Channel : IChannel
	{
		#region IChannel Members

		public string ChannelName {
			get { throw new NotImplementedException(); }
		}

		public int ChannelPriority {
			get { throw new NotImplementedException(); }
		}

		public string Parse(string url, out string objectURI) {
			throw new NotImplementedException();
		}

		#endregion
	}
}
