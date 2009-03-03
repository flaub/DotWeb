using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace H8.MVC.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Simple() {
			ViewData["Title"] = ".Web Simple Sample";
			return View();
		}

		public ActionResult ExtJs() {
			ViewData["Title"] = ".Web ExtJs Sample";
			return View();
		}
	}
}
