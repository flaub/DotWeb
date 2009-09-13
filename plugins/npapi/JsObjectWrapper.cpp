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
#include "JsObjectWrapper.h"
#include "JsAgent.h"
#include "Debug.h"
#include "Variant.h"

const char* debugName(NPIdentifier name) {
	static char buf[1024];
	if(NPN_IdentifierIsString(name)) {
		NPUTF8* strName = NPN_UTF8FromIdentifier(name);
		sprintf_s(buf, sizeof(buf), "'%s'", strName);
		NPN_MemFree(strName);
	}
	else {
		int intName = NPN_IntFromIdentifier(name);
		sprintf_s(buf, sizeof(buf), "%d", intName);
	}
	return buf;
}

DispatchIdentifier CreateDispatchIdentifier(NPIdentifier name) {
	static char buf[1024];
	DispatchIdentifier ret;
	if(NPN_IdentifierIsString(name)) {
		NPUTF8* strName = NPN_UTF8FromIdentifier(name);
		ret.tag = IT_String;
		ret.name = strName;
		NPN_MemFree(strName);
	}
	else {
		int id = NPN_IntFromIdentifier(name);
		ret.tag = IT_Int;
		ret.id = id;
	}
	return ret;
}

JsObjectWrapper::JsObjectWrapper(NPP npp)
	: NPObjectWrapper<JsObjectWrapper>(npp)
	, m_agent(NULL)
	, m_targetId(0)
	, m_indexerLength(-1)
	, m_hasInfo(false)
{}

JsObjectWrapper::~JsObjectWrapper(void) {
	Debug::println("JsObjectWrapper::~JsObjectWrapper");
	if(m_agent != NULL) {
		m_agent->onDestroy(m_targetId);
	}
}

void JsObjectWrapper::init(JsAgent* scriptable, uint32_t targetId) {
	m_agent = scriptable;
	m_targetId = targetId;
}

void JsObjectWrapper::detach() {
	m_agent = NULL;
}

bool JsObjectWrapper::enumeration(NPIdentifier** values, uint32_t* count) {
	Debug::println("JsObjectWrapper::enumeration");
	if(!getTypeInfo())
		return false;

	NPIdentifier* names = (NPIdentifier*)NPN_MemAlloc(m_byName.size() * sizeof(NPIdentifier));
	MembersByName_t::const_iterator it = m_byName.begin();
	MembersByName_t::const_iterator itEnd = m_byName.end();
	size_t i = 0;
	for(; it != itEnd; ++it) {
		const TypeMemberInfo& info = it->second;
		names[i++] = NPN_GetStringIdentifier(info.name.c_str());
	}
	*values = names;
	*count = m_byName.size();
	return true;
}

bool JsObjectWrapper::getProperty(NPIdentifier name, NPVariant* result) {
	Debug::println("JsObjectWrapper::getProperty: %s", debugName(name));
	DispatchIdentifier dispId = CreateDispatchIdentifier(name);
	return m_agent->invokeRemoteMember(m_targetId, dispId, DT_PropertyGet, NULL, 0, result);
}

bool JsObjectWrapper::setProperty(NPIdentifier name, const NPVariant* value) {
	Debug::println("JsObjectWrapper::setProperty: %s", debugName(name));
	m_hasInfo = false;
	DispatchIdentifier dispId = CreateDispatchIdentifier(name);
	return m_agent->invokeRemoteMember(m_targetId, dispId, DT_PropertySet, value, 1, NULL);
}

bool JsObjectWrapper::removeProperty(NPIdentifier name) {
	Debug::println("JsObjectWrapper::removeProperty: %s", debugName(name));
	m_hasInfo = false;
	return false;
}

bool JsObjectWrapper::invoke(NPIdentifier name, const NPVariant* args, unsigned argCount, NPVariant* result) {
	Debug::println("JsObjectWrapper::invoke: %s", debugName(name));
	DispatchIdentifier dispId = CreateDispatchIdentifier(name);
	return m_agent->invokeRemoteMember(m_targetId, dispId, DT_Method, args, argCount, result);
}

bool JsObjectWrapper::invokeDefault(const NPVariant* args, unsigned argCount, NPVariant* result) {
	if(argCount < 1) {
		Debug::println("JsObjectWrapper::invokeDefault> argCount < 1: %d", argCount);
		return false;
	}

	if(!NPVARIANT_IS_OBJECT(args[0])) {
		Debug::println("JsObjectWrapper::invokeDefault> args[0] not an object");
		return false;
	}

	NPObject* pArray = NPVARIANT_TO_OBJECT(args[0]);
	Variant varRet;
	if(!NPN_GetProperty(getNPP(), pArray, m_agent->methods.length, varRet.ptr())) {
		Debug::println("JsObjectWrapper::invokeDefault> get length failed");
		return false;
	}

	if(!NPVARIANT_IS_INT32(varRet.get())) {
		Debug::println("JsObjectWrapper::invokeDefault> length did not return an int");
		return false;
	}

	int len = NPVARIANT_TO_INT32(varRet.get());
	VariantArray varArgs(len);

	for(int i = 0; i < len; i++) {
		NPIdentifier id = NPN_GetIntIdentifier(i);
		Variant varItem;
		if(!NPN_GetProperty(getNPP(), pArray, id, varArgs[i].ptr())) {
			Debug::println("JsObjectWrapper::invokeDefault> get [%d] failed", i);
			return false;
		}
	}

	Debug::println("JsObjectWrapper::invokeDefault");
	if(!m_agent->invokeRemoteDelegate(m_targetId, varArgs.get(), len, result)) {
		Debug::println("JsObjectWrapper::invokeDefault> invokeRemoteDelegate() failed");
		return false;
	}

	return true;
}

bool JsObjectWrapper::hasMethod(NPIdentifier name) {
	Debug::println("JsObjectWrapper::hasMethod: %s", debugName(name));
	TypeMemberInfo info;
	if(!getInfo(name, info)) {
		Debug::println("JsObjectWrapper::hasMethod> not found: %s", debugName(name));
		return false;
	}
	return info.dispatchType == DT_Method;
}

bool JsObjectWrapper::hasProperty(NPIdentifier name) {
	Debug::println("JsObjectWrapper::hasProperty: %s", debugName(name));
	return true;
}

bool JsObjectWrapper::getTypeInfo() {
	if(!m_hasInfo) {
		GetTypeResponseMessage msg;
		if(!m_agent->getTypeInfo(m_targetId, msg))
			return false;

		m_byName.clear();

		m_indexerLength = msg.indexerLength;

		TypeMemberInfoList_t::const_iterator it = msg.members.begin();
		TypeMemberInfoList_t::const_iterator itEnd = msg.members.end();
		for(; it != itEnd; ++it) {
			const TypeMemberInfo& info = *it;
			m_byName.insert(std::make_pair(info.name, info));
		}
		m_hasInfo = true;
	}
	return true;
}

bool JsObjectWrapper::getInfo(NPIdentifier name, TypeMemberInfo& info) {
	if(!getTypeInfo())
		return false;

	if(NPN_IdentifierIsString(name)) {
		NPUTF8* id = NPN_UTF8FromIdentifier(name);
		MembersByName_t::const_iterator it = m_byName.find(id);
		NPN_MemFree(id);
		if(it == m_byName.end())
			return false;

		info = it->second;
		return true;
	}
	else if(m_indexerLength >= 0) {
		uint32_t index = NPN_IntFromIdentifier(name);
		if(index < m_indexerLength) {
			info.dispatchType = DT_PropertyGet | DT_PropertySet;
			//info.memberId = index;
			return true;
		}
	}

	return false;
}
