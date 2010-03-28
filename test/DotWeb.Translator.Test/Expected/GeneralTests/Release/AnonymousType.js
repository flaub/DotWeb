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

System.Text.StringBuilder.prototype.$ctor = function() {
	this.value = "";
	return this;
};

System.Text.StringBuilder.prototype.Append$0 = function(value) {
	var V_1 = value != null;
	if (!V_1) {
		return this;
	}
	V_1 = value.length != 0;
	if (!V_1) {
		this.value = value;
		return this;
	}
	this.value = this.value + value;
	return this;
};

System.Text.StringBuilder.prototype.toString = function() {
	return this.value;
};

System.Text.StringBuilder.prototype.Append$1 = function(value) {
	return this.Append$0(value.toString());
};

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

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

System.Console.WriteLine$0 = function(value) {
	System.Console.WriteLine$1(value.toString());
};

__f__AnonymousType0$2.prototype.get_Value = function() {
	return this._Value_i__Field;
};

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.AnonymousType = function() {
	var value = new __f__AnonymousType0$2().$ctor("Hi", 1);
	System.Console.WriteLine$0(value.get_Key().length);
	System.Console.WriteLine$0(value.get_Value());
};
