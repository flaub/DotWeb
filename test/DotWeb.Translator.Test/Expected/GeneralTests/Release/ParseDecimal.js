H8.GeneralTests.prototype.ParseDecimal = function(str, ptr) {
	var p = ptr;
	var n = 0;
	while (true) {
		var ch = str.charAt(p);
		if ((ch >= '0') && ('9' >= ch)) {
			n = ((n * 10) + ch) - 48;
			p = p + 1;
		}
		else {
			break;
		}
	}
	if (p == ptr) {
		return -1;
	}
	return n;
};
