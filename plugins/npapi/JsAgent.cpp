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
#include "JsAgent.h"
#include "JsObjectWrapper.h"
#include "Channel.h"
#include "ArchiveReader.h"
#include "ArchiveWriter.h"
#include "Messages.h"
#include "Variant.h"
#include "Debug.h"
#include "JsDebug.h"

#define MSG_DISPATCH(_Class, _Func) \
{ _Class msg; msg.serialize(ar); _Func(msg); }

JsAgent::JsAgent(NPP npp)
	: NPObjectWrapper<JsAgent>(npp)
	, m_channel(new Channel())
	, m_helper(NULL)
	, m_lastRefId(1)
{
	if (NPN_GetValue(npp, NPNVWindowNPObject, &m_window) != NPERR_NO_ERROR) {
		Debug::println("Error getting window object");
	}
}

JsAgent::MethodIds::MethodIds() 
	: onLoad(NPN_GetStringIdentifier("onLoad"))
	, onUnload(NPN_GetStringIdentifier("onUnload"))
	, toString(NPN_GetStringIdentifier("toString"))
	, defineFunction(NPN_GetStringIdentifier("defineFunction"))
	, invokeFunction(NPN_GetStringIdentifier("invokeFunction"))
	, invokeDelegate(NPN_GetStringIdentifier("invokeDelegate"))
	, wrapDelegate(NPN_GetStringIdentifier("wrapDelegate"))
	, length(NPN_GetStringIdentifier("length"))
	, debug(NPN_GetStringIdentifier("debug"))
	, createArgs(NPN_GetStringIdentifier("createArgs"))
	, index0(NPN_GetIntIdentifier(0))
	, index1(NPN_GetIntIdentifier(1))
{}

JsAgent::~JsAgent() {
	Debug::println("JsAgent::~JsAgent");
	if (m_window != NULL) {
		NPN_ReleaseObject(m_window);
	}
	if(m_helper != NULL) {
		NPN_ReleaseObject(m_helper);
	}
	RefToObj_t::iterator it = m_remoteObjects.begin();
	RefToObj_t::iterator itEnd = m_remoteObjects.end();
	for(; it != itEnd; ++it) {
		JsObjectWrapper* wrapper = (JsObjectWrapper*)it->second;
		wrapper->detach();
		//NPN_ReleaseObject(wrapper);
	}
	delete m_channel;
}

void JsAgent::onDestroy() {
	Debug::println("JsAgent::onDestroy");
}

bool JsAgent::enumeration(NPIdentifier** values, uint32_t* count) {
	Debug::println("JsAgent::enumeration");
	//	NPIdentifier* props = static_cast<NPIdentifier*>(NPN_MemAlloc(sizeof(NPIdentifier) * n));
	*values = NULL;
	*count = 0;
	return false;
}

bool JsAgent::getProperty(NPIdentifier name, NPVariant* result) {
	Debug::println("JsAgent::getProperty");
	return false;
}

bool JsAgent::setProperty(NPIdentifier name, const NPVariant* value) {
	Debug::println("JsAgent::setProperty");
	return false;
}

bool JsAgent::invoke(NPIdentifier name, const NPVariant* args, unsigned argCount, NPVariant* result) {
	//	NPUTF8* strName = NPN_UTF8FromIdentifier(name);
	Debug::println("JsAgent::invoke");

	if(name == methods.onLoad) {
		return onLoad(args, argCount);
	}
	else if(name == methods.onUnload) {
		return onUnload();
	}
	else if(name == methods.toString) {
		std::string str("[DotWeb Plugin]");
		Variant var;
		var.set(str);
		*result = var.take();
		return true;
	}

	return false;
}

bool JsAgent::invokeDefault(const NPVariant* args, unsigned argCount, NPVariant* result) {
	Debug::println("JsAgent::invokeDefault");
	return false;
}

bool JsAgent::hasMethod(NPIdentifier name) {
	//Debug::println("JsAgent::hasMethod");
	return (name == methods.onLoad || 
		name == methods.onUnload ||
		name == methods.toString);
}

bool JsAgent::hasProperty(NPIdentifier name) {
	//Debug::println("JsAgent::hasProperty");
	//	return name == statsID || name == connectedID || name == savedID;
	return false;
}

