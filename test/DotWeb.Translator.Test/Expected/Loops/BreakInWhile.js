Loops.prototype.BreakInWhile = function(/*System.Int32*/ a) {
	while(a < 100) {
		if (a == 12) {
			System.Console.WriteLine(a);
			break;
		}
		else {
			System.Console.WriteLine(a);
		}
		a = a - 1;
	}
	System.Console.WriteLine(a);
};
