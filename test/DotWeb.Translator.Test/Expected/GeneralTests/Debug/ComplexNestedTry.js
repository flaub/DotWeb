H8.GeneralTests.prototype.ComplexNestedTry = function(x) {
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
		var CS$4$0000 = x != 10;
		if (!CS$4$0000) {
			System.Console.WriteLine$1("x == 10");
		}
	}
	finally {
		System.Console.WriteLine$1("outer finally");
	}
	System.Console.WriteLine$1("exit");
};
