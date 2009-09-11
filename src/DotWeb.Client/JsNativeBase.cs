﻿// Copyright 2009, Frank Laub
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

using System.Collections.Generic;
using System.Diagnostics;

namespace DotWeb.Client
{
	/// <summary>
	/// A derivative of this class means that its definition actually exists
	/// as a native type in JavaScript.
	/// This base class is derived from JsAccessible because it can be called
	/// from JavaScript code.
	/// This class is the primary way to allow JS-generated objects to communicate
	/// with existing JavaScript (i.e. DOM objects, 3rd-party JS libraries)
	/// </summary>
	public abstract class JsNativeBase
	{
		public int Handle { get; set; }

		private abstract class VoidReturn { }

		protected void C_(params object[] args) {
			StackFrame previous = new StackFrame(2);
			// this prevents ctors from being called twice
			// we only want the derived class's ctor to execute, not any bases
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

	public class JsDynamicBase
	{
		public JsDynamicBase() {
			this.Properties = new Dictionary<string, object>();
		}

		public Dictionary<string, object> Properties { get; set; }

		public object this[string name]
		{
			get{ return this.Properties[name]; }
			set{ this.Properties[name] = value; }
		}

		protected void _(object value) {
			StackFrame frame = new StackFrame(1);
			string name = GetPropertyName(frame);
			this[name] = value;
		}

		protected R _<R>() {
			StackFrame frame = new StackFrame(1);
			string name = GetPropertyName(frame);
			return (R)this[name];
		}

		private string GetPropertyName(StackFrame frame) {
			return frame.GetMethod().Name.Substring("get_".Length);
		}
	}
}
