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
