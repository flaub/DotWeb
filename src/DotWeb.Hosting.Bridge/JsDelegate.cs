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
using System.Reflection;
using System.Reflection.Emit;
using DotWeb.Client;
using DotWeb.Utility;

namespace DotWeb.Hosting.Bridge
{
	class JsDelegateWrapper
	{
		private JsBridge bridge;
		public Type TargetType { get; set; }
		public Delegate Target { get; set; }
		public int Handle { get; set; }

		delegate void GenericVoidHandler();

		public JsDelegateWrapper(JsBridge bridge, int handle, Type targetType) {
			this.bridge = bridge;
			this.Handle = handle;
			this.TargetType = targetType;
		}

		public Delegate GetDelegate() {
			if (TargetType == typeof(Delegate)) {
				return new GenericVoidHandler(this.OnGenericVoidHandler);
			}

			VarArgsAttribute attr = TargetType.GetCustomAttribute<VarArgsAttribute>();
			MethodInfo invoke = TargetType.GetMethod("Invoke");
			ParameterInfo[] parameters = invoke.GetParameters();
			Type[] parameterTypes = parameters.Select(x => x.ParameterType).ToArray();
			bool isVoidReturn = invoke.ReturnType == typeof(void);

			if (isVoidReturn && !parameterTypes.Any()) {
				Delegate proxy = new GenericVoidHandler(this.OnGenericVoidHandler);
//				MethodInfo proxy = this.GetType().GetMethod("OnGenericVoidHandler");
				return Delegate.CreateDelegate(TargetType, this, proxy.Method);
			}
			else {
				string suffix;
				bool isVarArgs;
				if (attr != null) {
					suffix = "VarArgs";
					isVarArgs = true;
				}
				else {
					suffix = parameterTypes.Length.ToString();
					isVarArgs = false;
				}

				List<Type> types = new List<Type>();
				string prefix = "";
				if (isVoidReturn) {
					prefix = "Void";
				}
				else {
					types.Add(invoke.ReturnType);
				}

				if (!isVarArgs)
					types.AddRange(parameterTypes);

				string name = string.Format("OnGeneric{0}Handler{1}", prefix, suffix);
				MethodInfo generic = this.GetType().GetMethod(
					name,
					BindingFlags.NonPublic | BindingFlags.Instance
				);
				MethodInfo proxy = generic.MakeGenericMethod(types.ToArray());
				return Delegate.CreateDelegate(TargetType, this, proxy);
			}
		}

		private void OnGenericVoidHandler() {
			this.bridge.InvokeRemoteDelegate(null, this.Handle, null);
		}

		private void OnGenericVoidHandler1<T1>(T1 arg1) {
			this.bridge.InvokeRemoteDelegate(null, this.Handle, arg1);
		}

		private void OnGenericVoidHandler2<T1, T2>(T1 arg1, T2 arg2) {
			this.bridge.InvokeRemoteDelegate(null, this.Handle, arg1, arg2);
		}

		private void OnGenericVoidHandler3<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3) {
			this.bridge.InvokeRemoteDelegate(null, this.Handle, arg1, arg2, arg3);
		}

		private R OnGenericHandlerVarArgs<R>(params object[] args) {
			return (R)this.bridge.InvokeRemoteDelegate(typeof(R), this.Handle, args);
		}

		private R OnGenericHandler0<R>() {
			return (R)this.bridge.InvokeRemoteDelegate(typeof(R), this.Handle, null);
		}

		private R OnGenericHandler1<R, T1>(T1 arg1) {
			return (R)this.bridge.InvokeRemoteDelegate(typeof(R), this.Handle, arg1);
		}

		private R OnGenericHandler2<R, T1, T2>(T1 arg1, T2 arg2) {
			return (R)this.bridge.InvokeRemoteDelegate(typeof(R), this.Handle, arg1, arg2);
		}

		private R OnGenericHandler3<R, T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3) {
			return (R)this.bridge.InvokeRemoteDelegate(typeof(R), this.Handle, arg1, arg2, arg3);
		}
	}
}
