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

#include "StdAfx.h"
#include "ComDispatchInterceptor.h"

using namespace System::Runtime::InteropServices;
using namespace DotWeb::Agent::Ie::Interop;

typedef System::Runtime::InteropServices::ComTypes::DISPPARAMS ComDISPPARAMS;
typedef System::Runtime::InteropServices::ComTypes::EXCEPINFO ComEXCEPINFO;

ComDispatchInterceptor::ComDispatchInterceptor() {}
ComDispatchInterceptor::~ComDispatchInterceptor() {}

void ComDispatchInterceptor::SetImpl(DotWeb::Agent::Ie::Interop::IDispatchImpl^ impl)
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
	try {
		array<Object^>^ args = nullptr;
		if (pDispParams->cArgs > 0) {
			args = Marshal::GetObjectsForNativeVariants((IntPtr)pDispParams->rgvarg, pDispParams->cArgs);
			Array::Reverse(args);
		}

		ComEXCEPINFO exInfo;
		UINT err;
		Object^ ret;
		HRESULT hr = (HRESULT)m_spImpl->Invoke(id, lcid, wFlags, args, exInfo, err, ret);

		if(pvarResult != NULL)
		{
			Marshal::GetNativeVariantForObject(ret, (IntPtr)pvarResult);
			if(pExcepInfo != NULL)
			{
				Marshal::StructureToPtr(exInfo, (IntPtr)pExcepInfo, false);
			}
		}

		if(puArgErr != NULL) 
			*puArgErr = err;

		return S_OK;
	}
	catch(Exception^ ex)
	{
		return Marshal::GetHRForException(ex);
	}
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

	array<DISPID>^ dispIds;
	HRESULT hr = (HRESULT)m_spImpl->GetIDsOfNames(names, lcid, dispIds);
	if(hr == S_OK)
	{
		for(int i = 0; i < dispIds->Length; i++)
		{
			rgDispId[i] = dispIds[i];
		}
	}

	return hr;
}

STDMETHODIMP ComDispatchInterceptor::GetDispID( 
	/* [in] */ __RPC__in BSTR bstrName,
	/* [in] */ DWORD grfdex,
	/* [out] */ __RPC__out DISPID *pid)
{
	String^ name = Marshal::PtrToStringBSTR((IntPtr)bstrName);
	DISPID% idref = *pid;
	return (HRESULT)m_spImpl->GetDispID(name, grfdex, idref);
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
	return S_FALSE;
}

STDMETHODIMP ComDispatchInterceptor::DeleteMemberByDispID( 
	/* [in] */ DISPID id)
{
	return S_FALSE;
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
	String^ name;
	HRESULT hr = (HRESULT)m_spImpl->GetMemberName(id, name);
	if(name != nullptr)
	{
		*pbstrName = (BSTR)Marshal::StringToBSTR(name).ToPointer();
	}
	return hr;
}

STDMETHODIMP ComDispatchInterceptor::GetNextDispID( 
	/* [in] */ DWORD grfdex,
	/* [in] */ DISPID id,
	/* [out] */ __RPC__out DISPID *pid)
{
	DISPID% nextId = *pid;
	return (HRESULT)m_spImpl->GetNextDispID((GetNextDispIdFlags)grfdex, id, nextId);
}

STDMETHODIMP ComDispatchInterceptor::GetNameSpaceParent( 
	/* [out] */ __RPC__deref_out_opt IUnknown **ppunk)
{
	return E_NOTIMPL;
}
