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

#ifndef __ARCHIVE_READER_H__
#define __ARCHIVE_READER_H__

//#ifdef _MSC_VER
//#pragma warning(disable:4512)
//#endif //_MSC_VER

/* 
Takes a 'stream' object which matches the following concept:

Stream
{
	// Returns a single byte from the stream 
	bool readByte(uint8_t& value);

	// Reads a whole buffer, fails in unable to read entire thing
	bool readBuffer(uint8_t* buf, size_t len);
};

*/

template<typename Stream>
class ArchiveReader
{
public:
	ArchiveReader(Stream& stream)
		: m_stream(stream)
	{}

	template <typename T>
	bool transfer(T& value) {
		return value.serialize(*this);
	}

	bool transfer(bool& value) {
		uint8_t byte;
		if(!m_stream.readByte(byte))
			return false;
		value = (byte == 1);
		return true;
	}

	bool transfer(uint8_t& value) {
		return m_stream.readByte(value);
	}

	bool transfer(uint16_t& value) {
		uint16 temp;
		if(!m_stream.readBuffer((uint8_t*)&temp, sizeof(uint16_t)))
			return false;
		value = ntohs(temp);
		return true;
	}

	bool transfer(uint32_t& value) {
		uint32 temp;
		if(!m_stream.readBuffer((uint8_t*)&temp, sizeof(uint32_t)))
			return false;
		value = ntohl(temp);
		return true;
	}

	bool transfer(double& value) {
		return transfer((uint64_t&)value);
	}

	bool transfer(uint64_t& value) {
		uint8_t bytes[sizeof(uint64_t)];
		if(!m_stream.readBuffer(bytes, sizeof(uint64_t)))
			return false;

		value = bytes[0];
		value = (value << 8) | bytes[1];
		value = (value << 8) | bytes[2];
		value = (value << 8) | bytes[3];
		value = (value << 8) | bytes[4];
		value = (value << 8) | bytes[5];
		value = (value << 8) | bytes[6];
		value = (value << 8) | bytes[7];
		return true;
	}

	template <typename CharType>
	bool transfer(std::basic_string<CharType>& value) {
		uint32_t size = 0;
		if(!transfer(size))
			return false;
		value.resize(size);
		return m_stream.readBuffer((uint8_t*)value.data(), size);
	}

	bool transfer(void* value, size_t size) {
		return m_stream.readBuffer((uint8_t*)value, size);	
	}

	template <typename T>
	bool transferContainer(T& container) {
		uint32_t count = 0;
		if(!transfer(count)) 
			return false;

		container.clear();
		for(uint32_t i = 0; i < count; ++i) {
			typename T::value_type item;
			if(!transfer(item)) 
				return false;
			container.push_back(item);
		}
		return true;
	}

	template <size_t FixedSize, typename T>
	bool transferArray(T* value) {
		for(size_t i = 0; i < FixedSize; ++i) {
			if(!transfer(value[i])) 
				return false;
		}
		return true;
	}

private:
	Stream& m_stream;
};

#endif
