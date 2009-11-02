H8.SourceTests.prototype.WhileCondBreakLoop = function() {
	var i = 0;
	while(i < 9) {
		if (i == 10) {
			return;
		}
		else {
			System.Console.WriteLine(i);
			i = i + 1;
		}
	}
};
