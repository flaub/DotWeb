using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using mshtml;
using System.Runtime.InteropServices.Expando;

namespace Twinkie
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
			win2.execScript("function __cbWrapper(cb) { return function() { return _$.Callback(cb, arguments); } };", null);
			win2.execScript("function __createArray() { return []; };", null);
			win2.execScript("function __exec(fun, scope, args) { return window[fun].apply(scope, args); };", null);
		}

		public void OnDocumentComplete(HtmlDocument doc) {
			this.CurrentDocument = doc;
			this.ActiveForm = Form.ActiveForm;
		}

		public object OnCallback(Delegate cb, object args) {
			object[] converted = JsArray.Convert(args);
			JsDelegateAdapter adapter = (JsDelegateAdapter)cb.Target;
			return adapter.OnCallback(converted);
//			return cb.DynamicInvoke(converted);
		}

		private delegate void DefineFunctionHandler(string name, string args, string body);
		private delegate object InvokeFunctionHandler(string name, object scope, object[] args);

		private void DoDefineFunction(string name, string args, string body) {
			string definition = string.Format("function {0}({1}) {{ {2} }};", name, args, body);
			IHTMLWindow2 win2 = (IHTMLWindow2)CurrentDocument.Window.DomWindow;
			win2.execScript(definition, null);
		}

		private object DoInvokeFunction(string name, object scope, object[] args) {
			JsArray jsArray = new JsArray(args);
			object[] execArgs = new object[] { name, scope, jsArray.Handle };
			object ret = CurrentDocument.InvokeScript("__exec", execArgs);
			return ret;
		}

		#region IJsAgent Members

		public void DefineFunction(string name, string args, string body) {
			ActiveForm.Invoke(new DefineFunctionHandler(this.DoDefineFunction), name, args, body);
		}

		public object InvokeFunction(string name, object scope, params object[] args) {
			return ActiveForm.Invoke(new InvokeFunctionHandler(this.DoInvokeFunction), name, scope, args);
		}

		#endregion
	}
}
