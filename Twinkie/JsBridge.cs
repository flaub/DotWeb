using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using mshtml;
using System.Windows.Forms;
using System.Runtime.InteropServices.Expando;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Twinkie
{
	public class JsBridge : MarshalByRefObject, IJsBridge
	{
		public IJsAgent Agent { get; set; }
		private Dictionary<MethodBase, JavaScriptFunction> FunctionCache { get; set; }

		struct JavaScriptFunction
		{
			public string Name { get; set; }
			public string Args { get; set; }
			public string Body { get; set; }
		}

		static JsBridge() {
		}

		public JsBridge() {
			this.FunctionCache = new Dictionary<MethodBase, JavaScriptFunction>();
		}

		public static JsBridge Instance {
			get {
				return (JsBridge)CallContext.GetData("JsBridge");
			}
			set {
				CallContext.SetData("JsBridge", value);
			}
		}

		private void OnEvent(Tuple tuple, int id) {
			Console.WriteLine("OnEvent: {0}, {1}", tuple, id);
		}

		public void OnLoad(IJsAgent agent) {
			this.Agent = agent;
			Instance = this;

			Config config = new Config {
				Id = 666,
				Value = "value"
			};
			Tuple tuple = new Tuple(config);
			int id = tuple.id;
			tuple.id = 9;
			tuple.handler = this.OnEvent;
			Console.WriteLine("before");
			tuple.fireEvent();
			Console.WriteLine(id);

			Tuple.StaticMethod(2, 5);

			Tuple t2 = Tuple.Factory();
			Console.WriteLine(t2.id);
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

			JavaScriptFunction ret = new JavaScriptFunction {
				Name = name,
				Args = args,
				Body = js.Code
			};
			return ret;
		}

		public object ExecuteNative(MethodBase method, JsNativeBase scope, params object[] args) {
			JavaScriptFunction function;
			if (!this.FunctionCache.TryGetValue(method, out function)) {
				function = DefineFunction(method, scope);
				Agent.DefineFunction(function.Name, function.Args, function.Body);
				this.FunctionCache.Add(method, function);
			}

			object hScope = null;
			if (scope != null)
				hScope = scope.Handle;

			object[] converted = null;
			if (args.Any()) {
				converted = new object[args.Length];
				for (int i = 0; i < args.Length; i++) {
					object arg = args[i];
					if (arg is Delegate) {
						Delegate del = arg as Delegate;
						JsDelegateAdapter adapter = new JsDelegateAdapter(del);
						arg = adapter.GetWrappedDelegate();
					}
					converted[i] = arg;
				}
			}

			object ret = Agent.InvokeFunction(function.Name, hScope, converted);
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
