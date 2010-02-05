Loops.prototype.WhileCondBreak = function() {
	var i = 0;
	while(i < 9) {
		if (i == 10) {
			System.Console.WriteLine(i);
			break;
		}
		else {
			System.Console.WriteLine(i);
			i = i + 1;
		}
		System.Console.WriteLine(i);
	}
};
