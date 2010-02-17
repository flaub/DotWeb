H8.SourceTests.prototype.SwitchInsideWhile = function(x) {
	System.Console.WriteLine("enter");
	while (x > 10) {
		System.Console.WriteLine("head");
		var CS$0$0000 = x;
		switch (CS$0$0000) {
			case 0:
				System.Console.WriteLine("Zero: return");
				return;
			case 1:
			case 2:
				System.Console.WriteLine("One & Two");
				break;
			case 3:
				System.Console.WriteLine("Three: continue");
				continue;
			default:
				System.Console.WriteLine("default");
				break;
		}
		System.Console.WriteLine("tail");
	}
	System.Console.WriteLine("exit");
};
