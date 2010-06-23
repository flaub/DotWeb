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
	var CS$0$0001 = $Array(5, null);
	CS$0$0001[0] = "[";
	var R_2 = 1;
	var R_1 = CS$0$0001;
	if (!this.get_Key()) {
		var R_3 = String.empty;
	}
	else {
		var CS$0$0002 = this.get_Key();
		R_3 = CS$0$0002.toString();
	}
	R_1[R_2] = R_3;
	CS$0$0001[2] = ", ";
	R_2 = 3;
	R_1 = CS$0$0001;
	if (!this.get_Value()) {
		R_3 = String.empty;
	}
	else {
		var CS$0$0003 = this.get_Value();
		R_3 = CS$0$0003.toString();
	}
	R_1[R_2] = R_3;
	CS$0$0001[4] = "]";
	return CS$0$0001.join('');
};

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestKeyValuePair = function() {
	var kvp = new System.Collections.Generic.KeyValuePair$2().$ctor("key", "value");
	System.Console.WriteLine$1(kvp.toString());
};
