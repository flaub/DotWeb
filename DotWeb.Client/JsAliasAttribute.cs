using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Client
{
	public class JsAliasAttribute : Attribute
	{
		public string Alias { get; private set; }
		public JsAliasAttribute(string alias) {
			this.Alias = alias;
		}
	}
}
