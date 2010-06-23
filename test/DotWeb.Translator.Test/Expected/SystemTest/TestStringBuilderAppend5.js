$Class(null, 'System.Text', 'StringBuilder', { value: null });

//>System.Text.StringBuilder.$ctor

//>System.Text.StringBuilder.toString

//>System.Text.StringBuilder.Append$0

//>System.Text.StringBuilder.Append$1

//>System.Exception

//>System.SystemException

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

//>System.Text.StringBuilder.Append$5

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestStringBuilderAppend5 = function() {
	var sb = new System.Text.StringBuilder().$ctor();
	sb.Append$5("value", 1, 1);
};
