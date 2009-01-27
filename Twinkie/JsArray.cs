using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices.Expando;
using System.Windows.Forms;

namespace Twinkie
{
	public class JsArray
	{
		private IExpando hArray;

		public object Handle { get { return this.hArray; } }

		public JsArray() {
			hArray = JsBridge.Instance.CurrentDocument.InvokeScript("__createArray") as IExpando;
		}

		public JsArray(object[] args) {
			HtmlDocument document = JsBridge.Instance.CurrentDocument;
			hArray = document.InvokeScript("__createArray") as IExpando;
			foreach (object arg in args) {
				if (arg is Delegate) {
					object wrapped = document.InvokeScript("__cbWrapper", new object[] { arg });
					this.push(wrapped);
				}
				else {
					this.push(arg);
				}
			}
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
