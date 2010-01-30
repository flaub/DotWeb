Conditions.prototype.IfOrOr = function(/*System.Boolean*/ x, /*System.Boolean*/ y, /*System.Boolean*/ z) {
	var ret = 0;
	if ((x) || (y) || (z)) {
		ret = 1;
	}
	else {
		ret = 2;
	}
	ret = ret + 1;
	return ret;
};
