Conditionals.prototype.IfLessAndGreater = function(/*System.Int32*/ x, /*System.Int32*/ y) {
	var ret = 0;
	if ((x < 1) && (y > 1)) {
		ret = 1;
	}
	else {
		ret = 2;
	}
	ret = ret + 1;
	return ret;
};
