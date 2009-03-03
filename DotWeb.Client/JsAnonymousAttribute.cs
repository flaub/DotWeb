using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Client
{
	[AttributeUsage(AttributeTargets.Class)]
	public class JsAnonymousAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Delegate)]
	public class VarArgsAttribute : Attribute
	{
	}
}
