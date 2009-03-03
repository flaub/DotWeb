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
		double temp;
		if(!m_stream.readBuffer((uint8_t*)&temp, sizeof(double)))
			return false;
//		value = ntohl(temp);
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
