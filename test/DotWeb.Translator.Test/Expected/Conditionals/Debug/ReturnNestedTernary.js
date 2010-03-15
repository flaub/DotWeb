Conditionals.prototype.ReturnNestedTernary = function(a) {
	if (a >= 0) {
		if (a <= 0) {
			var R_1 = 42;
		}
		else {
			R_1 = 10;
		}
	}
	else {
		if (a >= 100) {
			R_1 = 24;
		}
		else {
			R_1 = 12;
		}
	}
	return R_1;
};
