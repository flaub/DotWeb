Loops.prototype.WhileTryCatchFinally = function(x) {
	System.Console.WriteLine("enter");
	while (x < 10) {
		try {
			System.Console.WriteLine("try");
		}
		catch (__ex__) {
			if (__ex__ instanceof System.NotImplementedException) {
				System.Console.WriteLine("continue");
				continue;
			}
			else if (__ex__ instanceof System.Exception) {
				System.Console.WriteLine("break");
				break;
			}
		}
		finally {
			System.Console.WriteLine("finally");
		}
	}
	System.Console.WriteLine("exit");
};
