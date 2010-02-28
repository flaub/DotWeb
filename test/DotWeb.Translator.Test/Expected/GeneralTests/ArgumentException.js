$Class(null, 'System', 'Exception');

System.Exception.prototype.set_Message = function(value) {
	this._Message_k__BackingField = value;
};

System.Exception.prototype.$ctor$1 = function(message) {
	this.set_Message(message);
	return this;
};

$Class(System.Exception, 'System', 'SystemException');

System.SystemException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

$Class(System.SystemException, 'System', 'ArgumentException');

System.ArgumentException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1("Value does not fall within the expected range.");
	return this;
};

System.Exception.prototype.get_Message = function() {
	var V_0 = this._Message_k__BackingField;
	return V_0;
};

System.ArgumentException.prototype.get_ParamName = function() {
	var V_0 = this._ParamName_k__BackingField;
	return V_0;
};

System.ArgumentException.prototype.get_Message = function() {
	var V_0 = this.$super.get_Message();
	if (this.get_ParamName()) {
		var R_1 = this.get_ParamName().length == 0;
	}
	else {
		R_1 = 1;
	}
	var V_2 = R_1;
	if (!V_2) {
		var V_1 = V_0 + "\nParameter name: " + this.get_ParamName();
	}
	else {
		V_1 = V_0;
	}
	return V_1;
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

$Class(null, 'H8', 'GeneralTests');

H8.GeneralTests.prototype.ArgumentException = function() {
	try {
		throw new System.ArgumentException().$ctor$0();
	}
	catch (__ex__) {
		if (__ex__ instanceof System.ArgumentException) {
			var ex = __ex__;
			System.Console.WriteLine$1(ex.get_Message());
			return;
		}
	}
};
