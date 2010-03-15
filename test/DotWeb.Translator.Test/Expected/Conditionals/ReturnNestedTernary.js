Conditionals.prototype.ReturnNestedTernary = function(a) {
	if (a >= 0) {
		if (a <= 0) {
			return 42;
		}
		return 10;
	}
	if (a >= 100) {
		return 24;
	}
	return 12;
};
