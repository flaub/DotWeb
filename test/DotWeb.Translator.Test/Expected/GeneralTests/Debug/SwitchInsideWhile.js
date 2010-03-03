H8.GeneralTests.prototype.SwitchInsideWhile = function(x) {
	System.Console.WriteLine$1("enter");
	while (true) {
		var CS$4$0001 = x > 10;
		if (!CS$4$0001) {
			System.Console.WriteLine$1("exit");
			break;
		}
		System.Console.WriteLine$1("head");
		var CS$4$0000 = x;
		switch (CS$4$0000) {
			case 0:
				System.Console.WriteLine$1("Zero: return");
				break;
			case 1:
			case 2:
				System.Console.WriteLine$1("One & Two");
				break;
			case 3:
				System.Console.WriteLine$1("Three: continue");
				continue;
			default:
				System.Console.WriteLine$1("default");
				break;
		}
		System.Console.WriteLine$1("tail");
	}
};
