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

// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "Plugin.h"
#include "JsAgent.h"
#include "Debug.h"

BOOL APIENTRY DllMain(HMODULE hModule, DWORD dwReason, LPVOID lpReserved)
{
	switch (dwReason)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}


extern "C" {
	static const NPNetscapeFuncs* browser;

	NPError WINAPI NP_Initialize(NPNetscapeFuncs* browserFuncs NPINIT_ARG(pluginFuncs));
	NPError WINAPI NP_GetEntryPoints(NPPluginFuncs* pluginFuncs);
	const char* NP_GetMIMEDescription();
	NP_SHUTDOWN_RETURN_TYPE WINAPI NP_Shutdown(void);

	NPError NPP_New(NPMIMEType pluginType, NPP instance, uint16 mode, int16 argc, char* argn[], char* argv[], NPSavedData* saved);
	NPError NPP_Destroy(NPP instance, NPSavedData** save);
	NPError NPP_SetWindow(NPP instance, NPWindow* window);
	NPError NPP_NewStream(NPP instance, NPMIMEType type, NPStream* stream, NPBool seekable, uint16* stype);
	NPError NPP_DestroyStream(NPP instance, NPStream* stream, NPReason reason);
	int32   NPP_WriteReady(NPP instance, NPStream* stream);
	int32   NPP_Write(NPP instance, NPStream* stream, int32 offset, int32 len, void* buffer);
	void    NPP_StreamAsFile(NPP instance, NPStream* stream, const char* fname);
	void    NPP_Print(NPP instance, NPPrint* platformPrint);
	int16   NPP_HandleEvent(NPP instance, void* event);
	void    NPP_URLNotify(NPP instance, const char* URL, NPReason reason, void* notifyData);
	NPError NP_GetValue(void*, NPPVariable variable, void *value);
	NPError	NPP_GetValue(NPP instance, NPPVariable variable, void *value);
	NPError	NPP_SetValue(NPP instance, NPNVariable variable, void *value);
};

NPError WINAPI NP_Initialize(NPNetscapeFuncs* browserFuncs NPINIT_ARG(pluginFuncs))
{

	Debug::println("NP_Initialize");

	SetNPNFuncs(browserFuncs);
	browser = &GetNPNFuncs();
	return NPERR_NO_ERROR;
}

NPError WINAPI NP_GetEntryPoints(NPPluginFuncs* pluginFuncs)
{
	Debug::println("NP_GetEntryPoints");
	if (pluginFuncs->size < sizeof(NPPluginFuncs)) {
		return NPERR_INVALID_FUNCTABLE_ERROR;
	}

	pluginFuncs->version = (NP_VERSION_MAJOR << 8) | NP_VERSION_MINOR;
	pluginFuncs->newp          = NPP_New;
	pluginFuncs->destroy       = NPP_Destroy;
	pluginFuncs->setwindow     = NPP_SetWindow;
	pluginFuncs->newstream     = NPP_NewStream;
	pluginFuncs->destroystream = NPP_DestroyStream;
	pluginFuncs->asfile        = NPP_StreamAsFile;
	pluginFuncs->writeready    = NPP_WriteReady;
	pluginFuncs->write         = NPP_Write;
	pluginFuncs->print         = NPP_Print;
	pluginFuncs->event         = NPP_HandleEvent;
	pluginFuncs->urlnotify     = NPP_URLNotify;
	pluginFuncs->getvalue      = NPP_GetValue;
	pluginFuncs->setvalue      = NPP_SetValue;
	pluginFuncs->javaClass     = NULL;

	return NPERR_NO_ERROR;
}

const char* NP_GetMIMEDescription()
{
	Debug::println("NP_GetMIMEDescription");
	return "application/x-dotweb::DotWeb Agent plugin";
}

NP_SHUTDOWN_RETURN_TYPE WINAPI NP_Shutdown(void)
{
	Debug::println("NP_Shutdown");
	return NP_SHUTDOWN_RETURN(NPERR_NO_ERROR);
}

