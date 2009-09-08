// DotWeb.Interop.Com.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "ComDispatchInterceptor.h"

using namespace System;
using namespace System::Runtime::InteropServices;

namespace DotWeb {
namespace Agent {
namespace Ie {
namespace Interop {

public ref class DispatchInterceptor
{
public:
	static Object^ Create(IDispatchImpl^ impl)
	{
		CComObject<ComDispatchInterceptor>* pDispatch;
		CComObject<ComDispatchInterceptor>::CreateInstance(&pDispatch);
		pDispatch->SetImpl(impl);
		return Marshal::GetObjectForIUnknown(IntPtr(pDispatch));
	}
};

} // Interop
} // Ie
} // Agent
} // DotWeb
