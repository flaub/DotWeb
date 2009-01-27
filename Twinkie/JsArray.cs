using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices.Expando;

namespace Twinkie
{
	public class JsArray
	{
		private IExpando hArray;

		public object Handle { get { return this.hArray; } }

		public JsArray() {
			hArray = JsBridge.Instance.CurrentDocument.InvokeScript("__createArray") as IExpando;
		}

		public void push(object item) {
			MethodInfo method = this.hArray.GetMethod("push", BindingFlags.Default);
			method.Invoke(this.hArray, new object[] { item });
		}

		public object pop() {
			MethodInfo method = this.hArray.GetMethod("pop", BindingFlags.Default);
			return method.Invoke(this.hArray, null);
		}
	}

}
