﻿$Class(null, 'System', 'Exception', { message: null, _InnerException_k__BackingField: null, _Source_k__BackingField: null, _StackTrace_k__BackingField: null });

System.Exception.prototype.set_Message = function(value) {
	this.message = value;
};

System.Exception.prototype.$ctor$1 = function(message) {
	this.set_Message(message);
	return this;
};

$Class(System.Exception, 'System', 'SystemException');

System.SystemException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

$Class(System.SystemException, 'System', 'ArgumentException', { _ParamName_k__BackingField: null });

System.ArgumentException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException', { _ActualValue_k__BackingField: null });

(function() {
	System.ArgumentOutOfRangeException.RangeMessage = "Specified argument was out of the range of valid values.";
})();

System.ArgumentOutOfRangeException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1(System.ArgumentOutOfRangeException.RangeMessage);
	return this;
};

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests._ExpectExceptionTest_b__4 = function() {
	throw new System.ArgumentOutOfRangeException().$ctor$0();
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

System.Exception.prototype.$ctor$0 = function() {
	return this;
};

H8.GeneralTests.prototype.ExpectException = function(name, action) {
	try {
		action();
		System.Console.WriteLine$1("Exception expected");
	}
	catch (__ex__) {
		if (__ex__) {
			var ex = __ex__;
			var actual = ex.$typename;
			if ((name == actual)) {
				System.Console.WriteLine$1("Correct exception thrown");
			}
			else {
				System.Console.WriteLine$1("Incorrect exception thrown");
			}
		}
	}
};

H8.GeneralTests.prototype.ExpectExceptionTest = function() {
	var R_2 = "System.ArgumentOutOfRangeException";
	var R_1 = this;
	if (!H8.GeneralTests.CS$__9__CachedAnonymousMethodDelegate5) {
		H8.GeneralTests.CS$__9__CachedAnonymousMethodDelegate5 = $Delegate(H8.GeneralTests, H8.GeneralTests._ExpectExceptionTest_b__4);
	}
	R_1.ExpectException(R_2, H8.GeneralTests.CS$__9__CachedAnonymousMethodDelegate5);
};
