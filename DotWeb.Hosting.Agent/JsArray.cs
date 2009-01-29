using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices.Expando;
using System.Windows.Forms;

namespace DotWeb.Hosting.Agent
{
	public class JsArray
	{
		private IExpando hArray;

		public object Handle { get { return this.hArray; } }

		public JsArray() {
			hArray = JsAgent.Instance.CurrentDocument.InvokeScript("__createArray") as IExpando;
		}

		public JsArray(object[] args) {
			HtmlDocument document = JsAgent.Instance.CurrentDocument;
			hArray = document.InvokeScript("__createArray") as IExpando;
			if (args != null) {
				foreach (object arg in args) {
					this.push(arg);
				}
			}
		}

		public static object[] Convert(object args) {
			IExpando ex = args as IExpando;
			PropertyInfo piLength = ex.GetProperty("length", BindingFlags.Default);
			int len = (int)piLength.GetValue(args, null);
			object[] converted = new object[len];
			for (int i = 0; i < len; i++) {
				PropertyInfo pi = ex.GetProperty(i.ToString(), BindingFlags.Default);
				object arg = pi.GetValue(args, null);
				converted[i] = arg;
			}
			return converted;
		}

		public void push(object item) {
			HtmlDocument document = JsAgent.Instance.CurrentDocument;
			Type type = item.GetType();
			if (!type.IsPrimitive) {
				IJsDelegate jsDelegate = item as IJsDelegate;
				if (jsDelegate != null) {
					JsDispatchDelegate disp = new JsDispatchDelegate(jsDelegate);
					item = disp.IDispatch;
				}
				else {
					JsDispatchObject disp = new JsDispatchObject(item);
					item = disp.IDispatch;
				}
			}

			MethodInfo method = this.hArray.GetMethod("push", BindingFlags.Default);
			method.Invoke(this.hArray, new object[] { item });
		}

		public object pop() {
			MethodInfo method = this.hArray.GetMethod("pop", BindingFlags.Default);
			return method.Invoke(this.hArray, null);
		}
	}

}
