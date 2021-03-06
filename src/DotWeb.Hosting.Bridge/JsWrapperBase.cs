// Copyright 2009, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 
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