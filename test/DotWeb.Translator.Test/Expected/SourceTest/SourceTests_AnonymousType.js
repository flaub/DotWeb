__f__AnonymousType0$2 = function() {
};

__f__AnonymousType0$2.prototype.$ctor = function(Key /*_Key_j__TPar*/, Value /*_Value_j__TPar*/) {
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

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(format /*System.String*/, arg0 /*System.Object*/, arg1 /*System.Object*/) {
	console.log(format);
};

$Namespace('H8');

H8.SourceTests = function() {
};

H8.SourceTests.prototype.AnonymousType = function() {
	var value = new __f__AnonymousType0$2().$ctor("Hi", 1);
	System.Console.WriteLine("{0}: {1}", value.get_Key().length, value.get_Value());
};
