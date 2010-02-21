Loops.prototype.WhileBreakContinue = function() {
	var i = 0;
	while (true) {
		System.Console.WriteLine$1("top");
		if (i == 10) {
			System.Console.WriteLine$1("continue");
			continue;
		}
		if (i == 20) {
			break;
		}
		System.Console.WriteLine$1("bottom");
		i = i + 1;
	}
	System.Console.WriteLine$1("break");
	System.Console.WriteLine$1("exit");
};
