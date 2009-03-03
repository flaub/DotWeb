using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client.Dom;
using System.Diagnostics;
using System.Reflection;

namespace DotWeb.Client
{
	public class JsScript : JsAccessible
	{
		public Window Window {
			[JsCode("return $wnd;")]
			get { return JsHost.Execute<Window>(MethodInfo.GetCurrentMethod(), null, null); }
		}
	}
}
