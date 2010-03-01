Loops.prototype.WhileIfLessOrLessBreak = function(x) {
	System.Console.WriteLine$1("enter");
	var p = 0;
	while (true) {
		System.Console.WriteLine$1("top");
		if ((x >= 0) && (9 >= x)) {
			System.Console.WriteLine$1("bottom");
			p = p + 1;
		}
		else {
			break;
		}
	}
	System.Console.WriteLine$1("exit");
};
