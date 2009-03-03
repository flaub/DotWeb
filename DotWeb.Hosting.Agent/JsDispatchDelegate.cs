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
using System.Runtime.InteropServices.Expando;
using System.Reflection;
using System.Runtime.InteropServices;
using ComDISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using ComEXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;
using DotWeb.Agent.Ie.Interop;
using DotWeb.Hosting;

namespace DotWeb.Agent.Ie
{
	[ClassInterface(ClassInterfaceType.None)]
	class JsDispatchDelegate : DispatchImpl
	{
		private int targetId;
		private JsAgent agent;

		private const int DispId_Invoke = 0;
		private const int DispId_ToString = 1;
		private const int DispId_Call = 2;
		private const int DispId_Apply = 3;

		public JsDispatchDelegate(JsAgent agent, int targetId) {
			this.agent = agent;
			this.targetId = targetId;
		}

		#region IDispatchImpl Members

		public override DispatchResult Invoke(
			int dispId, 
			uint lcid, 
			ushort wFlags, 
			object[] args, 
			out ComEXCEPINFO pExcepInfo, 
			out uint puArgErr,
			out object ret) {
			pExcepInfo = new ComEXCEPINFO();
			puArgErr = 0;
			DispatchType dispType = (DispatchType)wFlags;

			switch (dispId) {
				case DispId_Invoke:
					if (dispType.IsMethod()) {
						ret = this.agent.InvokeRemoteDelegate(this.targetId, args);
						return DispatchResult.Ok;
					}
					else if (dispType.IsPropertyGet()) {
						ret = ToString();
						return DispatchResult.Ok;
					}
					break;
				case DispId_ToString:
					if (dispType.IsMethod()) {
						ret = ToString();
						return DispatchResult.Ok;
					}
					else if (dispType.IsPropertyGet()) {
//						int toStringDispId = this.target.GetMethodId("ToString");
//						JsDelegateAdapter adapter = new JsDelegateAdapter(this.target, toStringDispId);
//						return adapter.IDispatch;
						ret = null;
						return DispatchResult.MemberNotFound;
					}
					break;
				case DispId_Apply:
					Console.WriteLine("Apply");
					break;
				case DispId_Call:
					Console.WriteLine("Call");
					break;
				default:
					ret = null;
					return DispatchResult.MemberNotFound;
			}

			ret = null;
			return DispatchResult.MemberNotFound;
		}

		public override DispatchResult GetDispID(string name, uint flags, out int id) {
			switch (name) {
				case "toString":
					id = DispId_ToString;
					break;
				case "call":
					id = DispId_Call;
					break;
				case "apply":
					id = DispId_Apply;
					break;
				default:
					id = DispId.Unknown;
					return DispatchResult.UnknownName;
			}
			return DispatchResult.Ok;
		}

		#endregion
	}
}
