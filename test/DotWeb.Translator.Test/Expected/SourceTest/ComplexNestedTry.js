H8.SourceTests.prototype.ComplexNestedTry = function(x) {
	System.Console.WriteLine("enter");
	try {
		System.Console.WriteLine("outer try");
		try {
			System.Console.WriteLine("inner try");
		}
		finally {
			System.Console.WriteLine("inner finally");
		}
		System.Console.WriteLine("inner follow");
		if (x == 10) {
			System.Console.WriteLine("x == 10");
		}
	}
	finally {
		System.Console.WriteLine("outer finally");
	}
	System.Console.WriteLine("exit");
};
