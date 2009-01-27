using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.Expando;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Reflection.Emit;
using System.Diagnostics;
using System.Windows.Forms;
using mshtml;

namespace Twinkie
{
	public class External
	{
		public External() {
		}

		public void Log(object args) {
			if (args is string) {
				Console.WriteLine(args);
			}
			else {
				IExpando ex = args as IExpando;
				if (ex != null) {
					MethodInfo mi = ex.GetMethod("toString", BindingFlags.Default);
					object str = mi.Invoke(args, null);
					Console.WriteLine(str);
				}
				else {
					IDispatch disp = args as IDispatch;
					if (disp != null) {
						Console.WriteLine(disp.ToString());
					}
					Console.WriteLine(args);
				}
			}
		}

		public object DoCallback(Delegate cb, object args) {
			IExpando ex = args as IExpando;
			PropertyInfo pi = ex.GetProperty("length", BindingFlags.Default);
			int len = (int)pi.GetValue(args, null);
			if (len > 0) {
				object[] converted = new object[len];
				for (int index = 0; index < len; index++) {
					PropertyInfo piElement = ex.GetProperty(index.ToString(), BindingFlags.Default);
					converted[index] = piElement.GetValue(args, null);
				}
				return cb.DynamicInvoke(converted);
			}
			return cb.DynamicInvoke(null);
		}
	}
}
