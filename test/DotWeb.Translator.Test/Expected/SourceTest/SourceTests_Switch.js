H8.SourceTests.prototype.Switch = function(val /*System.Int32*/) {
	System.Console.WriteLine("Hello");
	var loc0 = val;
	switch(loc0 - 1) {
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