bool JsAgent::onLoad(const NPVariant* args, unsigned argCount) {
	Debug::println("JsAgent::onLoad");

	if(argCount != 4) {
		return false;
	}

	if( !NPVARIANT_IS_OBJECT(args[0]) ||
		!NPVARIANT_IS_STRING(args[1]) ||
		!NPVARIANT_IS_INT32(args[2]) ||
		!NPVARIANT_IS_STRING(args[3]) ) {
		return false;
	}

	NPObject* pObject = NPVARIANT_TO_OBJECT(args[0]);
	m_helper = NPN_RetainObject(pObject);

	NPObject* pDebug = NPN_CreateObject(getNPP(), GetNPClass<JsDebug>());
	NPN_RetainObject(pDebug);
	Variant var;
	var.set(pDebug);

	if(!NPN_SetProperty(getNPP(), m_window, methods.debug, var.ptr())) {
		return false;
	}

	NPString npstr = NPVARIANT_TO_STRING(args[1]);
	std::string host(npstr.UTF8Characters, npstr.UTF8Length);

	int port = NPVARIANT_TO_INT32(args[2]);

	npstr = NPVARIANT_TO_STRING(args[3]);
	std::string typeName(npstr.UTF8Characters, npstr.UTF8Length);

	if(!m_channel->connect(host.c_str(), port)) {
		return false;
	}

	LoadMessage msg;
	msg.typeName = typeName;

	ArchiveWriter<Channel> ar(*m_channel);
	if(!Message::send(msg, ar))
		return false;

	JsValue ret;
	return dispatchAndReturn(ret);
}

bool JsAgent::onReturn(const ReturnMessage& msg, JsValue& ret) {
	ret = msg.value;
	if(msg.isException) {
		if(msg.value.tag == VT_String) {
			Debug::println("JsAgent::onException: %s", msg.value.strValue.c_str());
		}
		else {
			Debug::println("JsAgent::onException");
		}
	}
	return true;
}

bool JsAgent::dispatchAndReturn(JsValue& ret) {
	ArchiveReader<Channel> ar(*m_channel);
	while(true) {
		Debug::println("Waiting for MessageHeader...");
		MessageHeader mh;
		if(!mh.serialize(ar))
			return false;

		switch(mh.getMessageType()) {
			case MT_DefineFunction:
				Debug::println("MT_DefineFunction");
				MSG_DISPATCH(DefineFunctionMessage, onDefineFunction);
				break;
			case MT_InvokeFunction:
				Debug::println("MT_InvokeFunction");
				MSG_DISPATCH(InvokeFunctionMessage, onInvokeFunction);
				break;
			case MT_Return: {
					Debug::println("MT_Return");
					ReturnMessage msg; 
					msg.serialize(ar); 
					return onReturn(msg, ret);
				}
			case MT_Quit:
				Debug::println("MT_Quit");
				return true;
			default:
				Debug::println("Unknown message type!");
				return false;
		}

	}
	return false;
}

bool JsAgent::onUnload() {
	m_channel->disconnect();
	return false;
}

bool JsAgent::onDefineFunction(const DefineFunctionMessage& msg) {
	Debug::println("JsAgent::onDefineFunction: %s", msg.name.c_str());

	VariantArray args(3);
	args[0].set(msg.name);
	args[1].set(msg.args);
	args[2].set(msg.body);

	Variant varRet;
	return NPN_Invoke(getNPP(), m_helper, methods.defineFunction, args.get(), args.size(), varRet.ptr());
}

uint32_t JsAgent::getRefId(NPObject* pObject) {
	uint32_t id;
	ObjToRef_t::const_iterator it = m_objToRef.find(pObject);
	if(it == m_objToRef.end()) {
		id = m_lastRefId++;
		pObject = NPN_RetainObject(pObject);
		m_objToRef[pObject] = id;
		m_refToObj[id] = pObject;
	}
	else {
		id = it->second;
	}
	return id;
}

void JsAgent::onDestroy(uint32_t id) {
	Debug::println("JsAgent::onDestroy(id)");
	m_remoteObjects.erase(id);
}

NPObject* JsAgent::getLocalObject(uint32_t id) {
	RefToObj_t::const_iterator it = m_refToObj.find(id);
	if(it == m_refToObj.end()) 
		return NULL;
	return NPN_RetainObject(it->second);
}

NPObject* JsAgent::getRemoteObject(uint32_t id) {
	RefToObj_t::const_iterator it = m_remoteObjects.find(id);
	if(it == m_remoteObjects.end()) {
		JsObjectWrapper* wrapper = (JsObjectWrapper*)NPN_CreateObject(getNPP(), GetNPClass<JsObjectWrapper>());
		wrapper->init(this, id);
		m_remoteObjects[id] = wrapper;
		return NPN_RetainObject(wrapper);
	}
	else {
		return NPN_RetainObject(it->second);
	}
}

