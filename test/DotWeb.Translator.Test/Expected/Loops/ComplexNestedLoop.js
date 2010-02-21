Loops.prototype.ComplexNestedLoop = function() {
	var i = 0;
	System.Console.WriteLine$1("enter");
	while (true) {
		System.Console.WriteLine$1("top");
		if (i < 10) {
			System.Console.WriteLine$1("i < 10");
			if (i == 1) {
				System.Console.WriteLine$1("i == 1");
				break;
			}
			if (i == 2) {
				do {
					System.Console.WriteLine$1("inner loop");
				} while (i < 4);
				break;
			}
			System.Console.WriteLine$1("bottom");
		}
	}
	System.Console.WriteLine$1("return");
};
