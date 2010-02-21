Loops.prototype.WhileContinue = function() {
	var i = 0;
	while (true) {
		System.Console.WriteLine$1("top");
		if (i == 10) {
			System.Console.WriteLine$1("continue");
			continue;
		}
		System.Console.WriteLine$1("bottom");
		i = i + 1;
	}
};
