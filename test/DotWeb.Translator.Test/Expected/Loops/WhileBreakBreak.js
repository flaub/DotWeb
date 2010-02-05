Loops.prototype.WhileBreak = function() {
	var i = 0;
	while(true) {
		if (i == 10) {
			System.Console.WriteLine(i);
			break;
		}
		System.Console.WriteLine(i);
		i = i + 1;
	}
	System.Console.WriteLine(i);
};
