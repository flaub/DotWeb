H8.OuterClassTest = function() {
};

H8.OuterClassTest.prototype.get_Text = function() {
	return this._Text_k__BackingField;
};

H8.OuterClassTest.prototype.set_Text = function(value /*System.String*/) {
	this._Text_k__BackingField = value;
};

H8.OuterClassTest.prototype.get_Value = function() {
	return this.m_value;
};

H8.OuterClassTest.prototype.set_Value = function(value /*System.Int32*/) {
	this.m_value = value;
};

H8.OuterClassTest.prototype.$ctor = function() {
	return this;
};

H8.OuterClassTest.prototype.$ctor = function(text /*System.String*/, value /*System.Int32*/) {
	this.set_Text(text);
	this.set_Value(value);
	return this;
};
