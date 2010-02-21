Loops.prototype.WhileCondContinue = function() {
	var i = 0;
	while (i < 9) {
		System.Console.WriteLine$1("top");
		if (i == 10) {
			System.Console.WriteLine$1("continue");
			continue;
		}
		System.Console.WriteLine$1("bottom");
		i = i + 1;
	}
	System.Console.WriteLine$1("exit");
};
