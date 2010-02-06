Loops.prototype.WhileCondContinue = function() {
	var i = 0;
	while(i < 9) {
		System.Console.WriteLine("top");
		if (i == 10) {
			System.Console.WriteLine("continue");
			continue;
		}
		System.Console.WriteLine("bottom");
		i = i + 1;
	}
	System.Console.WriteLine("exit");
};
