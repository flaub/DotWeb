Loops.prototype.WhileBreakContinue = function() {
	var i = 0;
	while (true) {
		System.Console.WriteLine("top");
		if (i == 10) {
			System.Console.WriteLine("continue");
			continue;
		}
		if (i == 20) {
			break;
		}
		System.Console.WriteLine("bottom");
		i = i + 1;
	}
	System.Console.WriteLine("break");
	System.Console.WriteLine("exit");
};
