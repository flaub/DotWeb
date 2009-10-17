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
using System.DotWeb;

namespace DotWeb.Sample.Script.Test
{
	[JsNamespace]
	class ExpandoNative
	{
		public extern ExpandoNative(object cfg);
		public extern void CallHostedMethod();
		public extern void CallTearOffMethod();
		public extern void OverrideMethod();
		public extern void Expand();
		public extern void Remove();
		public extern void ExpandMethod();
	}

	public class Expando : JsScript
	{
		[JsAnonymous]
		private class Config : JsDynamic
		{
			public extern Action<string> HostedMethod { get; set; }
		}

		public Expando() {
			var cfg = new Config {
				HostedMethod = this.HostedMethod
			};

			var native = new ExpandoNative(cfg);

			native.CallHostedMethod();
			native.CallTearOffMethod();
			native.OverrideMethod();
			native.Expand();
//			native.Remove();
//			native.ExpandMethod();
		}

		public void HostedMethod(string msg) {
			Window.alert(msg);
		}
	}
}