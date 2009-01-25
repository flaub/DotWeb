using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.Support
{
	[AttributeUsage(AttributeTargets.Method)]
	public class JsFunctionAttribute : Attribute
	{
		public JsFunctionAttribute(string code) {
			this.Code = code;
		}

		public string Code { get; set; }
	}

}
