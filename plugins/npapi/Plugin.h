#ifndef __Plugin_H__
#define __Plugin_H__

#pragma once

class JsAgent;

class Plugin
{
public:
	Plugin(NPP npp);
	~Plugin(void);

	JsAgent* getAgent() { return m_agent; }

private:
	NPP m_npp;
	JsAgent* m_agent;
};

#endif
