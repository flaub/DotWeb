H8.SourceTests.prototype.Cifuentes = function() {
	var loc0 = 5;
	var loc1 = loc0 * 5;
	if (loc0 < loc1) {
		loc0 = loc0 * loc1;
		if ((loc0 * 2) <= loc1) {
			loc1 = loc1 << 3;
		}
		else {
			loc0 = loc0 << 3;
		}
	}
	var loc2 = 0;
	while(loc2 < 10) {
		var loc3 = loc2;
		do {
			loc3 = loc3 + 1;
			console.log("{0}, {1}", loc2, loc3);
		} while(loc3 < 5);
		loc2 = loc2 + 1;
	}
	if ((loc0 < loc1) || ((loc1 * 2) > loc0)) {
		loc0 = (loc0 + loc1) - 10;
		loc1 = loc1 / 2;
	}
};

