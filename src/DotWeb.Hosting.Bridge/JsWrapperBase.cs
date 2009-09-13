using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotWeb.Hosting.Bridge
{
	internal class JsWrapperBase {
		protected JsBridge bridge;

		protected JsWrapperBase(JsBridge bridge) {
			this.bridge = bridge;
		}

		protected Delegate GetMethodAsProperty(MethodInfo method, object target, out Type returnType) {
			Type delType = CreateTypeForMethod(method);
			Delegate del = Delegate.CreateDelegate(delType, target, method);
			returnType = delType;
			return del;
		}

		protected Type CreateTypeForMethod(MethodInfo method) {
			ParameterInfo[] paramaterInfos = method.GetParameters();
			Type baseType;
			string baseName;
			int typeLen;
			var genericTypes = new List<Type>();

			if (method.ReturnType == typeof(void)) {
				baseName = "System.Action";
				typeLen = paramaterInfos.Length;
				if (typeLen == 1)
					baseType = typeof(Action<>);
				else
					baseType = typeof(Action);
			}
			else {
				baseType = typeof(Func<>);
				baseName = "System.Func";
				typeLen = paramaterInfos.Length + 1;
				genericTypes.Add(method.ReturnType);
			}
			genericTypes.AddRange(paramaterInfos.Select(x => x.ParameterType));

			string typeName = string.Format("{0}`{1}, {2}", baseName, typeLen, baseType.Assembly.FullName);
			Type type = Type.GetType(typeName);
			Type baked = type.MakeGenericType(genericTypes.ToArray());
			return baked;
		}
	}
}