using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting;
using DotWeb.Hosting.Bridge;
using System.Runtime.Serialization.Formatters;
using System.Collections;

namespace H8.MVC
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",                                              // Route name
				"{controller}/{action}/{id}",                           // URL with parameters
				new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			);
		}

		protected void Application_Start() {
			RegisterRoutes(RouteTable.Routes);

			BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
			provider.TypeFilterLevel = TypeFilterLevel.Full;
			Hashtable props = new Hashtable();
			props["portName"] = "DotWeb.Server";
			props["exclusiveAddressUse"] = false;
			IpcChannel channel = new IpcChannel(props, null, provider);

			ChannelServices.RegisterChannel(channel, false);
			RemotingConfiguration.RegisterWellKnownServiceType(
				typeof(JsBridgeFactory), 
				"JsBridgeFactory", 
				WellKnownObjectMode.SingleCall);
		}
	}
}