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
#include "JsDebug.h"
#include "Variant.h"

JsDebug::JsDebug(NPP npp)
	: NPObjectWrapper<JsDebug>(npp)
	, idLog(NPN_GetStringIdentifier("log"))
{}

JsDebug::~JsDebug(void) {
}

bool JsDebug::hasMethod(NPIdentifier name) {
	return (name == idLog);
}

bool JsDebug::invoke(NPIdentifier name, const NPVariant* args, unsigned argCount, NPVariant* result) {
	if(name == idLog) {
		return log(args, argCount, result);
	}
	return false;
}

std::string JsDebug::getString(const NPVariant& var) {
	Variant wrapper(var);
	std::string ret = wrapper.toString(getNPP());
	wrapper.take();
	return ret;
}

bool JsDebug::log(const NPVariant* args, unsigned argCount, NPVariant* result) {

	if(argCount == 1) {
		std::string str = getString(args[0]);
		OutputDebugStringA(str.c_str());
	} 
	else if(argCount > 1) {
		char buf[1024];

		std::string fmt;
		if(NPVARIANT_IS_STRING(args[0])) {
			fmt = getString(args[0]);
		}
		else {
			for(unsigned i = 0; i < argCount; i++) {
				fmt += "%s ";
			}
		}

		switch(argCount) {
			case 2:
				sprintf_s(buf, sizeof(buf), fmt.c_str(), 
					getString(args[1]).c_str()
				);
				break;
			case 3:
				sprintf_s(buf, sizeof(buf), fmt.c_str(), 
					getString(args[1]).c_str(),
					getString(args[2]).c_str()
				);
				break;
			case 4:
			default:
				sprintf_s(buf, sizeof(buf), fmt.c_str(), 
					getString(args[1]).c_str(),
					getString(args[2]).c_str(),
					getString(args[3]).c_str()
				);
				break;
		}

		OutputDebugStringA(buf);
	}
	
	OutputDebugStringA("\n");

	VOID_TO_NPVARIANT(*result);
	return true;
}
