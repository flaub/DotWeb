using System;
using System.Runtime.InteropServices.Expando;
using System.Reflection;

namespace Twinkie
{
	public class External
	{
		public void Log(object args) {
			if (args is string) {
				Console.WriteLine(args);
				return;
			}
			IExpando ex = args as IExpando;
			if (ex != null) {
				MethodInfo mi = ex.GetMethod("toString", BindingFlags.Default);
				if (mi != null) {
					object str = mi.Invoke(args, null);
					Console.WriteLine(str);
					return;
				}
			}

			Console.WriteLine(args);
		}

		public object Callback(Delegate cb, object args) {
			return JsAgent.Instance.OnCallback(cb, args);
		}
	}
}
