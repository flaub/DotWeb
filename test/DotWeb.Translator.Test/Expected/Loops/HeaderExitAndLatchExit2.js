Loops.prototype.HeaderExitAndLatchExit2 = function(x) {
	while (true) {
		if (x < 10) {
			break;
		}
		System.Console.WriteLine$1("loop");
		if (x > 10) {
			return 0;
		}
	}
	return 1;
};
