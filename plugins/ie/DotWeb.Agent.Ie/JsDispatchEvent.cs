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
using System.Runtime.InteropServices;
using DotWeb.Agent.Ie.Interop;
using DotWeb.Hosting;

namespace DotWeb.Agent.Ie
{
	public delegate object JsEventHandler(object[] args);

	[ClassInterface(ClassInterfaceType.None)]
	class JsDispatchEvent : DispatchImpl
	{
		public JsEventHandler Handler { get; private set; }

		public JsDispatchEvent(JsEventHandler handler) {
			this.Handler = handler;
		}

		#region IDispatchImpl Members

		public override DispatchResult Invoke(
			int id, 
			uint lcid, 
			DispatchFlags wFlags, 
			object[] args, 
			out System.Runtime.InteropServices.ComTypes.EXCEPINFO pExcepInfo, 
			out uint puArgErr,
			out object ret) {
			pExcepInfo = new System.Runtime.InteropServices.ComTypes.EXCEPINFO();
			puArgErr = 0;
			ret = this.Handler(args);
			return DispatchResult.Ok;
		}

		public override uint GetMemberProperties(int id, GetMemberPropertiesFlags flags) {
			return (uint)GetMemberPropertiesFlags.CanCall;
		}

		#endregion
	}
}
