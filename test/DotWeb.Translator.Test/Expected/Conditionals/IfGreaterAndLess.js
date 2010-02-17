Conditionals.prototype.IfGreaterAndLess = function(x, y) {
	var ret = 0;
	if ((x > 1) && (y < 1)) {
		ret = 1;
	}
	else {
		ret = 2;
	}
	ret = ret + 1;
	return ret;
};
