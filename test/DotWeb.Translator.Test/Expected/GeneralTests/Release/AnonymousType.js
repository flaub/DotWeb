$Class(null, '', '__f__AnonymousType0$2', { _Key_i__Field: null, _Value_i__Field: null });

__f__AnonymousType0$2.prototype.$ctor = function(Key, Value) {
	this._Key_i__Field = Key;
	this._Value_i__Field = Value;
	return this;
};

__f__AnonymousType0$2.prototype.get_Key = function() {
	return this._Key_i__Field;
};

$Class(null, 'System.Text', 'StringBuilder', { value: null });

//>System.Text.StringBuilder.$ctor

//>System.Text.StringBuilder.Append$0

//>System.Text.StringBuilder.toString

//>System.Text.StringBuilder.Append$1

__f__AnonymousType0$2.prototype.toString = function() {
	var V_0 = new System.Text.StringBuilder().$ctor();
	V_0.Append$0("{ Key = ");
	V_0.Append$1(this._Key_i__Field);
	V_0.Append$0(", Value = ");
	V_0.Append$1(this._Value_i__Field);
	V_0.Append$0(" }");
	return V_0.toString();
};

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

//>System.Console.WriteLine$0 

__f__AnonymousType0$2.prototype.get_Value = function() {
	return this._Value_i__Field;
};

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.AnonymousType = function() {
	var value = new __f__AnonymousType0$2().$ctor("Hi", 1);
	System.Console.WriteLine$0(value.get_Key().length);
	System.Console.WriteLine$0(value.get_Value());
};
