Loops.prototype.WhileTryCatchFinally = function(x) {
	System.Console.WriteLine$1("enter");
	while (x < 10) {
		try {
			System.Console.WriteLine$1("try");
		}
		catch (__ex__) {
			if (__ex__ instanceof System.NotImplementedException) {
				System.Console.WriteLine$1("continue");
				continue;
			}
			else if (__ex__) {
				System.Console.WriteLine$1("break");
				break;
			}
		}
		finally {
			System.Console.WriteLine$1("finally");
		}
	}
	System.Console.WriteLine$1("exit");
};
