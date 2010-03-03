$Class(null, 'System.Text', 'StringBuilder');

System.Text.StringBuilder.prototype.$ctor = function() {
	this.value = "";
	return this;
};

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

$Class(System.SystemException, 'System', 'FormatException');

System.FormatException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

System.Text.StringBuilder.prototype.toString = function() {
	return this.value;
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
			this.value = this.value + value;
			V_0 = this;
		}
	}
	return V_0;
};

System.Text.StringBuilder.prototype.Append$1 = function(value) {
	return this.Append$0(value.toString());
};

$Class(System.SystemException, 'System', 'ArgumentException');

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException');

System.ArgumentOutOfRangeException.get_RangeMessage = function() {
	return "Specified argument was out of the range of valid values.";
};

System.ArgumentException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

System.ArgumentOutOfRangeException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1(System.ArgumentOutOfRangeException.get_RangeMessage());
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
		var V_1 = this;
	}
	else {
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
		V_1 = this;
	}
	return V_1;
};

$Class(null, 'System', 'String_FormatSpecifier');

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
		var V_3 = -1;
	}
	else {
		this.ptr = V_0;
		V_3 = V_1;
	}
	return V_3;
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
		var V_0 = this;
	}
	else {
		V_0 = this.substring(startIndex, startIndex + length);
	}
	return V_0;
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
	var V_2 = new Array(1);
	V_2[0] = arg0;
	var V_0 = String.formatHelper(null, format, V_2);
	return V_0.toString();
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

$Class(null, 'H8', 'GeneralTests');

H8.GeneralTests.prototype.StringFormat = function() {
	System.Console.WriteLine$1(String.format$0("Test: {0}", "arg0"));
};
