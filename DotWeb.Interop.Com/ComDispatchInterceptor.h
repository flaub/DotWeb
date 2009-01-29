#pragma once

#include <vcclr.h>
#include <DispEx.h>

using namespace System;
using namespace System::Runtime::InteropServices;

namespace DotWeb {
namespace Interop {
namespace Com {

public interface class IDispatchImpl
{
	UINT GetTypeInfoCount();

	System::Runtime::InteropServices::ComTypes::ITypeInfo^ GetTypeInfo( 
		/* [in] */ UINT iTInfo,
		/* [in] */ LCID lcid);

	array<DISPID>^ GetIDsOfNames( 
		/* [size_is][in] */ array<String^>^ rgszNames,
		/* [in] */ LCID lcid);

	Object^ Invoke( 
		/* [in] */ DISPID id,
		/* [in] */ LCID lcid,
		/* [in] */ WORD wFlags,
		/* [out][in] */ array<Object^>^ args,
		/* [out] */ [Out] System::Runtime::InteropServices::ComTypes::EXCEPINFO% pExcepInfo,
		/* [out] */ [Out] UINT% puArgErr);

	DISPID GetDispID(String^ name, DWORD flags);
	DWORD GetMemberProperties(DISPID id, DWORD flags);
};

class ComDispatchInterceptor : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<ComDispatchInterceptor>,
	public IDispatchEx
{
public:
	ComDispatchInterceptor();
	~ComDispatchInterceptor();

	DECLARE_NOT_AGGREGATABLE(ComDispatchInterceptor)
	DECLARE_PROTECT_FINAL_CONSTRUCT()

	BEGIN_COM_MAP(ComDispatchInterceptor)
		COM_INTERFACE_ENTRY(IDispatch)
		COM_INTERFACE_ENTRY(IDispatchEx)
	END_COM_MAP()

	HRESULT FinalConstruct() { return S_OK; }
	void FinalRelease() {}

	void SetImpl(IDispatchImpl^ impl);

private:
	gcroot<IDispatchImpl^> m_spImpl;

public:
	// IDispatch
	STDMETHOD(GetTypeInfoCount)( 
		/* [out] */ UINT *pctinfo);

	STDMETHOD(GetTypeInfo)( 
		/* [in] */ UINT iTInfo,
		/* [in] */ LCID lcid,
		/* [out] */ ITypeInfo **ppTInfo);

	STDMETHOD(GetIDsOfNames)( 
		/* [in] */ REFIID riid,
		/* [size_is][in] */ LPOLESTR *rgszNames,
		/* [in] */ UINT cNames,
		/* [in] */ LCID lcid,
		/* [size_is][out] */ DISPID *rgDispId);

	STDMETHOD(Invoke)( 
		/* [in] */ DISPID dispIdMember,
		/* [in] */ REFIID riid,
		/* [in] */ LCID lcid,
		/* [in] */ WORD wFlags,
		/* [out][in] */ ::DISPPARAMS *pDispParams,
		/* [out] */ VARIANT *pVarResult,
		/* [out] */ ::EXCEPINFO *pExcepInfo,
		/* [out] */ UINT *puArgErr);

public:
	// IDispatchEx
	STDMETHOD(GetDispID)( 
        /* [in] */ __RPC__in BSTR bstrName,
        /* [in] */ DWORD grfdex,
        /* [out] */ __RPC__out DISPID *pid);
    
    STDMETHOD(InvokeEx)( 
        /* [in] */ DISPID id,
        /* [in] */ LCID lcid,
        /* [in] */ WORD wFlags,
		/* [in] */ ::DISPPARAMS *pdp,
        /* [out] */ VARIANT *pvarRes,
		/* [out] */ ::EXCEPINFO *pei,
		/* [unique][in] */ ::IServiceProvider *pspCaller);
    
    STDMETHOD(DeleteMemberByName)( 
        /* [in] */ __RPC__in BSTR bstrName,
        /* [in] */ DWORD grfdex);
    
    STDMETHOD(DeleteMemberByDispID)( 
        /* [in] */ DISPID id);
    
    STDMETHOD(GetMemberProperties)( 
        /* [in] */ DISPID id,
        /* [in] */ DWORD grfdexFetch,
        /* [out] */ __RPC__out DWORD *pgrfdex);
    
    STDMETHOD(GetMemberName)( 
        /* [in] */ DISPID id,
        /* [out] */ __RPC__deref_out_opt BSTR *pbstrName);
    
    STDMETHOD(GetNextDispID)( 
        /* [in] */ DWORD grfdex,
        /* [in] */ DISPID id,
        /* [out] */ __RPC__out DISPID *pid);
    
    STDMETHOD(GetNameSpaceParent)( 
        /* [out] */ __RPC__deref_out_opt IUnknown **ppunk);
};


} // Com
} // Interop
} // DotWeb
