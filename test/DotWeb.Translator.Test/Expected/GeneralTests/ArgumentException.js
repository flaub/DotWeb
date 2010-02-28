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

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException');

System.ArgumentOutOfRangeException.prototype.get_ActualValue = function() {
	var V_0 = this._ActualValue_k__BackingField;
	return V_0;
};

$Class(null, 'System.Text', 'StringBuilder');

System.Text.StringBuilder.prototype.$ctor = function() {
	this.value = "";
	return this;
};

System.Text.StringBuilder.prototype.Append$0 = function(value) {
	var V_1 = value != null;
	if (!V_1) {
		var V_0 = this;
	}
	else {
		V_1 = value.length != 0;
		if (!V_1) {
			this.value = value;
			V_0 = this;
		}
		else {
			var D_0 = this;
			D_0.value = D_0.value + value;
			V_0 = this;
		}
	}
	return V_0;
};

System.Text.StringBuilder.prototype.toString = function() {
	var V_0 = this.value;
	return V_0;
};

$Class(null, 'System.Collections.Generic', 'List$1');

System.Collections.Generic.List$1.prototype.toString = function() {
	var V_0 = "[ " + this.items.toString() + " ]";
	return V_0;
};

System.Text.StringBuilder.prototype.Append$7 = function(value) {
	var V_0 = this.Append$0(value.toString());
	return V_0;
};

$Class(null, '', '__f__AnonymousType0$2');

__f__AnonymousType0$2.prototype.toString = function() {
	var V_0 = new System.Text.StringBuilder().$ctor();
	V_0.Append$0("{ Key = ");
	V_0.Append$7(this._Key_i__Field);
	V_0.Append$0(", Value = ");
	V_0.Append$7(this._Value_i__Field);
	V_0.Append$0(" }");
	return V_0.toString();
};

System.ArgumentOutOfRangeException.prototype.get_Message = function() {
	var V_0 = this.$super.get_Message();
	var V_3 = this.get_ActualValue() != null;
	if (!V_3) {
		var V_2 = V_0;
	}
	else {
		var V_1 = "Actual value was " + this.get_ActualValue().toString();
		V_3 = V_0 != null;
		if (!V_3) {
			V_2 = V_1;
		}
		else {
			V_2 = V_0 + "\n" + V_1;
		}
	}
	return V_2;
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
