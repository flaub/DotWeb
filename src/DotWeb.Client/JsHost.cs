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
		object InvokeRemoteMethod(JsObject scope, params object[] args);
		T Cast<T>(object obj);

		object GetImplicitDynamicProperty(JsDynamicBase obj);
		void SetImplicitDynamicProperty(JsDynamicBase obj, object value);

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
			object ret = Invoke(scope, args);
			if (ret == null)
				return default(R);
			return (R)ret;
		}

		public static object Invoke(JsObject scope, params object[] args) {
			//Debug.WriteLine(string.Format(
			//    "Execute: {0}, {1}, {2}",
			//    method,
			//    scope,
			//    args));
			return Instance.InvokeRemoteMethod(scope, args);
		}

		public static T Cast<T>(object obj) {
			return Instance.Cast<T>(obj);
		}

		public static object GetImplicitDynamicProperty(JsDynamicBase obj) {
			return Instance.GetImplicitDynamicProperty(obj);
		}

		public static void SetImplicitDynamicProperty(JsDynamicBase obj, object value) {
			Instance.SetImplicitDynamicProperty(obj, value);
		}

		public static object GetDynamicProperty(JsDynamicBase obj, string propertyName) {
			return Instance.GetDynamicProperty(obj, propertyName);
		}

		public static void SetDynamicProperty(JsDynamicBase obj, string propertyName, object value) {
			Instance.SetDynamicProperty(obj, propertyName, value);
		}
	}
}
