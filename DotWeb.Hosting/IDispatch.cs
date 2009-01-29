using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace DotWeb.Hosting
{
	[ComImport]
	[Guid("00020400-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDispatch
	{
		int GetTypeInfoCount();
		ITypeInfo GetTypeInfo(uint iTInfo, int lcid);
		int GetIDsOfNames(
			ref Guid riid,
			string[] rgszNames,
			uint cNames,
			int lcid,
			int[] rgDispId);

		int Invoke(
			int dispIdMember,
			ref Guid riid,
			int lcid,
			int wFlags,
			ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pDispParams,
			object[] pVarResult,
			System.Runtime.InteropServices.ComTypes.EXCEPINFO pExcepInfo,
			IntPtr[] puArgErr);
	}
}
