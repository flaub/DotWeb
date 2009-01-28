using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Twinkie
{
	public class JsDelegateAdapter : MarshalByRefObject
	{
		Delegate target;

		public JsDelegateAdapter(Delegate target) {
			this.target = target;
		}

		public delegate object GenericHandler(object[] args);

		public object OnCallback(object[] args) {
			ParameterInfo[] argInfos = this.target.Method.GetParameters();
			object[] converted = new object[argInfos.Length];
			for (int i = 0; i < argInfos.Length; i++) {
				object arg = args[i];
				converted[i] = JsTypeConverter.Convert(arg, argInfos[i].ParameterType);
			}
			return target.DynamicInvoke(converted);
		}

		public object GetWrappedDelegate() {
			return new GenericHandler(this.OnCallback);
		}
	}
}
