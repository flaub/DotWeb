#include "StdAfx.h"
#include "ComDispatchInterceptor.h"

using namespace System::Runtime::InteropServices;
using namespace DotWeb::Interop::Com;

typedef System::Runtime::InteropServices::ComTypes::DISPPARAMS ComDISPPARAMS;
typedef System::Runtime::InteropServices::ComTypes::EXCEPINFO ComEXCEPINFO;

ComDispatchInterceptor::ComDispatchInterceptor() {}
ComDispatchInterceptor::~ComDispatchInterceptor() {}

void ComDispatchInterceptor::SetImpl(DotWeb::Interop::Com::IDispatchImpl^ impl)
{
	m_spImpl = impl;
}

STDMETHODIMP ComDispatchInterceptor::Invoke(
	DISPID id, 
	REFIID riid, 
	LCID lcid, 
	WORD wFlags,
	::DISPPARAMS* pDispParams, 
	VARIANT* pvarResult,
	::EXCEPINFO* pExcepInfo,  
	UINT* puArgErr)
{
//	Guid guid(riid.Data1, riid.Data2, riid.Data3, 
//		riid.Data4[0], riid.Data4[1], riid.Data4[2], riid.Data4[3],
//		riid.Data4[4], riid.Data4[5], riid.Data4[6], riid.Data4[7]
//	);

	array<Object^>^ args = nullptr;
	if (pDispParams->cArgs > 0) {
		args = Marshal::GetObjectsForNativeVariants((IntPtr)pDispParams->rgvarg, pDispParams->cArgs);
	}

//	ComDISPPARAMS^ params = (ComDISPPARAMS^)Marshal::PtrToStructure((IntPtr)pDispParams, ComDISPPARAMS::typeid);

	ComEXCEPINFO exInfo;

//	System::Runtime::InteropServices::ComTypes::DISPPARAMS% paramsRef = *params;
	UINT% errRef = *puArgErr;

	Object^ ret = m_spImpl->Invoke(id, lcid, wFlags, args, exInfo, errRef);

	Marshal::GetNativeVariantForObject(ret, (IntPtr)pvarResult);
	if(pExcepInfo != NULL)
	{
		Marshal::StructureToPtr(exInfo, (IntPtr)pExcepInfo, false);
	}

	return S_OK;
}

STDMETHODIMP ComDispatchInterceptor::GetTypeInfoCount( 
	/* [out] */ UINT *pctinfo)
{
	*pctinfo = m_spImpl->GetTypeInfoCount();
	return S_OK;
}

STDMETHODIMP ComDispatchInterceptor::GetTypeInfo( 
	/* [in] */ UINT iTInfo,
	/* [in] */ LCID lcid,
	/* [out] */ ITypeInfo **ppTInfo)
{
	System::Runtime::InteropServices::ComTypes::ITypeInfo^ pInfo = m_spImpl->GetTypeInfo(iTInfo, lcid);
	IUnknown* pUnk = (IUnknown*)(Marshal::GetIUnknownForObject(pInfo).ToPointer());
	return pUnk->QueryInterface(IID_ITypeInfo, (void**)ppTInfo);
}

STDMETHODIMP ComDispatchInterceptor::GetIDsOfNames( 
	/* [in] */ REFIID riid,
	/* [size_is][in] */ LPOLESTR *rgszNames,
	/* [in] */ UINT cNames,
	/* [in] */ LCID lcid,
	/* [size_is][out] */ DISPID *rgDispId)
{
	array<String^>^ names = gcnew array<String^>(cNames);
	for(UINT i = 0; i < cNames; i++)
	{
		LPOLESTR szName = rgszNames[i];
		names[i] = Marshal::PtrToStringUni((IntPtr)szName);
	}

	array<DISPID>^ dispIds = m_spImpl->GetIDsOfNames(names, lcid);

	for(int i = 0; i < dispIds->Length; i++)
	{
		rgDispId[i] = dispIds[i];
	}

	return S_OK;
}

STDMETHODIMP ComDispatchInterceptor::GetDispID( 
	/* [in] */ __RPC__in BSTR bstrName,
	/* [in] */ DWORD grfdex,
	/* [out] */ __RPC__out DISPID *pid)
{
	String^ name = Marshal::PtrToStringBSTR((IntPtr)bstrName);
	*pid = m_spImpl->GetDispID(name, grfdex);
	return S_OK;
}

STDMETHODIMP ComDispatchInterceptor::InvokeEx( 
	/* [in] */ DISPID id,
	/* [in] */ LCID lcid,
	/* [in] */ WORD wFlags,
	/* [in] */ ::DISPPARAMS *pdp,
	/* [out] */ VARIANT *pvarRes,
	/* [out] */ ::EXCEPINFO *pei,
	/* [unique][in] */ ::IServiceProvider *pspCaller)
{
	UINT err;
	return Invoke(id, IID_NULL, lcid, wFlags, pdp, pvarRes, pei, &err);
}

STDMETHODIMP ComDispatchInterceptor::DeleteMemberByName( 
	/* [in] */ __RPC__in BSTR bstrName,
	/* [in] */ DWORD grfdex)
{
	return E_NOTIMPL;
}

STDMETHODIMP ComDispatchInterceptor::DeleteMemberByDispID( 
	/* [in] */ DISPID id)
{
	return E_NOTIMPL;
}

STDMETHODIMP ComDispatchInterceptor::GetMemberProperties( 
	/* [in] */ DISPID id,
	/* [in] */ DWORD grfdexFetch,
	/* [out] */ __RPC__out DWORD *pgrfdex)
{
	*pgrfdex = m_spImpl->GetMemberProperties(id, grfdexFetch);
	return S_OK;
}

STDMETHODIMP ComDispatchInterceptor::GetMemberName( 
	/* [in] */ DISPID id,
	/* [out] */ __RPC__deref_out_opt BSTR *pbstrName)
{
	return E_NOTIMPL;
}

STDMETHODIMP ComDispatchInterceptor::GetNextDispID( 
	/* [in] */ DWORD grfdex,
	/* [in] */ DISPID id,
	/* [out] */ __RPC__out DISPID *pid)
{
	return E_NOTIMPL;
}

STDMETHODIMP ComDispatchInterceptor::GetNameSpaceParent( 
	/* [out] */ __RPC__deref_out_opt IUnknown **ppunk)
{
	return E_NOTIMPL;
}
