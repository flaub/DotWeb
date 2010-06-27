using System;
using System.Collections.Generic;
using System.Linq;
using DotWeb.Hosting.Bridge;

namespace DotWeb.Debugger
{
	class Program
	{
		static void Main(string[] args) {
			new HostingServer().Start();
		}
	}
}
