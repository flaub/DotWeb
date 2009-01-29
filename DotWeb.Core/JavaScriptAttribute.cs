﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Core
{
	public class JavaScriptAttribute : Attribute
	{
		public string Code { get; private set; }
		public JavaScriptAttribute(string code) {
			this.Code = code;
		}
	}
}