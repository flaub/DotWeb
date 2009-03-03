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
