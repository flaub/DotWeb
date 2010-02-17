H8.SourceTests.prototype.GitHub_Issue6 = function(x) {
	System.Console.WriteLine("enter");
	try {
		System.Console.WriteLine("try begin");
		if (x) {
			throw new System.NotImplementedException().$ctor();
		}
		System.Console.WriteLine("try end");
	}
	catch (__ex__) {
		if (__ex__ instanceof System.NotImplementedException) {
			var ex = __ex__;
			System.Console.WriteLine("NotImplementedException: " + ex.get_Message());
		}
		else if (__ex__ instanceof System.Exception) {
			var ex = __ex__;
			System.Console.WriteLine("Exception: " + ex.get_Message());
		}
	}
	finally {
		System.Console.WriteLine("finally");
	}
	System.Console.WriteLine("exit");
};
