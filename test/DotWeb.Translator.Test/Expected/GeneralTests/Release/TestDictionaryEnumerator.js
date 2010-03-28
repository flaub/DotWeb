$Class(null, 'System.Collections.Generic', 'EqualityComparer$1');

System.Collections.Generic.EqualityComparer$1.prototype.$ctor = function() {
	return this;
};

$Class(System.Collections.Generic.EqualityComparer$1, 'System.Collections.Generic', 'EqualityComparer$1_DefaultComparer');

System.Collections.Generic.EqualityComparer$1_DefaultComparer.prototype.$ctor = function() {
	this.$super.$ctor();
	return this;
};

System.Collections.Generic.EqualityComparer$1.get_Default = function() {
	return new System.Collections.Generic.EqualityComparer$1_DefaultComparer().$ctor();
};

$Class(null, 'System.Collections.Generic', 'Dictionary$2', { table: 0, linkSlots: null, keySlots: null, valueSlots: null, touchedSlots: 0, emptySlot: 0, count: 0, threshold: 0, hcp: null, generation: 0 });

(function() {
	System.Collections.Generic.Dictionary$2.INITIAL_SIZE = 10;
	System.Collections.Generic.Dictionary$2.DEFAULT_LOAD_FACTOR = 0.9;
	System.Collections.Generic.Dictionary$2.NO_SLOT = -1;
	System.Collections.Generic.Dictionary$2.HASH_FLAG = -2147483648;
	var D_0 = [11, 19, 37, 73, 109, 163, 251, 367, 557, 823, 1237, 1861, 2777, 4177, 6247, 9371, 14057, 21089, 31627, 47431, 71143, 106721, 160073, 240101, 360163, 540217, 810343, 1215497, 1823231, 2734867, 4102283, 6153409, 9230113, 13845163];
	System.Collections.Generic.Dictionary$2.primeTable = D_0;
})();

