Loops.prototype.WhileBreak = function() {
	var i = 0;
	while(true) {
		System.Console.WriteLine("top");
		if (i == 10) {
			break;
		}
		System.Console.WriteLine("loop");
		i = i + 1;
	}
	System.Console.WriteLine("break");
	System.Console.WriteLine("exit");
};
