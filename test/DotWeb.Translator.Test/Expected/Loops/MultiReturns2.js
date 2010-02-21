Loops.prototype.MultiReturns2 = function() {
	var i = 0;
	System.Console.WriteLine$1("enter");
	while (i < 100) {
		System.Console.WriteLine$1("top");
		if (i > 10) {
			System.Console.WriteLine$1("return1");
			return;
		}
		if (i < 50) {
			System.Console.WriteLine$1("return2");
			return;
		}
		System.Console.WriteLine$1("bottom");
	}
	System.Console.WriteLine$1("return2");
};
