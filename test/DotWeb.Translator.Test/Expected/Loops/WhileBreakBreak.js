Loops.prototype.WhileBreakBreak = function() {
	var i = 0;
	while(true) {
		System.Console.WriteLine("top");
		if (i == 10) {
			System.Console.WriteLine("break1");
			break;
		}
		if (i == 5) {
			System.Console.WriteLine("break2");
			break;
		}
		System.Console.WriteLine("bottom");
		i = i + 1;
	}
	System.Console.WriteLine("exit");
};
