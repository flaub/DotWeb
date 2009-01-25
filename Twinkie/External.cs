using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.Expando;
using System.Reflection;

namespace Twinkie
{
	public class External
	{
		public External() {
			Example ex = new Example();
			this.Map = new Dictionary<string, object>();
			this.Map.Add("Example", ex);
			this.Map.Add("Callback", new Example.Handler(ex.Execute));
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

		public object get(string name) {
			return this.Map[name];
		}

		public object DoCallback(IDispatch disp) {
			//			Delegate function = (Delegate)cb;
			//			return function.DynamicInvoke(null);
			//Guid riid = new Guid();
			//System.Runtime.InteropServices.ComTypes.DISPPARAMS dp = new System.Runtime.InteropServices.ComTypes.DISPPARAMS();
			//			System.Runtime.InteropServices.ComTypes.EXCEPINFO ei = new System.Runtime.InteropServices.ComTypes.EXCEPINFO();
			//return disp.Invoke(0, ref riid, 0, 0, dp, null, null, null);
			return null;
		}

		public bool OnClick(object args) {
			IExpando ex = args as IExpando;
			MethodInfo mi = ex.GetMethod("toString", BindingFlags.Default);
			PropertyInfo pi = ex.GetProperty("callee", BindingFlags.Default);
			object val = pi.GetValue(args, null);
			object str = mi.Invoke(args, null);
			return true;
		}

		public Dictionary<string, object> Map { get; private set; }
	}

	public class Example
	{
		public delegate void Handler();

		public string Value { get; set; }
		public void Execute() {
			Console.WriteLine("Execute");
		}

		public void OnClick(object from, EventArgs e) {
		}
	}

}
