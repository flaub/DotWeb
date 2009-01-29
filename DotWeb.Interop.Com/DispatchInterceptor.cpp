// DotWeb.Interop.Com.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ComDispatchInterceptor.h"

using namespace System;
using namespace System::Runtime::InteropServices;

namespace DotWeb {
namespace Interop {
namespace Com {

public ref class DispatchInterceptor
{
public:
	static Object^ Create(IDispatchImpl^ impl)
	{
		CComObject<ComDispatchInterceptor>* pDispatch;
		CComObject<ComDispatchInterceptor>::CreateInstance(&pDispatch);
		ComDispatchInterceptor* ptr = pDispatch;
		ptr->SetImpl(impl);
//		ptr->AddRef();
		return Marshal::GetObjectForIUnknown(IntPtr(ptr));
	}
};

} // Com
} // Interop
} // DotWeb
