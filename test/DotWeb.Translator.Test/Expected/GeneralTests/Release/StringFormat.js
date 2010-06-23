$Class(null, 'System.Text', 'StringBuilder', { value: null });

//>System.Text.StringBuilder.$ctor

//>System.Exception

//>System.SystemException

//>System.FormatException

//>System.Text.StringBuilder.toString

//>System.Text.StringBuilder.Append$0

//>System.Exception.get_Message

System.Exception.prototype.get_InnerException = function() {
	return this._InnerException_k__BackingField;
};

System.Text.StringBuilder.prototype.AppendLine$0 = function() {
	return this;
};

//>System.Exception.toString

//>System.Text.StringBuilder.Append$1

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

$Class(null, 'System', 'String_FormatSpecifier', { str: null, ptr: 0, n: 0, width: 0, left_align: 0, format: null });

//>System.String_FormatSpecifier.ParseDecimal

//>System.String_FormatSpecifier.IsWhiteSpace

System.ArgumentOutOfRangeException.prototype.$ctor$3 = function(paramName, message) {
	this.$super.$ctor$3(message, paramName);
	return this;
};

(function() {
	String.empty = "";
})();

//>String._Substring$1

$Class(System.SystemException, 'System', 'IndexOutOfRangeException');

System.IndexOutOfRangeException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1("Array index is out of range.");
	return this;
};

//>System.String_FormatSpecifier.ParseFormatSpecifier

System.String_FormatSpecifier.prototype.$ctor = function(str, ptr) {
	this.str = str;
	this.ptr = ptr;
	this.ParseFormatSpecifier();
	return this;
};

//>System.Text.StringBuilder.Append$3

//>String.formatHelper

//>String.format$0

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.StringFormat = function() {
	System.Console.WriteLine$1(String.format$0("Test: {0}", "arg0"));
};
