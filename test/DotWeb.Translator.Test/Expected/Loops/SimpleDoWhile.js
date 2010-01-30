Loops.prototype.SimpleDoWhile = function(/*System.Int32*/ a) {
	System.Console.WriteLine(a);
	do {
		a = a + 1;
		System.Console.WriteLine(a);
	} while(a < 100);
	System.Console.WriteLine(a);
};
