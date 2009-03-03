#include "StdAfx.h"
#include "Debug.h"

void Debug::print(const char* fmt, ...) {
	char buf[1024];
	va_list args;
	va_start(args, fmt);
	vsprintf_s(buf, 1024, fmt, args);
	OutputDebugStringA(buf);
}

void Debug::println(const char* fmt, ...) {
	char buf[1024];
	va_list args;
	va_start(args, fmt);
	vsprintf_s(buf, 1024, fmt, args);
	OutputDebugStringA(buf);
	OutputDebugStringA("\n");
}
