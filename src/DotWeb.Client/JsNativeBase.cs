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

namespace DotWeb.Client
{
	public class JsObject
	{
	}

	/// <summary>
	/// A derivative of this class means that its definition actually exists
	/// as a native type in JavaScript.
	/// This class is the primary way to allow JS-generated objects to communicate
	/// with existing JavaScript (i.e. DOM objects, 3rd-party JS libraries)
	/// </summary>
	public abstract class JsNativeBase : JsObject
	{
		protected void C_(params object[] args) {
			JsHost.InternalInvoke(this, 1, args);
		}

		protected void _(params object[] args) {
			JsHost.InternalInvoke(this, 1, args);
		}

		protected R _<R>(params object[] args) {
			return JsHost.InternalInvoke<R>(this, 1, args);
		}

		protected static void S_(params object[] args) {
			JsHost.InternalInvoke(null, 1, args);
		}

		protected static R S_<R>(params object[] args) {
			return JsHost.InternalInvoke<R>(null, 1, args);
		}
	}
}
