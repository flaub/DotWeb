H8.SourceTests.prototype.NestedTry = function() {
	System.Console.WriteLine$1("enter");
	try {
		System.Console.WriteLine$1("outer try");
		try {
			System.Console.WriteLine$1("inner try");
		}
		finally {
			System.Console.WriteLine$1("inner finally");
		}
		System.Console.WriteLine$1("inner follow");
	}
	finally {
		System.Console.WriteLine$1("outer finally");
	}
	System.Console.WriteLine$1("exit");
};
