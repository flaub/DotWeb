Loops.prototype.NestedDoWhile = function(/*System.Int32*/ a) {
	while (a < 100) {
		do {
			a = a * 10;
		} while(a < 10);
		a = a + 2;
	}
};
