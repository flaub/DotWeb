using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twinkie
{
	public interface IJsBridge
	{
		void OnLoad(IJsAgent agent);
	}
}
