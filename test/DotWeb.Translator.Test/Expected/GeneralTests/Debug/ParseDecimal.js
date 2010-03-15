H8.GeneralTests.prototype.ParseDecimal = function(str, ptr) {
	var p = ptr;
	var n = 0;
	while (true) {
		var CS$4$0001 = true;
		var ch = str.charAt(p);
		if (ch >= '0') {
			var R_1 = '9' >= ch;
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
	CS$4$0001 = p != ptr;
	if (!CS$4$0001) {
		return -1;
	}
	return n;
};
