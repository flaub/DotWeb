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
using System.Diagnostics;
using System.Reflection;

namespace DotWeb.Client
{
	public abstract class JsNativeBase : JsAccessible
	{
		public int Handle { get; set; }

		private class VoidReturn { }

		protected void C_(params object[] args) {
			StackFrame previous = new StackFrame(2);
			if (previous.GetMethod().DeclaringType.IsSubclassOf(typeof(JsNativeBase))) {
				return;
			}
			StackFrame frame = new StackFrame(1);
			JsHost.Execute<VoidReturn>(frame.GetMethod(), this, args);
		}

		protected void _(params object[] args) {
			StackFrame frame = new StackFrame(1);
			JsHost.Execute<VoidReturn>(frame.GetMethod(), this, args);
		}

		protected R _<R>(params object[] args) {
			StackFrame frame = new StackFrame(1);
			return JsHost.Execute<R>(frame.GetMethod(), this, args);
		}

		protected static void S_(params object[] args) {
			StackFrame frame = new StackFrame(1);
			JsHost.Execute<VoidReturn>(frame.GetMethod(), null, args);
		}

		protected static R S_<R>(params object[] args) {
			StackFrame frame = new StackFrame(1);
			return JsHost.Execute<R>(frame.GetMethod(), null, args);
		}
	}
}
