// Copyright 2009, Frank Laub
//
// This file is part of DotWeb.
//
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Expando;
using System.Reflection;
using System.Diagnostics;

namespace DotWeb.Agent.Ie
{
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class JsConsole
	{
		private bool isDebug;

		public JsConsole(object window, bool isDebug) {
			this.isDebug = isDebug;
			IExpando exWindow = window as IExpando;
			string propName = isDebug ? "debug" : "console";
			PropertyInfo pi = exWindow.AddProperty(propName);
			pi.SetValue(exWindow, this, null);
		}

		private string GetArray(IReflect reflect) {
			PropertyInfo piLength = reflect.GetProperty("length", BindingFlags.Default);
			int len = (int)piLength.GetValue(reflect, null);
			string[] ret = new string[len];
			for (int i = 0; i < len; i++) {
				PropertyInfo pi = reflect.GetProperty(i.ToString(), BindingFlags.Default);
				object item;
				if (pi == null) {
					item = null;
				}
				else {
					item = pi.GetValue(reflect, null);
				}
				ret[i] = GetString(item);
			}
			return string.Format("[ {0} ]", string.Join(", ", ret));
		}

		private string GetString(object value) {
			if (value == null) {
				return "<null>";
			}

			if (value is string) {
				return string.Format("'{0}'", value);
			}

			IReflect reflect = value as IReflect;
			if (reflect != null) {
				PropertyInfo piLength = reflect.GetProperty("length", BindingFlags.Default);
				if (piLength != null) {
					return GetArray(reflect);
				}
				else {
					MethodInfo miToString = reflect.GetMethod("toString", BindingFlags.Default);
					if (miToString != null) {
						string str = miToString.Invoke(reflect, null) as string;
						if (str == null)
							return value.ToString();
						else
							return str;
					}
				}
			}
			return value.ToString();
		}

		public void log(object value) {
			string str = GetString(value);
			if (this.isDebug)
				Debug.WriteLine(str);
			else
				Console.WriteLine(str);
		}
	}
}
