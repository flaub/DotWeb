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

#pragma once

#include <vcclr.h>
#include <DispEx.h>

using namespace System;
using namespace System::Runtime::InteropServices;

namespace DotWeb {
namespace Agent {
namespace Ie {
namespace Interop {

public enum class DispatchResult : HRESULT
{
	Success = S_OK,
	Ok = S_OK,
	False = S_FALSE,
	EnumerationDone = S_FALSE,
	UnknownName = DISP_E_UNKNOWNNAME,
	BadParamCount = DISP_E_BADPARAMCOUNT,
	BadVarType = DISP_E_BADVARTYPE,
	Exception = DISP_E_EXCEPTION,
	MemberNotFound = DISP_E_MEMBERNOTFOUND,
	NoNamedArgs = DISP_E_NONAMEDARGS, 
	Overflow = DISP_E_OVERFLOW,
	ParamNotFound = DISP_E_PARAMNOTFOUND,
	TypeMismatch = DISP_E_TYPEMISMATCH,
	UnknownLcid = DISP_E_UNKNOWNLCID,
	ParamNotOptional = DISP_E_PARAMNOTOPTIONAL,
	OutOfMemory = E_OUTOFMEMORY,
	NotImpl = E_NOTIMPL,
};

public enum class GetNextDispIdFlags 
{
	Default = fdexEnumDefault,
	All = fdexEnumAll
};

public ref class DispId
{
public:
	static const DISPID Unknown = DISPID_UNKNOWN;
	static const DISPID Value = DISPID_VALUE;
	static const DISPID PropertyPut = DISPID_PROPERTYPUT;
	static const DISPID NewEnum = DISPID_NEWENUM;
	static const DISPID Evaluate = DISPID_EVALUATE;
	static const DISPID Constructor = DISPID_CONSTRUCTOR;
	static const DISPID Destructor = DISPID_DESTRUCTOR;
	static const DISPID Collect = DISPID_COLLECT;
};

public interface class IDispatchImpl
{
	UINT GetTypeInfoCount();

	System::Runtime::InteropServices::ComTypes::ITypeInfo^ GetTypeInfo( 
		/* [in] */ UINT iTInfo,
		/* [in] */ LCID lcid);

	DispatchResult GetIDsOfNames( 
		/* [size_is][in] */ array<String^>^ names,
		/* [in] */ LCID lcid,
		/* [out] */ [Out] array<DISPID>^% dispIds);

	DispatchResult Invoke( 
		/* [in] */ DISPID id,
		/* [in] */ LCID lcid,
		/* [in] */ WORD flags,
		/* [out][in] */ array<Object^>^ args,
		/* [out] */ [Out] System::Runtime::InteropServices::ComTypes::EXCEPINFO% pExcepInfo,
		/* [out] */ [Out] UINT% puArgErr,
		/* [out] */ [Out] Object^% ret);

	DispatchResult GetDispID(String^ name, DWORD flags, [Out] DISPID% id);
	DWORD GetMemberProperties(DISPID id, DWORD flags);

	DispatchResult GetNextDispID( 
		/* [in] */ GetNextDispIdFlags flags,
		/* [in] */ DISPID id,
		/* [out] */ [Out] DISPID% nextId);

	DispatchResult GetMemberName(
		/* [in] */ DISPID id, 
		/* [out] */ [Out] String^% name);
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


} // Interop
} // Ie
} // Agent
} // DotWeb
