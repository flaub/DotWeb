Conditionals.prototype.Switch = function(/*System.Int32*/ x) {
	System.Console.WriteLine("enter");
	var CS$0$0000 = x;
	switch(CS$0$0000) {
		case 0:
			System.Console.WriteLine("Zero");
			break;
		case 1:
		case 2:
			System.Console.WriteLine("One & Two");
			break;
		default:
			System.Console.WriteLine("default");
			break;
	}
	System.Console.WriteLine("exit");
};
