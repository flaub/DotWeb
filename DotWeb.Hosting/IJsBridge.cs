using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Hosting
{
	public interface IJsBridge
	{
		void OnLoad(string typeName);
	}

	public interface IJsDelegate
	{
		object Invoke(object[] args);
	}
}
