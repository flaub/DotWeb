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
