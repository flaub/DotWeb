Conditionals.prototype.SimpleIfOrNot = function(x, y) {
	var ret = 0;
	if (x || !y) {
		ret = 1;
	}
	else {
		ret = 2;
	}
	return ret + 1;
};
