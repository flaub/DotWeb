// Copyright 2009, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 
using System.Web.Mvc;
using System.Web;

namespace DotWeb.Sample.MVC.Controllers
{
	[HandleError]
	public class HomeController : BaseController
	{
		public ActionResult Simple() {
			ViewData["Title"] = "DotWeb Simple Sample";
			return View();
		}

		public ActionResult Console() {
			ViewData["Title"] = "DotWeb Console";
			return View();
		}

		public ActionResult ExtJs() {
			ViewData["Title"] = "DotWeb ExtJs Sample";
			return View();
		}

		public ActionResult Tests() {
			ViewData["Title"] = "DotWeb Tests";
			return View();
		}

		public ActionResult Mode() {
			ViewData["Title"] = "Change Mode";
			var mode = Request.Cookies["DotWeb-Mode"];
			mode.Value = (mode.Value == "Web") ? "Hosted" : "Web";
			Response.Cookies.Set(mode);
			return Redirect(Request.UrlReferrer.ToString());
		}

		public ActionResult WebMode() {
			var mode = new HttpCookie("DotWeb-Mode", "Web");
			Response.Cookies.Set(mode);
			return RedirectToAction("Mode");
		}

		public ActionResult HostedMode() {
			var mode = new HttpCookie("DotWeb-Mode", "Hosted");
			Response.Cookies.Set(mode);
			return RedirectToAction("Mode");
		}
	}
}