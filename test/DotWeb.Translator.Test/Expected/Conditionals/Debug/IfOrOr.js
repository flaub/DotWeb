Conditionals.prototype.IfOrOr = function(x, y, z) {
	var ret = 0;
	if (!x && !y) {
		var R_1 = !z;
	}
	else {
		R_1 = 0;
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
