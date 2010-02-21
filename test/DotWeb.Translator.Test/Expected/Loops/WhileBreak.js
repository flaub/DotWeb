Loops.prototype.WhileBreak = function() {
	var i = 0;
	while (true) {
		System.Console.WriteLine$1("top");
		if (i == 10) {
			break;
		}
		System.Console.WriteLine$1("loop");
		i = i + 1;
	}
	System.Console.WriteLine$1("break");
	System.Console.WriteLine$1("exit");
};
