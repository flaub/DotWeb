using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Core
{
	public interface IJsHost
	{
		R Execute<R>(MethodBase method, JsNativeBase scope, params object[] args);
	}
}
