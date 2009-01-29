using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using DotWeb.Hosting;

namespace DotWeb.Hosting.Bridge
{
	public class JsDelegate : MarshalByRefObject, IJsDelegate
	{
		Delegate target;

		public JsDelegate(Delegate target) {
			this.target = target;
		}

		public object Invoke(object[] args) {
			ParameterInfo[] argInfos = this.target.Method.GetParameters();
			object[] converted = new object[argInfos.Length];
			for (int i = 0; i < argInfos.Length; i++) {
				object arg = args[i];
				converted[i] = JsTypeConverter.Convert(arg, argInfos[i].ParameterType);
			}
			return target.DynamicInvoke(converted);
		}
	}
}
