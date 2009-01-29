// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"

class Module : public CAtlDllModuleT<Module> {} theModule;

BOOL APIENTRY DllMain(HMODULE hModule, DWORD dwReason, LPVOID lpReserved)
{
//	if(dwReason == DLL_PROCESS_ATTACH)
//		GlobalInitialize();
    return theModule.DllMain(dwReason, lpReserved); 
}

