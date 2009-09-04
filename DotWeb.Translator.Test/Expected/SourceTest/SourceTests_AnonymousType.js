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

__f__AnonymousType0$2.prototype.get_Value = function() {
	return this._Value_i__Field;
};

H8.SourceTests.prototype.AnonymousType = function() {
	var loc0 = new __f__AnonymousType0$2().$ctor("Hi", 1);
	console.log("{0}: {1}", loc0.get_Key().get_Length(), loc0.get_Value());
};

