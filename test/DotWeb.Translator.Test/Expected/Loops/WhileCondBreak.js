Loops.prototype.WhileCondBreak = function() {
	var i = 0;
	while (i < 9) {
		System.Console.WriteLine("top");
		if (i == 10) {
			System.Console.WriteLine("break");
			break;
		}
		System.Console.WriteLine("loop");
		i = i + 1;
	}
	System.Console.WriteLine("exit");
};
