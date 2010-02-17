H8.SourceTests.prototype.TryInsideCatch = function() {
	System.Console.WriteLine("enter");
	try {
		System.Console.WriteLine("try1");
	}
	catch (__ex__) {
		if (__ex__ instanceof System.Exception) {
			System.Console.WriteLine("catch");
			try {
				System.Console.WriteLine("try2");
			}
			finally {
				System.Console.WriteLine("finally");
			}
			System.Console.WriteLine("try2 follow");
		}
	}
	System.Console.WriteLine("exit");
};
