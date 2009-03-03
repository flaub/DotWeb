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
			ushort wFlags, 
			object[] args, 
			out System.Runtime.InteropServices.ComTypes.EXCEPINFO pExcepInfo, 
			out uint puArgErr,
			out object ret) {
			pExcepInfo = new System.Runtime.InteropServices.ComTypes.EXCEPINFO();
			puArgErr = 0;
			ret = this.Handler(args);
			return DispatchResult.Ok;
		}

		public override uint GetMemberProperties(int id, uint flags) {
			return (uint)MemberProperties.CanCall;
		}

		#endregion
	}
}
