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

$Namespace('System');

System.String = function() {
};

System.String.prototype.get_Length = function() {
	var V_0 = this._Length_k__BackingField;
	return V_0;
};

__f__AnonymousType0$2.prototype.get_Value = function() {
	return this._Value_i__Field;
};

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
	System.Console.WriteLine("{0}: {1}", value.get_Key().get_Length(), value.get_Value());
};
