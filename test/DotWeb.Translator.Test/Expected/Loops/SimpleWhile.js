Loops.prototype.SimpleWhile = function(/*System.Int32*/ a) {
	System.Console.WriteLine(a);
	while(a < 100) {
		a = a + 1;
		System.Console.WriteLine(a);
	}
	System.Console.WriteLine(a);
};