NPObject* JsAgent::wrapDelegate(NPObject* obj) {
	VariantArray args(1);
	args[0].set(obj);

	Variant varRet;
	if(!NPN_Invoke(getNPP(), m_helper, methods.wrapDelegate, args.get(), args.size(), varRet.ptr()))
		return NULL;

	if(!varRet.isObject())
		return NULL;

	return NPN_RetainObject(varRet.asObject());
}

bool JsAgent::wrapRemoteValue(const JsValue& value, Variant& variant) {
	if(value.tag == VT_Object) {
		NPObject* obj = getRemoteObject(value.intValue);
		variant.set(obj);
	}
	else if(value.tag == VT_Delegate) {
		NPObject* obj = getRemoteObject(value.intValue);
		NPObject* wrapper = wrapDelegate(obj);
		variant.set(wrapper);
	}
	else if(value.tag == VT_JsObject) {
		NPObject* obj = getLocalObject(value.intValue);
		if(obj == NULL)
			return false;
		variant.set(obj);
	}
	else if(value.tag == VT_String) {
		variant.set(value.strValue);
	}
	else if(value.tag == VT_Int) {
		variant.setInt(value.intValue);
	}
	else if(value.tag == VT_Bool) {
		variant.set(value.boolValue);
	}
	else if(value.tag == VT_Null) {
		variant.setNull();
	}
	else if(value.tag == VT_Void) {
		variant.setVoid();
	}
	else if(value.tag == VT_Double) {
		variant.set(value.doubleValue);
	}
	else {
		return false;
	}
	return true;
}

bool JsAgent::wrapLocalValue(const Variant& var, JsValue& value) {
	if(var.isInt()) {
		value.tag = VT_Int;
		value.intValue = var.asInt();
	} 
	else if(var.isString()) {
		value.tag = VT_String;
		value.strValue = var.asString();
	}
	else if(var.isObject()) {
		NPObject* pObject = var.asObject();
		uint32_t id = getRefId(pObject);
		value.tag = VT_JsObject;
		value.intValue = id;
		// determine if this is a managed object
	}
	else if(var.isNull()) {
		value.tag = VT_Null;
	}
	else if(var.isBool()) {
		value.tag = VT_Bool;
		value.boolValue = var.asBool();
	}
	else if(var.isDouble()) {
		value.tag = VT_Double;
		value.doubleValue = var.asDouble();
	}
	else if(var.isVoid()) {
		value.tag = VT_Void;
	}
	else {
		return false;
	}
	return true;
}

bool JsAgent::onHandleReturn(const Variant& varRet) {
	if(!varRet.isObject()) {
		Debug::println("JsAgent::onHandleReturn> NPN_Invoke did not return an object");
		return false;
	}

	NPObject* pReturn = varRet.asObject();
	Variant varFlag;
	if(!NPN_GetProperty(getNPP(), pReturn, methods.index0, varFlag.ptr())) {
		Debug::println("JsAgent::onHandleReturn> ret[0] failed");
		return false;
	}

	Variant varResult;
	if(!NPN_GetProperty(getNPP(), pReturn, methods.index1, varResult.ptr())) {
		Debug::println("JsAgent::onHandleReturn> ret[1] failed");
		return false;
	}

	if(!varFlag.isBool()) {
		Debug::println("JsAgent::onHandleReturn> flag was not bool");
		return false;
	}

	ReturnMessage retMsg;
	retMsg.isException = varFlag.asBool();
	std::string strRet = varResult.toString(getNPP());
	if(retMsg.isException) {
		Debug::println("JsAgent::onHandleReturn> Exception: '%s'", strRet.c_str());
		NPN_SetException(this, strRet.c_str());
	}
	else {
		Debug::println("JsAgent::onHandleReturn> returned: %s", strRet.c_str());
	}

	if(!wrapLocalValue(varResult, retMsg.value)) {
		Debug::println("JsAgent::onHandleReturn> wrapLocalValue() failed");
		return false;
	}

	ArchiveWriter<Channel> ar(*m_channel);
	if(!Message::send(retMsg, ar)) {
		Debug::println("JsAgent::onHandleReturn> Message::send() failed");
		return false;
	}
	return true;
}

