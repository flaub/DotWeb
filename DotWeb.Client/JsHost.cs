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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Reflection;
using System.Diagnostics;

namespace DotWeb.Client
{
	public interface IJsHost
	{
		R InvokeRemoteMethod<R>(MethodBase method, JsNativeBase scope, params object[] args);
	}

	public static class JsHost
	{
		private const string JsHostName = "JsHost";

		public static IJsHost Instance {
			get {
				IJsHost host = CallContext.GetData(JsHostName) as IJsHost;
				if (host == null) {
					Debugger.Log(0, "DotWeb", "Lost my mind");
					Debugger.Break();
				}
				return host;
			}
			set {
				CallContext.SetData(JsHostName, value);
			}
		}

		public static R Execute<R>(MethodBase method, JsNativeBase scope, params object[] args) {
			string str = string.Format("{0}: {1}, {2}\n", method, scope, args);
			Debugger.Log(0, "DotWeb", str);
			return Instance.InvokeRemoteMethod<R>(method, scope, args);
		}
	}
}
