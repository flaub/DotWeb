﻿//>System.Exception

//>System.SystemException

$Class(System.SystemException, 'System', 'ArgumentException', { _ParamName_k__BackingField: null });

//>System.ArgumentException.$ctor$1

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException', { _ActualValue_k__BackingField: null });

(function() {
	System.ArgumentOutOfRangeException.RangeMessage = "Specified argument was out of the range of valid values.";
})();

//>System.ArgumentOutOfRangeException.$ctor$0

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests._ExpectExceptionTest_b__4 = function() {
	throw new System.ArgumentOutOfRangeException().$ctor$0();
};

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

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
			var CS$4$0000 = !(name == actual);
			if (!CS$4$0000) {
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
