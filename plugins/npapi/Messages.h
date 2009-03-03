#ifndef __Messages_H__
#define __Messages_H__

#pragma once

enum MessageType
{
	MT_Load             = 0,
	MT_GetTypeRequest   = 1,
	MT_GetTypeResponse  = 2,
	MT_InvokeMember     = 3,
	MT_InvokeDelegate   = 4,
	MT_DefineFunction   = 5,
	MT_InvokeFunction   = 6,
	MT_Return           = 7,
	MT_Quit             = 8
};

enum DispatchType 
{
	DT_Method      = 0x01,
	DT_PropertyGet = 0x02,
	DT_PropertySet = 0x04
};

enum ValueType
{
	VT_Null = 0,
	VT_Bool = 1,
	VT_Int = 2,
	VT_Double = 3,
	VT_String = 4,
	VT_Object = 5,
	VT_Delegate = 6,
	VT_Void = 7,
	VT_JsObject = 8
};

struct JsValue 
{
	uint8_t tag;
	union
	{
		bool boolValue;
		uint32_t intValue;
		double doubleValue;
	};

	std::string strValue;

	template <typename Archive>
	bool serialize(Archive& ar) {
		bool ret = ar.transfer(tag);
		if(!ret) return ret;
		switch(tag) {
			case VT_Null:
			case VT_Void:
				return true;
			case VT_Bool:
				return ar.transfer(boolValue);
			case VT_Int:
				return ar.transfer(intValue);
			case VT_Double:
				return ar.transfer(doubleValue);
			case VT_String:
				return ar.transfer(strValue);
			case VT_Object:
			case VT_JsObject:
			case VT_Delegate:
				return ar.transfer(intValue);
		}
		return false;
	}
};


struct MessageHeader
{
	uint8_t type;
	MessageType getMessageType() const { return (MessageType)type; }

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(type)
			;
	}
};

struct Message
{
	template <typename MsgType, typename Archive>
	static bool send(MsgType msg, Archive& ar) {
		Debug::println("send: %s", typeid(MsgType).name());
		return ar.transfer((uint8_t)MsgType::MT)
			&& msg.serialize(ar);
	}
};

struct LoadMessage 
{
	static const MessageType MT = MT_Load;
	std::string typeName;

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(typeName)
			;
	}
};

struct TypeMemberInfo
{
	uint32_t memberId;
	std::string name;
	uint8_t dispatchType;

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(memberId)
			&& ar.transfer(name)
			&& ar.transfer(dispatchType)
			;
	}
};

struct GetTypeRequestMessage
{
	static const MessageType MT = MT_GetTypeRequest;
	uint32_t targetId;

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(targetId);
	}
};

typedef std::list<TypeMemberInfo> TypeMemberInfoList_t;
struct GetTypeResponseMessage
{
	static const MessageType MT = MT_GetTypeResponse;
	uint32_t indexerLength;
	TypeMemberInfoList_t members;

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(indexerLength)
			&& ar.transferContainer(members);
	}
};

struct DefineFunctionMessage 
{
	static const MessageType MT = MT_DefineFunction;
	std::string name;
	std::string args;
	std::string body;

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(name)
			&& ar.transfer(args)
			&& ar.transfer(body)
			;
	}
};

struct InvokeFunctionMessage 
{
	static const MessageType MT = MT_InvokeFunction;
	std::string name;
	uint32_t scopeId;
	std::list<JsValue> args;

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(name)
			&& ar.transfer(scopeId)
			&& ar.transferContainer(args)
			;
	}
};

struct InvokeDelegateMessage 
{
	static const MessageType MT = MT_InvokeDelegate;
	uint32_t targetId;
	std::list<JsValue> args;

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(targetId)
			&& ar.transferContainer(args)
			;
	}
};

struct InvokeMemberMessage 
{
	static const MessageType MT = MT_InvokeMember;
	uint32_t targetId;
	uint32_t memberId;
	uint8_t dispatchType;
	std::list<JsValue> args;

	DispatchType getDispatchType() const { return (DispatchType)dispatchType; }

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(targetId)
			&& ar.transfer(memberId)
			&& ar.transfer(dispatchType)
			&& ar.transferContainer(args)
			;
	}
};

struct ReturnMessage 
{
	static const MessageType MT = MT_Return;
	bool isException;
	JsValue value;

	template <typename Archive>
	bool serialize(Archive& ar) {
		return ar.transfer(isException)
			&& ar.transfer(value)
			;
	}
};

struct QuitMessage 
{
	static const MessageType MT = MT_Quit;
	template <typename Archive>
	bool serialize(Archive& ar) {
		return true;
	}
};

#endif
