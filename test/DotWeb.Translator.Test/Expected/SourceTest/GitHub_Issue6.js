H8.SourceTests.prototype.GitHub_Issue6 = function(/*System.Boolean*/ x) {
	System.Console.WriteLine("enter");
	try {
		System.Console.WriteLine("try begin");
		if (x) {
			throw new System.NotImplementedException().$ctor();
		}
		System.Console.WriteLine("try end");
	}
	catch(__ex__) {
		if(__ex__ instanceof System.NotImplementedException) {
			System.Console.WriteLine("NotImplementedException: " + __ex__.Message);
		}
		else if(__ex__ instanceof System.Exception) {
			System.Console.WriteLine("Exception: " + __ex__.Message);
		}
	}
	finally {
		System.Console.WriteLine("finally");
	}
	System.Console.WriteLine("exit");
};
