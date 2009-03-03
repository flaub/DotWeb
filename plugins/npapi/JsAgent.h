#ifndef __JsAgent_H__
#define __JsAgent_H__

#pragma once

#include "Messages.h"

class Channel;
class Variant;

class JsAgent : public NPObjectWrapper<JsAgent>
{
	friend class NPObjectWrapper<JsAgent>;
public:
	JsAgent(NPP npp);
	~JsAgent();

	void onDestroy();
	void onDestroy(uint32_t id);

	struct MethodIds
	{
		MethodIds();
		const NPIdentifier onLoad;
		const NPIdentifier onUnload;
		const NPIdentifier toString;

		const NPIdentifier defineFunction;
		const NPIdentifier invokeFunction;
		const NPIdentifier invokeDelegate;
		const NPIdentifier wrapDelegate;

		const NPIdentifier length;
		const NPIdentifier debug;
		const NPIdentifier createArgs;

		const NPIdentifier index0;
		const NPIdentifier index1;
	} methods;

public:
	bool getTypeInfo(uint32_t targetId, GetTypeResponseMessage& ret);
	bool invokeRemoteMember(uint32_t targetId, uint32_t memberId, DispatchType dt, const NPVariant* args, unsigned argCount, NPVariant* result);
	bool invokeRemoteDelegate(uint32_t targetId, const NPVariant* args, unsigned argCount, NPVariant* result);

private:
	bool enumeration(NPIdentifier** values, uint32_t* count);
	bool getProperty(NPIdentifier name, NPVariant* result);
	bool setProperty(NPIdentifier name, const NPVariant* value);
	bool invoke(NPIdentifier name, const NPVariant* args, unsigned argCount, NPVariant* result);
	bool invokeDefault(const NPVariant* args, unsigned argCount, NPVariant* result);
	bool hasMethod(NPIdentifier name);
	bool hasProperty(NPIdentifier name);

private:
	bool onLoad(const NPVariant* args, unsigned argCount);
	bool onUnload();

	bool dispatchAndReturn(JsValue& ret);

	bool onDefineFunction(const DefineFunctionMessage& msg);
	bool onInvokeFunction(const InvokeFunctionMessage& msg);
	bool onInvokeDelegate(const InvokeDelegateMessage& msg);
	bool onHandleReturn(const Variant& var);
	bool onReturn(const ReturnMessage& msg, JsValue& ret);

	NPObject* wrapDelegate(NPObject* obj);
	bool wrapRemoteValue(const JsValue& value, Variant& variant);
	bool wrapLocalValue(const Variant& variant, JsValue& value);
	uint32_t getRefId(NPObject* pObject);
	
	NPObject* getLocalObject(uint32_t id);
	NPObject* getRemoteObject(uint32_t id);

private:
	NPObject* m_window;
	NPObject* m_helper;
	Channel* m_channel;
	uint32_t m_lastRefId;

	typedef std::map<int, NPObject*> RefToObj_t;
	typedef std::map<NPObject*, int> ObjToRef_t;

	RefToObj_t m_refToObj;
	ObjToRef_t m_objToRef;

	RefToObj_t m_remoteObjects;
};

#endif
