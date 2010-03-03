Conditionals.prototype.SimpleIfAnd = function(x, y) {
	var ret = 0;
	if (x) {
		var R_1 = !y;
	}
	else {
		R_1 = 1;
	}
	var CS$4$0001 = R_1;
	if (!CS$4$0001) {
		ret = 1;
	}
	else {
		ret = 2;
	}
	ret = ret + 1;
	return ret;
};
