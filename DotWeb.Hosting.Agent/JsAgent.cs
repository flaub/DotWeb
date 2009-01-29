using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using mshtml;
using System.Runtime.InteropServices.Expando;
using DotWeb.Hosting;

namespace DotWeb.Hosting.Agent
{
	public class JsAgent : MarshalByRefObject, IJsAgent
	{
		public static JsAgent Instance { get; private set; }

		private Form ActiveForm { get; set; }
		public HtmlDocument CurrentDocument { get; private set; }

		static JsAgent() {
			Instance = new JsAgent();
		}

		private JsAgent() {
		}

		public void OnNavigating(HtmlDocument doc) {
		}

		public void OnNavigated(HtmlDocument doc) {
			IHTMLWindow2 win2 = (IHTMLWindow2)doc.Window.DomWindow;
			win2.execScript("_$ = window.external;", null);
			win2.execScript("console = {}; console.log = function(args) { _$.Log(args); };", null);
//			win2.execScript("function __cbWrapper(cb) { console.log(cb); return function() { return console.log(cb); _$.Callback(cb, arguments); } };", null);
			win2.execScript("function __createArray() { return []; };", null);
			win2.execScript("function __exec(fun, scope, args) { return window[fun].apply(scope, args); };", null);
		}

		public void OnDocumentComplete(HtmlDocument doc) {
			this.CurrentDocument = doc;
			this.ActiveForm = Form.ActiveForm;
		}

//		public object OnCallback(object target, object args) {
//			object[] converted = JsArray.Convert(args);
//			IJsDelegate del = (IJsDelegate)cb.Target;
//			return del.OnCallback(converted);
//			return null;
//		}

		private delegate void DefineFunctionHandler(string name, string args, string body);
		private delegate object InvokeFunctionHandler(string name, object scope, object[] args);
		private delegate string InvokeToStringHandler(object scope);

		private void DoDefineFunction(string name, string args, string body) {
			try {
				string definition = string.Format("function {0}({1}) {{ {2} }};", name, args, body);
				IHTMLWindow2 win2 = (IHTMLWindow2)CurrentDocument.Window.DomWindow;
				win2.execScript(definition, null);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				throw ex;
			}
		}

		private object DoInvokeFunction(string name, object scope, object[] args) {
			try {
				JsArray jsArray = new JsArray(args);
				object[] execArgs = new object[] { name, scope, jsArray.Handle };
				object ret = CurrentDocument.InvokeScript("__exec", execArgs);
				return ret;
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				throw ex;
			}
		}

		private string DoInvokeToString(object scope) {
			JsObjectWrapper wrapper = new JsObjectWrapper(scope);
			return wrapper.ToString();
		}

		#region IJsAgent Members

		public void DefineFunction(string name, string args, string body) {
			ActiveForm.Invoke(new DefineFunctionHandler(this.DoDefineFunction), name, args, body);
		}

		public object InvokeFunction(string name, object scope, params object[] args) {
			return ActiveForm.Invoke(new InvokeFunctionHandler(this.DoInvokeFunction), name, scope, args);
		}

		public string InvokeToString(object scope) {
			return (string)ActiveForm.Invoke(new InvokeToStringHandler(this.DoInvokeToString), scope);
		}

		#endregion
	}
}
