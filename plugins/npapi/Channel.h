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
