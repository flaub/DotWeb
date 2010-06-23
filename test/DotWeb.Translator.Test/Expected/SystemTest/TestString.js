$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

//>System.Console.WriteLine$0 

//>System.Exception

//>System.SystemException

$Class(System.SystemException, 'System', 'ArgumentException', { _ParamName_k__BackingField: null });

System.ArgumentException.prototype.set_ParamName = function(value) {
	this._ParamName_k__BackingField = value;
};

System.ArgumentException.prototype.$ctor$3 = function(message, paramName) {
	this.$super.$ctor$1(message);
	this.set_ParamName(paramName);
	return this;
};

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException', { _ActualValue_k__BackingField: null });

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
	var CS$4$0001 = startIndex != 0;
	if (!CS$4$0001) {
		return this;
	}
	if (startIndex >= 0) {
		var R_1 = startIndex <= this.length;
	}
	else {
		R_1 = 0;
	}
	CS$4$0001 = R_1;
	if (!CS$4$0001) {
		throw new System.ArgumentOutOfRangeException().$ctor$1("startIndex");
	}
	return this.substring(startIndex, this.length);
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestString = function() {
	var str = "This is a test";
	System.Console.WriteLine$0(str.length);
	var test = str._Substring$0(9);
	System.Console.WriteLine$1(test);
};
