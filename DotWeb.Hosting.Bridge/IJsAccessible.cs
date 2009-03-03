using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Hosting.Bridge
{
	public interface IJsAccessible
	{
		object Invoke(int id, DispatchType dispType, JsValue[] args);
		GetTypeResponseMessage GetTypeInfo();
	}
}
