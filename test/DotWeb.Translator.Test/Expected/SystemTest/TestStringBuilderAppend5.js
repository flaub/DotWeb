$Class(null, 'System.Text', 'StringBuilder', { value: null });

System.Text.StringBuilder.prototype.$ctor = function() {
	this.value = "";
	return this;
};

System.Text.StringBuilder.prototype.toString = function() {
	return this.value;
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

System.Text.StringBuilder.prototype.Append$1 = function(value) {
	return this.Append$0(value.toString());
};

$Class(null, 'System', 'Exception', { message: null, _InnerException_k__BackingField: null, _Source_k__BackingField: null, _StackTrace_k__BackingField: null });

System.Exception.prototype.set_Message = function(value) {
	this.message = value;
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

$Class(System.SystemException, 'System', 'ArgumentException', { _ParamName_k__BackingField: null });

System.ArgumentException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException', { _ActualValue_k__BackingField: null });

(function() {
	System.ArgumentOutOfRangeException.RangeMessage = "Specified argument was out of the range of valid values.";
})();

System.ArgumentOutOfRangeException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1(System.ArgumentOutOfRangeException.RangeMessage);
	return this;
};

System.ArgumentException.prototype.set_ParamName = function(value) {
	this._ParamName_k__BackingField = value;
};

System.ArgumentException.prototype.$ctor$3 = function(message, paramName) {
	this.$super.$ctor$1(message);
	this.set_ParamName(paramName);
	return this;
};

$Class(System.ArgumentException, 'System', 'ArgumentNullException');

(function() {
	System.ArgumentNullException.DefaultMessage = "Value cannot be null.";
})();

System.ArgumentNullException.prototype.$ctor$1 = function(paramName) {
	this.$super.$ctor$3(System.ArgumentNullException.DefaultMessage, paramName);
	return this;
};

System.Text.StringBuilder.prototype.Append$5 = function(value, startIndex, count) {
	var V_2 = value != null;
	if (!V_2) {
		if (startIndex) {
			var R_1 = count == 0;
		}
		else {
			R_1 = 1;
		}
		V_2 = R_1;
		if (!V_2) {
			throw new System.ArgumentNullException().$ctor$1("value");
		}
		return this;
	}
	if ((count >= 0) && (startIndex >= 0)) {
		R_1 = startIndex <= (value.length - count);
	}
	else {
		R_1 = 0;
	}
	V_2 = R_1;
	if (!V_2) {
		throw new System.ArgumentOutOfRangeException().$ctor$0();
	}
	var V_0 = startIndex;
	while (true) {
		V_2 = V_0 < (startIndex + count);
		if (!V_2) {
			break;
		}
		this.Append$1(value.charAt(V_0));
		V_0 = V_0 + 1;
	}
	return this;
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestStringBuilderAppend5 = function() {
	var sb = new System.Text.StringBuilder().$ctor();
	sb.Append$5("value", 1, 1);
};
