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

using System.Reflection;

namespace DotWeb.Client
{
	public interface IJsHost
	{
		object InvokeRemoteMethod(JsObject scope, int stackDepth, params object[] args);
		T Cast<T>(object obj);

		object GetImplicitDynamicProperty(JsDynamicBase obj, int stackDepth);
		void SetImplicitDynamicProperty(JsDynamicBase obj, int stackDepth, object value);

		object GetDynamicProperty(JsDynamicBase obj, string name);
		void SetDynamicProperty(JsDynamicBase obj, string propertyName, object value);
	}

	public interface IJsHostStorage
	{
		IJsHost Host { get; }
	}

	public static class JsHost
	{
		private abstract class VoidReturn { }

		public static IJsHostStorage Storage { get; set; }

		public static IJsHost Instance {
			get { return Storage.Host; }
		}

		public static R Invoke<R>(JsObject scope, params object[] args) {
			return InternalInvoke<R>(scope, 1, args);
		}

		public static void Invoke(JsObject scope, params object[] args) {
			InternalInvoke(scope, 1, args);
		}

		internal static R InternalInvoke<R>(JsObject scope, int stackDepth, params object[] args) {
			object ret = InternalInvoke(scope, stackDepth + 1, args);
			if (ret == null)
				return default(R);
			return (R)ret;
		}

		internal static object InternalInvoke(JsObject scope, int stackDepth, params object[] args) {
			//Debug.WriteLine(string.Format(
			//    "Execute: {0}, {1}, {2}",
			//    method,
			//    scope,
			//    args));
			return Instance.InvokeRemoteMethod(scope, stackDepth + 1, args);
		}

		public static T Cast<T>(object obj) {
			return Instance.Cast<T>(obj);
		}

		public static object GetImplicitDynamicProperty(JsDynamicBase obj, int stackDepth) {
			return Instance.GetImplicitDynamicProperty(obj, stackDepth + 1);
		}

		public static void SetImplicitDynamicProperty(JsDynamicBase obj, int stackDepth, object value) {
			Instance.SetImplicitDynamicProperty(obj, stackDepth + 1, value);
		}

		public static object GetDynamicProperty(JsDynamicBase obj, string propertyName) {
			return Instance.GetDynamicProperty(obj, propertyName);
		}

		public static void SetDynamicProperty(JsDynamicBase obj, string propertyName, object value) {
			Instance.SetDynamicProperty(obj, propertyName, value);
		}
	}
}
