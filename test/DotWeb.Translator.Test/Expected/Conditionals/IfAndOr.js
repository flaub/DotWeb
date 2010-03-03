Conditionals.prototype.IfAndOr = function(x, y, z) {
	var ret = 0;
	if ((x && y) || z) {
		ret = 1;
	}
	else {
		ret = 2;
	}
	return ret + 1;
};
