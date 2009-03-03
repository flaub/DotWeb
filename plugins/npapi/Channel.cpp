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
#include "Channel.h"

Channel::Channel(void)
	: m_socket(-1)
{
#ifdef _WINDOWS
	WORD ver = MAKEWORD(2, 2);
	WSADATA wsaData;
	WSAStartup(ver, &wsaData);
#endif
}

Channel::~Channel(void) {
	close();
}

void Channel::close() {
	if(m_socket > 0) {
#ifdef _WINDOWS
		shutdown(m_socket, SD_BOTH);
		closesocket(m_socket);
#else
		shutdown(m_socket, SHUT_RDWR);
		close(m_socket);
#endif
		m_socket = -1;
	}
}

bool Channel::connect(const char* host, int port) {
	m_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if(m_socket < 0)
		return false;

	struct sockaddr_in sa;
	memset(&sa, 0, sizeof(sa));
	unsigned long ipAddress = inet_addr(host);
	if (ipAddress != 0xFFFFFFFF) {
		sa.sin_addr.s_addr = ipAddress;
		sa.sin_family = AF_INET;
	} 
	else {
		struct hostent* hent = gethostbyname(host);
		if (!hent || !hent->h_addr_list[0]) {
			return false;
		}

		memcpy(&(sa.sin_addr), hent->h_addr_list[0], hent->h_length);
		sa.sin_family = hent->h_addrtype;
	}
	
	sa.sin_port = htons(port);
	
	if(::connect(m_socket, (struct sockaddr*) &sa, sizeof(sa)) < 0) {
		return false;
	}

	return true;
}

bool Channel::disconnect() {
	close();
	return true;
}

bool Channel::readByte(uint8_t& value) {
	int ret = ::recv(m_socket, (char*)&value, 1, 0);
	if(ret != 1) {
		return false;
	}
	return true;
}


bool Channel::readBuffer(uint8_t* buf, size_t len) {
	int remain = len;
	char* ptr = (char*)buf;
	while(remain > 0) {
		int ret = ::recv(m_socket, ptr, remain, 0);
		if(ret < 0)
			return false;
		remain -= ret;
		ptr += ret;
	}
	return true;
}

bool Channel::writeByte(const uint8_t& byte) {
	int ret = ::send(m_socket, (const char*)&byte, 1, 0);
	if(ret != 1) {
		return false;
	}
	return true;
}

bool Channel::writeBuffer(const uint8_t* buf, size_t len) {
	int remain = len;
	const char* ptr = (const char*)buf;
	while(remain > 0) {
		int ret = ::send(m_socket, ptr, remain, 0);
		if(ret < 0)
			return false;
		remain -= ret;
		ptr += ret;
	}
	return true;
}
