using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Twinkie
{
	public enum DOCHOSTUIDBLCLK : uint
	{
		DOCHOSTUIDBLCLK_DEFAULT = 0,
		DOCHOSTUIDBLCLK_SHOWPROPERTIES = 1,
		DOCHOSTUIDBLCLK_SHOWCODE = 2
	}

	public struct DOCHOSTUIINFO
	{
		public int cbSize;
		public int dwFlags;
		public DOCHOSTUIDBLCLK dwDoubleClick;
		public int pchHostCss;
		public int pchHostNS;
	};

	public struct POINT
	{
		public uint x;
		public uint y;
	}

	public struct RECT
	{
		public int left;
		public int top;
		public int right;
		public int bottom;
	}

	public struct MSG
	{
		public IntPtr hwnd;
		public int message;
		public int wParam;
		public int lParam;
		public int time;
		public POINT pt;
	}

	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("FC4801A3-2BA9-11CF-A229-00AA003D7352")]
	public interface IObjectWithSite
	{
		[PreserveSig]
		int SetSite([MarshalAs(UnmanagedType.IUnknown)] object site);

		[PreserveSig]
		int GetSite(ref Guid guid, out IntPtr ppvSite);
	}

	[ComImport]
	[Guid("BD3F23C0-D43E-11CF-893B-00AA00BDCE1A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDocHostUIHandler
	{
		void ShowContextMenu(int dwContext, ref POINT pPoint, uint pCommandTarget, uint HTMLTagElement);
		void GetHostInfo(ref DOCHOSTUIINFO theHostUIInfo);
		[PreserveSig]
		int ShowUI(int dwID, uint pActiveObject, uint pCommandTarget, uint pFrame, uint pDoc);
		[PreserveSig]
		int HideUI();
		[PreserveSig]
		int UpdateUI();
		[PreserveSig]
		int EnableModeless(int fEnable);
		void OnDocWindowActivate(int fActivate);
		void OnFrameWindowActivate(int fActivate);
		void ResizeBorder(ref RECT prcBorder, int pUIWindow, int fFrameWindow);
		[PreserveSig]
		int TranslateAccelerator(ref MSG lpMsg, ref Guid pguidCmdGroup, int nCmdID);
		[PreserveSig]
		int GetOptionKeyPath(ref int pchKey, int dw);
		[PreserveSig]
		int GetDropTarget(uint pDropTarget);
		object GetExternal();
		[PreserveSig]
		int TranslateUrl(int dwTranslate, int pchURLIn, out int ppchURLOut);
		[PreserveSig]
		int FilterDataObject(IDataObject pDO, ref IDataObject ppDORet);
	}

	[ComImport]
	[Guid("00000118-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleClientSite
	{
		int SaveObject();
		object GetMoniker(uint dwAssign, uint dwWhichMoniker);
		object GetContainer();
		int ShowObject();
		int OnShowWindow(bool fShow);
		int RequestNewObjectLayout();
	}

	[ComImport]
	[Guid("00000112-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleObject
	{
		void SetClientSite(IOleClientSite pClientSite);
		IOleClientSite GetClientSite();
		void SetHostNames(object szContainerApp, object szContainerObj);
		void Close(uint dwSaveOption);
		void SetMoniker(uint dwWhichMoniker, object pmk);
		void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk);
		void InitFromData(IDataObject pDataObject, bool fCreation, uint dwReserved);
		void GetClipboardData(uint dwReserved, IDataObject ppDataObject);
		void DoVerb(int iVerb, MSG lpmsg, IOleClientSite pActiveSite, int lindex, IntPtr hwndParent, RECT lprcPosRect);
		void EnumVerbs(object ppEnumOleVerb);
		void Update();
		void IsUpToDate();
		void GetUserClassID(uint pClsid);
		void GetUserType(uint dwFormOfType, uint pszUserType);
		void SetExtent(uint dwDrawAspect, uint psizel);
		void GetExtent(uint dwDrawAspect, uint psizel);
		void Advise(object pAdvSink, uint pdwConnection);
		void Unadvise(uint dwConnection);
		void EnumAdvise(object ppenumAdvise);
		void GetMiscStatus(uint dwAspect, uint pdwStatus);
		void SetColorScheme(object pLogpal);
	};

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

	/// <summary>
	/// Input flags for GetDispID
	/// </summary>
	[Flags]
	public enum NameFlags : uint
	{
		CaseSensitive = 0x00000001,
		Ensure = 0x00000002,
		Implicit = 0x00000004,
		CaseInsensitive = 0x00000008,
		Internal = 0x00000010,
		NoDynamicProperties = 0x00000020,
	}

	/// <summary>
	/// Output flags for GetMemberProperties
	/// </summary>
	[Flags]
	public enum PropFlags : uint
	{
		CanGet = 0x00000001,
		CannotGet = 0x00000002,
		CanPut = 0x00000004,
		CannotPut = 0x00000008,
		CanPutRef = 0x00000010,
		CannotPutRef = 0x00000020,
		NoSideEffects = 0x00000040,
		DynamicType = 0x00000080,
		CanCall = 0x00000100,
		CannotCall = 0x00000200,
		CanConstruct = 0x00000400,
		CannotConstruct = 0x00000800,
		CanSourceEvents = 0x00001000,
		CannotSourceEvents = 0x00002000,

		CanAll = CanGet | CanPut | CanPutRef | CanCall | CanConstruct | CanSourceEvents,
		CannotAll = CannotGet | CannotPut | CannotPutRef | CannotCall | CannotConstruct | CannotSourceEvents,
		ExtraAll = NoSideEffects | DynamicType,
		All = CanAll | CannotAll | ExtraAll,
	}

	/// <summary>
	/// Input flags for GetNextDispID
	/// </summary>
	[Flags]
	public enum EnumFlags : uint
	{
		Default = 0x00000001,
		All = 0x00000002,
	}

	public static class DispatchExConstant
	{
		public const int DISPID_STARTENUM = -1;
		public const int S_OK = 0;
		public const int S_FALSE = 1;
	}

	[ComImport]
	[Guid("A6EF9860-C720-11d0-9337-00A0C90DCAA9")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDispatchEx : IDispatch
	{
		int GetDispID(string bstrName, NameFlags grfdex, out int pid);

		int InvokeEx(
			int id,
			int lcid,
			int wFlags,
			ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pdp,
			object[] pvarRes,
			System.Runtime.InteropServices.ComTypes.EXCEPINFO pei,
			IServiceProvider pspCaller);

		int DeleteMemberByName(string bstrName, NameFlags grfdex);
		int DeleteMemberByDispID(int id);
		int GetMemberProperties(int id, PropFlags grfdexFetch, out PropFlags pgrfdex);
		int GetMemberName(int id, out string pbstrName);
		int GetNextDispID(int grfdex, int id, ref int pid);
	}
}