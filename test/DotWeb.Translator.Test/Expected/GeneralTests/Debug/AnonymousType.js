﻿$Class(null, '', '__f__AnonymousType0$2');

__f__AnonymousType0$2.prototype.$ctor = function(Key, Value) {
	this._Key_i__Field = Key;
	this._Value_i__Field = Value;
	return this;
};

__f__AnonymousType0$2.prototype.get_Key = function() {
	return this._Key_i__Field;
};

__f__AnonymousType0$2.prototype.get_Value = function() {
	return this._Value_i__Field;
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$3 = function(format, arg0, arg1) {
	console.log(format);
};

$Class(null, 'H8', 'GeneralTests');

H8.GeneralTests.prototype.AnonymousType = function() {
	var value = new __f__AnonymousType0$2().$ctor("Hi", 1);
	System.Console.WriteLine$3("{0}: {1}", value.get_Key().length, value.get_Value());
};