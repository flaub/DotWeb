H8.GeneralTests.prototype.GitHub_Issue6 = function(x) {
	System.Console.WriteLine$1("enter");
	try {
		System.Console.WriteLine$1("try begin");
		var CS$4$0000 = !x;
		if (!CS$4$0000) {
			throw new System.NotImplementedException().$ctor$0();
		}
		System.Console.WriteLine$1("try end");
	}
	catch (__ex__) {
		if (__ex__ instanceof System.NotImplementedException) {
			var ex = __ex__;
			System.Console.WriteLine$1("NotImplementedException: " + ex.get_Message());
		}
		else if (__ex__) {
			ex = __ex__;
			System.Console.WriteLine$1("Exception: " + ex.get_Message());
		}
	}
	finally {
		System.Console.WriteLine$1("finally");
	}
	System.Console.WriteLine$1("exit");
};
