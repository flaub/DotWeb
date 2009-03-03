using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using mshtml;

namespace DotWeb.Agent.Ie
{
	class JsHelper
	{
		private object target;
		private JsAgent agent;
		private Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();

		public JsHelper(object target, JsAgent agent) {
			this.target = target;
			this.agent = agent;

			IReflect reflect = target as IReflect;
			foreach (MethodInfo method in reflect.GetMethods(BindingFlags.Default)) {
				methods[method.Name] = method;
			}
		}

		public void DefineFunction(string name, string args, string body) {
			this.methods["defineFunction"].Invoke(this.target, new object[] { name, args, body });
		}

		public object InvokeFunction(object[] args) {
			return this.methods["invokeFunction"].Invoke(this.target, args);
		}

		public object InvokeDelegate(object[] args) {
			return this.methods["invokeDelegate"].Invoke(this.target, args);
		}

		public IHTMLWindow2 GetWindow() {
			return this.methods["getWindow"].Invoke(this.target, null) as IHTMLWindow2;
		}

		public void CreateArgs(object[] args) {
			this.methods["createArgs"].Invoke(this.target, args);
		}
	}
}
