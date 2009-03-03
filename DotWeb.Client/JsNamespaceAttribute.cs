using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Client
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
	public class JsNamespaceAttribute : Attribute
	{
		public string Namespace { get; private set; }
		public JsNamespaceAttribute() {
		}

		public JsNamespaceAttribute(string ns) {
			this.Namespace = ns;
		}
	}
}
