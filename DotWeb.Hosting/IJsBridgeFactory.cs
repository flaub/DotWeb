using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Hosting
{
	public interface IJsBridgeFactory
	{
		IJsBridge CreateBridge(IJsAgent agent);
	}
}
