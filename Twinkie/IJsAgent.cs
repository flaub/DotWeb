using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twinkie
{
	public interface IJsAgent
	{
		void DefineFunction(string name, string args, string body);
		object InvokeFunction(string name, object scope, params object[] args);
	}
}
