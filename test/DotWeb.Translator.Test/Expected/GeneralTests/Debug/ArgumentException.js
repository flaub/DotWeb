//>System.Exception

//>System.SystemException

$Class(System.SystemException, 'System', 'ArgumentException', { _ParamName_k__BackingField: null });

System.ArgumentException.prototype.$ctor$0 = function() {
	System.SystemException.prototype.$ctor$1.call(this, "Value does not fall within the expected range.");
	return this;
};

$Class(null, 'System.Text', 'StringBuilder', { value: null });

//>System.Text.StringBuilder.$ctor

//>System.FormatException

//>System.Text.StringBuilder.toString

//>System.Text.StringBuilder.Append$0

System.Exception.prototype.get_InnerException = function() {
	return this._InnerException_k__BackingField;
};

System.Text.StringBuilder.prototype.AppendLine$0 = function() {
	return this;
};

//>System.Exception.toString

//>System.Text.StringBuilder.Append$1

//>System.ArgumentException.$ctor$1

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException', { _ActualValue_k__BackingField: null });

(function() {
	System.ArgumentOutOfRangeException.RangeMessage = "Specified argument was out of the range of valid values.";
})();

//>System.ArgumentOutOfRangeException.$ctor$0

System.ArgumentException.prototype.set_ParamName = function(value) {
	this._ParamName_k__BackingField = value;
};

//>System.ArgumentException.$ctor$3

//>System.ArgumentNullException

//>System.Text.StringBuilder.Append$5

$Class(null, 'System', 'String_FormatSpecifier', { str: null, ptr: 0, n: 0, width: 0, left_align: 0, format: null });

//>System.String_FormatSpecifier.ParseDecimal

//>System.String_FormatSpecifier.IsWhiteSpace

//>System.ArgumentOutOfRangeException.$ctor$3

(function() {
	String.empty = "";
})();

//>String._Substring$1

//>System.IndexOutOfRangeException

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

//>System.Exception.get_Message

System.ArgumentException.prototype.get_ParamName = function() {
	return this._ParamName_k__BackingField;
};

//>System.ArgumentException.get_Message

System.ArgumentOutOfRangeException.prototype.get_ActualValue = function() {
	return this._ActualValue_k__BackingField;
};

//>System.ArgumentOutOfRangeException.get_Message

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

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
		else {
			throw __ex__;
		}
	}
};
