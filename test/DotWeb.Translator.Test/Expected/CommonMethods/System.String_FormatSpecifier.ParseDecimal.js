System.String_FormatSpecifier.prototype.ParseDecimal = function() {
	var p = this.ptr;
	var n = 0;
	while (true) {
		var CS$4$0001 = true;
		var ch = this.str.charCodeAt(p);
		if (ch >= 48) {
			var R_1 = 57 >= ch;
		}
		else {
			R_1 = 0;
		}
		CS$4$0001 = R_1;
		if (!CS$4$0001) {
			break;
		}
		n = ((n * 10) + ch) - 48;
		p = p + 1;
	}
	CS$4$0001 = p != this.ptr;
	if (!CS$4$0001) {
		return -1;
	}
	this.ptr = p;
	return n;
};