System.Collections.Generic.Dictionary$2.prototype.InitArrays = function(size) {
	this.table = $Array(size, 0);
	this.linkSlots = $Array(size, null);
	this.emptySlot = -1;
	this.keySlots = $Array(size, null);
	this.valueSlots = $Array(size, null);
	this.touchedSlots = 0;
	this.threshold = Math.floor(this.table.length * 0.9);
	if (!this.threshold) {
		var R_1 = this.table.length <= 0;
	}
	else {
		R_1 = 1;
	}
	var V_0 = R_1;
	if (!V_0) {
		this.threshold = 1;
	}
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

System.Collections.Generic.Dictionary$2.prototype.Init = function(capacity, hcp) {
	var V_0 = capacity >= 0;
	if (!V_0) {
		throw new System.ArgumentOutOfRangeException().$ctor$1("capacity");
	}
	var R_1 = this;
	if (!hcp) {
		var R_2 = System.Collections.Generic.EqualityComparer$1.get_Default();
	}
	else {
		R_2 = hcp;
	}
	R_1.hcp = R_2;
	V_0 = capacity != 0;
	if (!V_0) {
		capacity = 10;
	}
	capacity = Math.floor(capacity / 0.9) + 1;
	this.InitArrays(capacity);
	this.generation = 0;
};

System.Collections.Generic.Dictionary$2.prototype.$ctor$3 = function(capacity) {
	this.Init(capacity, null);
	return this;
};

$Class(null, 'System.Text', 'StringBuilder', { value: null });

System.Text.StringBuilder.prototype.$ctor = function() {
	this.value = "";
	return this;
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

$Class(System.SystemException, 'System', 'FormatException');

System.FormatException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

System.Text.StringBuilder.prototype.toString = function() {
	return this.value;
};

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
	this.$super.$ctor$1(message);
	return this;
};

System.Collections.Generic.Dictionary$2_Enumerator.prototype.VerifyState = function() {
	var V_0 = this.dictionary.generation == this.stamp;
	if (!V_0) {
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
	var V_5 = this.next >= 0;
	if (!V_5) {
		return false;
	}
	while (true) {
		V_5 = this.next < this.dictionary.touchedSlots;
		if (!V_5) {
			break;
		}
		var D_0 = this.next;
		var V_6 = D_0;
		this.next = D_0 + 1;
		var V_0 = V_6;
		var V_1 = this.dictionary.linkSlots[V_0];
		V_5 = (V_1.HashCode & -2147483648) == 0;
		if (!V_5) {
			var V_2 = this.dictionary.keySlots[V_0];
			var V_3 = this.dictionary.valueSlots[V_0];
			this.current = new System.Collections.Generic.KeyValuePair$2().$ctor(V_2, V_3);
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
	var V_1 = $Array(5, null);
	V_1[0] = "[";
	var R_2 = 1;
	var R_1 = V_1;
	if (!this.get_Key()) {
		var R_3 = String.empty;
	}
	else {
		var V_2 = this.get_Key();
		R_3 = V_2.toString();
	}
	R_1[R_2] = R_3;
	V_1[2] = ", ";
	R_2 = 3;
	R_1 = V_1;
	if (!this.get_Value()) {
		R_3 = String.empty;
	}
	else {
		var V_3 = this.get_Value();
		R_3 = V_3.toString();
	}
	R_1[R_2] = R_3;
	V_1[4] = "]";
	return V_1.join('');
};

System.Collections.Generic.Dictionary$2_Enumerator.prototype.Dispose = function() {
	this.dictionary = null;
};

System.Collections.Generic.Dictionary$2.prototype.toString = function() {
	var V_0 = new System.Text.StringBuilder().$ctor();
	V_0.Append$0("{");
	var V_1 = true;
	var V_4 = this.GetEnumerator();
	try {
		while (true) {
			var V_5 = V_4.MoveNext();
			if (!V_5) {
				break;
			}
			var V_2 = V_4.get_Current();
			V_5 = !V_1;
			if (!V_5) {
				V_1 = false;
			}
			else {
				V_0.Append$0(", ");
			}
			V_0.Append$1(V_2.get_Key());
			V_0.Append$0(": ");
			V_0.Append$1(V_2.get_Value());
		}
	}
	finally {
		V_5 = V_4 == null;
		if (!V_5) {
			V_4.Dispose();
		}
	}
	V_0.Append$0("}");
	return V_0.toString();
};

System.Text.StringBuilder.prototype.Append$1 = function(value) {
	return this.Append$0(value.toString());
};

System.ArgumentException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

System.ArgumentOutOfRangeException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1(System.ArgumentOutOfRangeException.RangeMessage);
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

$Class(null, 'System', 'String_FormatSpecifier', { str: null, ptr: 0, n: 0, width: 0, left_align: 0, format: null });

System.String_FormatSpecifier.prototype.ParseDecimal = function() {
	var V_0 = this.ptr;
	var V_1 = 0;
	while (true) {
		var V_4 = true;
		var V_2 = this.str.charCodeAt(V_0);
		if (V_2 >= 48) {
			var R_1 = 57 >= V_2;
		}
		else {
			R_1 = 0;
		}
		V_4 = R_1;
		if (!V_4) {
			break;
		}
		V_1 = ((V_1 * 10) + V_2) - 48;
		V_0 = V_0 + 1;
	}
	V_4 = V_0 != this.ptr;
	if (!V_4) {
		return -1;
	}
	this.ptr = V_0;
	return V_1;
};

System.String_FormatSpecifier.prototype.IsWhiteSpace = function() {
	var V_0 = this.str.charCodeAt(this.ptr);
	if ((((V_0 < 9) || (V_0 > 13)) && (V_0 != 32)) && (V_0 != 133)) {
		var R_1 = V_0 == 8287;
	}
	else {
		R_1 = 1;
	}
	return R_1;
};

System.ArgumentOutOfRangeException.prototype.$ctor$3 = function(paramName, message) {
	this.$super.$ctor$3(message, paramName);
	return this;
};

(function() {
	String.empty = "";
})();

String.prototype._Substring$1 = function(startIndex, length) {
	var V_1 = length >= 0;
	if (!V_1) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("length", "Cannot be negative.");
	}
	V_1 = startIndex >= 0;
	if (!V_1) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("startIndex", "Cannot be negative.");
	}
	V_1 = startIndex <= this.length;
	if (!V_1) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("startIndex", "Cannot exceed length of string.");
	}
	V_1 = startIndex <= (this.length - length);
	if (!V_1) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("length", "startIndex + length > this.length");
	}
	if (!startIndex) {
		var R_1 = length != this.length;
	}
	else {
		R_1 = 1;
	}
	V_1 = R_1;
	if (!V_1) {
		return this;
	}
	return this.substring(startIndex, startIndex + length);
};

