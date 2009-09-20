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
	public class JsDynamicBase
	{
		public JsDynamicBase() {
//			this.Properties = new Dictionary<string, object>();
		}

//		public Dictionary<string, object> Properties { get; set; }

		public object this[string name]
		{
			get { return JsHost.GetDynamicProperty(this, name); }
			set { JsHost.SetDynamicProperty(this, name, value); }
//			get{ return this.Properties[name]; }
//			set{ this.Properties[name] = value; }
		}

		protected void _(object value) {
//			StackFrame frame = new StackFrame(1);
//			string name = GetPropertyName(frame);
//			this[name] = value;
			JsHost.SetImplicitDynamicProperty(this, value);
		}

		protected R _<R>() {
//			StackFrame frame = new StackFrame(1);
//			string name = GetPropertyName(frame);
//			return (R)this[name];
			return (R)JsHost.GetImplicitDynamicProperty(this);
		}

//		private string GetPropertyName(StackFrame frame) {
//			return frame.GetMethod().Name.Substring("get_".Length);
//		}
	}
}
