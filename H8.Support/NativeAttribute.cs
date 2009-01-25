using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.Support
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class NativeAttribute : Attribute
	{
	}
}
