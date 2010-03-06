$Class(null, 'System', 'Console');

System.Console.WriteLine$0 = function(value) {
	console.log(value);
};

$Class(null, 'System', 'Exception');

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

$Class(System.SystemException, 'System', 'ArgumentException');

System.ArgumentException.prototype.set_ParamName = function(value) {
	this._ParamName_k__BackingField = value;
};

System.ArgumentException.prototype.$ctor$3 = function(message, paramName) {
	this.$super.$ctor$1(message);
	this.set_ParamName(paramName);
	return this;
};

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException');

(function() {
	System.ArgumentOutOfRangeException.RangeMessage = "Specified argument was out of the range of valid values.";
})();

System.ArgumentOutOfRangeException.prototype.$ctor$1 = function(paramName) {
	this.$super.$ctor$3(System.ArgumentOutOfRangeException.RangeMessage, paramName);
	return this;
};

(function() {
	String.empty = "";
})();

String.prototype._Substring$0 = function(startIndex) {
	var V_1 = startIndex != 0;
	if (!V_1) {
		var V_0 = this;
	}
	else {
		if (startIndex >= 0) {
			var R_1 = startIndex <= this.length;
		}
		else {
			R_1 = 0;
		}
		V_1 = R_1;
		if (!V_1) {
			throw new System.ArgumentOutOfRangeException().$ctor$1("startIndex");
		}
		V_0 = this.substring(startIndex, this.length);
	}
	return V_0;
};

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestString = function() {
	var str = "This is a test";
	System.Console.WriteLine$0(str.length);
	var test = str._Substring$0(9);
	System.Console.WriteLine$1(test);
};
