H8.GeneralTests.prototype.SwitchInsideWhile = function(x) {
	System.Console.WriteLine$1("enter");
	while (x > 10) {
		System.Console.WriteLine$1("head");
		var CS$0$0000 = x;
		switch (CS$0$0000) {
			case 0:
				System.Console.WriteLine$1("Zero: return");
				return;
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
	System.Console.WriteLine$1("exit");
};
