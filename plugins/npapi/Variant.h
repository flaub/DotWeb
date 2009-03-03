#ifndef __Variant_H__
#define __Variant_H__

#pragma once

class Variant
{
public:
	Variant() {
		VOID_TO_NPVARIANT(m_var);
	}

	Variant(const NPVariant var) : m_var(var) {
	}

	~Variant() {
		NPN_ReleaseVariantValue(&m_var);
	}

	NPVariant* ptr() { return &m_var; }
	const NPVariant* ptr() const { return &m_var; }

	NPVariant& get() { return m_var; }
	const NPVariant& get() const { return m_var; }

	NPVariant take() {
		NPVariant ret(m_var);
		VOID_TO_NPVARIANT(m_var);
		return ret;
	}

	void set(Variant& value) {
		m_var = value.take();
	}

	void set(const std::string& value) {
		size_t len = value.size();
		NPUTF8* buf = (NPUTF8*)NPN_MemAlloc(len);
		memcpy(buf, value.data(), len);
		STRINGN_TO_NPVARIANT(buf, len, m_var);
	}

	void setInt(int value) {
		INT32_TO_NPVARIANT(value, m_var);
	}

	void set(double value) {
		DOUBLE_TO_NPVARIANT(value, m_var);
	}

	void set(NPObject* value) {
		OBJECT_TO_NPVARIANT(value, m_var);
	}

	void setNull() {
		NULL_TO_NPVARIANT(m_var);
	}

	void setVoid() {
		VOID_TO_NPVARIANT(m_var);
	}

	std::string toString(NPP npp) const;

	bool isBool() const { return NPVARIANT_IS_BOOLEAN(m_var); }
	bool isInt() const { return NPVARIANT_IS_INT32(m_var); }
	bool isDouble() const { return NPVARIANT_IS_DOUBLE(m_var); }
	bool isObject() const { return NPVARIANT_IS_OBJECT(m_var); }
	bool isNull() const { return NPVARIANT_IS_NULL(m_var); }
	bool isVoid() const { return NPVARIANT_IS_VOID(m_var); }
	bool isString() const { return NPVARIANT_IS_STRING(m_var); }

	bool asBool() const { return NPVARIANT_TO_BOOLEAN(m_var); }
	int asInt() const { return NPVARIANT_TO_INT32(m_var); }
	double asDouble() const { return NPVARIANT_TO_DOUBLE(m_var); }
	NPObject* asObject() const { return NPVARIANT_TO_OBJECT(m_var); }
	std::string asString() const { 
		const NPString& npstr = NPVARIANT_TO_STRING(m_var);
		std::string str = std::string(npstr.UTF8Characters, npstr.UTF8Length);
		return str; 
	}

private:
	NPVariant m_var;
};

class VariantArray : public std::vector<Variant> 
{
public:
	VariantArray(size_t count) : std::vector<Variant>(count) {
	}

	NPVariant* get() {
		return (NPVariant*)&front();
	}
};

#endif
