using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace H8.MVC.Controllers
{
	[HandleError]
	public class TestController : Controller
	{
		public ActionResult Sanity() {
			ViewData["Title"] = "Sanity Test";
			return View();
		}
	}
}
