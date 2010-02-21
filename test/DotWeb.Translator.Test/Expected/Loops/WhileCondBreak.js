Loops.prototype.WhileCondBreak = function() {
	var i = 0;
	while (i < 9) {
		System.Console.WriteLine$1("top");
		if (i == 10) {
			System.Console.WriteLine$1("break");
			break;
		}
		System.Console.WriteLine$1("loop");
		i = i + 1;
	}
	System.Console.WriteLine$1("exit");
};