bool JsAgent::onInvokeFunction(const InvokeFunctionMessage& msg) {
	Debug::println("JsAgent::onInvokeFunction: %s", msg.name.c_str());

	VariantArray args(msg.args.size() + 2);
	int i = 0;
	args[i++].set(msg.name);

	int scopeId = msg.scopeId;
	if(scopeId != 0) {
		NPObject* obj = getLocalObject(scopeId);
		if(obj == NULL) {
			Debug::println("JsAgent::onInvokeFunction> getLocalObject() returned NULL");
			return false;
		}
		args[i++].set(obj);
	} 
	else {
		args[i++].setNull();
	}

	std::list<JsValue>::const_iterator it = msg.args.begin();
	std::list<JsValue>::const_iterator itEnd = msg.args.end();
	for(; it != itEnd; ++it) {
		const JsValue& value = *it;
		wrapRemoteValue(value, args[i++]);
	}

	Variant varRet;
	if(!NPN_Invoke(getNPP(), m_helper, methods.invokeFunction,  args.get(), args.size(), varRet.ptr())) {
		Debug::println("JsAgent::onInvokeFunction> NPN_Invoke failed");
		return false;
	}

	return onHandleReturn(varRet);
}

bool JsAgent::onInvokeDelegate(const InvokeDelegateMessage& msg) {
	Debug::println("JsAgent::onInvokeDelegate: %d", msg.targetId);
	VariantArray args(msg.args.size() + 1);

	NPObject* obj = getLocalObject(msg.targetId);
	if(obj == NULL) {
		Debug::println("JsAgent::onInvokeDelegate> getLocalObject() returned NULL");
		return false;
	}

	int i = 0;
	args[i++].set(obj);

	std::list<JsValue>::const_iterator it = msg.args.begin();
	std::list<JsValue>::const_iterator itEnd = msg.args.end();
	for(; it != itEnd; ++it) {
		const JsValue& value = *it;
		wrapRemoteValue(value, args[i++]);
	}

	Variant varRet;
	if(!NPN_Invoke(getNPP(), m_helper, methods.invokeDelegate, args.get(), args.size(), varRet.ptr())) {
		Debug::println("JsAgent::onInvokeDelegate> NPN_Invoke failed");
		return false;
	}

	return onHandleReturn(varRet);
}

bool JsAgent::invokeRemoteMember(
	uint32_t targetId, 
	uint32_t memberId, 
	DispatchType dt, 
	const NPVariant* args, 
	unsigned argCount, 
	NPVariant* result) {
	Debug::println("JsAgent::invokeRemoteMember: %d, %d", targetId, memberId);

	InvokeMemberMessage msg;
	msg.targetId = targetId;
	msg.memberId = memberId;
	msg.dispatchType = dt;

	for(size_t i = 0; i < argCount; i++) {
		JsValue value;
		if(!wrapLocalValue(args[i], value))
			return false;
		msg.args.push_back(value);
	}

	ArchiveWriter<Channel> ar(*m_channel);
	if(!Message::send(msg, ar))
		return false;

	JsValue ret;
	if(!dispatchAndReturn(ret))
		return false;

	if(result != NULL) {
		Variant varRet;
		if(!wrapRemoteValue(ret, varRet))
			return false;
		*result = varRet.take();
	}
	return true;
}

bool JsAgent::invokeRemoteDelegate(
	uint32_t targetId, 
	const NPVariant* args, 
	unsigned argCount, 
	NPVariant* result) {
	Debug::println("JsAgent::invokeRemoteDelegate: %d", targetId);

	InvokeDelegateMessage msg;
	msg.targetId = targetId;

	for(size_t i = 0; i < argCount; i++) {
		JsValue value;
		if(!wrapLocalValue(args[i], value))
			return false;
		msg.args.push_back(value);
	}

	ArchiveWriter<Channel> ar(*m_channel);
	if(!Message::send(msg, ar))
		return false;

	JsValue ret;
	if(!dispatchAndReturn(ret))
		return false;

	if(result != NULL) {
		Variant varRet;
		if(!wrapRemoteValue(ret, varRet))
			return false;
		*result = varRet.take();
	}
	return true;
}

bool JsAgent::getTypeInfo(uint32_t targetId, GetTypeResponseMessage& ret) {
	Debug::println("JsAgent::getTypeInfo: %d", targetId);

	GetTypeRequestMessage msg;
	msg.targetId = targetId;

	ArchiveWriter<Channel> writer(*m_channel);
	if(!Message::send(msg, writer))
		return false;

	ArchiveReader<Channel> reader(*m_channel);
	MessageHeader mh;
	if(!mh.serialize(reader))
		return false;

	if(mh.getMessageType() != MT_GetTypeResponse)
		return false;

	return ret.serialize(reader);
}