$Class(System.SystemException, 'System', 'IndexOutOfRangeException');

System.IndexOutOfRangeException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1("Array index is out of range.");
	return this;
};

System.String_FormatSpecifier.prototype.ParseFormatSpecifier = function() {
	try {
		this.n = this.ParseDecimal();
		var V_2 = this.n >= 0;
		if (!V_2) {
			throw new System.FormatException().$ctor$1("Invalid argument specifier.");
		}
		V_2 = this.str.charAt(this.ptr) != ',';
		if (!V_2) {
			this.ptr = this.ptr + 1;
			while (true) {
				V_2 = this.IsWhiteSpace();
				if (!V_2) {
					break;
				}
				this.ptr = this.ptr + 1;
			}
			var V_0 = this.ptr;
			var V_1 = this.ptr - V_0;
			this.format = this.str._Substring$1(V_0, V_1);
			this.left_align = this.str.charAt(this.ptr) == '-';
			V_2 = !this.left_align;
			if (!V_2) {
				this.ptr = this.ptr + 1;
			}
			this.width = this.ParseDecimal();
			V_2 = this.width >= 0;
			if (!V_2) {
				throw new System.FormatException().$ctor$1("Invalid width specifier.");
			}
		}
		else {
			this.width = 0;
			this.left_align = false;
			this.format = "";
		}
		V_2 = this.str.charAt(this.ptr) != ':';
		if (!V_2) {
			var D_0 = this.ptr + 1;
			var V_3 = D_0;
			this.ptr = D_0;
			V_0 = V_3;
			while (true) {
				V_2 = this.str.charAt(this.ptr) != '}';
				if (!V_2) {
					break;
				}
				this.ptr = this.ptr + 1;
			}
			this.format = this.format + this.str._Substring$1(V_0, this.ptr - V_0);
		}
		else {
			this.format = null;
		}
		var D_1 = this.ptr;
		V_3 = D_1;
		this.ptr = D_1 + 1;
		V_2 = this.str.charAt(V_3) == '}';
		if (!V_2) {
			throw new System.FormatException().$ctor$1("Missing end characeter.");
		}
	}
	catch (__ex__) {
		if (__ex__ instanceof System.IndexOutOfRangeException) {
			throw new System.FormatException().$ctor$1("Input string was not in a correct format.");
		}
		else {
			throw __ex__;
		}
	}
};

System.String_FormatSpecifier.prototype.$ctor = function(str, ptr) {
	this.str = str;
	this.ptr = ptr;
	this.ParseFormatSpecifier();
	return this;
};

System.Text.StringBuilder.prototype.Append$3 = function(value, repeatCount) {
	var V_0 = 0;
	while (true) {
		var V_2 = V_0 < repeatCount;
		if (!V_2) {
			break;
		}
		this.Append$1(value);
		V_0 = V_0 + 1;
	}
	return this;
};

