#ifndef __JsObjectWrapper_H__
#define __JsObjectWrapper_H__

#pragma once

#include "Messages.h"

class JsAgent;

class JsObjectWrapper : public NPObjectWrapper<JsObjectWrapper>
{
	friend class NPObjectWrapper<JsObjectWrapper>;
public:
	JsObjectWrapper(NPP npp);
	~JsObjectWrapper(void);

	void init(JsAgent* scriptable, uint32_t targetId);
	void detach();

private:
	bool enumeration(NPIdentifier** values, uint32_t* count);
	bool getProperty(NPIdentifier name, NPVariant* result);
	bool setProperty(NPIdentifier name, const NPVariant* value);
	bool invoke(NPIdentifier name, const NPVariant* args, unsigned argCount, NPVariant* result);
	bool invokeDefault(const NPVariant* args, unsigned argCount, NPVariant* result);
	bool hasMethod(NPIdentifier name);
	bool hasProperty(NPIdentifier name);

private:
	bool getTypeInfo();
	bool getInfo(NPIdentifier name, TypeMemberInfo& info);

private:
	JsAgent* m_agent;
	uint32_t m_targetId;
	uint32_t m_indexerLength;
	bool m_hasInfo;

	typedef std::map<std::string, TypeMemberInfo> MembersByName_t;
	MembersByName_t m_byName;
};

#endif

