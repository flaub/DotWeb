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
using Castle.DynamicProxy;
using Castle.Core.Interceptor;
using System.Collections.Generic;

namespace DotWeb.Hosting.Bridge
{
	public class DefaultFactory : IObjectFactory
	{
		private readonly ProxyGenerator proxyGenerator = new ProxyGenerator();

		#region IObjectFactory Members

		public object CreateInstance(JsBridge bridge, Type type) {
			if (type.IsInterface) {
				return CreateInstanceForInterface(bridge, type);
			}
			else {
				return Activator.CreateInstance(type);
			}
		}

		#endregion

		private object CreateInstanceForInterface(JsBridge bridge, Type type) {
			var interceptor = new Interceptor(bridge);
			var ret = this.proxyGenerator.CreateInterfaceProxyWithoutTarget(type, interceptor);
			return ret;
		}

		private class Interceptor : IInterceptor
		{
			private readonly JsBridge bridge;

			public Interceptor(JsBridge bridge) {
				this.bridge = bridge;
			}

			#region IInterceptor Members

			public void Intercept(IInvocation invocation) {
				Type declaringType = invocation.Method.DeclaringType;
				if (declaringType == typeof(object)) {
					invocation.Proceed();
				}
				else {
					invocation.ReturnValue = this.bridge.Invoke(invocation.Proxy, invocation.Method, invocation.Arguments);
				}
			}

			#endregion
		}
	}
}