NPError NPP_New(NPMIMEType pluginType, NPP instance, uint16 mode, int16 argc, char* argn[], char* argv[], NPSavedData* saved)
{
	Debug::println("NPP_New");

	if (browser->version < 14) {
		return NPERR_INVALID_INSTANCE_ERROR;
	}
	if (instance == NULL) {
		return NPERR_INVALID_INSTANCE_ERROR;
	}

	Plugin* plugin = new Plugin(instance);
	instance->pdata = plugin;

	// Make this a windowless plugin.
	return NPN_SetValue(instance, NPPVpluginWindowBool, NULL);
}

NPError NPP_Destroy(NPP instance, NPSavedData** save)
{
	Debug::println("NPP_Destroy");
	if (instance == NULL) {
		return NPERR_INVALID_INSTANCE_ERROR;
	}

	Plugin* plugin = static_cast<Plugin*>(instance->pdata);
	if(plugin != NULL) {
		delete plugin;
		instance->pdata = 0;
	}

	return NPERR_NO_ERROR;
}

NPError NPP_SetWindow(NPP instance, NPWindow* window)
{
	//Debug::println("NPP_SetWindow");
	return NPERR_NO_ERROR;
}

NPError NPP_NewStream(NPP instance, NPMIMEType type, NPStream* stream, NPBool seekable, uint16* stype)
{
	Debug::println("NPP_NewStream");
	*stype = NP_ASFILEONLY;
	return NPERR_NO_ERROR;
}

NPError NPP_DestroyStream(NPP instance, NPStream* stream, NPReason reason)
{
	Debug::println("NPP_DestroyStream");
	return NPERR_NO_ERROR;
}

int32 NPP_WriteReady(NPP instance, NPStream* stream)
{
	Debug::println("NPP_WriteReady");
	return 0;
}

int32 NPP_Write(NPP instance, NPStream* stream, int32 offset, int32 len, void* buffer)
{
	Debug::println("NPP_Write");
	return 0;
}

void NPP_StreamAsFile(NPP instance, NPStream* stream, const char* fname)
{
	Debug::println("NPP_StreamAsFile");
}

void NPP_Print(NPP instance, NPPrint* platformPrint)
{
	Debug::println("NPP_Print");
}

int16 NPP_HandleEvent(NPP instance, void* event)
{
	//Debug::println("NPP_HandleEvent");
	return 1;
}

void NPP_URLNotify(NPP instance, const char* URL, NPReason reason, void* notifyData)
{
	Debug::println("NPP_URLNotify");
}

NPObject* NPP_GetScriptableInstance(NPP instance) {
	Debug::println("NPP_GetScriptableInstance");
	if (instance == NULL) {
		return NULL;
	}

	Plugin* plugin = static_cast<Plugin*>(instance->pdata);
	JsAgent* agent = plugin->getAgent();
	NPN_RetainObject(agent);  // caller expects it retained.
	return agent;
}

NPError	NPP_GetValue(NPP instance, NPPVariable variable, void *value)
{
	Debug::println("NPP_GetValue");

	switch (variable) {
	case NPPVpluginScriptableNPObject:
		*static_cast<NPObject**>(value) = NPP_GetScriptableInstance(instance);
		break;
	default:
		return NP_GetValue(0, variable, value);
	}

	return NPERR_NO_ERROR;
}

NPError NP_GetValue(void*, NPPVariable variable, void* value)
{
	Debug::println("NP_GetValue");
	switch (variable) {
	case NPPVpluginNameString:
		*static_cast<const char **>(value) = "DotWeb Hosted-mode Plugin";
		break;
	case NPPVpluginDescriptionString:
		*static_cast<const char **>(value) = "Plugin to enable debugging of DotWeb applications in hosted mode.";
		break;
	default:
//		Debug::log(Debug::Info) << "NPP_GetValue(var=" << variable << ") -- unexpected variable type" << Debug::flush;
		return NPERR_GENERIC_ERROR;
	}
	return NPERR_NO_ERROR;
}

NPError	NPP_SetValue(NPP instance, NPNVariable variable, void *value)
{
	Debug::println("NPP_SetValue");
	return NPERR_NO_ERROR;
}
