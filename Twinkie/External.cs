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
			}
			else {
				IExpando ex = args as IExpando;
				if (ex != null) {
					MethodInfo mi = ex.GetMethod("toString", BindingFlags.Default);
					object str = mi.Invoke(args, null);
					Console.WriteLine(str);
				}
				else {
					Console.WriteLine(args);
				}
			}
		}

		public object Callback(Delegate cb, object args) {
			IExpando ex = args as IExpando;
			ParameterInfo[] parameters = cb.Method.GetParameters();
			if (parameters.Length > 0) {
				object[] converted = new object[parameters.Length];
				for (int index = 0; index < parameters.Length; index++) {
					PropertyInfo pi = ex.GetProperty(index.ToString(), BindingFlags.Default);
					object arg = pi.GetValue(args, null);
					ParameterInfo parameter = parameters[index];
					converted[index] = JsTypeConverter.Convert(arg, parameter.ParameterType);
				}
				return cb.DynamicInvoke(converted);
			}
			return cb.DynamicInvoke(null);
		}
	}
}
