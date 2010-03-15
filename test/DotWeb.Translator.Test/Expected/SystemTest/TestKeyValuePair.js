$Class(null, 'System.Collections.Generic', 'KeyValuePair$2', { _Key_k__BackingField: null, _Value_k__BackingField: null });

System.Collections.Generic.KeyValuePair$2.prototype.set_Key = function(value) {
	this._Key_k__BackingField = value;
};

System.Collections.Generic.KeyValuePair$2.prototype.set_Value = function(value) {
	this._Value_k__BackingField = value;
};

System.Collections.Generic.KeyValuePair$2.prototype.$ctor = function(key, value) {
	this.set_Key(key);
	this.set_Value(value);
	return this;
};

System.Collections.Generic.KeyValuePair$2.prototype.get_Key = function() {
	return this._Key_k__BackingField;
};

System.Collections.Generic.KeyValuePair$2.prototype.get_Value = function() {
	return this._Value_k__BackingField;
};

System.Collections.Generic.KeyValuePair$2.prototype.toString = function() {
	var V_1 = $Array(5, null);
	V_1[0] = "[";
	var R_2 = 1;
	var R_1 = V_1;
	if (!this.get_Key()) {
		var R_3 = String.empty;
	}
	else {
		var V_2 = this.get_Key();
		R_3 = V_2.toString();
	}
	R_1[R_2] = R_3;
	V_1[2] = ", ";
	R_2 = 3;
	R_1 = V_1;
	if (!this.get_Value()) {
		R_3 = String.empty;
	}
	else {
		var V_3 = this.get_Value();
		R_3 = V_3.toString();
	}
	R_1[R_2] = R_3;
	V_1[4] = "]";
	return V_1.join('');
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestKeyValuePair = function() {
	var kvp = new System.Collections.Generic.KeyValuePair$2().$ctor("key", "value");
	System.Console.WriteLine$1(kvp.toString());
};
