using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using DotWeb.Core;

namespace DotWeb.Hosting.Bridge
{
	public class JsBridge : MarshalByRefObject, IJsBridge, IJsHost
	{
		public IJsAgent Agent { get; private set; }
		private Dictionary<MethodBase, JavaScriptFunction> FunctionCache { get; set; }

		struct JavaScriptFunction
		{
			public string Name { get; set; }
			public string Args { get; set; }
			public string Body { get; set; }
		}

		static JsBridge() {
		}

		public JsBridge(IJsAgent agent) {
			this.FunctionCache = new Dictionary<MethodBase, JavaScriptFunction>();
			this.Agent = agent;
		}

		public void OnLoad(string typeName) {
			try {
				JsHost.Instance = this;

				Type type = Type.GetType(typeName);
				Activator.CreateInstance(type);
			}
			catch (Exception ex) {
				Console.WriteLine(ex);
				throw ex;
			}
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

		public string ExecuteToString(JsNativeBase scope) {
			object hScope = null;
			if (scope != null)
				hScope = scope.Handle;
			return Agent.InvokeToString(hScope);
		}

		public R Execute<R>(MethodBase method, JsNativeBase scope, params object[] args) {
			try {
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
						Delegate del = arg as Delegate;
						if (del != null) {
							JsDelegate adapter = new JsDelegate(del);
							arg = adapter;
						}
						converted[i] = arg;
					}
				}

				object ret = Agent.InvokeFunction(function.Name, hScope, converted);
				if (ret == null)
					return default(R);

				if (method.IsConstructor) {
					scope.Handle = ret;
					return default(R);
				}
				else {
					MethodInfo mi = method as MethodInfo;
					ret = JsTypeConverter.Convert(ret, mi.ReturnType);
				}

				return (R)ret;
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				throw ex;
			}
		}
	}

}
