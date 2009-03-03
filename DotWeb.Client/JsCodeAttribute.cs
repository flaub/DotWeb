using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Client
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
	public class JsCodeAttribute : Attribute
	{
		public string Code { get; private set; }
		public JsCodeAttribute(string code) {
			this.Code = code;
		}
	}
}
