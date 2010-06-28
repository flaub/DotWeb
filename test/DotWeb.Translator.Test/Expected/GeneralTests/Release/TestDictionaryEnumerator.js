$Class(null, 'System.Collections.Generic', 'EqualityComparer$1');

System.Collections.Generic.EqualityComparer$1.prototype.$ctor = function() {
	return this;
};

$Class(System.Collections.Generic.EqualityComparer$1, 'System.Collections.Generic', 'EqualityComparer$1_DefaultComparer');

System.Collections.Generic.EqualityComparer$1_DefaultComparer.prototype.$ctor = function() {
	System.Collections.Generic.EqualityComparer$1.prototype.$ctor.call(this);
	return this;
};

System.Collections.Generic.EqualityComparer$1.get_Default = function() {
	return new System.Collections.Generic.EqualityComparer$1_DefaultComparer().$ctor();
};

//>System.Collections.Generic.Dictionary$2

//>System.Collections.Generic.Dictionary$2.InitArrays

//>System.Exception

//>System.SystemException

$Class(System.SystemException, 'System', 'ArgumentException', { _ParamName_k__BackingField: null });

System.ArgumentException.prototype.set_ParamName = function(value) {
	this._ParamName_k__BackingField = value;
};

//>System.ArgumentException.$ctor$3

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException', { _ActualValue_k__BackingField: null });

(function() {
	System.ArgumentOutOfRangeException.RangeMessage = "Specified argument was out of the range of valid values.";
})();

//>System.ArgumentOutOfRangeException.$ctor$1

//>System.Collections.Generic.Dictionary$2.Init

System.Collections.Generic.Dictionary$2.prototype.$ctor$3 = function(capacity) {
	this.Init(capacity, null);
	return this;
};

$Class(null, 'System.Text', 'StringBuilder', { value: null });

//>System.Text.StringBuilder.$ctor

//>System.Text.StringBuilder.Append$0

//>System.FormatException

//>System.Text.StringBuilder.toString

$Class(null, 'System.Collections.Generic', 'Dictionary$2_Enumerator', { dictionary: null, next: 0, stamp: 0, current: null });

System.Collections.Generic.Dictionary$2_Enumerator.prototype.$ctor = function(dictionary) {
	this.dictionary = dictionary;
	this.stamp = dictionary.generation;
	return this;
};

System.Collections.Generic.Dictionary$2.prototype.GetEnumerator = function() {
	return new System.Collections.Generic.Dictionary$2_Enumerator().$ctor(this);
};

$Class(System.SystemException, 'System', 'InvalidOperationException');

System.InvalidOperationException.prototype.$ctor$1 = function(message) {
	System.SystemException.prototype.$ctor$1.call(this, message);
	return this;
};

System.Collections.Generic.Dictionary$2_Enumerator.prototype.VerifyState = function() {
	var CS$4$0000 = this.dictionary.generation == this.stamp;
	if (!CS$4$0000) {
		throw new System.InvalidOperationException().$ctor$1("out of sync");
	}
};

$Class(null, 'System.Collections.Generic', 'KeyValuePair$2', { _Key_k__BackingField: null, _Value_k__BackingField: null });

System.Collections.Generic.KeyValuePair$2.prototype.set_Key = function(value) {
	this._Key_k__BackingField = value;
};

System.Collections.Generic.KeyValuePair$2.prototype.set_Value = function(value) {
	this._Value_k__BackingField = value;
};

System.Collections.Generic.KeyValuePair$2.prototype.$ctor = function(key, value) {
	this.set_Key(key);
	this.set_Value(value);
	return this;
};

System.Collections.Generic.Dictionary$2_Enumerator.prototype.MoveNext = function() {
	this.VerifyState();
	var CS$4$0001 = this.next >= 0;
	if (!CS$4$0001) {
		return false;
	}
	while (true) {
		CS$4$0001 = this.next < this.dictionary.touchedSlots;
		if (!CS$4$0001) {
			break;
		}
		var D_0 = this.next;
		var CS$0$0002 = D_0;
		this.next = D_0 + 1;
		var cur = CS$0$0002;
		var link = this.dictionary.linkSlots[cur];
		CS$4$0001 = (link.HashCode & -2147483648) == 0;
		if (!CS$4$0001) {
			var key = this.dictionary.keySlots[cur];
			var value = this.dictionary.valueSlots[cur];
			this.current = new System.Collections.Generic.KeyValuePair$2().$ctor(key, value);
			return true;
		}
	}
	this.next = -1;
	return false;
};

System.Collections.Generic.Dictionary$2_Enumerator.prototype.get_Current = function() {
	return this.current;
};

System.Collections.Generic.KeyValuePair$2.prototype.get_Key = function() {
	return this._Key_k__BackingField;
};

System.Collections.Generic.KeyValuePair$2.prototype.get_Value = function() {
	return this._Value_k__BackingField;
};

System.Collections.Generic.KeyValuePair$2.prototype.toString = function() {
	var CS$0$0001 = $Array(5, null);
	CS$0$0001[0] = "[";
	var R_2 = 1;
	var R_1 = CS$0$0001;
	if (!this.get_Key()) {
		var R_3 = String.empty;
	}
	else {
		var CS$0$0002 = this.get_Key();
		R_3 = CS$0$0002.toString();
	}
	R_1[R_2] = R_3;
	CS$0$0001[2] = ", ";
	R_2 = 3;
	R_1 = CS$0$0001;
	if (!this.get_Value()) {
		R_3 = String.empty;
	}
	else {
		var CS$0$0003 = this.get_Value();
		R_3 = CS$0$0003.toString();
	}
	R_1[R_2] = R_3;
	CS$0$0001[4] = "]";
	return CS$0$0001.join('');
};

System.Collections.Generic.Dictionary$2_Enumerator.prototype.Dispose = function() {
	this.dictionary = null;
};

System.Collections.Generic.Dictionary$2.prototype.toString = function() {
	var result = new System.Text.StringBuilder().$ctor();
	result.Append$0("{");
	var isFirst = true;
	var CS$5$0001 = this.GetEnumerator();
	try {
		while (true) {
			var CS$4$0002 = CS$5$0001.MoveNext();
			if (!CS$4$0002) {
				break;
			}
			var item = CS$5$0001.get_Current();
			CS$4$0002 = !isFirst;
			if (!CS$4$0002) {
				isFirst = false;
			}
			else {
				result.Append$0(", ");
			}
			result.Append$1(item.get_Key());
			result.Append$0(": ");
			result.Append$1(item.get_Value());
		}
	}
	finally {
		CS$4$0002 = CS$5$0001 == null;
		if (!CS$4$0002) {
			CS$5$0001.Dispose();
		}
	}
	result.Append$0("}");
	return result.toString();
};

//>System.Text.StringBuilder.Append$1

//>System.ArgumentException.$ctor$1

//>System.ArgumentOutOfRangeException.$ctor$0

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

System.Exception.prototype.get_InnerException = function() {
	return this._InnerException_k__BackingField;
};

System.Text.StringBuilder.prototype.AppendLine$0 = function() {
	return this;
};

//>System.Exception.toString

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

//>System.Console.WriteLine$0 

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.TestDictionaryEnumerator = function() {
	var dict = new System.Collections.Generic.Dictionary$2().$ctor$3(1);
	System.Console.WriteLine$0(dict);
};
