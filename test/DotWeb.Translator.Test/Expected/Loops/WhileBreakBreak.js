Loops.prototype.WhileBreakBreak = function() {
	var i = 0;
	while (true) {
		System.Console.WriteLine$1("top");
		if (i == 10) {
			System.Console.WriteLine$1("break1");
			break;
		}
		if (i == 5) {
			System.Console.WriteLine$1("break2");
			break;
		}
		System.Console.WriteLine$1("bottom");
		i = i + 1;
	}
	System.Console.WriteLine$1("exit");
};
