Loops.prototype.BreakInWhile = function(a) {
	while (a < 100) {
		if (a == 12) {
			System.Console.WriteLine("break");
			break;
		}
		System.Console.WriteLine("else");
		a = a - 1;
	}
	System.Console.WriteLine(a);
};
