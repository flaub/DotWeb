H8.SourceTests.prototype.NestedTry = function() {
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
	}
	finally {
		System.Console.WriteLine("outer finally");
	}
	System.Console.WriteLine("exit");
};
