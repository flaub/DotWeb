using System;
using System.Runtime.InteropServices.Expando;
using System.Reflection;

namespace DotWeb.Hosting.Agent
{
	public class JsObjectWrapper
	{
		private IExpando target;

		public object Handle { get { return this.target; } }

		public JsObjectWrapper(object target) {
			this.target = target as IExpando;
		}

		public override string ToString() {
			MethodInfo mi = this.target.GetMethod("toString", BindingFlags.Default);
			if (mi == null)
				return base.ToString();
			return (string)mi.Invoke(this.target, null);
		}
	}

	public class External
	{
		public void Log(object args) {
			if (args is string) {
				Console.WriteLine(args);
				return;
			}
			IExpando ex = args as IExpando;
			if (ex != null) {
				JsObjectWrapper wrapper = new JsObjectWrapper(ex);
				Console.WriteLine(wrapper);
				return;
			}

			Console.WriteLine(args);
		}

//		public object Callback(object target, object args) {
//			return JsAgent.Instance.OnCallback(target, args);
//		}
	}
}
