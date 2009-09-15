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
using DotWeb.Client;
using DotWeb.Client.Dom;
using System;

namespace DotWeb.Sample.Script.Test
{
	[JsNamespace]
	class ExpandoNative : JsNativeBase
	{
		public ExpandoNative(object cfg) { C_(cfg); }
		public void CallHostedMethod() { _(); }
		public void CallTearOffMethod() { _(); }
		public void OverrideMethod() { _(); }
		public void Expand() { _(); }
		public void Remove() { _(); }
		public void ExpandMethod() { _(); }
	}

	public class Expando : JsScript
	{
		[JsAnonymous]
		private class Config : JsDynamicBase
		{
			public Action<string> HostedMethod { get { return _<Action<string>>(); } set { _(value); } }
		}

		public Expando() {
			var cfg = new Config {
				HostedMethod = this.HostedMethod
			};

			var native = new ExpandoNative(cfg);

			//native.CallHostedMethod();
			//native.CallTearOffMethod();
			native.OverrideMethod();
			//native.Expand();
//			native.Remove();
//			native.ExpandMethod();
		}

		public void HostedMethod(string msg) {
			Window.alert(msg);
		}
	}
}