#ifndef __Channel_H__
#define __Channel_H__

#pragma once

#ifdef _WINDOWS
#include <winsock2.h>
#include <ws2tcpip.h>
typedef SOCKET Socket_t;
#else
#include <netdb.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
#include <sys/time.h>
typedef int Socket_t;
#endif

class Channel
{
public:
	Channel(void);
	~Channel(void);

	bool connect(const char* host, int port);
	bool disconnect();

	bool readByte(uint8_t& byte);
	bool readBuffer(uint8_t* buf, size_t len);

	bool writeByte(const uint8_t& byte);
	bool writeBuffer(const uint8_t* buf, size_t len);

private:
	void close();

private:
	Socket_t m_socket;
};

#endif
