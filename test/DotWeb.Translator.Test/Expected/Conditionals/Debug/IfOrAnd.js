Conditionals.prototype.IfOrAnd = function(x, y, z) {
	var ret = 0;
	if (!x) {
		if (y) {
			var R_1 = !z;
		}
		else {
			R_1 = 1;
		}
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
	var CS$1$0000 = ret;
	return CS$1$0000;
};
