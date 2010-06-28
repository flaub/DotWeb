$Class(null, 'System.Text', 'StringBuilder', { value: null });

//>System.Text.StringBuilder.$ctor

//>System.Text.StringBuilder.toString

//>System.Text.StringBuilder.Append$0

//>System.Text.StringBuilder.Append$1

//>System.Exception

//>System.SystemException

$Class(System.SystemException, 'System', 'ArgumentException', { _ParamName_k__BackingField: null });

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

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestStringBuilderAppend5 = function() {
	var sb = new System.Text.StringBuilder().$ctor();
	sb.Append$5("value", 1, 1);
};
