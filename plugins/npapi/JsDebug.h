#ifndef __JsDebug_H__
#define __JsDebug_H__

#pragma once

class JsDebug : public NPObjectWrapper<JsDebug>
{
	friend class NPObjectWrapper<JsDebug>;
public:
	JsDebug(NPP npp);
	~JsDebug(void);

private:
	bool hasMethod(NPIdentifier name);
	bool invoke(NPIdentifier name, const NPVariant* args, unsigned argCount, NPVariant* result);

private:
	std::string getString(const NPVariant& var);
	bool log(const NPVariant* args, unsigned argCount, NPVariant* result);

private:
	const NPIdentifier idLog;
};

#endif
