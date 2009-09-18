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
using DotWeb.Client;
using Castle.DynamicProxy;
using Castle.Core.Interceptor;

namespace DotWeb.Hosting.Bridge
{
	public class DefaultFactory : IObjectFactory
	{
		private ProxyGenerator proxyGenerator = new ProxyGenerator();
		private ProxyInterceptor interceptor = new ProxyInterceptor();

		#region IObjectFactory Members

		public object CreateInstance(Type type) {
			if (type.IsInterface) {
				return CreateInstanceForInterface(type);
			}
			else {
				return Activator.CreateInstance(type);
			}
		}

		#endregion

		private object CreateInstanceForInterface(Type type) {
			//var options = new ProxyGenerationOptions {
			//};
			var options = ProxyGenerationOptions.Default;
			var ret = this.proxyGenerator.CreateClassProxy(typeof(JsObject), new Type[] { type }, options, interceptor);
			return ret;
		}
	}

	public class ProxyInterceptor : IInterceptor
	{
		#region IInterceptor Members

		public void Intercept(IInvocation invocation) {
			Type declaringType = invocation.Method.DeclaringType;
			if (declaringType == typeof(object)) {
				invocation.Proceed();
			}
			else {
				invocation.ReturnValue = JsHost.Execute(invocation.Method, (JsObject)invocation.Proxy, invocation.Arguments);
			}
		}

		#endregion
	}
}