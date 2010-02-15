Loops.prototype.WhileContinue = function() {
	var i = 0;
	while(true) {
		System.Console.WriteLine("top");
		if (i == 10) {
			System.Console.WriteLine("continue");
			continue;
		}
		System.Console.WriteLine("bottom");
		i = i + 1;
	}
};
