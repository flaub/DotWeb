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
	public class DelegateWrapper
	{
		private IJsDelegate target;
		public DelegateWrapper(IJsDelegate target) {
			this.target = target;
		}

		public object Invoke(object[] args) {
			return target.Invoke(args);
		}
	}

	public class JsDispatchDelegate : IDispatchImpl
	{
		private IJsDelegate target;

		private const int DispId_Invoke = 0;
		private const int DispId_ToString = 1;
		private const int DispId_Call = 2;
		private const int DispId_Apply = 3;

		public JsDispatchDelegate(object target) {
			this.target = (IJsDelegate)target;
			this.IDispatch = DispatchInterceptor.Create(this);
		}

		public object IDispatch { get; set; }

		public override string ToString() {
//			return string.Format("function {0}() {{ [native code] }}", this.target);
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

			switch (dispId) {
				case DispId_Invoke:
					if (dispType.IsMethod()) {
						return this.target.Invoke(args);
					}
					else if (dispType.IsPropertyGet()) {
						return ToString();
					}
					break;
				case DispId_ToString:
					if (dispType.IsMethod()) {
						return ToString();
					}
					else if (dispType.IsPropertyGet()) {
//						int toStringDispId = this.target.GetMethodId("ToString");
//						JsDelegateAdapter adapter = new JsDelegateAdapter(this.target, toStringDispId);
//						return adapter.IDispatch;
					}
					break;
				case DispId_Apply:
					Console.WriteLine("Apply");
					break;
				case DispId_Call:
					Console.WriteLine("Call");
					break;
				default:
					throw new NotSupportedException();
			}
			throw new NotSupportedException();
		}

		public int GetDispID(string name, uint flags) {
			switch (name) {
				case "toString":
					return DispId_ToString;
				case "call":
					return DispId_Call;
				case "apply":
					return DispId_Apply;
				default:
					throw new NotSupportedException();
			}
		}

		public uint GetMemberProperties(int id, uint flags) {
			return 0;
		}

		#endregion
	}
}
