﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotWeb.Functional.Test.Server
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",
				"{controller}/{action}/{mode}/{test}",
				new { controller = "Test", action = "Harness", test = "Sanity", mode = "Web" }
			);
		}

		protected void Application_Start() {
			RegisterRoutes(RouteTable.Routes);
		}
	}
}