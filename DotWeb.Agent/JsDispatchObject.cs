using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.Expando;
using System.Reflection;
using System.Runtime.InteropServices;
using DotWeb.Interop.Com;
using ComDISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using ComEXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace DotWeb.Hosting.Agent
{
	[ClassInterface(ClassInterfaceType.None)]
	public class JsDispatchObject : IDispatchImpl
	{
		private IJsAccessible target;

		public JsDispatchObject(object target) {
			this.target = (IJsAccessible)target;
			this.IDispatch = DispatchInterceptor.Create(this);
		}

		public object IDispatch { get; set; }

		public override string ToString() {
			return base.ToString();
		}

		#region IDispatchImpl Members

		public int[] GetIDsOfNames(string[] names, uint lcid) {
			int[] ret = new int[1];
			ret[0] = GetDispID(names.First(), 0);
			return ret;
		}

		public System.Runtime.InteropServices.ComTypes.ITypeInfo GetTypeInfo(uint iTInfo, uint lcid) {
			throw new NotImplementedException();
		}

		uint IDispatchImpl.GetTypeInfoCount() {
			throw new NotImplementedException();
		}

		public object Invoke(
			int dispId, 
			uint lcid, 
			ushort wFlags, 
			object[] args, 
			out ComEXCEPINFO pExcepInfo, 
			out uint puArgErr) {
			pExcepInfo = new ComEXCEPINFO();
			puArgErr = 0;

			DispatchType dispType = (DispatchType)wFlags;
			if (dispId == 0) {
				if (dispType.IsPropertyGet()) {
					return this.target.ToString();
				}
				throw new NotSupportedException();
			}

//			if (dispType.IsPropertyGet()) {
//				JsMethodAdapter adapter = new JsMethodAdapter(this.target, dispId);
//				return adapter.IDispatch;
//			}

			object ret = this.target.Invoke(dispId, dispType, args);
			return ret;
		}

		public int GetDispID(string name, uint flags) {
			return this.target.GetMemberId(name);
		}

		public uint GetMemberProperties(int id, uint flags) {
			return (uint)this.target.GetMemberProperties(id, (MemberProperties)flags);
		}

		#endregion
	}
}
