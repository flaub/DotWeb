
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Hosting;

namespace DotWeb.Hosting.Bridge
{
	public class JsBridgeFactory : MarshalByRefObject, IJsBridgeFactory
	{
		public IJsBridge CreateBridge(IJsAgent agent) {
			return new JsBridge(agent);
		}
	}
}
