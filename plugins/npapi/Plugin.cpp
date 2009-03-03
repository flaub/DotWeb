#include "StdAfx.h"
#include "Plugin.h"
#include "JsAgent.h"

Plugin::Plugin(NPP npp) : m_npp(npp)
{
	m_agent = static_cast<JsAgent*>(NPN_CreateObject(npp, GetNPClass<JsAgent>()));
}

Plugin::~Plugin(void)
{
	if (m_agent) {
		m_agent->onDestroy();
		NPN_ReleaseObject(m_agent);
		m_agent = NULL;
	}
}
