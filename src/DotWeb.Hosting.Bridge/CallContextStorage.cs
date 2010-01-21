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

using System.Runtime.Remoting.Messaging;
using System.Diagnostics;

namespace DotWeb.Hosting.Bridge
{
	public class CallContextStorage : IDotWebHost
	{
		private const string DataSlotName = "DotWebHost";

		public IDotWebHost Host {
			get {
				var host = CallContext.GetData(DataSlotName) as IDotWebHost;
				if (host == null) {
					Debugger.Log(0, "DotWeb", "Lost my mind");
					Debugger.Break();
				}
				return host;
			}

			set {
				CallContext.SetData(DataSlotName, value);
			}
		}

		#region IDotWebHost Members

		public object Invoke(object scope, object method, object[] args) {
			return this.Host.Invoke(scope, method, args);
		}

		public T Cast<T>(object obj) {
			return this.Host.Cast<T>(obj);
		}

		#endregion
	}
}
