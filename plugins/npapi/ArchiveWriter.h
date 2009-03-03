#ifndef __ARCHIVE_WRITER_H__
#define __ARCHIVE_WRITER_H__

//#ifdef _MSC_VER
//#pragma warning(disable:4512)
//#endif //_MSC_VER

/* 
Takes a 'stream' object which matches the following concept:

Stream
{
	// Returns a single byte from the stream 
	bool writeByte(const uint8_t& byte);

	// Writes a whole buffer, fails in unable to write entire thing
	bool writeBuffer(const uint8_t* buf, size_t len);
};

*/

template<typename Stream>
class ArchiveWriter
{
public:
	ArchiveWriter(Stream& stream)
		: m_stream(stream)
	{}

	template <typename T>
	bool transfer(const T& value) {
		return const_cast<T&>(value).serialize(*this);
	}

	bool transfer(const bool& value) {
		return m_stream.writeByte(value ? 1 : 0); 
	}

	bool transfer(const uint8_t& value) {
		return m_stream.writeByte(value); 
	}

	bool transfer(const uint16_t& value) {
		uint16_t temp = htons(value);
		return m_stream.writeBuffer((uint8_t*)&temp, sizeof(temp));
	}

	bool transfer(const uint32_t& value) {
		uint32_t temp = htonl(value);
		return m_stream.writeBuffer((uint8_t*)&temp, sizeof(temp));
	}

	bool transfer(const double& value) {
		double temp = value; // conversion
		return m_stream.writeBuffer((uint8_t*)&temp, sizeof(temp));
	}

	//bool transfer(const uint64& value) {
	//	m_stream.writeByte(static_cast<uint8_t>(value >> 56));
	//	m_stream.writeByte(static_cast<uint8_t>((value >> 48) & 0xff)); 
	//	m_stream.writeByte(static_cast<uint8_t>((value >> 40) & 0xff)); 
	//	m_stream.writeByte(static_cast<uint8_t>((value >> 32) & 0xff)); 
	//	m_stream.writeByte(static_cast<uint8_t>((value >> 24) & 0xff)); 
	//	m_stream.writeByte(static_cast<uint8_t>((value >> 16) & 0xff)); 
	//	m_stream.writeByte(static_cast<uint8_t>((value >> 8) & 0xff)); 
	//	m_stream.writeByte(static_cast<uint8_t>(value & 0xff)); 
	//	return true;
	//}

	template <typename CharType>
	bool transfer(const std::basic_string<CharType>& value) {
		return transfer((uint32_t)value.size())
			&& transfer((void*)value.data(), value.size() * sizeof(CharType));
	}

	bool transfer(const void* value, size_t size) {
		return m_stream.writeBuffer((uint8_t*)value, size);
	}

	template <typename T>
	bool transferContainer(const T& container) {
		if(!transfer((uint32_t)container.size())) 
			return false;

		typedef typename T::const_iterator const_iterator;		
		const_iterator itEnd = container.end();
		for(const_iterator it = container.begin(); it != itEnd; ++it) {
			if(!transfer(*it)) 
				return false;
		}

		return true;
	}

	template <size_t FixedSize, typename T>
	bool transferArray(const T* value) {
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
