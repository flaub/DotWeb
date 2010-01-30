H8.SourceTests.prototype.Switch = function(/*System.Int32*/ val) {
	System.Console.WriteLine("Hello");
	var CS$0$0000 = val;
	switch(CS$0$0000 - 1) {
		default:
			System.Console.WriteLine("default");
			break;
		case 0:
			System.Console.WriteLine("1");
			break;
		case 1:
			System.Console.WriteLine("2");
			break;
		case 2:
			System.Console.WriteLine("3");
			break;
		case 3:
		case 4:
			System.Console.WriteLine("4, 5");
			break;
	}
	System.Console.WriteLine("Bye");
};
