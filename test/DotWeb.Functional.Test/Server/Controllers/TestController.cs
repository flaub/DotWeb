using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotWeb.Functional.Test.Server.Controllers
{
	[HandleError]
	public class TestController : Controller
	{
		protected override void Initialize(System.Web.Routing.RequestContext requestContext) {
			base.Initialize(requestContext);

			var path = Server.MapPath("~\\App_Data\\TestDirectory.txt");
			var tests = System.IO.File.ReadAllLines(path);
			ViewData["TestDirectory"] = tests;
		}

		public ActionResult Harness(string mode, string test) {
			ViewData["Title"] = string.Format("{0} - {1} Mode", test, mode);
			ViewData["Mode"] = mode;
			ViewData["TypeName"] = string.Format("DotWeb.Functional.Test.Client.{0}, DotWeb.Functional.Test.Client", test);
			return View();
		}
	}
}
