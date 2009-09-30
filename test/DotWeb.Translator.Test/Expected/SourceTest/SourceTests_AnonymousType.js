__f__AnonymousType0$2 = function() {
};

__f__AnonymousType0$2.prototype.$ctor = function(Key /*System.String*/, Value /*System.Int32*/) {
	this._Key_i__Field = Key;
	this._Value_i__Field = Value;
	return this;
};

__f__AnonymousType0$2.prototype.get_Key = function() {
	return this._Key_i__Field;
};

$Namespace('System');

System.String = function() {
};

System.String.prototype.get_Length = function() {
	var loc0 = this._Length_k__BackingField;
	return loc0;
};

__f__AnonymousType0$2.prototype.get_Value = function() {
	return this._Value_i__Field;
};

System.Console = function() {
};

System.Console.WriteLine = function(format /*System.String*/, arg0 /*System.Object*/, arg1 /*System.Object*/) {
	// nop
};

$Namespace('H8');

H8.SourceTests = function() {
};

H8.SourceTests.prototype.AnonymousType = function() {
	var loc0 = new __f__AnonymousType0$2().$ctor("Hi", 1);
	System.Console.WriteLine("{0}: {1}", loc0.get_Key().get_Length(), loc0.get_Value());
};
