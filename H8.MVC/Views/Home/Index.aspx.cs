using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H8.MVC.Views.Home
{
	public partial class Index : ViewPage
	{
		protected override void OnLoad(EventArgs e) {
			this.clientCode.Source = typeof(TestScript).AssemblyQualifiedName;
			base.OnLoad(e);
		}
	}
}
