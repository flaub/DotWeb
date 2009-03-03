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

