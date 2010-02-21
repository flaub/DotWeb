Loops.prototype.BreakInWhile = function(a) {
	while (a < 100) {
		if (a == 12) {
			System.Console.WriteLine$1("break");
			break;
		}
		System.Console.WriteLine$1("else");
		a = a - 1;
	}
	System.Console.WriteLine$0(a);
};
