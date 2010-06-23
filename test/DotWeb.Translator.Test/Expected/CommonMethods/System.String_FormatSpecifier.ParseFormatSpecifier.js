System.String_FormatSpecifier.prototype.ParseFormatSpecifier = function() {
	try {
		this.n = this.ParseDecimal();
		var CS$4$0000 = this.n >= 0;
		if (!CS$4$0000) {
			throw new System.FormatException().$ctor$1("Invalid argument specifier.");
		}
		CS$4$0000 = this.str.charAt(this.ptr) != ',';
		if (!CS$4$0000) {
			this.ptr = this.ptr + 1;
			while (true) {
				CS$4$0000 = this.IsWhiteSpace();
				if (!CS$4$0000) {
					break;
				}
				this.ptr = this.ptr + 1;
			}
			var start = this.ptr;
			var len = this.ptr - start;
			this.format = this.str._Substring$1(start, len);
			this.left_align = this.str.charAt(this.ptr) == '-';
			CS$4$0000 = !this.left_align;
			if (!CS$4$0000) {
				this.ptr = this.ptr + 1;
			}
			this.width = this.ParseDecimal();
			CS$4$0000 = this.width >= 0;
			if (!CS$4$0000) {
				throw new System.FormatException().$ctor$1("Invalid width specifier.");
			}
		}
		else {
			this.width = 0;
			this.left_align = false;
			this.format = "";
		}
		CS$4$0000 = this.str.charAt(this.ptr) != ':';
		if (!CS$4$0000) {
			var D_0 = this.ptr + 1;
			var CS$0$0001 = D_0;
			this.ptr = D_0;
			start = CS$0$0001;
			while (true) {
				CS$4$0000 = this.str.charAt(this.ptr) != '}';
				if (!CS$4$0000) {
					break;
				}
				this.ptr = this.ptr + 1;
			}
			this.format = this.format + this.str._Substring$1(start, this.ptr - start);
		}
		else {
			this.format = null;
		}
		var D_1 = this.ptr;
		CS$0$0001 = D_1;
		this.ptr = D_1 + 1;
		CS$4$0000 = this.str.charAt(CS$0$0001) == '}';
		if (!CS$4$0000) {
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
