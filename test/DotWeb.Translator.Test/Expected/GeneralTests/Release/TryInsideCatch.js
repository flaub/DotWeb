H8.GeneralTests.prototype.TryInsideCatch = function() {
	System.Console.WriteLine$1("enter");
	try {
		System.Console.WriteLine$1("try1");
	}
	catch (__ex__) {
		if (__ex__) {
			System.Console.WriteLine$1("catch");
			try {
				System.Console.WriteLine$1("try2");
			}
			finally {
				System.Console.WriteLine$1("finally");
			}
			System.Console.WriteLine$1("try2 follow");
		}
	}
	System.Console.WriteLine$1("exit");
};
