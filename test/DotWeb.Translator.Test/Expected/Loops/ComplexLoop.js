Loops.prototype.ComplexLoop = function() {
	var i = 0;
	System.Console.WriteLine("enter");
	while (true) {
		System.Console.WriteLine("top");
		if (i < 10) {
			System.Console.WriteLine("i < 10");
			if (i == 1) {
				System.Console.WriteLine("i == 1");
				break;
			}
			if (i == 2) {
				System.Console.WriteLine("i == 2");
				continue;
			}
			break;
		}
		System.Console.WriteLine("bottom");
	}
	System.Console.WriteLine("return");
};
