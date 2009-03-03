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
