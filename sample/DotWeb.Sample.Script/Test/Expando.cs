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

namespace DotWeb.Sample.Script.Test
{
	public class Expando : JsScript
	{
		[JsNamespace]
		class Native : JsNativeBase
		{
			public Native(object cfg) { C_(cfg); }
			public void CallHostedMethod() { _(); }
			public void CallTearOffMethod() { _(); }
			public void OverrideMethod() { _(); }
			public void Expand() { _(); }
			public void Remove() { _(); }
			public void ExpandMethod() { _(); }
		}

		[JsAnonymous]
		private class Config : JsDynamicBase
		{
			public void HostedMethod(string msg) { Window.Instance.alert("HostedMethod: " + msg); }
		}

		public Expando() {
			var cfg = new Config();
			var native = new Native(cfg);

			native.CallHostedMethod();
			native.CallTearOffMethod();
			native.OverrideMethod();
			native.Expand();
//			native.Remove();
//			native.ExpandMethod();
		}
	}
}