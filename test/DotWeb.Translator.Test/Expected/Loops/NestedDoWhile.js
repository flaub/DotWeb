Loops.prototype.NestedDoWhile = function(a) {
	while (a < 100) {
		do {
			a = a * 10;
		} while (a < 10);
		a = a + 2;
	}
};