String.formatHelper = function(result, format, args) {
	var V_8 = format != null;
	if (!V_8) {
		throw new System.ArgumentNullException().$ctor$1("format");
	}
	V_8 = args != null;
	if (!V_8) {
		throw new System.ArgumentNullException().$ctor$1("args");
	}
	V_8 = result != null;
	if (!V_8) {
		result = new System.Text.StringBuilder().$ctor();
	}
	var V_0 = 0;
	var V_1 = V_0;
	while (true) {
		V_8 = V_0 < format.length;
		if (!V_8) {
			break;
		}
		var D_0 = V_0;
		V_0 = D_0 + 1;
		var V_2 = format.charAt(D_0);
		V_8 = V_2 != '{';
		if (!V_8) {
			result.Append$5(format, V_1, (V_0 - V_1) - 1);
			V_8 = format.charAt(V_0) != '{';
			if (!V_8) {
				var D_2 = V_0;
				V_0 = D_2 + 1;
				V_1 = D_2;
				continue;
			}
			var V_3 = new System.String_FormatSpecifier().$ctor(format, V_0);
			V_0 = V_3.ptr;
			V_8 = V_3.n < args.length;
			if (!V_8) {
				throw new System.FormatException().$ctor$1("Index (zero based) must be greater than or equal to zero and less than the size of the argument list.");
			}
			var V_4 = args[V_3.n];
			V_8 = V_4 != null;
			if (!V_8) {
				var V_5 = "";
			}
			V_5 = V_4.toString();
			V_8 = V_3.width <= V_5.length;
			if (!V_8) {
				var V_6 = V_3.width - V_5.length;
				V_8 = !V_3.left_align;
				if (!V_8) {
					result.Append$0(V_5);
					result.Append$3(' ', V_6);
				}
				else {
					result.Append$3(' ', V_6);
					result.Append$0(V_5);
				}
			}
			else {
				result.Append$0(V_5);
			}
			V_1 = V_0;
			V_8 = R_1;
			if (!V_8) {
				result.Append$5(format, V_1, (V_0 - V_1) - 1);
				var D_1 = V_0;
				V_0 = D_1 + 1;
				V_1 = D_1;
			}
			else {
				V_8 = V_2 != '}';
				if (!V_8) {
					throw new System.FormatException().$ctor$1("Input string was not in a correct format.");
				}
			}
		}
		else {
			if ((V_2 == '}') && (V_0 < format.length)) {
				var R_1 = format.charAt(V_0) != '}';
			}
			else {
				R_1 = 1;
			}
		}
	}
	V_8 = V_1 >= format.length;
	if (!V_8) {
		result.Append$5(format, V_1, format.length - V_1);
	}
	return result;
};

String.format$0 = function(format, arg0) {
	var V_2 = $Array(1, null);
	V_2[0] = arg0;
	var V_0 = String.formatHelper(null, format, V_2);
	return V_0.toString();
};

System.Exception.prototype.get_Message = function() {
	var V_1 = this.message != null;
	if (!V_1) {
		this.message = String.format$0("Exception of type '{0}' was thrown.", this.$typename);
	}
	return this.message;
};

System.ArgumentException.prototype.get_ParamName = function() {
	return this._ParamName_k__BackingField;
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
		return V_0 + "\nParameter name: " + this.get_ParamName();
	}
	return V_0;
};

System.ArgumentOutOfRangeException.prototype.get_ActualValue = function() {
	return this._ActualValue_k__BackingField;
};

System.ArgumentOutOfRangeException.prototype.get_Message = function() {
	var V_0 = this.$super.get_Message();
	var V_3 = this.get_ActualValue() != null;
	if (!V_3) {
		return V_0;
	}
	var V_1 = "Actual value was " + this.get_ActualValue().toString();
	V_3 = V_0 != null;
	if (!V_3) {
		return V_1;
	}
	return V_0 + "\n" + V_1;
};

System.Exception.prototype.get_InnerException = function() {
	return this._InnerException_k__BackingField;
};

System.Text.StringBuilder.prototype.AppendLine$0 = function() {
	return this;
};

System.Exception.prototype.toString = function() {
	var V_0 = new System.Text.StringBuilder().$ctor();
	V_0.Append$0(this.$typename);
	V_0.Append$0(": ").Append$0(this.get_Message());
	var V_2 = this.get_InnerException() == null;
	if (!V_2) {
		V_0.Append$0(" ---> ").Append$0(this.get_InnerException().toString());
		V_0.AppendLine$0();
		V_0.Append$0("  --- End of inner exception stack trace ---");
	}
	return V_0.toString();
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

System.Console.WriteLine$0 = function(value) {
	System.Console.WriteLine$1(value.toString());
};

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.TestDictionaryEnumerator = function() {
	var dict = new System.Collections.Generic.Dictionary$2().$ctor$3(1);
	System.Console.WriteLine$0(dict);
};
