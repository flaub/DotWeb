Loops.prototype.MultiReturns = function() {
	var i = 0;
	System.Console.WriteLine("enter");
	while(i < 100) {
		System.Console.WriteLine("top");
		if (i == 10) {
			System.Console.WriteLine("return1");
			return;
		}
		if (i == 50) {
			System.Console.WriteLine("break");
			break;
		}
		System.Console.WriteLine("bottom");
	}
	System.Console.WriteLine("return2");
};
