using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using mshtml;
using System.Windows.Forms;
using System.Runtime.InteropServices.Expando;

namespace Twinkie
{
	public class JsBridge
	{
		public static JsBridge Instance { get; private set; }

		private Dictionary<MethodBase, JavaScriptFunction> FunctionCache { get; set; }
		public HtmlDocument CurrentDocument { get; private set; }

		struct JavaScriptFunction
		{
			public string Name { get; set; }
			public string Body { get; set; }
			public string Definition { get; set; }
		}

		static JsBridge() {
			Instance = new JsBridge();
		}

		private JsBridge() {
			this.FunctionCache = new Dictionary<MethodBase, JavaScriptFunction>();
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
		}

		private string GetTarget(MethodBase method) {
			if (method.IsStatic) {
				return method.DeclaringType.FullName;
			}
			else {
				return "this";
			}
		}

		private string GetArgsString(MethodBase method) {
			ParameterInfo[] parameters = method.GetParameters();
			string[] argNames = parameters.Select(x => x.Name).ToArray();
			string args = string.Join(", ", argNames);
			return args;
		}

		private string CallGetter(MethodBase method) {
			ParameterInfo[] args = method.GetParameters();
			if (args.Length == 0) {
				string propName = method.Name.Substring("get_".Length);
				string target = GetTarget(method);
				return string.Format("return {0}.{1};", target, propName);
			}
			else {
				throw new NotSupportedException();
			}
		}

		private string CallSetter(MethodBase method) {
			ParameterInfo[] args = method.GetParameters();
			if (args.Length == 1) {
				string propName = method.Name.Substring("set_".Length);
				string target = GetTarget(method);
				return string.Format("{0}.{1} = value;", target, propName);
			}
			else {
				throw new NotSupportedException();
			}
		}

		private string CallConstructor(MethodBase method) {
			string target = method.DeclaringType.FullName;
			string args = GetArgsString(method);
			return string.Format("return new {0}({1});", target, args);
		}

		private string CallMethod(MethodBase method) {
			string name = method.Name;
			string target = GetTarget(method);
			string args = GetArgsString(method);
			return string.Format("return {0}.{1}({2});", target, name, args);
		}

		private string GenerateFunctionBody(MethodBase method) {
			if (method.IsSpecialName) {
				if (method.Name.StartsWith("get_")) {
					return CallGetter(method);
				}
				else if (method.Name.StartsWith("set_")) {
					return CallSetter(method);
				}
			}

			if (method is ConstructorInfo) {
				return CallConstructor(method);
			}
			else {
				return CallMethod(method);
			}
		}

		private JavaScriptFunction DefineFunction(MethodBase method, object scope) {
			JavaScriptAttribute js = Attribute.GetCustomAttribute(method, typeof(JavaScriptAttribute))
				as JavaScriptAttribute;
			if (js == null) {
				string code = GenerateFunctionBody(method);
				js = new JavaScriptAttribute(code);
			}

			string type = method.DeclaringType.FullName.Replace(".", "_").Replace("+", "$");
			string name = string.Format("__{0}${1}", type, method.Name.Replace(".", "$"));
			string args = GetArgsString(method);
			string definition = string.Format("function {0}({1}) {{ {2} }};", name, args, js.Code);

			JavaScriptFunction ret = new JavaScriptFunction {
				Name = name,
				Body = js.Code,
				Definition = definition
			};
			return ret;
		}

		public object ExecuteNative(MethodBase method, JsNativeBase scope, params object[] args) {
			JavaScriptFunction function;
			if (!this.FunctionCache.TryGetValue(method, out function)) {
				function = DefineFunction(method, scope);
				IHTMLWindow2 win2 = (IHTMLWindow2)CurrentDocument.Window.DomWindow;
				win2.execScript(function.Definition, null);
				this.FunctionCache.Add(method, function);
			}

			JsArray jsArray = new JsArray(args);

			object[] execArgs = new object[] {
			    function.Name,
			    scope == null ? null : scope.Handle, 
			    jsArray.Handle
			};

			object ret = CurrentDocument.InvokeScript("__exec", execArgs);
			if (ret == null)
				return null;

			if (method.IsConstructor) {
				scope.Handle = ret;
			}
			else {
				MethodInfo mi = method as MethodInfo;
				return JsTypeConverter.Convert(ret, mi.ReturnType);
			}

			return ret;
		}
	}

}
