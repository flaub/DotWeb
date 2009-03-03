#include "StdAfx.h"
#include "Variant.h"

std::string Variant::toString(NPP npp) const {
	if(isNull()) {
		return "<null>";
	}

	char buf[1024];
	buf[0] = '\0';
	if(isString()) {
		sprintf_s(buf, sizeof(buf), "'%s'", asString().c_str());
		return buf;
	}
	if(isInt()) {
		sprintf_s(buf, sizeof(buf), "%d", asInt());
		return buf;
	}
	if(isBool()) {
		return asBool() ? "true" : "false";
	}
	if(isDouble()) {
		sprintf_s(buf, sizeof(buf), "%f", asDouble());
		return buf;
	}
	if(isVoid()) {
		return "undefined";
	}
	if(isObject()) {
		NPObject* obj = asObject();
		Variant varRet;
		if(NPN_Invoke(npp, obj, NPN_GetStringIdentifier("toString"), NULL, 0, varRet.ptr())) {
			if(varRet.isString()) {
				return varRet.asString();
			}
		}

		return "[object]";
	}

	return "";
}
